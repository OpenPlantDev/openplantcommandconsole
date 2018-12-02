using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenPlantCommandConsole
{
    public partial class TabPageCommandListView : UserControl
    {
        public TabPageCommandListView()
        {
            InitializeComponent();
        }

        public ListView CommandListView
        {
            get
            {
                return this.CommandListViewControl;
            }
        }

        private void CommandListViewControl_HelpRequested(object sender, HelpEventArgs hlpevent)
            {
            if(CommandListViewControl.View == View.Tile)
                CommandListViewControl.View = View.LargeIcon;
            else if(CommandListViewControl.View == View.LargeIcon)
                CommandListViewControl.View = View.SmallIcon;
            else if(CommandListViewControl.View == View.SmallIcon)
                CommandListViewControl.View = View.List;
            else if(CommandListViewControl.View == View.List)
                CommandListViewControl.View = View.Tile;
            }
        }
}
