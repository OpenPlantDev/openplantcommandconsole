using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class Configuration
    {
        const string DefaultUserConfigurationFileName = "userConfiguration.json";
        public string Name { get; set; }
        public string Description { get; set; }
        public string BaseConfigFile { get; set; }
        public string UserConfigFile { get; set; }
        public Settings Settings { get; set; }
        public IList<Stream> Streams { get; set; }
        public IList<Application> Applications { get; set; }
        public IList<Command> Commands { get; set; }
        public IList<CommandTab> CommandTabs { get; set; }
        public IList<Repository> Repositories { get; set; }
        public IList<Part> Parts { get; set; }

        public IList<LocationCategory> LocationCategories { get; set; }
        public IList<FileCategory> FileCategories { get; set; }

        public IList<ShellEnvVariable> ShellEnvVariables { get; set; }
        public IList<TextEditorSession> TextEditorSessions { get; set; }
        public IList<WebPage> WebPages { get; set; }
        public string ConfigFile { get; set; }

        public TextEditor TextEditor { get; set; }

        public Configuration(string configFile)
        {
            Settings = new Settings();
            LocationCategories = new List<LocationCategory>();
            FileCategories = new List<FileCategory>();
            Streams = new List<Stream>();
            Applications = new List<Application>();
            Commands = new List<Command>();
            CommandTabs = new List<CommandTab> ();
            ShellEnvVariables = new List<ShellEnvVariable>();
            TextEditorSessions = new List<TextEditorSession>();
            WebPages = new List<WebPage>();
            Repositories = new List<Repository>();

            if (!System.IO.File.Exists(configFile))
                return;

            ConfigFile = configFile;

            jsonDeserializer deserializer = new jsonDeserializer();
            jsonConfiguration jCfg = deserializer.DeserializeConfiguration(ConfigFile);
            if (jCfg == null)
                return;

            if (jCfg.BaseConfigurationFile != null)
            {
                Name = !String.IsNullOrEmpty(jCfg.Name) ? jCfg.Name : Guid.NewGuid().ToString();
                Description = !String.IsNullOrEmpty(jCfg.Description) ? jCfg.Description : Name;
                BaseConfigFile = this.FindConfigurationFile(jCfg.BaseConfigurationFile);
                jsonConfiguration jBaseCfg = deserializer.DeserializeConfiguration(BaseConfigFile);
                if (jBaseCfg != null)
                    UpdateFromJson(jBaseCfg);
            }

            UserConfigFile = FindConfigurationFile(jCfg.UserConfigurationFile);
            if(String.IsNullOrEmpty(UserConfigFile))
                UserConfigFile = UserConfigFile = FindConfigurationFile(DefaultUserConfigurationFileName);

            // Update with the User Configuation
            jsonConfiguration jUserCfg = deserializer.DeserializeConfiguration(UserConfigFile);
            if(jUserCfg != null)
                UpdateFromJson(jUserCfg);

            // Update using the main configuration
            UpdateFromJson(jCfg);

        }

        private string FindConfigurationFile(string configurationFile)
        {
            if (String.IsNullOrEmpty(configurationFile))
                return null;

            if (System.IO.File.Exists(configurationFile))
                return configurationFile;

            string fileName = System.IO.Path.GetFileName(configurationFile);
            string defPath = System.IO.Path.GetDirectoryName(ConfigFile);

            string fullpath = System.IO.Path.Combine(defPath, fileName);
            if (System.IO.File.Exists(fullpath))
                return fullpath;

            return null;

        }

        private void UpdateFromJson(jsonConfiguration jCfg)
        {
            if (jCfg != null)
            {
                UpdateSettingsFromJsonData(jCfg.Settings);
                UpdateLocationsFromJsonData(jCfg.LocationCategories);
                UpdateFilesFromJsonData(jCfg.FileCategories);
                UpdateStreamsFromJsonData(jCfg.Streams);
                UpdateApplicationsFromJsonData(jCfg.Applications);
                UpdateCommandsFromJsonData(jCfg.Commands);
                UpdateCommandTabsFromJsonData(jCfg.CommandTabs, cmdTabOverwrite: true);
                UpdateRepositoriesFromJsonData(jCfg.Repositories);
                UpdateWebPagesFromJsonData(jCfg.WebPages);
                UpdateShellEnvVariablesFromJsonData(jCfg.ShellEnvVariables);
                UpdateTextEditorFromJsonData(jCfg.TextEditor);
                UpdateTextEditorSessionsFromJsonData(jCfg.TextEditorSessions);

            }

        }

        private void UpdateSettingsFromJsonData(jsonSettings jSettings)
        {
            if (Settings == null)
                Settings = new Settings();

            Settings.UpdateFromJson(jSettings);
        }

        private void UpdateStreamsFromJsonData(IList<jsonStream> jStreams)
        {
            if (Streams == null)
                Streams = new List<Stream>();

            if (jStreams == null)
                return;

            foreach (jsonStream jStream in jStreams)
            {
                if (String.IsNullOrEmpty(jStream.Name))
                    continue;

                Stream stream = Utilities.Instance.FindStream(Streams, jStream.Name);
                bool existingStream = (stream != null);
                if (!existingStream)
                    stream = new Stream(jStream.Name);
                stream.UpdateFromJson(jStream);
                if (!existingStream)
                    Streams.Add(stream);

            }

        }

        private void UpdateApplicationsFromJsonData(IList<jsonApplication> jApps)
        {
            if (Applications == null)
                Applications = new List<Application>();

            if (jApps == null)
                return;

            foreach (jsonApplication jApp in jApps)
            {
                if (String.IsNullOrEmpty(jApp.Name))
                    continue;

                Application app = Utilities.Instance.FindApp(Applications, jApp.Name);
                bool existingApp = (app != null);
                if (!existingApp)
                    app = new Application(jApp.Name);

                app.UpdateFromJson(jApp);

                if (!existingApp)
                    Applications.Add(app);
            }
        }

        private void UpdateCommandsFromJsonData(IList<jsonCommand> jCmds)
        {
            if (Commands == null)
                Commands = new List<Command>();

            if (jCmds == null)
                return;

            foreach (jsonCommand jCmd in jCmds)
            {
                if (String.IsNullOrEmpty(jCmd.Name))
                    continue;

                Command cmd = Utilities.Instance.FindCommandByName(Commands, jCmd.Name);
                bool existingCommand = (cmd != null);
                if(!existingCommand)
                    cmd = new Command(jCmd.Name);

                cmd.UpdateFromJson(jCmd);

                if(!existingCommand)
                    Commands.Add(cmd);
            }
        }

        private void UpdateCommandTabsFromJsonData(IList<jsonCommandTab> jCmdTabs, bool cmdTabOverwrite)
        {
            if (jCmdTabs == null)
                return;

            // if you define cmdTabs it will overwrite from base configuration
            if (cmdTabOverwrite || CommandTabs == null)
                CommandTabs = new List<CommandTab>();

            foreach (jsonCommandTab jCmdTab in jCmdTabs)
            {
                if (String.IsNullOrEmpty(jCmdTab.TabName))
                    continue;

                CommandTab cmdTab = new CommandTab(jCmdTab.TabName);
                cmdTab.UpdateFromJson(jCmdTab);
                CommandTabs.Add(cmdTab);
            }
        }

        private void UpdateLocationsFromJsonData(IList<jsonLocationCategory> jLocCategories)
        {
            if (LocationCategories == null)
                LocationCategories = new List<LocationCategory>();

            if (jLocCategories == null)
                return;

            foreach (jsonLocationCategory jLocCategory in jLocCategories)
            {
                if (String.IsNullOrEmpty(jLocCategory.Name))
                    continue;

                LocationCategory locCategory = Utilities.Instance.FindLocationCategoryByName(LocationCategories, jLocCategory.Name);
                bool existingLocCat = (locCategory != null);
                if(!existingLocCat)
                    locCategory = new LocationCategory(jLocCategory.Name);

                locCategory.UpdateFromJson(jLocCategory);

                if(!existingLocCat)
                    LocationCategories.Add(locCategory);
            }
        }

        private void UpdateFilesFromJsonData(IList<jsonFileCategory> jFileCategories)
        {
            if (FileCategories == null)
                FileCategories = new List<FileCategory>();

            if (jFileCategories == null)
                return;

            foreach (jsonFileCategory jFileCategory in jFileCategories)
            {
                if (String.IsNullOrEmpty(jFileCategory.Name))
                    continue;
                FileCategory fileCategory = Utilities.Instance.FindFileCategoryByName(FileCategories, jFileCategory.Name);
                bool existingFileCat = (fileCategory != null);
                if(!existingFileCat)
                    fileCategory = new FileCategory(jFileCategory.Name);

                fileCategory.UpdateFromJson(jFileCategory);

                if (!existingFileCat)
                    FileCategories.Add(fileCategory);
            }
        }

        private void UpdateRepositoriesFromJsonData(IList<jsonRepository> jRepos)
        {
            if (Repositories == null)
                Repositories = new List<Repository>();

            if (jRepos == null)
                return;

            foreach (jsonRepository jRepo in jRepos)
            {
                if (String.IsNullOrEmpty(jRepo.Name))
                    continue;

                Repository repo = Utilities.Instance.FindRepository(Repositories, jRepo.Name);
                bool existingRepo = (repo != null);
                if(!existingRepo)
                    repo = new Repository(jRepo.Name);

                repo.UpdateFromJson(jRepo);

                if(!existingRepo)
                    Repositories.Add(repo);
            }
        }

        private void UpdateWebPagesFromJsonData(IList<jsonWebPage> jWebPages)
        {
            if (WebPages == null)
                WebPages = new List<WebPage>();

            if (jWebPages == null)
                return;

            foreach (jsonWebPage jWebPage in jWebPages)
            {
                if (String.IsNullOrEmpty(jWebPage.Name))
                    continue;

                WebPage webPage = new WebPage(jWebPage.Name);
                webPage.UpdateFromJson(jWebPage);

                WebPages.Add(webPage);
            }
        }

        private void UpdateShellEnvVariablesFromJsonData(IList<jsonShellEnvVariable> jShellEnvVariables)
        {
            if (ShellEnvVariables == null)
                ShellEnvVariables = new List<ShellEnvVariable>();

            if (jShellEnvVariables == null)
                return;

            foreach (jsonShellEnvVariable jShellEnvVar in jShellEnvVariables)
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
        private void UpdateTextEditorFromJsonData(jsonTextEditor jTextEditor)
        {
            if(jTextEditor == null)
                return;

            if (TextEditor == null)
                TextEditor = new TextEditor("");

            TextEditor.UpdateFromJson(jTextEditor);
        }


        private void UpdateTextEditorSessionsFromJsonData(IList<jsonTextEditorSession> jSessions)
        {
            if (TextEditorSessions == null)
                TextEditorSessions = new List<TextEditorSession>();

            if (jSessions == null)
                return;

            foreach (jsonTextEditorSession jSession in jSessions)
            {
                if (String.IsNullOrEmpty(jSession.Name))
                    continue;

                TextEditorSession session = Utilities.Instance.FindTextEditorSession(TextEditorSessions, jSession.Name);
                bool existingRepo = (session != null);
                if(!existingRepo)
                    session = new TextEditorSession(jSession.Name);

                session.UpdateFromJson(jSession);

                if(!existingRepo)
                    TextEditorSessions.Add(session);
            }
        }

    }
}
