using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class Command
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Cmd { get; set; }
        public string IconName { get; set; }
        public bool ConfirmCommand { get; set; }
        public bool RequiresShell { get; set; }
        public string Args { get; set; }
        public bool Refresh { get; set; }

        //public bool RunInBackground { get; set; }
        public Command(string name)
        {
            Name = name;
            RequiresShell = true;
        }

        public Command(string name, string cmd)
        {
            Name = name;
            Cmd = cmd;
            RequiresShell = true;
        }

        public void UpdateFromJson(jsonCommand jCmd)
        {
            if (jCmd == null)
                return;

            Cmd = !String.IsNullOrEmpty(jCmd.Cmd) ? jCmd.Cmd : Cmd;
            Label = !String.IsNullOrEmpty(jCmd.Label) ? jCmd.Label : Label;
            IconName = !String.IsNullOrEmpty(jCmd.IconName) ? jCmd.IconName : IconName;
            ConfirmCommand = (jCmd.ConfirmCommand != null) ? (bool)jCmd.ConfirmCommand : ConfirmCommand;
            RequiresShell = (jCmd.RequiresShell != null) ? (bool)jCmd.RequiresShell : RequiresShell;
            Args = !String.IsNullOrEmpty(jCmd.Args) ? jCmd.Args : Args;
            Refresh = (jCmd.Refresh != null) ? (bool)jCmd.Refresh : Refresh;
            //cmd.RunInBackground = (jCmd.RunInBackground != null) ? (bool)jCmd.RunInBackground : cmd.RunInBackground;

            }
    }
}
