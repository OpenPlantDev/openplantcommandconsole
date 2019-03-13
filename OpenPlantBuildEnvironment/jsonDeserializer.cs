using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace OpenPlantBuildEnvironment
{
    public class jsonSettings
    {
        public string RootFolder { get; set; }
        public string LocalBuildStrategiesFolder { get; set; }
        public string BatFolder { get; set; }
        public string SourceFolder { get; set; }
        public string OutFolder { get; set; }
        public string BaseEnvBatFile { get; set; }
        public string PowerPlatformVersion { get; set; }
        public string AppBackgroundColor { get; set; }

        public string CmdShellBackgroundColor { get; set; }
        public string CmdShellForegroundColor { get; set; }
        public IList<jsonLocation> Locations { get; set; }
        public string ConfigFileEditor { get; set; }
        public string HgWorkBenchExe { get; set; }
        public bool? Debug { get; set; }
        public bool? ConfirmCommand { get; set; }
        public bool? EnableOverrides { get; set; }
        public bool? EnableSeeding { get; set; }
        //public bool? EnableBackgroundCommands { get; set; }
        public string SeedRootFolder { get; set; }
        public string SeedAppFolder { get; set; }
        public bool? ShowLocationsToolTips { get; set; }
        public bool? ShowPartsToolTips { get; set; }
        public string LocationsDoubleClickAction { get; set; }
        public string FilesDoubleClickAction { get; set; }
        public string PartsDoubleClickAction { get; set; }
        public string CodeSnippetsFileName { get; set; }

        public string ScratchPadFileName { get; set; }
        public string IconsPath { get; set; }

        public bool? MonitorClipboard { get; set; }

        public bool? CommandSingleClickOption { get; set; }

        public string DefaultCmdStartPath { get; set; }

    }

    public class jsonStream
    {
        public string Name { get; set; }
        public string IconName { get; set; }
        public string FolderName { get; set; }
        public string RepositoryRoot { get; set; }
        public bool? Enabled { get; set; }
        public string Description { get; set; }
        public string PowerPlatformVersion { get; set; }
        public string ECFrameworkVersion { get; set; }
        public string MergeToStream { get; set; }
        public bool? Debug { get; set; }
        //public string MappedDrive { get; set; }

    }

    public class jsonRepository
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Path { get; set; }
        public string App { get; set; }
        public IList<jsonPart> Parts { get; set; }
    }

    public class jsonLocationCategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<jsonLocation> Locations { get; set; }
    }

    public class jsonLocation
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }

    public class jsonFileCategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string App { get; set; }
        public string Path { get; set; }
        public IList<jsonFile> Files { get; set; }
    }

    public class jsonFile
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string App { get; set; }
        public string Description { get; set; }
    }

    public class jsonApplication
    {
        public string Name { get; set; }
        public string IconName { get; set; }
        public bool? Enabled { get; set; }
        public string Description { get; set; }
        public string FolderName { get; set; }
        public string EnvBatFile { get; set; }
        public string BuildStrategy { get; set; }
        public string OutputProductFolder { get; set; }
        public string ProductName { get; set; }
        public string RunCmd { get; set; }
        public string CmdShellBackgroundColor { get; set; }
        public string CmdShellForegroundColor { get; set; }
        public IList<jsonApplicationOverride> Overrides { get; set; }
        public string SolutionName { get; set; }
        public bool? AssociateWithAllFiles { get; set; }

        public IList<jsonBuildSet> BuildSets { get; set; }
        public IList<jsonShellEnvVariable> ShellEnvVariables { get; set; }

        }

    public class jsonCommand
    {
        public string ButtonId { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Cmd { get; set; }
        public string IconName { get; set; }

        public bool? ConfirmCommand { get; set; }

        public bool? RequiresShell { get; set; }
        //public bool? RunInBackground { get; set; }
        public string Args { get; set; }

        public bool? Refresh { get; set; }
        }

    public class jsonCommandTab
    {
        public string TabName { get; set; }
        public IList<string> Commands { get; set; }
        public bool? Enabled { get; set; }


    }

    public class jsonBuildSet
    {
        public string Name { get; set; }
        public IList<string> PartNames { get; set; }
        public bool? Enabled { get; set; }


    }

    public class jsonPart
    {
        public string PartName { get; set; }
        public string Description { get; set; }
        public string SubFolder { get; set; }
        public string App { get; set; }
   }

    public class jsonApplicationOverride
    {
        public string Stream { get; set; }
        public string PowerPlatformVersion { get; set; }
        public string ECFrameworkVersion { get; set; }
        public string BuildStrategy { get; set; }
        public bool? Debug { get; set; }
    }

    public class jsonWebPage
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
        public bool? Enabled { get; set; }
    }

    public class jsonShellEnvVariable
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class jsonTextEditor
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string SingleFileParams { get; set; }
        public string MultipleFileParams { get; set; }
        public bool? AllowOpenAll { get; set; }

    }

    public class jsonTextEditorSession
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string App { get; set; }
        public bool? Enabled { get; set; }

    }

    public class jsonConfiguration
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string BaseConfigurationFile { get; set; }
        public string UserConfigurationFile { get; set; }
        public jsonSettings Settings { get; set; }
        public IList<jsonCommand> Commands { get; set; }
        public IList<jsonCommandTab> CommandTabs { get; set; }
        public IList<jsonLocationCategory> LocationCategories { get; set; }
        public IList<jsonFileCategory> FileCategories { get; set; }

        public IList<jsonStream> Streams { get; set; }
        public IList<jsonApplication> Applications { get; set; }
        public IList<jsonRepository> Repositories { get; set; }
        public IList<jsonPart> Parts { get; set; }

        public IList<jsonWebPage> WebPages { get; set; }

        public IList<jsonShellEnvVariable> ShellEnvVariables { get; set; }

        public IList<jsonTextEditorSession> TextEditorSessions { get; set; }

        public jsonTextEditor TextEditor { get; set; }

    }


    public class jsonDeserializer
    {
        public jsonConfiguration DeserializeConfiguration(string configFile)
        {
            if (String.IsNullOrEmpty(configFile) || !System.IO.File.Exists(configFile))
                return null;

            try
            {
                JObject jsonData = JObject.Parse(System.IO.File.ReadAllText(configFile));

                return jsonData.ToObject<jsonConfiguration>();
            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("Unable to parse json file: {0}", configFile), ex);
            }
        }



    }
}
