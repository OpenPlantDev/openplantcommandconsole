using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class Application
    {
        public string Name { get; set; }
        public string IconName { get; set; }
        public bool Enabled { get; set; }
        public string Description { get; set; }
        public string FolderName { get; set; }
        public string EnvBatFileName { get; set; }
        public string BuildStrategy { get; set; }
        public string OutputProductFolder { get; set; }
        public string ProductName { get; set; }
        public IList<ApplicationOverride> Overrides { get; set; }
        public string RunCmd { get; set; }
        public string CmdShellBackgroundColor { get; set; }
        public string CmdShellForegroundColor { get; set; }

        public string SolutionName { get; set; }

        public bool AssociateWithAllFiles { get; set; }

        public IList<BuildSet> BuildSets { get; set; }

        public IList<ShellEnvVariable> ShellEnvVariables { get; set; }


        public Application(string name)
        {
            Name = name;
            IconName = Name.ToUpper();
            Enabled = true;
            FolderName = name.ToUpper();
            EnvBatFileName = String.Format("{0}Env.bat", Name);
            BuildStrategy = String.Format("{0}.dev", Name);
            Overrides = new List<ApplicationOverride>();
            AssociateWithAllFiles = false;
            BuildSets = new List<BuildSet>();
            ShellEnvVariables = new List<ShellEnvVariable>();

        }

        public void UpdateFromJson(jsonApplication jApp)
        {
            if (jApp == null || String.IsNullOrEmpty(jApp.Name))
                return;

            IconName = !String.IsNullOrEmpty(jApp.IconName) ? jApp.IconName : IconName;
            Enabled = (jApp.Enabled != null) ? (bool)jApp.Enabled : Enabled;
            Description = !String.IsNullOrEmpty(jApp.Description) ? jApp.Description : Description;
            BuildStrategy = !String.IsNullOrEmpty(jApp.BuildStrategy) ? jApp.BuildStrategy : BuildStrategy;
            OutputProductFolder = !String.IsNullOrEmpty(jApp.OutputProductFolder) ? jApp.OutputProductFolder : OutputProductFolder;
            ProductName = !String.IsNullOrEmpty(jApp.ProductName) ? jApp.ProductName : ProductName;
            EnvBatFileName = !String.IsNullOrEmpty(jApp.EnvBatFile) ? jApp.EnvBatFile : EnvBatFileName;
            FolderName = !String.IsNullOrEmpty(jApp.FolderName) ? jApp.FolderName : FolderName;
            RunCmd = !String.IsNullOrEmpty(jApp.RunCmd) ? jApp.RunCmd : RunCmd;
            CmdShellBackgroundColor = !String.IsNullOrEmpty(jApp.CmdShellBackgroundColor) ? jApp.CmdShellBackgroundColor : CmdShellBackgroundColor;
            CmdShellForegroundColor = !String.IsNullOrEmpty(jApp.CmdShellForegroundColor) ? jApp.CmdShellForegroundColor : CmdShellForegroundColor;

            SolutionName = !String.IsNullOrEmpty(jApp.SolutionName) ? jApp.SolutionName : SolutionName;
            AssociateWithAllFiles = (jApp.AssociateWithAllFiles != null) ? (bool)jApp.AssociateWithAllFiles : AssociateWithAllFiles;

            if (Overrides == null)
                Overrides = new List<ApplicationOverride>();
            if (jApp.Overrides != null)
            {
                foreach (jsonApplicationOverride jOverride in jApp.Overrides)
                {
                    ApplicationOverride appoverride = new ApplicationOverride(jOverride.Stream, Name);
                    appoverride.PowerPlatformVersion = !String.IsNullOrEmpty(jOverride.PowerPlatformVersion) ? jOverride.PowerPlatformVersion : appoverride.PowerPlatformVersion;
                    appoverride.ECFrameworkVersion = !String.IsNullOrEmpty(jOverride.ECFrameworkVersion) ? jOverride.ECFrameworkVersion : appoverride.ECFrameworkVersion;
                    appoverride.BuildStrategy = !String.IsNullOrEmpty(jOverride.BuildStrategy) ? jOverride.BuildStrategy : appoverride.BuildStrategy;
                    appoverride.Debug = (jOverride.Debug != null) ? (bool)jOverride.Debug : appoverride.Debug;
                    Overrides.Add(appoverride);
                }
            }

            if(BuildSets == null)
                BuildSets = new List<BuildSet>();
            if(jApp.BuildSets != null)
            {
                foreach(jsonBuildSet jBuildSet in jApp.BuildSets)
                {

                    BuildSet buildSet = Utilities.Instance.FindBuildSetByName(BuildSets, jBuildSet.Name);
                    bool existingBuildSet = buildSet != null;
                    if(!existingBuildSet)
                        buildSet = new BuildSet(jBuildSet.Name);
                    buildSet.PartNames = jBuildSet.PartNames != null ? jBuildSet.PartNames : buildSet.PartNames;
                    buildSet.Enabled = jBuildSet.Enabled != null ? (bool)jBuildSet.Enabled : buildSet.Enabled;
                    if(!existingBuildSet)
                        BuildSets.Add(buildSet);
                }
            }

            if (ShellEnvVariables == null)
                ShellEnvVariables = new List<ShellEnvVariable>();

            if (jApp.ShellEnvVariables != null)
            {
                foreach (jsonShellEnvVariable jShellEnvVar in jApp.ShellEnvVariables)
                {
                    if (String.IsNullOrEmpty(jShellEnvVar.Name))
                        continue;

                    ShellEnvVariable shellEnvVar = Utilities.Instance.FindShellEnvVariable(ShellEnvVariables, jShellEnvVar.Name);
                    bool existingShellEnvVar = (shellEnvVar != null);
                    if (!existingShellEnvVar)
                        shellEnvVar = new ShellEnvVariable(jShellEnvVar.Name);
                    shellEnvVar.UpdateFromJson(jShellEnvVar);
                    if (!existingShellEnvVar)
                        ShellEnvVariables.Add(shellEnvVar);
                }
            }

        }

        public override string ToString()
        {
            return Name.ToUpper(); // !String.IsNullOrEmpty(Description) ? Description : Name;
        }

        public ApplicationOverride GetOverride(string streamName)
        {
            if (String.IsNullOrEmpty(streamName) || (Overrides == null))
                return null;

           
            foreach(ApplicationOverride appOverride in Overrides)
            {
                if(streamName.Equals(appOverride.StreamName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return appOverride;
                }
            }

            return null;
        }

        public void Override(ApplicationOverride overrides)
        {
            if ((overrides == null) || String.IsNullOrEmpty(overrides.StreamName))
                return;

            ApplicationOverride existingOverride = GetOverride(overrides.StreamName);
            if (existingOverride != null)
                Overrides.Remove(existingOverride);
            
            Overrides.Add(overrides);
            return;


        }

    }
}
