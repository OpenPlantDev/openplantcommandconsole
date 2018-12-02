using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenPlantCommandConsole
    {
    
    public enum ManagerMode
        {
        Cmd,
        Explorer
        }
    public partial class ProcessManager : Form
        {
        [DllImport ("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport ("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdshow);
        private IntPtr handle;
        private Timer m_refreshTimer = null;
        private MenuItem m_KillMenu = null;
        private MenuItem m_PopMenu = null;
        private MenuItem m_MinMenu = null;
        private MenuItem m_MaxMenu = null;
        private ContextMenu m_rightClickMenu = null;

        private const int DefaultTimerValue = 100000;
        private const bool DefaultCheckState = false;
        private ManagerMode m_explorerMode = ManagerMode.Cmd;

        private string m_processName =  "cmd";

        private enum CmdDisplayState
            {
            Minimize = 2,
            Restore = 9
            }

        public ProcessManager(ManagerMode explorerMode)
            {
            InitializeComponent ();
            m_explorerMode = explorerMode;
            if(m_explorerMode == ManagerMode.Explorer)
                this.Text = "File Explorer Manager (Double click to Pop)";

            FillOutCmdProcess ();

            m_refreshTimer = new Timer ();
            if(checkBoxTimer.Checked)
                {
                m_refreshTimer.Interval = DefaultTimerValue;
                m_refreshTimer.Tick += M_refreshTimer_Tick;
                m_refreshTimer.Start ();
                }

            m_KillMenu = new MenuItem ("Kill Process");
            m_PopMenu = new MenuItem ("Pop Process");
            m_MinMenu = new MenuItem ("Minimize Process");
            m_MaxMenu = new MenuItem ("Restore Process");

            m_rightClickMenu = new ContextMenu ();
            m_rightClickMenu.MenuItems.Add (m_KillMenu);
            m_rightClickMenu.MenuItems.Add (m_PopMenu);
            m_rightClickMenu.MenuItems.Add (m_MinMenu);
            m_rightClickMenu.MenuItems.Add (m_MaxMenu);
            m_KillMenu.Click += M_KillMenu_Click;
            m_PopMenu.Click += M_PopMenu_Click;
            m_MinMenu.Click += M_MinMenu_Click;
            m_MaxMenu.Click += M_MaxMenu_Click;
            this.textBoxTimer.Text = DefaultTimerValue.ToString();
            this.treeViewProcess.NodeMouseClick += TreeViewProcess_NodeMouseClick;
            }

        private void FillOutExplorer ()
            {
            SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows ();

            string filename;
            System.Collections.ArrayList windows = new System.Collections.ArrayList ();

            foreach(SHDocVw.InternetExplorer ie in shellWindows)
                {
                filename = System.IO.Path.GetFileNameWithoutExtension (ie.FullName).ToLower ();
                if(filename.Equals ("explorer"))
                    {

                    string loc = ie.LocationURL.Replace(@"file:///", "");
                    loc = loc.Replace (@"/", @"\");
                    loc = loc.Replace (@"%20", @" ");

                    if(string.IsNullOrEmpty (loc))
                        continue;

                    TreeNode parentNode = treeViewProcess.Nodes.Add (loc, loc);
                    parentNode.Checked = DefaultCheckState;
                    parentNode.Tag = ie;
                    }
                }
            }

        private void M_MaxMenu_Click(object sender, EventArgs e)
            {
            MinimizeRestoreProcess (CmdDisplayState.Restore, treeViewProcess.SelectedNode);
            PopProcess ();
            }

        private void M_MinMenu_Click(object sender, EventArgs e)
            {
            MinimizeRestoreProcess (CmdDisplayState.Minimize, treeViewProcess.SelectedNode);
            }

        private void M_PopMenu_Click(object sender, EventArgs e)
            {
            PopProcess ();
            }

        private void TreeViewProcess_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
            {
            if(e.Button == MouseButtons.Right && e.Node.Tag != null)
                {
                m_rightClickMenu.Show (treeViewProcess, e.Location);
                }
            }

        private void M_KillMenu_Click(object sender, EventArgs e)
            {
            KillProcess (treeViewProcess.SelectedNode);
            }

        private void RefreshProcesses ()
            {
            int timerInt = 0;
            if(!int.TryParse (this.textBoxTimer.Text, out timerInt) )
                timerInt = DefaultTimerValue;
            if (timerInt <= 0)
                timerInt = DefaultTimerValue;

            m_refreshTimer.Interval = timerInt;
            m_refreshTimer.Stop ();
            FillOutCmdProcess ();
            if (checkBoxTimer.Checked)
                m_refreshTimer.Start ();
            }

        private void textBoxTimer_KeyDown(object sender, KeyEventArgs e)
            {
            if(e.KeyCode == Keys.Enter)
                RefreshProcesses ();

            }
        private void M_refreshTimer_Tick(object sender, EventArgs e)
            {
            RefreshProcesses ();
            }

        private void buttonRefresh_Click(object sender, EventArgs e)
            {
            RefreshProcesses ();
            }

        private void FillOutCmdProcess()
            {
            treeViewProcess.Nodes.Clear ();
            if (m_explorerMode == ManagerMode.Explorer)
                {
                FillOutExplorer ();
                return;
                }

            Process[] processes = Process.GetProcesses ().Where (pr => pr.ProcessName == m_processName).ToArray();

            if(processes == null || processes.Count () <= 0)
                return;

            int cmdCount = 0;
            foreach(var process in processes)
                {
                if(!string.IsNullOrEmpty (process.MainWindowTitle))
                    cmdCount++;
                }
            if(cmdCount == 0)
                return;

            PopulateTree (processes);

            }

        private void treeViewProcess_AfterCheck(object sender, TreeViewEventArgs e)
            {
            if(m_inPopulate)
                return;

            if(e.Node.Tag != null)
                return;

            m_inPopulate = true;
            foreach(TreeNode node in e.Node.Nodes)
                node.Checked = e.Node.Checked;
            m_inPopulate = false;

            }
        private bool m_inPopulate = false;

        private void PopulateTree(Process[] processes)
            {
            m_inPopulate = true;
            foreach(var process in processes)
                {
                string part = process.MainWindowTitle;
                if(string.IsNullOrEmpty (part))
                    continue;

                string[] parts = part.Split (':');
                if(parts.Length >= 4)
                    {
                    string partParent = parts[1].Trim () + ":" + parts[2].Trim ();
                    TreeNode[] parents = treeViewProcess.Nodes.Find (partParent, true);
                    if(parents != null && parents.Count () > 0)
                        {
                        AddChildNode (parents[0], parts[3], process);
                        }
                    else
                        {
                        AddParentandChildNode (partParent, parts[3], process);
                        }
                    }
                else
                    {
                    TreeNode[] parents = treeViewProcess.Nodes.Find ("Misc", true);
                    if(parents != null && parents.Count () > 0)
                        {
                        AddChildNode (parents[0], part, process);
                        }
                    else
                        {
                        AddParentandChildNode ("Misc", part, process);
                        }
                    }
                }
            treeViewProcess.ExpandAll ();
            m_inPopulate = false;
            }

        private void AddChildNode(TreeNode parentNode, string child, Process process)
            {
            TreeNode childNode = parentNode.Nodes.Add (child);
            childNode.Tag = process;
            childNode.Checked = DefaultCheckState;
            }

        private void AddParentandChildNode (string parent,string child, Process process )
            {
            TreeNode parentNode = treeViewProcess.Nodes.Add (parent, parent);
            parentNode.Checked = DefaultCheckState;
            TreeNode childNode = parentNode.Nodes.Add (child);
            childNode.Tag = process;
            childNode.Checked = DefaultCheckState;
            }

        private void buttonSelect_Click(object sender, EventArgs e)
            {
            bool isChecked = false;
            
            IList<TreeNode> removeItems = new List<TreeNode> ();
            IEnumerable<TreeNode> items = Collect (treeViewProcess.Nodes);
            foreach(TreeNode item in items)
                {
                if(item != null && item.Checked)
                    {
                    isChecked = true;
                    break;
                    }
                }
            
            foreach(TreeNode item in items)
                item.Checked = !isChecked;

            }

        private void buttonDone_Click(object sender, EventArgs e)
            {
            Close ();
            }

        private void buttonKillAction_Click(object sender, EventArgs e)
            {
            KillAllProcesses ();
            }

        private void PopProcess()
            {
            if(treeViewProcess.SelectedNode == null || treeViewProcess.SelectedNode.Tag == null)
                return;

            handle = GetPointerHandle (treeViewProcess.SelectedNode.Tag);
            MinimizeRestoreProcess (CmdDisplayState.Restore, treeViewProcess.SelectedNode);
            SetForegroundWindow (handle);
            }

        private IntPtr GetPointerHandle (object tag)
            {
            if(tag is Process)
                {
                Process process = tag as Process;
                return process.MainWindowHandle;
                }
            if(tag is SHDocVw.InternetExplorer)
                {
                SHDocVw.InternetExplorer process = tag as SHDocVw.InternetExplorer;
                return (IntPtr)process.HWND;
                }
            return (IntPtr)0;
            }

        IEnumerable<TreeNode> Collect(TreeNodeCollection nodes)
            {
            foreach(TreeNode node in nodes)
                {
                yield return node;
                if (node == null)
                    yield return null;
                foreach(var child in Collect (node.Nodes))
                    yield return child;
                }
            }

        private void KillAllProcesses ()
            {
            if(checkBoxPrompt.Checked && MessageBox.Show (string.Format ("Kill all checked processes?"),
                "Kill commands", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            IList<TreeNode> removeItems = new List<TreeNode>();
            IEnumerable<TreeNode> items = Collect (treeViewProcess.Nodes);
            foreach(TreeNode node in items)
                {
                if(node != null && node.Checked)
                    {
                    if(node.Tag is Process)
                        {
                        Process process = node.Tag as Process;
                        if(process == null)
                            continue;

                        if(!process.HasExited)
                            process.Kill ();
                        }
                    else if(node.Tag is SHDocVw.InternetExplorer)
                        {
                        SHDocVw.InternetExplorer ie = node.Tag as SHDocVw.InternetExplorer;
                        ie.Quit ();
                        }

                    removeItems.Add (node);
                    }
                }
            foreach (TreeNode item in removeItems)
                treeViewProcess.Nodes.Remove (item);

            FillOutCmdProcess ();
            }

        private void KillProcess(TreeNode node)
            {
            if (node == null|| node.Tag == null)
                return;
            Process process = null;
            if(node.Tag is Process)
                {
                process = node.Tag as Process;
                if(process == null)
                    return;
                if(checkBoxPrompt.Checked && MessageBox.Show (string.Format ("Kill selected cmd process? \n{0}", process.MainWindowTitle),
                    "Kill commands", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                if(!process.HasExited)
                    process.Kill ();

                }
            else if (node.Tag is SHDocVw.InternetExplorer)
                {
                SHDocVw.InternetExplorer ie = node.Tag as SHDocVw.InternetExplorer;
                if(checkBoxPrompt.Checked && MessageBox.Show (string.Format ("Kill selected File Explorer process? \n{0}", node.Text),
                    "Kill commands", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                ie.Quit ();
                }

            treeViewProcess.Nodes.Remove (node);
            FillOutCmdProcess ();
            }

        private void MinimizeOrRestoreProcesses(CmdDisplayState state)
            {
            IEnumerable<TreeNode> items = Collect (treeViewProcess.Nodes);
            foreach(TreeNode item in items)
                {
                if(item.Checked)
                    {
                    handle = GetPointerHandle (item.Tag);
                    int display = (int)state;
                    ShowWindow (handle, display);
                    }
                }
            }
        private void MinimizeRestoreProcess(CmdDisplayState state, TreeNode item)
            {
            if(item == null)
                return;

            handle = GetPointerHandle (item.Tag);
            int display = (int)state;
            ShowWindow (handle, display);
            }

        private void buttonPop_Click(object sender, EventArgs e)
            {
            PopProcess ();
            }

        private void treeViewProcess_DoubleClick(object sender, EventArgs e)
            {
            PopProcess ();
            }

        private void buttonMin_Click(object sender, EventArgs e)
            {
            MinimizeOrRestoreProcesses (CmdDisplayState.Minimize);
            }

        private void buttonRestore_Click(object sender, EventArgs e)
            {
            MinimizeOrRestoreProcesses (CmdDisplayState.Restore);
            }


        }
    }
