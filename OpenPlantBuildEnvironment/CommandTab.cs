using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class CommandTab
    {
        public string TabName { get; set; }
        public IList<string> Commands { get; set; }
        public bool Enabled { get; set; }

        public CommandTab (string name)
        {
            TabName = name;
            Commands = new List<string>();
            Enabled = true;
        }

        public void UpdateFromJson(jsonCommandTab jCmdTab)
        {
            if (jCmdTab == null)
                return;

            Commands = (jCmdTab.Commands != null) ? jCmdTab.Commands : Commands;
            Enabled = (jCmdTab.Enabled != null) ? (bool)jCmdTab.Enabled : Enabled;
        }
    }
}
