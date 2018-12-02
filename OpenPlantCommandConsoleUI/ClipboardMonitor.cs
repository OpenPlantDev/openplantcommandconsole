using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenPlantCommandConsole
{

    public class ClipboardMonitor
    {
        HashSet<int> ClipboardItems;
        IList<string> ClipboardHistory { get; set; }

        public delegate void ClipboardUpdatedHandler();

        public static event ClipboardUpdatedHandler ClipboardUpdated;

        public ClipboardMonitor()
        {
            ClipboardNotification.ClipboardUpdate += new System.EventHandler(ClipboardUpdateHandler);

            ClipboardItems = new HashSet<int>();
            ClipboardHistory = new List<string>();
            string cbText = Clipboard.GetText();
            if(!String.IsNullOrEmpty(cbText))
            {
                ClipboardItems.Add(cbText.GetHashCode());
                ClipboardHistory.Add(cbText);
            }
        }

        protected void OnClipboardEvent()
        {

        }

        private void ClipboardUpdateHandler(object sender, System.EventArgs e)
        {
            try
                {
                string cbText = Clipboard.GetText ();
                if(String.IsNullOrEmpty (cbText))
                    return;

                int hashCode = cbText.GetHashCode ();
                if(ClipboardItems.Contains (hashCode))
                    return;

                ClipboardItems.Add (hashCode);
                ClipboardHistory.Insert (0, "--------------------------");
                ClipboardHistory.Insert (0, cbText);

                ClipboardUpdated ();
                }
            catch { }
        }

        public string[] Items
        {
            get
            {
                return ClipboardHistory.ToArray<string>();
            }
        }

    }


    // from: http://stackoverflow.com/questions/2226920/how-to-monitor-clipboard-content-changes-in-c

    /// <summary>
    /// Provides notifications when the contents of the clipboard is updated.
    /// </summary>
    public sealed class ClipboardNotification
    {
        /// <summary>
        /// Occurs when the contents of the clipboard is updated.
        /// </summary>
        public static event EventHandler ClipboardUpdate;

        private static ClipboardNotificationForm _cbNotificationForm = new ClipboardNotificationForm();

        /// <summary>
        /// Raises the <see cref="ClipboardUpdate"/> event.
        /// </summary>
        /// <param name="e">Event arguments for the event.</param>
        private static void OnClipboardUpdate(EventArgs e)
        {
            var handler = ClipboardUpdate;
            if (handler != null)
            {
                handler(null, e);
            }
        }

        /// <summary>
        /// Hidden form to recieve the WM_CLIPBOARDUPDATE message.
        /// </summary>
        private class ClipboardNotificationForm : Form
        {
            public ClipboardNotificationForm()
            {
                NativeMethods.SetParent(Handle, NativeMethods.HWND_MESSAGE);
                NativeMethods.AddClipboardFormatListener(Handle);
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == NativeMethods.WM_CLIPBOARDUPDATE)
                {
                    OnClipboardUpdate(null);
                }
                base.WndProc(ref m);
            }
        }
    }

    internal static class NativeMethods
    {
        // See http://msdn.microsoft.com/en-us/library/ms649021%28v=vs.85%29.aspx
        public const int WM_CLIPBOARDUPDATE = 0x031D;
        public static IntPtr HWND_MESSAGE = new IntPtr(-3);

        // See http://msdn.microsoft.com/en-us/library/ms632599%28VS.85%29.aspx#message_only
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddClipboardFormatListener(IntPtr hwnd);

        // See http://msdn.microsoft.com/en-us/library/ms633541%28v=vs.85%29.aspx
        // See http://msdn.microsoft.com/en-us/library/ms649033%28VS.85%29.aspx
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    }






}
