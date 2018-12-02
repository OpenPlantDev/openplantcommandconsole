using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public sealed class Utilities
    {
        private static volatile Utilities instance;
        private static object syncRoot = new Object();

        private Utilities() { }

        public static Utilities Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Utilities();
                    }
                }

                return instance;
            }
        }

        public Stream FindStream(IList<Stream> streams, string name)
        {
            if ((streams == null) || (name == null))
                return null;


            foreach(Stream stream in streams)
            {
                if (name.Equals(stream.Name, StringComparison.InvariantCultureIgnoreCase))
                    return stream;
            }


            return null;
        }

        public Repository FindRepository(IList<Repository> repos, string name)
        {
            if ((repos == null) || (name == null))
                return null;


            foreach (Repository repo in repos)
            {
                if (name.Equals(repo.Name, StringComparison.InvariantCultureIgnoreCase))
                    return repo;
            }


            return null;
        }
        public Part FindPart (IList<Part> parts, string name)
        {
            if ((parts == null) || (name == null))
                return null;


            foreach (Part part in parts)
            {
                if (name.Equals(part.PartName, StringComparison.InvariantCultureIgnoreCase))
                    return part;
            }


            return null;
        }


        public Application FindApp(IList<Application> apps, string name)
        {
            if ((apps == null) || (name == null))
                return null;


            foreach (Application app in apps)
            {
                if (name.Equals(app.Name, StringComparison.InvariantCultureIgnoreCase))
                    return app;
            }

            return null;
        }

        public Command FindCommandByName(IList<Command> commands, string cmdName)
        {
            if (commands == null)
                return null;

            if (String.IsNullOrEmpty(cmdName))
                return null;

            foreach(Command cmd in commands)
            {
                if (cmd.Name.Equals(cmdName, StringComparison.InvariantCultureIgnoreCase))
                    return cmd;
            }

            return null;
        }

        public LocationCategory FindLocationCategoryByName (IList<LocationCategory> locCategories, string name)
        {
            if (locCategories == null)
                return null;

            if (String.IsNullOrEmpty(name))
                return null;

            foreach (LocationCategory locCat in locCategories)
            {
                if (locCat.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                    return locCat;
            }

            return null;
        }

        public FileCategory FindFileCategoryByName (IList<FileCategory> fileCategories, string name)
        {
            if (fileCategories == null)
                return null;

            if (String.IsNullOrEmpty(name))
                return null;

            foreach (FileCategory fileCat in fileCategories)
            {
                if (fileCat.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                    return fileCat;
            }

            return null;
        }

        public BuildSet FindBuildSetByName (IList<BuildSet> buildSets, string name)
        {
            if (buildSets == null)
                return null;

            if (String.IsNullOrEmpty(name))
                return null;

            foreach (BuildSet buildSet in buildSets)
            {
                if (buildSet.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                    return buildSet;
            }

            return null;
        }
        public ShellEnvVariable FindShellEnvVariable(IList<ShellEnvVariable> shellEnvVars, string name)
        {
            if ((shellEnvVars == null) || (name == null))
                return null;


            foreach(ShellEnvVariable shellEnvVar in shellEnvVars)
            {
                if (name.Equals(shellEnvVar.Name, StringComparison.InvariantCultureIgnoreCase))
                    return shellEnvVar;
            }


            return null;
        }

        public TextEditorSession FindTextEditorSession(IList<TextEditorSession> sessions, string name)
        {
            if ((sessions == null) || (name == null))
                return null;


            foreach (TextEditorSession session in sessions)
            {
                if (name.Equals(session.Name, StringComparison.InvariantCultureIgnoreCase))
                    return session;
            }


            return null;
        }

        public void RunCommand(string cmd, string sourceFolder)
            {
            CurrentProcess = new System.Diagnostics.Process ();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo ();

            if (!string.IsNullOrEmpty(sourceFolder))
                startInfo.WorkingDirectory = sourceFolder;
            startInfo.FileName = @"cmd.exe";

            if(!string.IsNullOrEmpty (cmd))
                //startInfo.Arguments = "/c " + cmd; // kills window
                startInfo.Arguments = "/k " + cmd;

            startInfo.Verb = "runas";
            CurrentProcess.StartInfo = startInfo;
            try
                {
                CurrentProcess.Start ();
                LastHandle = CurrentProcess.Handle;
                }
            catch { }

            }

        public System.Diagnostics.Process CurrentProcess { get; set; }

        public void KillCurrentProcess ()
            {
            if(CurrentProcess == null)
                return;
            try
                {
                if(!CurrentProcess.HasExited)
                    CurrentProcess.Kill ();
                CurrentProcess = null;
                }
            catch { }
            }

        public void RunProcess (string processName, string args)
        {
            if (String.IsNullOrEmpty(processName))
                return;

            //if (String.IsNullOrEmpty(args))
            //{
            //    RunProcess(processName);
            //    return;
            //}

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

            startInfo.FileName = processName;

            startInfo.Arguments = args;

            startInfo.Verb = "";
            process.StartInfo = startInfo;
            try
            {
                process.Start();
                LastHandle = process.Handle;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public IntPtr LastHandle { get; set; }

        public void RunProcess(string processName)
        {
            if (String.IsNullOrEmpty(processName))
                return;

            try
            {
                System.Diagnostics.Process.Start(processName);
            }
            catch (Exception ex)
            {
                
            }
            return;


        }


    }
}
