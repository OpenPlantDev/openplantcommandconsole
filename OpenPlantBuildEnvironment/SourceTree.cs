using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class SourceTree
    {
        public Configuration Configuration { get; set; }
        public Settings Settings { get; set; }
        public IList<Command> Commands { get; set; }
        public Stream Stream { get; set; }
        public Application Application { get; set; }

        public SourceTree(OpenPlantBuildEnvironment.Configuration config,
                          OpenPlantBuildEnvironment.Stream stream, OpenPlantBuildEnvironment.Application app)
        {
            Configuration = config;
            Settings = config.Settings;
            Commands = config.Commands;
            Stream = stream;
            Application = app;

            CreateEnvBatFile();

            // Define env variables for use with commands and locations
            System.Environment.SetEnvironmentVariable("OP_RootFolder", String.Format("{0}\\", Configuration.Settings.RootFolder));
            System.Environment.SetEnvironmentVariable("OP_StreamFolder", String.Format("{0}\\", StreamFolder));
            System.Environment.SetEnvironmentVariable("OP_AppFolder", String.Format("{0}\\", ApplicationFolder));
            System.Environment.SetEnvironmentVariable("OP_SrcFolder", String.Format("{0}\\", SourceFolder));
            System.Environment.SetEnvironmentVariable("OP_OutFolder", String.Format("{0}\\", OutFolder));
            System.Environment.SetEnvironmentVariable("OP_AppName", String.Format("{0}", app.Name.ToUpper()));
            System.Environment.SetEnvironmentVariable("OP_StreamName", String.Format("{0}", stream.Name));
            if (!String.IsNullOrEmpty(Application.OutputProductFolder))
            {
                // Why two different variables?
                System.Environment.SetEnvironmentVariable("OutProductName", String.Format("{0}", Application.OutputProductFolder));
                System.Environment.SetEnvironmentVariable("OP_APP_OUTPRODUCTFOLDER", String.Format("{0}", Application.OutputProductFolder));
            }

            string seedSrcFolder = SeedSourceFolder;
            if(!String.IsNullOrEmpty(seedSrcFolder))
                System.Environment.SetEnvironmentVariable("OP_SeedSrcFolder", String.Format("{0}\\", seedSrcFolder));

        }

        //public bool StreamMapped
        //{
        //    get
        //    {
        //        return !String.IsNullOrEmpty(Stream.MappedDrive);
        //    }
        //}

        public string StreamFolder
        {
            get
            {
                return System.IO.Path.Combine(Settings.RootFolder, !String.IsNullOrEmpty(Stream.FolderName) ? Stream.FolderName : Stream.Name);
            }
        }

        //public string MappedStreamFolder
        //{
        //    get
        //    {
        //        if (StreamMapped)
        //            return String.Format("{0}\\", Stream.MappedDrive);

        //        return StreamFolder;
        //    }
        //}

        public string ApplicationFolder
        {
            get
            {
                return System.IO.Path.Combine(StreamFolder, Application.FolderName);
            }
        }

        //public string MappedApplicationFolder
        //{
        //    get
        //    {
        //         return System.IO.Path.Combine(StreamMapped ? MappedStreamFolder : StreamFolder, Application.FolderName);
        //    }
        //}

        public string SourceFolder
        {
            get
            {
                return System.IO.Path.Combine(ApplicationFolder, Settings.SourceFolder);
            }
        }

        //public string MappedSourceFolder
        //{
        //    get
        //    {
        //        return System.IO.Path.Combine(StreamMapped ? MappedApplicationFolder : ApplicationFolder, Settings.SourceFolder);
        //    }
        //}

        public string OutFolder
        {
            get
            {
                return System.IO.Path.Combine(ApplicationFolder, Settings.OutFolder);
            }
        }

        //public string MappedOutFolder
        //{
        //    get
        //    {
        //        return System.IO.Path.Combine(StreamMapped ? MappedApplicationFolder : ApplicationFolder, Settings.OutFolder);
        //    }
        //}


        public string SeedSourceFolder
        {
            get
            {
                if (Settings.EnableSeeding && !String.IsNullOrEmpty(Settings.SeedRootFolder) && !String.IsNullOrEmpty(Settings.SeedAppFolder))
                    return System.IO.Path.Combine(Settings.SeedRootFolder, Stream.FolderName, Settings.SeedAppFolder, Settings.SourceFolder);

                return null;
            }
        }
        public string Title
        {
            get
            {
                return String.Format("{0}:{1}:{2}", Configuration.Name, Application.Name.ToUpper(), Stream.Name);
            }
        }

        public string Color
        {
            get
            {
                string backgroundColor = Settings.CmdShellBackgroundColor;
                string foregroundColor = Settings.CmdShellBackgroundColor;
                backgroundColor = !String.IsNullOrEmpty(Application.CmdShellBackgroundColor) ? Application.CmdShellBackgroundColor : Settings.CmdShellBackgroundColor;
                foregroundColor = !String.IsNullOrEmpty(Application.CmdShellForegroundColor) ? Application.CmdShellForegroundColor : Settings.CmdShellForegroundColor;

                return String.Format("{0}{1}", backgroundColor, foregroundColor);
            }
        }

        public bool Bootstrapped
        {
            get
            {
                return System.IO.Directory.Exists(SourceFolder);
            }
        }

        public void CreateEnvBatFile(bool forceUpdate=false)
        {
            string envBatFileFolder = ApplicationFolder;
            if (!System.IO.Directory.Exists(envBatFileFolder))
                System.IO.Directory.CreateDirectory(envBatFileFolder);
            if (!System.IO.Directory.Exists(envBatFileFolder))
            {
                // invalid path
                return;
            }
            string envBatFileFullPath = System.IO.Path.Combine(envBatFileFolder, Application.EnvBatFileName);
            string baseEnvBatFileFullPath = Settings.BaseEnvBatFile;

            if (System.IO.File.Exists(envBatFileFullPath))
                    System.IO.File.Delete(envBatFileFullPath);

            //if (System.IO.File.Exists(envBatFileFullPath))
            //{
            //    if (forceUpdate)
            //        System.IO.File.Delete(envBatFileFullPath);
            //    else
            //    { 
            //        DateTime cfgFileModified = System.IO.File.GetLastWriteTime(Configuration.ConfigFile);
            //        DateTime baseCfgFileModified = System.IO.File.Exists(Configuration.BaseConfigFile) ? System.IO.File.GetLastWriteTime(Configuration.BaseConfigFile) : cfgFileModified;
            //        DateTime envBatFileCreated = System.IO.File.GetCreationTime(envBatFileFullPath);
            //        DateTime baseEnvBatFileModified = System.IO.File.Exists(baseEnvBatFileFullPath) ? System.IO.File.GetLastWriteTime(baseEnvBatFileFullPath) : envBatFileCreated;
            //        if (!forceUpdate && (envBatFileCreated > cfgFileModified) && (envBatFileCreated > baseCfgFileModified) && (envBatFileCreated >= baseEnvBatFileModified))
            //            return;
            //        System.IO.File.Delete(envBatFileFullPath);
            //    }
            //}

            IList<string> cmdFileContents = new List<string>();

            // Add the stream and application specific variables
            cmdFileContents.Add("@echo off");
            cmdFileContents.Add(String.Format("set OP_APP={0}", Application.Name));
            cmdFileContents.Add(String.Format("set OP_APP_OUTPRODUCTFOLDER={0}", Application.OutputProductFolder));
            cmdFileContents.Add(String.Format("set OP_APP_PRODUCTNAME={0}", Application.ProductName));
            cmdFileContents.Add(String.Format("set OP_APP_BUILDSTRATEGY={0}", BuildStrategy));
            cmdFileContents.Add(String.Format("set OP_APP_DESC={0}", Application.Description));
            cmdFileContents.Add(String.Format("set PP_VER={0}", PowerPlatformVersion));
            if(!String.IsNullOrEmpty(ECFrameworkVersion))
                cmdFileContents.Add(String.Format("set ECF_VER={0}", ECFrameworkVersion));
            cmdFileContents.Add(String.Format("set Teamname={0}", Stream.Name));
            if(!String.IsNullOrEmpty(Stream.MergeToStream))
                cmdFileContents.Add(String.Format("set OP_MERGETOSTREAM={0}", Stream.MergeToStream));
            cmdFileContents.Add(String.Format("set BUILDSTRATEGYPATH={0}", Settings.LocalBuildStrategiesFolder));
            cmdFileContents.Add(String.Format("set DEBUG={0}", Debug ? 1 : 0));

            //string appSolution = @"C:\Vancouver\Bentley.OPEF.Addin.sln";
            cmdFileContents.Add (String.Format ("set slnName={0}", Application.SolutionName));

            foreach(ShellEnvVariable shellEnvVar in Configuration.ShellEnvVariables)
            {
                cmdFileContents.Add (String.Format ("set {0}={1}", shellEnvVar.Name, shellEnvVar.Value));
            }


            // Check for mapping of root folder
            //if (!String.IsNullOrEmpty(Stream.MappedDrive))
            //{
            //    cmdFileContents.Add(String.Format("if not exist {0} subst {0} {1}", Stream.MappedDrive, StreamFolder));
            //}
            cmdFileContents.Add(String.Format("set OP_APP_DIR={0}\\", ApplicationFolder)); // MappedApplicationFolder));


            cmdFileContents.Add(String.Format("set BSISRC={0}\\", SourceFolder)); // MappedSourceFolder));
            cmdFileContents.Add(String.Format("set BSIOUT={0}\\", OutFolder)); // MappedOutFolder));

            //cmdFileContents.Add("");
            //cmdFileContents.Add(String.Format("set SharedShellColor={0}", Color));
            

            // call the baseEnvBat file
            cmdFileContents.Add("");
            if (System.IO.File.Exists(baseEnvBatFileFullPath))
                cmdFileContents.Add(String.Format("call {0}", baseEnvBatFileFullPath));
            else
                cmdFileContents.Add(String.Format("echo Warning: Unable to locate OpenPlant Base Env bat file: {0}", baseEnvBatFileFullPath));

           // Add path to bat folder
            cmdFileContents.Add("");
            cmdFileContents.Add(String.Format("set Path={0};%PATH%", Settings.BatFolder));

            // Set the runCmd variable here because it references %outroot%
            cmdFileContents.Add(String.Format("set OP_APP_RunCmd={0}", Application.RunCmd));

            // Title and Color
            cmdFileContents.Add("");
            cmdFileContents.Add(String.Format("Title {0}", Title));
            cmdFileContents.Add(String.Format("color {0}", Color));
            cmdFileContents.Add("");

            //with this the cmd will exit
            string exit = " && exit";
            exit = string.Empty;

            // now add stuff for running commands
            cmdFileContents.Add("rem The following commands are defined in the configuration file");
            foreach (Command cmd in Commands)
            {
                if (cmd.RequiresShell && !String.IsNullOrEmpty(cmd.Name) && !String.IsNullOrEmpty(cmd.Cmd))
                {
                    //string title = String.Format("{0} - {1}", Title, cmd.Name);
                    string title = String.Format ("{0} - {1}", Title, cmd.Label);
                    //cmdFileContents.Add(String.Format("if /i [%1]==[{0}] Title {2}&echo \"calling {1}\"&{1}", cmd.Name, cmd.Cmd, title));
                    cmdFileContents.Add(String.Format("if /i [%1]==[{0}] Title {2}&echo \"calling {1}\"&{1}{3}", cmd.Name, cmd.Cmd, title, exit));
                }
            }

            cmdFileContents.Add("");
            cmdFileContents.Add("rem The following commands are hard-coded in application");
            // add command for changing directory
            cmdFileContents.Add(String.Format("if /i [%1]==[cd] cd /d %2"));
            // add command for rebuilding a part
            //cmdFileContents.Add(String.Format("if /i [%1]==[rebuild] echo calling bb re %2&bb re %2"));
            // add command for pseudolocalizing a part
            //cmdFileContents.Add(String.Format("if /i [%1]==[pseudo] echo calling bb pseudolocalize %2&bb pseudolocalize %2"));
            // add command for martianizing a part
            //cmdFileContents.Add(String.Format("if /i [%1]==[martianize] echo calling bb -l mr re --tkOnly %2&bb -l mr re --tkOnly %2"));
            // add command for seeding
            cmdFileContents.Add(String.Format("if /i [%1]==[seed] echo calling seed %2&call seed %2"));

            // write out the file
            System.IO.File.WriteAllLines(envBatFileFullPath, cmdFileContents);


        }

        public string PowerPlatformVersion
        {
            get
            {
                ApplicationOverride appOverride = Application.GetOverride(Stream.Name);
                if ((appOverride != null) && !String.IsNullOrEmpty(appOverride.PowerPlatformVersion))
                    return appOverride.PowerPlatformVersion;

                if (!String.IsNullOrEmpty(Stream.PowerPlatformVersion))
                    return Stream.PowerPlatformVersion;

                return Settings.PowerPlatformVersion;
            }
        }

        public string ECFrameworkVersion
        {
            get
            {
                ApplicationOverride appOverride = Application.GetOverride(Stream.Name);
                if ((appOverride != null) && !String.IsNullOrEmpty(appOverride.ECFrameworkVersion))
                    return appOverride.ECFrameworkVersion;

                if (!String.IsNullOrEmpty(Stream.ECFrameworkVersion))
                    return Stream.ECFrameworkVersion;

                return null;
            }
        }

        public string BuildStrategy
        {
            get
            {
                ApplicationOverride appOverride = Application.GetOverride(Stream.Name);
                if ((appOverride != null) && !String.IsNullOrEmpty(appOverride.BuildStrategy))
                    return appOverride.BuildStrategy;

                return Application.BuildStrategy;
            }
        }

        public bool Debug
        {
            get
            {
                ApplicationOverride appOverride = Application.GetOverride(Stream.Name);
                if ((appOverride != null) && (appOverride.Debug != null))
                    return (bool)appOverride.Debug;

                if (Stream.Debug != null)
                    return (bool)Stream.Debug;

                return Settings.Debug;
            }

        }


        public void Bootstrap()
        {
            string srcFolder = SourceFolder;
            if (!System.IO.Directory.Exists(srcFolder))
                System.IO.Directory.CreateDirectory(srcFolder);

            string bootstrapCmd = String.Format("bentleybootstrap.py {0}", Stream.Name);
            runCmd (bootstrapCmd);
        }

        public string GetFullCommandString(string cmd)
        {
            return String.Format("{0} {1}", System.IO.Path.Combine(ApplicationFolder, Application.EnvBatFileName), cmd);  // MappedApplicationFolder

        }

        public void RunCommand(string cmd, bool forceEnvBatUpdate=false)
        {
            if (forceEnvBatUpdate)
                CreateEnvBatFile(forceEnvBatUpdate);

            runCmd(cmd);
        }


        private void runCmd(string cmd)
        {
            Utilities.Instance.RunCommand (cmd, SourceFolder);
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            ////startInfo.UseShellExecute = false;
            //startInfo.WorkingDirectory = SourceFolder;
            //startInfo.FileName = @"cmd.exe";
            //startInfo.Arguments = "/k " + cmd;
            //startInfo.Verb = "runas";
            //process.StartInfo = startInfo;

            //try
            //{
            //    process.Start();
            //}
            //catch { }

        }

        public void OpenCommandShell(string path)
        {
            string command = String.Format("{0} cd \"{1}\"", System.IO.Path.Combine(ApplicationFolder, Application.EnvBatFileName), path); //MappedApplicationFolder
            Utilities.Instance.RunCommand (command, SourceFolder);

            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            ////startInfo.UseShellExecute = false;
            //startInfo.WorkingDirectory = SourceFolder;
            //startInfo.FileName = @"cmd.exe";
            //startInfo.Arguments = "/k " + command;
            //startInfo.Verb = "runas";
            //process.StartInfo = startInfo;
            //try
            //{
            //    process.Start();
            //}
            //catch { }
        }



    }
}
