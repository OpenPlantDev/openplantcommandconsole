using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class ShellEnvVariable
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public ShellEnvVariable(string name)
        {
            Name = name;
        }

        public void UpdateFromJson(jsonShellEnvVariable jShellEnvVar)
        {
            if (jShellEnvVar == null)
                return;

            Name = (jShellEnvVar.Name != null) ? jShellEnvVar.Name : Name;
            Value = (jShellEnvVar.Value != null) ? jShellEnvVar.Value : Value;
        }


    }
}
