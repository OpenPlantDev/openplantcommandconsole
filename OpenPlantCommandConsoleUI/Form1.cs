using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPlantBuildEnvironment;
using System.Resources;
using System.Runtime.InteropServices;
//using OpenPlantCommandConsoleUI;
//using CefSharp;
//using CefSharp.WinForms;

namespace OpenPlantCommandConsole
{
    public partial class MainForm : Form
        {
        public Configuration Configuration { get; set; }
        public bool Initialized { get; set; }
        public bool InUpdateForm { get; set; }

        public string ConfigurationFile { get; set; }

        public IList<ConfigurationFile> ConfigurationFiles { get; set; }

        public Color DefaultBackgroundColor { get; set; }

        ClipboardMonitor cbMonitor;

        private TreePartsAddon m_treeParts { get; set; }

        private ListSearcher m_listSearcher { get; set; }
        private const string ExpandDialogImageName = "ExpandSize.png";
        private const string CollapseDialogImageName = "CollapseSize.png";
        private bool m_RichtextboxIgnoreCase = true;
        private IList<int> m_richTextIndexesSearchList = null;
        private int m_richNextCnt = 0;
        private object selectedSender = null;

        [DllImport ("user32.dll", SetLastError = true)]
        private static extern bool BringWindowToTop(IntPtr hWnd);

        public MainForm()
            {
            InitializeComponent ();
            //InitializeChromium();
            DefaultBackgroundColor = this.BackColor;

            // How to turn on/off the clipboard monitor???
            cbMonitor = new ClipboardMonitor ();
            ClipboardMonitor.ClipboardUpdated += new ClipboardMonitor.ClipboardUpdatedHandler (ClipboardUpdatedHandler);

            m_listSearcher = new ListSearcher (this);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler (KeyUpEventHandler);
            m_treeParts = new TreePartsAddon (this.PartsTreeView);

            this.listViewHistoryBrowserParts.Columns[this.listViewHistoryBrowserParts.Columns.Count - 1].Width = -2;
            listViewHistoryBrowserParts.Columns[0].ImageKey = "Part.png";
            }

        private void MainForm_Load(object sender, EventArgs e)
            {
            InitializeConfigurationFile ();

            Initialize ();

            InitializePartsTreeViewContextMenu ();
            InitializeLocationsTreeViewContextMenu ();
            InitializeFilesTreeViewContextMenu ();

            Padding pd = StreamIconToolStripButton.Margin;
            pd.Left = 80;
            StreamIconToolStripButton.Margin = pd;

            AddTextboxContextMenu (this.ScratchPadRichTextBox);
            AddTextboxContextMenu (this.CodeSnippetsRichTextBox);
            this.Location = OpenPlantCommandConsoleUI.Settings.Default.Location;
            ResetIfOffScreen ();
            }


        public void ResetIfOffScreen()
            {
            Screen[] screens = Screen.AllScreens;
            foreach(Screen screen in screens)
                {
                Point formTopLeft = new Point (Left, Top);

                if(screen.WorkingArea.Contains (formTopLeft))
                    return;
                }
            this.Location = new Point (0, 0);
            }

        //private void InitializeChromium()
        //{
        //    CefSettings settings = new CefSettings();
        //    // Initialize cef with the provided settings
        //    Cef.Initialize(settings);
        //}

        public void InitializeConfigurationFile()
            {
            ConfigurationFile = null;

            ConfigurationFiles = GetSavedConfigurationFiles ();

            string lastCfgFile = GetLastUsedConfigurationFile ();

            foreach(ConfigurationFile cfgFile in ConfigurationFiles)
                {
                if(!String.IsNullOrEmpty (cfgFile.FileName) && System.IO.File.Exists (cfgFile.FileName))
                    {
                    if((ConfigurationFile == null) || cfgFile.FileName.Equals (lastCfgFile, StringComparison.InvariantCultureIgnoreCase))
                        {
                        ConfigurationFile = cfgFile.FileName;
                        }
                    }
                }
            if(ConfigurationFile == null)
                {
                if(lastCfgFile != null)
                    ConfigurationFile = lastCfgFile;
                else
                    ConfigurationFile = GetConfigurationFile ();

                ConfigurationFiles = new List<ConfigurationFile> () { new ConfigurationFile (ConfigurationFile) };
                }

            PopulateConfigurationToolStripComboBox ();
            }

        private IList<ConfigurationFile> GetSavedConfigurationFiles()
            {
            IList<ConfigurationFile> configurationFiles = new List<ConfigurationFile> ();
            string savedCfgFiles = OpenPlantCommandConsoleUI.Settings.Default.CfgFiles;

            IList<string> configurationFileNames = null;
            if(!String.IsNullOrEmpty (savedCfgFiles))
                configurationFileNames = savedCfgFiles.Split (';').ToList<string> ();

            if(configurationFileNames != null)
                {
                foreach(string fileName in configurationFileNames)
                    configurationFiles.Add (new ConfigurationFile (fileName));
                }

            return configurationFiles;
            }

        private string GetLastUsedConfigurationFile()
            {
            string lastCfgFile = OpenPlantCommandConsoleUI.Settings.Default.LastUsedConfigFile;
            if(String.IsNullOrEmpty (lastCfgFile) || !System.IO.File.Exists (lastCfgFile))
                lastCfgFile = null;

            return lastCfgFile;
            }

        private void PopulateConfigurationToolStripComboBox()
            {
            string currCfgFile = ConfigurationFile;
            ConfigurationToolStripComboBox.Items.Clear ();
            foreach(ConfigurationFile cfgFile in ConfigurationFiles)
                {
                if(!String.IsNullOrEmpty (cfgFile.FileName) && System.IO.File.Exists (cfgFile.FileName))
                    {
                    ConfigurationToolStripComboBox.Items.Add (cfgFile);
                    if((this.ConfigurationToolStripComboBox.SelectedItem == null) ||
                        ((currCfgFile != null) && cfgFile.FileName.Equals (currCfgFile, StringComparison.InvariantCultureIgnoreCase))
                      )
                        this.ConfigurationToolStripComboBox.SelectedItem = cfgFile;

                    }
                }
            }



        private void Initialize()
            {
            Initialized = false;

            try
                {
                Configuration = new Configuration (ConfigurationFile);
                }
            catch(Exception ex)
                {
                MessageBox.Show (String.Format ("{0}\n{1}", ex.Message, (ex.InnerException != null) ? ex.InnerException.Message : String.Empty));
                }

            if(!String.IsNullOrEmpty (Configuration.Settings.ApplicationBackgroundColor))
                this.BackColor = Color.FromName (Configuration.Settings.ApplicationBackgroundColor);
            else
                this.BackColor = DefaultBackgroundColor;

            foreach(TabPage tp in this.ConfigurationTabControl.TabPages)
                {
                tp.BackColor = this.BackColor;
                }


            PopulateStreamsComboBox ();

            PopulateApplicationsComboBox ();

            AddWebBrowserTabs ();

            SetupCommandTabs ();

            RestorePartHistory ();

            Initialized = true;
            UpdateForm ();

            }

        private void ExecuteCommand(Command cmd)
            {
            if(cmd == null)
                return;

            SourceTree sourceTree = GetSourceTree ();
            if(sourceTree == null)
                return;

            if(!sourceTree.Bootstrapped)
                {
                BootStrap (sourceTree);
                // even though we bootstrap we need to return without executing the command, user has to pick it again
                return;
                }

            ApplicationOverride appOverrides = GetApplicationOverrides (sourceTree.Stream, sourceTree.Application);
            sourceTree.Application.Override (appOverrides);

            string cmdString = sourceTree.GetFullCommandString (cmd.Name);

            if(!ConfirmCommand (sourceTree, cmd, cmdString))
                return;

            if(!String.IsNullOrEmpty (cmd.Cmd))
                Clipboard.SetText (cmd.Cmd);

            KillCurrentProcessButton.Enabled = true;
            if(cmd.RequiresShell)
                sourceTree.RunCommand (cmdString, true);
            else
                {
                Utilities.Instance.RunProcess (cmd.Cmd, cmd.Args);
                }

            if(cmd.Refresh)
                {
                //MessageBox.Show ("Select Ok to refresh", "refresh", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.Sleep (4500);
                RefreshConfiguration ();
                }

            }


        private void BootStrap(SourceTree sourceTree)
            {

            DialogResult dialogResult = MessageBox.Show (String.Format ("Source folder {0} does not exist.\nDo you want to bootstrap?", sourceTree.SourceFolder), "Source Folder Not Found", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
                sourceTree.Bootstrap ();
            }

        private bool ConfirmCommand(SourceTree sourceTree, Command cmd, string cmdString)
            {
            if(!Configuration.Settings.ConfirmCommand || !cmd.ConfirmCommand)
                return true;

            System.Windows.Forms.DialogResult dialogResult =
                System.Windows.Forms.MessageBox.Show (
                    String.Format ("{1} {2}{0}{3} {4}{0}{5} {6}{0}{7} {8}{0}{0}{9} {0}",
                                    System.Environment.NewLine,
                                    "Configuration:", Configuration.Description,
                                    "Stream:", sourceTree.Stream,
                                    "Application:", sourceTree.Application,
                                    "Command:", cmdString,
                                    "Proceed?"),
                        "Command Confirmation",
                        System.Windows.Forms.MessageBoxButtons.YesNo
                );
            if(dialogResult == System.Windows.Forms.DialogResult.Yes)
                return true;

            return false;

            }



        private SourceTree GetSourceTree()
            {
            OpenPlantBuildEnvironment.Stream stream = (OpenPlantBuildEnvironment.Stream)this.StreamComboBox.SelectedItem;
            OpenPlantBuildEnvironment.Application app = (OpenPlantBuildEnvironment.Application)this.ApplicationComboBox.SelectedItem;

            SourceTree sourceTree = new SourceTree (Configuration, stream, app);


            return sourceTree;

            }

        private ApplicationOverride GetApplicationOverrides(Stream stream, OpenPlantBuildEnvironment.Application app)
            {
            ApplicationOverride appOverride = new ApplicationOverride (stream.Name, app.Name);
            appOverride.BuildStrategy = this.BuildStrategyTextBox.Text;
            appOverride.PowerPlatformVersion = this.PPVerTextBox.Text;
            appOverride.ECFrameworkVersion = this.ECFVerTextBox.Text;
            appOverride.Debug = this.DebugCheckBox.Checked;

            return appOverride;

            }

        private void PopulateStreamsComboBox()
            {
            this.StreamComboBox.Items.Clear ();
            string lastUsedStream = OpenPlantCommandConsoleUI.Settings.Default.LastUsedStream;
            foreach(OpenPlantBuildEnvironment.Stream stream in Configuration.Streams)
                {
                if(stream.Enabled)
                    {
                    this.StreamComboBox.Items.Add (stream);
                    if((this.StreamComboBox.SelectedItem == null) || stream.Name.Equals (lastUsedStream, StringComparison.InvariantCultureIgnoreCase))
                        this.StreamComboBox.SelectedItem = stream;
                    }
                }

            }

        private void PopulateApplicationsComboBox()
            {
            this.ApplicationComboBox.Items.Clear ();
            string lastUsedApp = OpenPlantCommandConsoleUI.Settings.Default.LastUsedApplication;
            foreach(OpenPlantBuildEnvironment.Application app in Configuration.Applications)
                {
                if(app.Enabled)
                    {
                    this.ApplicationComboBox.Items.Add (app);
                    if((this.ApplicationComboBox.SelectedItem == null) || app.Name.Equals (lastUsedApp, StringComparison.InvariantCultureIgnoreCase))
                        this.ApplicationComboBox.SelectedItem = app;
                    }
                }

            }

        private void AddWebBrowserTabs()
            {
            if(Configuration.WebPages == null)
                return;

            RemoveExistingWebBrowserTabs ();
            foreach(WebPage webPage in Configuration.WebPages)
                {
                if(!webPage.Enabled)
                    continue;

                try
                    {
                    TabPage webBrowserTabPage = new TabPage (webPage.Name);
                    webBrowserTabPage.Text = webPage.Label;
                    webBrowserTabPage.Tag = webPage;

                    WebBrowser webBrowser = new WebBrowser ();
                    webBrowser.Url = new System.Uri (webPage.Url);

                    // webBrowser = new ChromiumWebBrowser(webPage.Url);

                    webBrowserTabPage.Controls.Add (webBrowser);
                    webBrowser.Dock = DockStyle.Fill;

                    this.ConfigurationTabControl.TabPages.Add (webBrowserTabPage);
                    }
                catch(Exception ex)
                    {
                    MessageBox.Show (String.Format ("Error loading web page: {0}\n{1}\n{2}", webPage.Url, ex.Message, (ex.InnerException != null) ? ex.InnerException.Message : ""));
                    continue;
                    }
                }
            }

        private void RemoveExistingWebBrowserTabs()
            {
            foreach(TabPage tabPage in this.ConfigurationTabControl.TabPages)
                {
                if(tabPage.Tag is WebPage)
                    this.ConfigurationTabControl.TabPages.Remove (tabPage);
                }
            }

        private void PopulatePartsTreeView(SourceTree sourceTree)
            {
            this.PartsTreeView.Nodes.Clear ();
            this.PartsTreeView.ShowNodeToolTips = Configuration.Settings.ShowPartsToolTips;

            if(Configuration.Repositories == null)
                return;

            string lastUsedPart = OpenPlantCommandConsoleUI.Settings.Default.LastUsedPart;

            // first add all repositories, might rework this later

            bool showAllParts = this.ShowAllPartsCheckBox.Checked;

            foreach(Repository repo in Configuration.Repositories)
                {
                string path = repo.ExpandedPath;
                bool pathExists = (!String.IsNullOrEmpty (path) && System.IO.Directory.Exists (path));
                if(showAllParts || pathExists)
                    {
                    if( !IsAssociatedWithApp (repo.App, sourceTree))
                        continue;

                    TreeNode repoNode = this.PartsTreeView.Nodes.Add (repo.Name, repo.Name);
                    repoNode.Tag = repo;
                    if(repo.Parts != null)
                        {
                        foreach(Part part in repo.Parts)
                            {
                            if(!showAllParts && !IsAssociatedWithApp (part.App, sourceTree))
                                continue;

                            TreeNode partNode = repoNode.Nodes.Add (part.Description);
                            partNode.Tag = part;
                            partNode.ToolTipText = GetPathFromPartsTreeNode (partNode);
                            if(!pathExists)
                                partNode.ForeColor = Color.Gray;

                            //if (part.PartName.Equals(lastUsedPart, StringComparison.InvariantCultureIgnoreCase))
                            //    this.PartsTreeView.SelectedNode = partNode;
                            }

                        }
                    }
                }

            m_treeParts.AddTreePartsFromPartsFileRead (sourceTree);


            }

        private void PopulateLocationsTreeView(SourceTree sourceTree)
            {
            this.LocationsTreeView.Nodes.Clear ();
            this.LocationsTreeView.ShowNodeToolTips = Configuration.Settings.ShowLocationsToolTips;

            if(Configuration.LocationCategories == null)
                return;

            bool showAllLocations = ShowAllPartsCheckBox.Checked;
            //bool showAllLocations = this.ShowAllLocationsCheckBox.Checked;

            foreach(LocationCategory locCat in Configuration.LocationCategories)
                {
                TreeNode catNode = this.LocationsTreeView.Nodes.Add (locCat.ToString ());
                if(locCat.Locations != null)
                    {
                    foreach(Location loc in locCat.Locations)
                        {
                        if(!String.IsNullOrEmpty (loc.Name) && !String.IsNullOrEmpty (loc.Path))
                            {
                            bool pathExists = System.IO.Directory.Exists (loc.ExpandedPath);
                            if(showAllLocations || pathExists)
                                {
                                TreeNode locNode = catNode.Nodes.Add (loc.ToString ());
                                locNode.Tag = loc;
                                locNode.ToolTipText = loc.ExpandedPath;
                                if(!pathExists)
                                    locNode.ForeColor = Color.Gray;
                                }
                            }
                        }
                    }
                }

            }

        private void PopulateFilesTreeView(SourceTree sourceTree)
            {
            this.FilesTreeView.Nodes.Clear ();
            this.FilesTreeView.ShowNodeToolTips = Configuration.Settings.ShowLocationsToolTips;

            if(Configuration.FileCategories == null)
                return;

            bool showAllFiles = ShowAllPartsCheckBox.Checked;
            //bool showAllFiles = this.ShowAllFilesCheckBox.Checked;

            foreach(FileCategory fileCat in Configuration.FileCategories)
                {
                if(!showAllFiles && !IsAssociatedWithApp (fileCat.App, sourceTree))
                    continue;

                TreeNode catNode = this.FilesTreeView.Nodes.Add (fileCat.ToString ());
                catNode.Tag = "Category";
                if(fileCat.Files != null)
                    {
                    foreach(File file in fileCat.Files)
                        {
                        if(!showAllFiles && !IsAssociatedWithApp (file.App, sourceTree)) //!String.IsNullOrEmpty(file.App) && !file.App.Equals(sourceTree.Application.Name, StringComparison.InvariantCultureIgnoreCase))
                            continue;
                        if(!String.IsNullOrEmpty (file.Name) && !String.IsNullOrEmpty (file.Path))
                            {
                            if (file.Name.Contains("*") || file.Name.Contains("?"))
                                {
                                if (!System.IO.Directory.Exists(file.ExpandedPath))
                                    break;
                                string[] fileNames = System.IO.Directory.GetFiles(file.ExpandedPath, file.Name);
                                foreach (string fileName in fileNames)
                                    {
                                    File wildCardFile = new File(System.IO.Path.GetFileName(fileName), file.Path);
                                    TreeNode fileNode = catNode.Nodes.Add(wildCardFile.ToString());
                                    fileNode.Tag = wildCardFile;
                                    fileNode.ToolTipText = wildCardFile.ExpandedFileName;
                                    }
                                }
                            else
                                { 
                                bool fileExists = System.IO.File.Exists (file.ExpandedFileName);
                                if(showAllFiles || fileExists)
                                    {
                                    TreeNode fileNode = catNode.Nodes.Add (file.ToString ());
                                    fileNode.Tag = file;
                                    fileNode.ToolTipText = file.ExpandedFileName;
                                    if(!fileExists)
                                        fileNode.ForeColor = Color.Gray;
                                    }
                                }
                            }
                        }
                    }
                }

            }

        private bool IsAssociatedWithApp(string appName, SourceTree sourceTree)
            {
            if(String.IsNullOrEmpty (appName) || (sourceTree == null) || (sourceTree.Application == null) || String.IsNullOrEmpty (sourceTree.Application.Name))
                return true;

            if(sourceTree.Application.AssociateWithAllFiles || appName.Equals (sourceTree.Application.Name, StringComparison.InvariantCultureIgnoreCase))
                return true;

            return false;
            }

        private void SetupCommandTabs()
            {
            if(Configuration.CommandTabs == null)
                return;

            this.ShellCommandsTabControl.TabPages.Clear ();


            foreach(CommandTab cmdTab in Configuration.CommandTabs)
                {
                if(!cmdTab.Enabled)
                    continue;

                TabPage tabPage = new TabPage (cmdTab.TabName);
                this.ShellCommandsTabControl.TabPages.Add (tabPage);
                tabPage.Padding = new Padding (0, 7, 0, 0);

                IList<Command> commands = new List<Command> ();

                foreach(string cmdName in cmdTab.Commands)
                    {
                    Command cmd = Utilities.Instance.FindCommandByName (Configuration.Commands, cmdName);
                    if(cmd != null)
                        commands.Add (cmd);
                    }

                TabPageCommandListView listView = SetupCommandListView (commands);
                listView.Dock = DockStyle.Fill;
                tabPage.BackColor = Color.White;
                listView.BackColor = Color.Transparent;

                tabPage.Controls.Add (listView);

                }

            }

        private TabPageCommandListView SetupCommandListView(IList<Command> commands)
            {
            TabPageCommandListView tabPageCommandListView = new TabPageCommandListView ();
            ListView listView = tabPageCommandListView.CommandListView;
            listView.LargeImageList = this.CommandsImageListLarge;
            listView.SmallImageList = this.CommandsImageListSmall;
            listView.MouseDoubleClick += ShellCommandsListView_MouseDoubleClick;
            listView.MouseClick += ListView_MouseClick;


            listView.Items.Clear ();

            if(commands == null)
                return tabPageCommandListView;

            foreach(Command cmd in commands)
                {
                string iconName = !String.IsNullOrEmpty (cmd.IconName) ? cmd.IconName : "cmdConsole.ico";
                string label = System.Environment.ExpandEnvironmentVariables (cmd.Label);
                ListViewItem cmdItem = new ListViewItem (label, iconName);

                if(!listView.LargeImageList.Images.ContainsKey (iconName))
                    {
                    iconName = System.Environment.ExpandEnvironmentVariables (cmd.IconName);
                    if(!listView.LargeImageList.Images.ContainsKey (iconName))
                        {
                        if(!AddIconFromExternalFile (iconName, cmdItem))
                            cmdItem.ImageKey = "cmdConsole.ico";
                        }
                    else
                        cmdItem.ImageKey = iconName;
                    }

                cmdItem.Tag = cmd;
                cmdItem.ToolTipText = cmd.Cmd;
                listView.Items.Add (cmdItem);
                }

            return tabPageCommandListView;
            }

        private void UpdateCommandListItems()
            {
            if((this.ShellCommandsTabControl == null) || (this.ShellCommandsTabControl.TabPages == null))
                return;

            foreach(TabPage tabPage in this.ShellCommandsTabControl.TabPages)
                {
                foreach(Control ctrl in tabPage.Controls)
                    {
                    TabPageCommandListView cmdListView = ctrl as TabPageCommandListView;
                    if(cmdListView == null)
                        continue;
                    ListView listView = cmdListView.CommandListView;
                    if(listView == null)
                        continue;
                    foreach(ListViewItem listViewItem in listView.Items)
                        {
                        Command cmd = listViewItem.Tag as Command;
                        if(cmd == null)
                            continue;

                        string label = System.Environment.ExpandEnvironmentVariables (cmd.Label);
                        listViewItem.Text = label;
                        if(string.IsNullOrEmpty (cmd.IconName))
                            cmd.IconName = string.Empty;
                        string iconName = System.Environment.ExpandEnvironmentVariables (cmd.IconName);
                        if(listViewItem.ImageList.Images.ContainsKey (iconName))
                            {
                            string pathIco = null;
                            if(ExternalFileIconExists (iconName, out pathIco))
                                {
                                if(RemoveIconFromExternalFile (iconName, listViewItem))
                                    AddIconFromExternalFile (iconName, listViewItem);
                                }
                            else
                                listViewItem.ImageKey = iconName;
                            }
                        else
                            {
                            if(!AddIconFromExternalFile (iconName, listViewItem))
                                listViewItem.ImageKey = "cmdConsole.ico";
                            }
                        }
                    }
                }
            }

        private bool RemoveIconFromExternalFile(string iconName, ListViewItem listViewItem)
            {
            string fullPath = string.Empty;
            if(!ExternalFileIconExists (iconName, out fullPath))
                return false;
            try
                {
                if(CommandsImageListLarge.Images.ContainsKey (iconName))
                    {
                    CommandsImageListLarge.Images.RemoveByKey (iconName);
                    if(CommandsImageListSmall.Images.ContainsKey (iconName))
                        CommandsImageListSmall.Images.RemoveByKey (iconName);
                    return true;
                    }

                return false;
                }
            catch { return false; }
            }

        private bool AddIconFromExternalFile(string iconName, ListViewItem listViewItem)
            {

            string fullPath = string.Empty;

            if(!ExternalFileIconExists (iconName, out fullPath))
                return false;

            try
                {
                Icon ico = new Icon (fullPath);
                CommandsImageListLarge.Images.Add (iconName, ico);
                listViewItem.ImageKey = iconName;
                CommandsImageListSmall.Images.Add (iconName, ico);
                return true;
                }
            catch { return false; }
            }

        private bool ExternalFileIconExists(string iconName, out string fullPath)
            {
            fullPath = string.Empty;

            if(!System.IO.Directory.Exists (Configuration.Settings.IconsPath))
                return false;

            fullPath = System.IO.Path.Combine (Configuration.Settings.IconsPath, iconName);
            if(!System.IO.File.Exists (fullPath))
                {
                fullPath = null;
                return false;
                }

            return true;
            }

        private void ListView_MouseClick(object sender, MouseEventArgs e)
            {
            if(Configuration.Settings.CommandSingleClickOption)
                DoCommandClick (sender);
            }

        private void ShellCommandsListView_MouseDoubleClick(object sender, MouseEventArgs e)
            {
            if(!Configuration.Settings.CommandSingleClickOption)
                DoCommandClick (sender);
            }

        private void DoCommandClick(object sender)
            {
            ListView listView = sender as ListView;
            if(listView == null)
                return;

            if(listView.SelectedItems == null)
                return;

            if(listView.SelectedItems.Count != 1)
                return;

            Command cmd = listView.SelectedItems[0].Tag as Command;
            if(cmd == null)
                return;

            ExecuteCommand (cmd);
            }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
            {
            SaveSettings ();
            //Cef.Shutdown();
            }

        private void SaveSettings()
            {
            OpenPlantBuildEnvironment.Stream stream = (OpenPlantBuildEnvironment.Stream)this.StreamComboBox.SelectedItem;
            if(stream != null)
                OpenPlantCommandConsoleUI.Settings.Default.LastUsedStream = stream.Name;

            OpenPlantBuildEnvironment.Application app = (OpenPlantBuildEnvironment.Application)this.ApplicationComboBox.SelectedItem;
            if(app != null)
                OpenPlantCommandConsoleUI.Settings.Default.LastUsedApplication = app.Name;

            //OpenPlantBuildEnvironment.Part pb = (OpenPlantBuildEnvironment.Part)this.PartsComboBox.SelectedItem;
            //if (pb != null)
            //    OpenPlantCommandConsoleUI.Settings.Default.LastUsedPart = pb.PartName;

            OpenPlantCommandConsoleUI.Settings.Default.LastUsedConfigFile = ConfigurationFile;

            string cfgFiles = "";
            foreach(ConfigurationFile cfgFile in this.ConfigurationToolStripComboBox.Items)
                {
                cfgFiles = String.Format ("{0}{1};", cfgFiles, cfgFile.FileName);
                }

            OpenPlantCommandConsoleUI.Settings.Default.CfgFiles = cfgFiles;

            SavePartHistory ();
            OpenPlantCommandConsoleUI.Settings.Default.Location = this.Location;
            OpenPlantCommandConsoleUI.Settings.Default.Size = this.Size;


            OpenPlantCommandConsoleUI.Settings.Default.Save ();
            }

        private void StreamComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
            UpdateForm ();
            }

        private void ApplicationComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
            UpdateForm ();
            }

        private string GetConfigurationFile()
            {
            this.ConfigFileDialog.Title = "Specify Configuration File";
            this.ConfigFileDialog.AddExtension = true;
            this.ConfigFileDialog.Filter = "(*.json)|*.json|All files (*.*)|*.*";
            DialogResult dlgResult = this.ConfigFileDialog.ShowDialog ();
            if(dlgResult != DialogResult.OK)
                return null;

            return this.ConfigFileDialog.FileName;


            }

        private void UpdateForm()
            {
            if(!Initialized)
                return;

            InUpdateForm = true;

            this.Text = String.Format ("Command Console - RootFolder: {0}", Configuration.Settings.RootFolder);

            SourceTree sourceTree = GetSourceTree ();

            this.BuildStrategyTextBox.Text = sourceTree.BuildStrategy;
            this.PPVerTextBox.Text = sourceTree.PowerPlatformVersion;
            this.ECFVerTextBox.Text = sourceTree.ECFrameworkVersion;
            this.DebugCheckBox.Checked = sourceTree.Debug;
            this.BootstrapButton.Enabled = !sourceTree.Bootstrapped;
            this.CmdShellColorTextBox.Text = sourceTree.Color;

            this.ToolTip.SetToolTip (this.StreamComboBox, sourceTree.StreamFolder);
            this.ToolTip.SetToolTip (this.ApplicationComboBox, sourceTree.SourceFolder);

            this.StreamIconPictureBox.Image = GetApplicationIcon (sourceTree.Stream.IconName).ToBitmap ();
            this.ToolTip.SetToolTip (this.StreamIconPictureBox, String.Format ("{0} - Click to Browse", sourceTree.Stream.Name));
            this.ApplicationIconPictureBox.Image = GetApplicationIcon (sourceTree.Application.IconName).ToBitmap ();
            this.ToolTip.SetToolTip (this.ApplicationIconPictureBox, String.Format ("{0} - Click to Run", sourceTree.Application.Description));

            this.ApplicationExeToolStripButton.Image = ApplicationIconPictureBox.Image;
            this.ApplicationExeToolStripButton.ToolTipText = String.Format ("{0} - Click to Run", sourceTree.Application.Description);

            this.StreamIconToolStripButton.Image = GetApplicationIcon (sourceTree.Stream.IconName).ToBitmap ();
            StreamIconToolStripButton.ToolTipText = String.Format ("{0} - Click to Browse", sourceTree.Stream.Name);

            PopulatePartsTreeView (sourceTree);
            PopulateLocationsTreeView (sourceTree);
            PopulateFilesTreeView (sourceTree);

            ScratchPadRichTextBox.Tag = Configuration.Settings.ScratchPadFileName;
            ScratchPadTabPage.ToolTipText = Configuration.Settings.ScratchPadFileName;
            PopulateTextEditBox (sourceTree, ScratchPadRichTextBox);

            CodeSnippetsRichTextBox.Tag = Configuration.Settings.CodeSnippetsFileName;
            this.CodeSnippetsTabPage.ToolTipText = Configuration.Settings.CodeSnippetsFileName;
            PopulateTextEditBox (sourceTree, CodeSnippetsRichTextBox);
            m_listSearcher.ResetNodes ();

            this.UpdateCommandListItems ();
            InUpdateForm = false;

            }

        private void BootstrapButton_Click(object sender, EventArgs e)
            {
            bool bootstrap = true;
            SourceTree sourceTree = GetSourceTree ();
            if(sourceTree.Bootstrapped)
                {
                DialogResult dialogResult = MessageBox.Show (String.Format ("Source folder already exists.\nDo you still want to bootstrap?", sourceTree.SourceFolder), "Source Folder Exists", MessageBoxButtons.YesNo);
                bootstrap = (dialogResult == DialogResult.Yes);
                }
            if(bootstrap)
                sourceTree.Bootstrap ();


            }

        private void OpenConfigurationButton_Click(object sender, EventArgs e)
            {
            string selectedCfgFile = GetConfigurationFile ();
            if(!String.IsNullOrEmpty (selectedCfgFile) && (System.IO.File.Exists (selectedCfgFile)))
                {
                ConfigurationFile = selectedCfgFile;
                //this.CfgFileTextBox.Text = ConfigurationFile;
                bool isNewCfgFile = true;
                foreach(ConfigurationFile cfgFile in this.ConfigurationToolStripComboBox.Items)
                    {
                    if(cfgFile.FileName.Equals (selectedCfgFile, StringComparison.InvariantCultureIgnoreCase))
                        {
                        this.ConfigurationToolStripComboBox.SelectedItem = cfgFile;
                        isNewCfgFile = false;
                        break;

                        }
                    }
                if(isNewCfgFile)
                    {
                    ConfigurationFile cfgFile = new ConfigurationFile (selectedCfgFile);
                    this.ConfigurationToolStripComboBox.Items.Add (cfgFile);
                    this.ConfigurationToolStripComboBox.SelectedItem = cfgFile;
                    ConfigurationFiles.Add (cfgFile);
                    }

                SaveSettings ();
                Initialize ();
                }
            }

        private void RemoveConfigurationButton_Click(object sender, EventArgs e)
            {
            ConfigurationFile cfgFile = (ConfigurationFile)this.ConfigurationToolStripComboBox.SelectedItem;
            DialogResult dialogResult = MessageBox.Show (String.Format ("Are you sure tha you want to remove\n{0}", cfgFile.FileName), "Remove Configuration", MessageBoxButtons.YesNo);

            if(dialogResult == DialogResult.Yes)
                {
                this.ConfigurationToolStripComboBox.Items.Remove (this.ConfigurationToolStripComboBox.SelectedItem);
                ConfigurationFile = String.Empty;
                SaveSettings ();
                InitializeConfigurationFile ();
                Initialize ();
                }
            }

        private void CfgEditButton_Click(object sender, EventArgs e)
            {
            if(String.IsNullOrEmpty (ConfigurationFile) || !System.IO.File.Exists (ConfigurationFile) || String.IsNullOrEmpty (Configuration.Settings.ConfigFileEditor))
                return;

            OpenFile (ConfigurationFile);
            }


        private void CfgEditBaseButton_Click (object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty (Configuration.BaseConfigFile) || !System.IO.File.Exists (Configuration.BaseConfigFile) || String.IsNullOrEmpty (Configuration.Settings.ConfigFileEditor))
                return;

            OpenFile (Configuration.BaseConfigFile);

        }

        private void CfgEditUserButton_Click (object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty (Configuration.UserConfigFile) || !System.IO.File.Exists (Configuration.UserConfigFile) || String.IsNullOrEmpty (Configuration.Settings.ConfigFileEditor))
                return;

            OpenFile (Configuration.UserConfigFile);

        }

        private void RefreshButton_Click(object sender, EventArgs e)
            {
            RefreshConfiguration ();
            }

        private void RefreshConfiguration()
            {
            SaveSettings ();
            Initialize ();
            }

        private void ExploreConfigurationButton_Click(object sender, EventArgs e)
            {
            if(!String.IsNullOrEmpty (ConfigurationFile) && System.IO.File.Exists (ConfigurationFile))
                {
                string path = System.IO.Path.GetDirectoryName (ConfigurationFile);
                ExplorePath (path);
                }
            }

        private void ApplicationOverrides_Changed(object sender, EventArgs e)
            {
            if(InUpdateForm)
                return;

            SourceTree sourceTree = GetSourceTree ();
            if(sourceTree == null)
                return;

            ApplicationOverride appOverrides = GetApplicationOverrides (sourceTree.Stream, sourceTree.Application);
            sourceTree.Application.Override (appOverrides);

            }

        private void BrowseButton_Click(object sender, EventArgs e)
            {
            DoBrowseStream ();
            }
        private void DoBrowseStream()
            {
            SourceTree sourceTree = GetSourceTree ();
            if(sourceTree == null)
                return;

            string streamRoot = sourceTree.Stream.RepositoryRoot;
            if(String.IsNullOrEmpty (streamRoot))
                return;

            System.Diagnostics.Process.Start (streamRoot);
            }

        private Icon GetApplicationIcon(string appName)
            {
            Icon appIcon = GetIconByName (appName);
            if(appIcon != null)
                return appIcon;
            return OpenPlantCommandConsoleUI.Properties.Resources.Bentley;
            }

        private Icon GetStreamIcon(string streamName)
            {
            Icon steamIcon = GetIconByName (streamName);
            if(steamIcon != null)
                return steamIcon;
            return OpenPlantCommandConsoleUI.Properties.Resources.Bentley;
            }

        private Icon GetIconByName(string name)
            {
            object obj = OpenPlantCommandConsoleUI.Properties.Resources.ResourceManager.GetObject (name);
            if(obj != null)
                return ((System.Drawing.Icon)(obj));

            return null;
            }

        private void ApplicationIconPictureBox_Click(object sender, EventArgs e)
            {
            RunApplication ();
            }
        private void RunApplication()
            {
            Command cmd = new Command ("runApp", "runApp");
            ExecuteCommand (cmd);
            }


        private void MainForm_Clicked(object sender, EventArgs e)
            {
            //if (Opacity == 0.1)
            //    Opacity = 1.0;
            //else
            //    Opacity = 0.1;
            }

        private void ExplorePath(string path)
            {
            if(String.IsNullOrEmpty (path))
                return;

            if(!System.IO.Directory.Exists (path))
                {
                System.Windows.Forms.MessageBox.Show (String.Format ("Location not found: {0}", path), "Location not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }

            System.Diagnostics.Process.Start (path);

            }

        private void OpenCommandShellAtPath(string path)
            {
            if(String.IsNullOrEmpty (path))
                return;

            if(!System.IO.Directory.Exists (path))
                {
                System.Windows.Forms.MessageBox.Show (String.Format ("Location not found: {0}", path), "Location not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
            SourceTree sourceTree = GetSourceTree ();

            sourceTree.OpenCommandShell (path);

            }

        private void OpenFile(string fileName)
            {
            if(String.IsNullOrEmpty (fileName) || !System.IO.File.Exists (fileName))
                return;

            System.Diagnostics.Process.Start (Configuration.Settings.ConfigFileEditor, fileName);
            }

        private void OpenSession(IList<string> fileNames)
        {
            string arguments = "-multiInst -nosession";
            string files = arguments;
            foreach (string fileName in fileNames)
            {
                files = string.Format("{0} \"{1}\"", files, fileName);
            }
            System.Diagnostics.Process.Start(Configuration.Settings.ConfigFileEditor, files);
        }


        private void InitializePartsTreeViewContextMenu()
            {
            this.BuildPartContextMenuItem.Click += new System.EventHandler (this.BuildPartContextMenuItem_Click);
            this.ExplorePartContextMenuItem.Click += new System.EventHandler (this.ExplorePartContextMenuItem_Click);
            this.CmdShellAtPartContextMenuItem.Click += new System.EventHandler (this.CmdShellAtPartContextMenuItem_Click);
            this.PseudoLocalizePartContextMenuItem.Click += new System.EventHandler (this.PseudoLocalizePartContextMenuItem_Click);
            this.MartianizePartContextMenuItem.Click += new System.EventHandler (this.MartianizePartContextMenuItem_Click);
            this.HgWorkBenchPartContextMenuItem.Click += new System.EventHandler (this.HgWorkBenchPartContextMenuItem_Click);
            this.BrowseRepositoryPartContextMenuItem.Click += new System.EventHandler (this.BrowseRepositoryPartContextMenuItem_Click);
            this.OpenPartFileContextMenuItem.Click += new System.EventHandler (this.OpenPartFileContextMenuItem_Click);
            this.CopyBuildCmdContextMenuItem.Click += new System.EventHandler (this.CopyBuildCmdContextMenuItem_Click);
            this.CopyLocalPathContextMenuItem.Click += new System.EventHandler (this.CopyLocalPathContextMenuItem_Click);
            this.CopyRemotePathContextMenuItem.Click += new System.EventHandler (this.CopyRemotePathContextMenuItem_Click);
            this.PartsTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler (this.PartsTreeView_MouseUp);
            this.PartsTreeView.NodeMouseDoubleClick += PartsTreeView_NodeMouseDoubleClick;

            this.listViewHistoryBrowserParts.MouseUp += ListViewHistoryBrowserParts_MouseUp;
            }



        private void BuildPartContextMenuItem_Click(object sender, System.EventArgs e)
            {
            ExecutePartCommandAtSelectedPartsTreeNode ("rebuild");
            }


        private Part GetPartFromSender
            {
            get
                {
                if(selectedSender == null)
                    return null;

                if(selectedSender is TreeView)
                    return this.PartsTreeView.SelectedNode.Tag as Part;

                if(selectedSender is ListView)
                    {
                    if(this.listViewHistoryBrowserParts.SelectedItems.Count > 0)
                        return this.listViewHistoryBrowserParts.SelectedItems[0].Tag as Part;

                    return null;
                    }

                return null;
                }
            }

        private Repository GetRepoFromSender
            {
            get
                {
                if(selectedSender == null)
                    return null;

                if(selectedSender is TreeView)
                    return this.PartsTreeView.SelectedNode.Tag as Repository;

                return null;
                }
            }

        private void ExecutePartCommandAtSelectedPartsTreeNode(string cmdName)
            {
            if(String.IsNullOrEmpty (cmdName))
                return;

            Part part = GetPartFromSender;
            if(part == null)
                return;

            ExecutePartCommand (part, cmdName);
            }


        private void CopyBuildCmdContextMenuItem_Click(object sender, System.EventArgs e)
            {
            Part part = GetPartFromSender;

            if(part == null)
                return;

            System.Environment.SetEnvironmentVariable ("OP_PartName", part.PartName);
            Command cmd = Utilities.Instance.FindCommandByName (Configuration.Commands, "rebuild");

            if((cmd == null) || String.IsNullOrEmpty (cmd.Cmd))
                return;

            string pasteCmd = System.Environment.ExpandEnvironmentVariables (cmd.Cmd);
            Clipboard.SetText (pasteCmd);
            CreateListViewBuildPartsHistory (pasteCmd, part);

            System.Environment.SetEnvironmentVariable ("OP_PartName", null);
            }

        private void CreateListViewBuildPartsHistory(string pasteCmd, Part part)
            {
            ListViewItem li = new ListViewItem (part.PartName);
            li.Tag = part;
            if(listViewHistoryBrowserParts.FindItemWithText (part.PartName) == null)
                listViewHistoryBrowserParts.Items.Add (li);
            }

        private void ExplorePartContextMenuItem_Click(object sender, EventArgs e)
            {
            string path = GetPathFromSelectedPartsTreeNode ();

            if(String.IsNullOrEmpty (path) || !System.IO.Directory.Exists (path))
                return;

            ExplorePath (path);

            }

        private void CopyLocalPathContextMenuItem_Click(object sender, EventArgs e)
            {
            string path = GetPathFromSelectedPartsTreeNode ();

            if(String.IsNullOrEmpty (path) || !System.IO.Directory.Exists (path))
                return;

            Clipboard.SetText (path);

            }


        private void BrowseRepositoryPartContextMenuItem_Click(object sender, EventArgs e)
            {
            string repoUrl = GetRepoUrlFromSelectedPartsTreeNode ();
            if(String.IsNullOrEmpty (repoUrl))
                return;

            System.Diagnostics.Process.Start (repoUrl);
            }

        private void CopyRemotePathContextMenuItem_Click(object sender, EventArgs e)
            {
            string repoUrl = GetRepoUrlFromSelectedPartsTreeNode ();
            if(String.IsNullOrEmpty (repoUrl))
                return;

            Clipboard.SetText (repoUrl);
            }

        private void PseudoLocalizePartContextMenuItem_Click(object sender, EventArgs e)
            {
            ExecutePartCommandAtSelectedPartsTreeNode ("pseudo");
            }

        private void MartianizePartContextMenuItem_Click(object sender, EventArgs e)
            {
            ExecutePartCommandAtSelectedPartsTreeNode ("martianize");
            }

        private void HgWorkBenchPartContextMenuItem_Click(object sender, EventArgs e)
            {
            string path = GetPathFromSelectedPartsTreeNode ();
            HgWorkBenchAtPath (path);


            }

        private void HgWorkBenchAtPath(string path)
            {
            if(String.IsNullOrEmpty (path) || !System.IO.Directory.Exists (path))
                return;

            string args = String.Format ("-R \"{0}\"", path);
            try
                {
                System.Diagnostics.Process.Start (Configuration.Settings.HgWorkBenchExe, args);
                }
            catch(Exception ex)
                {
                System.Windows.Forms.MessageBox.Show (ex.Message);
                }

            }

        private void OpenPartFileContextMenuItem_Click(object sender, EventArgs e)
            {
            string partFilename = GetPartFileNameFromSelectedTreeNode ();

            if(String.IsNullOrEmpty (partFilename) || !System.IO.File.Exists (partFilename))
                return;

            OpenFile (partFilename);

            }

        private void CmdShellAtPartContextMenuItem_Click(object sender, EventArgs e)
            {
            string path = GetPathFromSelectedPartsTreeNode ();

            if(String.IsNullOrEmpty (path) || !System.IO.Directory.Exists (path))
                return;

            OpenCommandShellAtPath (path);

            }

        private string GetPathFromSelectedPartsTreeNode()
            {

            TreeNode selectedNode = this.PartsTreeView.SelectedNode;
            return GetPathFromPartsTreeNode (selectedNode);
            }

        private string GetPathFromPartsTreeNode(TreeNode selectedNode)
            {
            if (selectedSender is ListView)
                {
                if(this.listViewHistoryBrowserParts.SelectedItems.Count == 0)
                    return null;
                return GetPathFromPartsListView (this.listViewHistoryBrowserParts.SelectedItems[0]);
                }

            Repository repo = selectedNode.Tag as Repository;
            if(repo != null)
                return repo.ExpandedPath;

            Part part = selectedNode.Tag as Part;
            if(part == null)
                return null;

            string subFolder = !String.IsNullOrEmpty (part.SubFolder) ? part.SubFolder : "";


            repo = selectedNode.Parent.Tag as Repository;
            if((repo == null) || String.IsNullOrEmpty (repo.Path))
                return null;

            string path = repo.ExpandedPath;
            if(String.IsNullOrEmpty (path))
                return null;

            return System.IO.Path.Combine (path, subFolder);

            }

        private string GetPathFromPartsListView(ListViewItem item)
            {
            Repository repo = item.Tag as Repository;
            if(repo != null)
                return repo.ExpandedPath;

            Part part = item.Tag as Part;
            if(part == null)
                return null;

            string subFolder = !String.IsNullOrEmpty (part.SubFolder) ? part.SubFolder : "";

            TreeNode node = FindPartNode (part);
            if(node != null)
                repo = node.Tag as Repository;

            if((repo == null) || String.IsNullOrEmpty (repo.Path))
                return null;

            string path = repo.ExpandedPath;
            if(String.IsNullOrEmpty (path))
                return null;

            return System.IO.Path.Combine (path, subFolder);

            }

        private string GetPartFileNameFromSelectedListViewItem(ListViewItem item)
            {
            Repository repo = item.Tag as Repository;
            if(repo == null)
                return null;

            string path = repo.ExpandedPath;
            if(String.IsNullOrEmpty (path))
                return null;

            string partFileName = String.Format ("{0}.PartFile.xml", repo.Name);
            return System.IO.Path.Combine (path, partFileName);
            }

        private string GetPartFileNameFromSelectedTreeNode()
            {
            Repository repo = this.PartsTreeView.SelectedNode.Tag as Repository;
            if(repo == null)
                return null;

            string path = repo.ExpandedPath;
            if(String.IsNullOrEmpty (path))
                return null;

            string partFileName = String.Format ("{0}.PartFile.xml", repo.Name);
            return System.IO.Path.Combine (path, partFileName);

            }

        private string GetUrlFromSelectedPartsTreeNode()
            {
            Repository repo = GetRepoFromSender;
            if((repo == null) || String.IsNullOrEmpty (repo.Url))
                {
                Part part = GetPartFromSender;
                if(part != null && selectedSender != null && selectedSender is TreeView)
                    repo = this.PartsTreeView.SelectedNode.Parent.Tag as Repository;
                else if(part != null && selectedSender != null && selectedSender is ListView)
                    {
                    TreeNode node = FindPartNode (part);
                    if (node != null)
                        repo = node.Tag as Repository;
                    }
                }

            if(repo == null)
                return null;

            return repo.Url;
            }


        private TreeNode FindPartNode (Part part)
            {
            if(part == null)
                return null;
            foreach (TreeNode n in PartsTreeView.Nodes)
                {
                if(n.Nodes.Count == 0)
                    continue;
                Part nodePart = n.Tag as Part;
                if ((nodePart != null) && nodePart.PartName.Equals(part.PartName))
                    return n;
                foreach (TreeNode cn in n.Nodes)
                    {
                    nodePart = cn.Tag as Part;
                    if ((nodePart != null) && nodePart.PartName.Equals(part.PartName))
                        return n;
                    }
                }

            return null;
            }
        private string GetRepoUrlFromSelectedPartsTreeNode()
            {
            string url = GetUrlFromSelectedPartsTreeNode ();
            if(String.IsNullOrEmpty (url))
                return null;

            SourceTree sourceTree = GetSourceTree ();
            if(sourceTree == null)
                return null;

            string streamRoot = sourceTree.Stream.RepositoryRoot;
            if(String.IsNullOrEmpty (streamRoot))
                return null;

            return String.Format ("{0}/{1}", streamRoot, url);

            }

        private void ListViewHistoryBrowserParts_MouseUp(object sender, MouseEventArgs e)
            {
            // Show menu only if the right mouse button is clicked.
            if(e.Button != MouseButtons.Right)
                return;

            // Point where the mouse is clicked.
            Point p = new Point (e.X, e.Y);

            // Get the node that the user has clicked.
            ListViewItem selectedNode = this.listViewHistoryBrowserParts.GetItemAt (p.X, p.Y);
            if(selectedNode != null)
                {
                if(selectedNode.Tag == null)
                    return;
                selectedSender = sender;

                if(this.listViewHistoryBrowserParts.SelectedItems.Count == 0)
                    return;

                ListViewItem lvi = this.listViewHistoryBrowserParts.SelectedItems[0];
                bool isPart = ((lvi.Tag as Part) != null);

                this.BuildPartContextMenuItem.Visible = isPart;
                this.CopyBuildCmdContextMenuItem.Visible = isPart;
                this.PartContextMenuSeparator2.Visible = isPart;
                this.PseudoLocalizePartContextMenuItem.Visible = isPart;
                this.MartianizePartContextMenuItem.Visible = isPart;

                
                string path = GetPathFromPartsListView (lvi);
                bool pathFound = !String.IsNullOrEmpty (path) && System.IO.Directory.Exists (path);

                if(!pathFound)
                    {
                    this.BuildPartContextMenuItem.Enabled = m_treeParts.OverrideBuildPartCheck (selectedNode);
                    this.CopyBuildCmdContextMenuItem.Enabled = m_treeParts.OverrideBuildPartCheck (selectedNode);
                    }
                else
                    {
                    this.BuildPartContextMenuItem.Enabled = pathFound;
                    this.CopyBuildCmdContextMenuItem.Enabled = pathFound;
                    }

                this.ExplorePartContextMenuItem.Enabled = pathFound;
                this.CmdShellAtPartContextMenuItem.Enabled = pathFound;
                this.HgWorkBenchPartContextMenuItem.Enabled = pathFound;
                this.PseudoLocalizePartContextMenuItem.Enabled = pathFound;
                this.MartianizePartContextMenuItem.Enabled = pathFound;
                this.CopyLocalPathContextMenuItem.Enabled = pathFound;

                bool isRepo = ((lvi.Tag as Repository) != null);
                this.OpenPartFileContextMenuItem.Visible = isRepo;
                string partFileName = GetPartFileNameFromSelectedListViewItem (lvi);
                bool partFileFound = !String.IsNullOrEmpty (partFileName) && System.IO.File.Exists (partFileName);
                this.OpenPartFileContextMenuItem.Enabled = partFileFound;
                toolStripSeparator1.Visible = true;
                RemoveHistoryItem.Visible = true;
                this.PartsContextMenuStrip.Show (Cursor.Position);

                }
            }

        //private TreeNode PreviousPartSelected { get; set; }
        private void PartsTreeView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
            {
            // Show menu only if the right mouse button is clicked.
            if(e.Button != MouseButtons.Right)
                return;

            
            // Point where the mouse is clicked.
            Point p = new Point (e.X, e.Y);

            // Get the node that the user has clicked.
            TreeNode selectedNode = PartsTreeView.GetNodeAt (p);
            if(selectedNode != null)
                {
                selectedSender = sender;
                // Select the node the user has clicked.
                // The node appears selected until the menu is displayed on the screen.
                //PreviousPartSelected = PartsTreeView.SelectedNode;
                PartsTreeView.SelectedNode = selectedNode;

                if(selectedNode.Tag == null)
                    return;

                bool isPart = ((selectedNode.Tag as Part) != null);

                this.BuildPartContextMenuItem.Visible = isPart;
                this.CopyBuildCmdContextMenuItem.Visible = isPart;
                this.PartContextMenuSeparator2.Visible = isPart;
                this.PseudoLocalizePartContextMenuItem.Visible = isPart;
                this.MartianizePartContextMenuItem.Visible = isPart;

                string path = GetPathFromSelectedPartsTreeNode ();
                bool pathFound = !String.IsNullOrEmpty (path) && System.IO.Directory.Exists (path);

                if(!pathFound)
                    {
                    this.BuildPartContextMenuItem.Enabled = m_treeParts.OverrideBuildPartCheck (selectedNode);
                    this.CopyBuildCmdContextMenuItem.Enabled = m_treeParts.OverrideBuildPartCheck (selectedNode);
                    }
                else
                    {
                    this.BuildPartContextMenuItem.Enabled = pathFound;
                    this.CopyBuildCmdContextMenuItem.Enabled = pathFound;
                    }

                this.ExplorePartContextMenuItem.Enabled = pathFound;
                this.CmdShellAtPartContextMenuItem.Enabled = pathFound;
                this.HgWorkBenchPartContextMenuItem.Enabled = pathFound;
                this.PseudoLocalizePartContextMenuItem.Enabled = pathFound;
                this.MartianizePartContextMenuItem.Enabled = pathFound;
                //this.CopyBuildCmdContextMenuItem.Enabled = pathFound;
                this.CopyLocalPathContextMenuItem.Enabled = pathFound;

                bool isRepo = ((selectedNode.Tag as Repository) != null);
                this.OpenPartFileContextMenuItem.Visible = isRepo;
                string partFileName = GetPartFileNameFromSelectedTreeNode ();
                bool partFileFound = !String.IsNullOrEmpty (partFileName) && System.IO.File.Exists (partFileName);
                this.OpenPartFileContextMenuItem.Enabled = partFileFound;
                toolStripSeparator1.Visible = false;
                RemoveHistoryItem.Visible = false;
                this.PartsContextMenuStrip.Show (Cursor.Position);

                //if ((selectedNode.Tag as Part) != null)
                //    this.PartsContextMenuStrip.Show(Cursor.Position);
                //else if ((selectedNode.Tag as Repository) != null)
                //    this.RepositoryContextMenuStrip.Show(Cursor.Position);
                }
            }

        private void InitializeLocationsTreeViewContextMenu()
            {
            this.ExploreLocationContextMenuItem.Click += new System.EventHandler (this.ExploreLocationContextMenuItem_Click);
            this.CmdShellAtLocationContextMenuItem.Click += new System.EventHandler (this.CmdShellAtLocationContextMenuItem_Click);
            this.CopyToClipboardLocationContextMenuItem.Click += new System.EventHandler (this.CopyToClipboardLocationContextMenuItem_Click);
            this.LocationsTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler (this.LocationsTreeView_MouseUp);
            }



        //private TreeNode PreviousPartSelected { get; set; }
        private void LocationsTreeView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
            {
            // Show menu only if the right mouse button is clicked.
            if(e.Button != MouseButtons.Right)
                return;

            // Point where the mouse is clicked.
            Point p = new Point (e.X, e.Y);

            // Get the node that the user has clicked.
            TreeNode selectedNode = LocationsTreeView.GetNodeAt (p);
            if(selectedNode != null)
                {
                // Select the node the user has clicked.
                // The node appears selected until the menu is displayed on the screen.
                //PreviousPartSelected = PartsTreeView.SelectedNode;
                LocationsTreeView.SelectedNode = selectedNode;

                if(selectedNode.Tag == null)
                    return;

                Location loc = LocationsTreeView.SelectedNode.Tag as Location;
                if((loc == null) || String.IsNullOrEmpty (loc.Path))
                    return;
                string path = loc.ExpandedPath;
                bool pathFound = !String.IsNullOrEmpty (path) && System.IO.Directory.Exists (path);

                this.ExploreLocationContextMenuItem.Enabled = pathFound;
                this.CmdShellAtLocationContextMenuItem.Enabled = pathFound;

                this.LocationsContextMenuStrip.Show (Cursor.Position);

                //if ((selectedNode.Tag as Part) != null)
                //    this.PartsContextMenuStrip.Show(Cursor.Position);
                //else if ((selectedNode.Tag as Repository) != null)
                //    this.RepositoryContextMenuStrip.Show(Cursor.Position);
                }
            }


        private void ExploreLocationContextMenuItem_Click(object sender, EventArgs e)
            {
            string path = GetPathFromSelectedLocationsTreeNode ();

            if(String.IsNullOrEmpty (path) || !System.IO.Directory.Exists (path))
                return;

            ExplorePath (path);
            }

        private void CmdShellAtLocationContextMenuItem_Click(object sender, EventArgs e)
            {
            string path = GetPathFromSelectedLocationsTreeNode ();

            if(String.IsNullOrEmpty (path) || !System.IO.Directory.Exists (path))
                return;

            OpenCommandShellAtPath (path);

            }

        private void CopyToClipboardLocationContextMenuItem_Click(object sender, EventArgs e)
            {
            string path = GetPathFromSelectedLocationsTreeNode ();

            if(String.IsNullOrEmpty (path))
                path = "";

            Clipboard.SetText (path);

            }

        private string GetPathFromSelectedLocationsTreeNode()
            {
            return GetPathFromLocationsTreeNode (LocationsTreeView.SelectedNode);

            }

        private string GetPathFromLocationsTreeNode(TreeNode selectedNode)
            {
            if(selectedNode == null)
                return null;

            Location loc = selectedNode.Tag as Location;
            if((loc == null) || String.IsNullOrEmpty (loc.Path))
                return null;
            return loc.ExpandedPath;
            }


        private void InitializeFilesTreeViewContextMenu()
            {
            this.OpenFileContextMenuItem.Click += new System.EventHandler (this.OpenFileContextMenuItem_Click);
            this.ExploreFileContextMenuItem.Click += new System.EventHandler (this.ExploreFileContextMenuItem_Click);
            this.CmdShellAtFileContextMenuItem.Click += new System.EventHandler (this.CmdShellAtFileContextMenuItem_Click);
            this.CopyToClipboardFileContextMenuItem.Click += new System.EventHandler (this.CopyToClipboardFileContextMenuItem_Click);
            this.FilesTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler (this.FilesTreeView_MouseUp);
            }



        //private TreeNode PreviousPartSelected { get; set; }
        private void FilesTreeView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
            {
            // Show menu only if the right mouse button is clicked.
            if(e.Button != MouseButtons.Right)
                return;

            // Point where the mouse is clicked.
            Point p = new Point (e.X, e.Y);

            // Get the node that the user has clicked.
            TreeNode selectedNode = FilesTreeView.GetNodeAt (p);
            if(selectedNode != null)
                {
                // Select the node the user has clicked.
                // The node appears selected until the menu is displayed on the screen.
                //PreviousPartSelected = PartsTreeView.SelectedNode;
                FilesTreeView.SelectedNode = selectedNode;

                if(selectedNode.Tag == null)
                    return;
                string tag = FilesTreeView.SelectedNode.Tag as string;
                if (!string.IsNullOrEmpty(tag) && string.Equals(tag, "Category", StringComparison.InvariantCultureIgnoreCase))
                {
                    this.FolderContextMenuStrip.Show(Cursor.Position);
                    return;
                }
                File file = FilesTreeView.SelectedNode.Tag as File;
                if((file == null) || String.IsNullOrEmpty (file.Name) || String.IsNullOrEmpty (file.Path))
                    return;
                string path = file.ExpandedPath;
                bool pathFound = !String.IsNullOrEmpty (path) && System.IO.Directory.Exists (path);
                string fileName = file.ExpandedFileName;
                bool fileFound = pathFound && !String.IsNullOrEmpty (fileName) && System.IO.File.Exists (fileName);

                this.OpenFileContextMenuItem.Enabled = fileFound;
                this.ExploreFileContextMenuItem.Enabled = pathFound;
                this.CmdShellAtFileContextMenuItem.Enabled = pathFound;

                this.FilesContextMenuStrip.Show (Cursor.Position);

                //if ((selectedNode.Tag as Part) != null)
                //    this.PartsContextMenuStrip.Show(Cursor.Position);
                //else if ((selectedNode.Tag as Repository) != null)
                //    this.RepositoryContextMenuStrip.Show(Cursor.Position);
                }
            }


        private void OpenFileContextMenuItem_Click(object sender, EventArgs e)
            {
            string filename = GetFileNameFromSelectedFilesTreeNode ();

            if(String.IsNullOrEmpty (filename) || !System.IO.File.Exists (filename))
                return;

            OpenFile (filename);

            }
        private void ExploreFileContextMenuItem_Click(object sender, EventArgs e)
            {
            string path = GetPathFromSelectedFilesTreeNode ();

            if(String.IsNullOrEmpty (path) || !System.IO.Directory.Exists (path))
                return;

            ExplorePath (path);
            }

        private void CmdShellAtFileContextMenuItem_Click(object sender, EventArgs e)
            {
            string path = GetPathFromSelectedFilesTreeNode ();

            if(String.IsNullOrEmpty (path) || !System.IO.Directory.Exists (path))
                return;

            OpenCommandShellAtPath (path);

            }

        private void CopyToClipboardFileContextMenuItem_Click(object sender, EventArgs e)
            {
            string path = GetPathFromSelectedFilesTreeNode ();

            if(String.IsNullOrEmpty (path))
                path = "";

            Clipboard.SetText (path);

            }

        private string GetPathFromSelectedFilesTreeNode()
            {
            return GetPathFromFilesTreeNode (FilesTreeView.SelectedNode);

            }

        private string GetPathFromFilesTreeNode(TreeNode selectedNode)
            {
            if(selectedNode == null)
                return null;

            File file = selectedNode.Tag as File;
            if((file == null) || String.IsNullOrEmpty (file.Path))
                return null;
            return file.ExpandedPath;
            }

        private string GetFileNameFromSelectedFilesTreeNode()
            {
            return GetFileNameFromFilesTreeNode (FilesTreeView.SelectedNode);

            }

        private string GetFileNameFromFilesTreeNode(TreeNode selectedNode)
            {
            if(selectedNode == null)
                return null;

            File file = selectedNode.Tag as File;
            if((file == null) || String.IsNullOrEmpty (file.Path) || String.IsNullOrEmpty (file.Name))
                return null;
            return file.ExpandedFileName;
            }






        private void ShowAllPartsCheckBox_CheckedChanged(object sender, EventArgs e)
            {
            UpdateForm ();
            }

        private void ShowAllLocationsCheckBox_CheckedChanged(object sender, EventArgs e)
            {
            UpdateForm ();
            }

        private void LocationsTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
            {
            string path = GetPathFromLocationsTreeNode (e.Node);
            if(String.IsNullOrEmpty (path))
                return;

            if((Configuration.Settings.LocationsDoubleClickAction == Settings.LocationsDoubleClickActionOption.Explorer) && System.IO.Directory.Exists (path))
                ExplorePath (path);
            else if((Configuration.Settings.LocationsDoubleClickAction == Settings.LocationsDoubleClickActionOption.CmdShell) && System.IO.Directory.Exists (path))
                OpenCommandShellAtPath (path);
            else if(Configuration.Settings.LocationsDoubleClickAction == Settings.LocationsDoubleClickActionOption.CopyToClipboard)
                Clipboard.SetText (path);

            }

        private void FilesTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
            {
            string path = GetPathFromFilesTreeNode (e.Node);
            if(String.IsNullOrEmpty (path))
                return;

            string fileName = GetFileNameFromFilesTreeNode (e.Node);
            if(String.IsNullOrEmpty (fileName))
                return;

            if((Configuration.Settings.FilesDoubleClickAction == Settings.LocationsDoubleClickActionOption.Open) && System.IO.File.Exists (fileName))
                OpenFile (fileName);
            else if((Configuration.Settings.FilesDoubleClickAction == Settings.LocationsDoubleClickActionOption.Explorer) && System.IO.Directory.Exists (path))
                ExplorePath (path);
            else if((Configuration.Settings.FilesDoubleClickAction == Settings.LocationsDoubleClickActionOption.CmdShell) && System.IO.Directory.Exists (path))
                OpenCommandShellAtPath (path);
            else if(Configuration.Settings.FilesDoubleClickAction == Settings.LocationsDoubleClickActionOption.CopyToClipboard)
                Clipboard.SetText (fileName);

            }

        private void PartsTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
            {
            selectedSender = sender;
            string path = GetPathFromPartsTreeNode (e.Node);
            if(String.IsNullOrEmpty (path))
                return;

            if((Configuration.Settings.PartsDoubleClickAction == Settings.PartsDoubleClickActionOption.BuildPart) && System.IO.Directory.Exists (path))
                ExecutePartCommandAtSelectedPartsTreeNode ("rebuild");
            else if((Configuration.Settings.PartsDoubleClickAction == Settings.PartsDoubleClickActionOption.Explorer) && System.IO.Directory.Exists (path))
                ExplorePath (path);
            else if((Configuration.Settings.PartsDoubleClickAction == Settings.PartsDoubleClickActionOption.CmdShell) && System.IO.Directory.Exists (path))
                OpenCommandShellAtPath (path);
            else if((Configuration.Settings.PartsDoubleClickAction == Settings.PartsDoubleClickActionOption.HgWorkBench) && System.IO.Directory.Exists (path))
                HgWorkBenchAtPath (path);
            else if(Configuration.Settings.PartsDoubleClickAction == Settings.PartsDoubleClickActionOption.CopyToClipboard)
                Clipboard.SetText (path);
            }


        private void KeyUpEventHandler(object sender, KeyEventArgs e) //Keyup Event 
            {
            if(e.KeyCode == Keys.F5)
                {
                RefreshConfiguration ();
                }
            }


        private void ConfigurationTabControl_SelectedIndexChanged(object sender, EventArgs e)
            {
            TabControl tabCntrl = sender as TabControl;
            if(tabCntrl == null)
                return;

            //if (tabCntrl.SelectedTab.Name == "CodeSnippetsTabPage")
            //    UpdateCodeSnippetsTabPage();
            else if(tabCntrl.SelectedTab.Name == "ClipboardHistoryTabPage")
                UpdateClipboardHistoryRichTextBox ();

            return;
            }

        private void UpdateCodeSnippetsTabPage()
            {
            string csFileName = Configuration.Settings.CodeSnippetsFileName;
            if(String.IsNullOrEmpty (csFileName) || !System.IO.File.Exists (csFileName))
                return;

            string[] snippets = System.IO.File.ReadAllLines (csFileName);
            if(snippets == null)
                return;

            this.CodeSnippetsRichTextBox.Lines = snippets;
            }

        private void UpdateClipboardHistoryRichTextBox()
            {
            this.ClipboardHistoryRichTextBox.Lines = cbMonitor.Items;
            }


        private void ClipboardUpdatedHandler()
            {
            if(Configuration.Settings.MonitorClipboard)
                UpdateClipboardHistoryRichTextBox ();
            }

        private void ApplicationExetoolStripButton_Click(object sender, EventArgs e)
            {
            RunApplication ();
            }

        private void ConfigurationToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
            if(Initialized)
                {
                ConfigurationFile cfgFile = (ConfigurationFile)this.ConfigurationToolStripComboBox.SelectedItem;
                if(!String.IsNullOrEmpty (cfgFile.FileName) && System.IO.File.Exists (cfgFile.FileName))
                    {
                    ConfigurationFile = cfgFile.FileName;
                    Initialize ();
                    }
                }
            }

        private void StreamIconToolStripButton_Click(object sender, EventArgs e)
            {
            DoBrowseStream ();
            }

        //todo need a setting for this
        private void CommandToolStripButton_Click(object sender, EventArgs e)
            {
            Utilities.Instance.RunCommand (string.Empty, Configuration.Settings.DefaultCmdStartPath);
            }

        private void ProcessMantoolStripButton_Click(object sender, EventArgs e)
            {
            if(m_processManager == null || m_processManager.IsDisposed)
                {
                m_processManager = null;
                m_processManager = new ProcessManager (ManagerMode.Cmd);
                m_processManager.Show (this);
                }
            else
                {
                m_processManager.BringToFront ();
                if(m_processManager.WindowState == FormWindowState.Minimized)
                    m_processManager.WindowState = FormWindowState.Normal;
                }
            }
        private ProcessManager m_processManager = null;

        private void toolStripButton1_Click(object sender, EventArgs e)
            {
            if(m_exprocessManager == null || m_exprocessManager.IsDisposed)
                {
                m_exprocessManager = null;
                m_exprocessManager = new ProcessManager (ManagerMode.Explorer);
                m_exprocessManager.Show (this);
                }
            else
                {
                m_exprocessManager.BringToFront ();
                if(m_exprocessManager.WindowState == FormWindowState.Minimized)
                    m_exprocessManager.WindowState = FormWindowState.Normal;
                }
            }
        private ProcessManager m_exprocessManager = null;

        private void PopulateTextEditBox(SourceTree sourceTree, RichTextBox rtb)
            {
            string text = string.Empty;
            if(rtb.Tag != null)
                {
                string file = rtb.Tag.ToString ();
                if(System.IO.File.Exists (file))
                    text = System.IO.File.ReadAllText (file);
                else
                    {
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo (file);
                    if(!fileInfo.Exists)
                        System.IO.Directory.CreateDirectory (fileInfo.Directory.FullName);

                    using(System.IO.TextWriter tw = new System.IO.StreamWriter (file))
                        {
                        tw.Close ();
                        }
                    }
                }

            rtb.Text = text;
            }
        private void AddTextboxContextMenu(RichTextBox rtb)
            {
            if(rtb.ContextMenuStrip != null)
                return;

            ContextMenuStrip cms = new ContextMenuStrip { ShowImageMargin = true };

            ToolStripMenuItem tsmiCut = new ToolStripMenuItem ("Cut");
            tsmiCut.Image = this.IconList.Images["ClipboardCut.ico"];
            tsmiCut.Click += (sender, e) => rtb.Cut ();
            cms.Items.Add (tsmiCut);

            ToolStripMenuItem tsmiCopy = new ToolStripMenuItem ("Copy");
            tsmiCopy.Image = this.IconList.Images["ClipboardCopy.ico"];
            tsmiCopy.Click += (sender, e) => rtb.Copy ();
            cms.Items.Add (tsmiCopy);

            ToolStripMenuItem tsmiPaste = new ToolStripMenuItem ("Paste");
            tsmiPaste.Image = this.IconList.Images["ClipboardPaste.ico"];
            tsmiPaste.Click += (sender, e) => rtb.Paste ();
            cms.Items.Add (tsmiPaste);

            ToolStripSeparator tsmSep = new ToolStripSeparator ();
            cms.Items.Add (tsmSep);

            ToolStripMenuItem tsmSave = new ToolStripMenuItem ("Save");
            tsmSave.Image = this.IconList.Images["ClipboardSave.ico"];
            tsmSave.Click += (sender, e) => SaveRtb (rtb);
            cms.Items.Add (tsmSave);

            ToolStripMenuItem tsmOpen = new ToolStripMenuItem ("Open: " + rtb.Tag.ToString ());
            tsmOpen.Image = this.IconList.Images["ClipboardOpen.ico"];
            tsmOpen.Click += (sender, e) => OpenRtb (rtb.Tag.ToString ());
            cms.Items.Add (tsmOpen);

            rtb.ContextMenuStrip = cms;

            }
        private void SaveRtb(RichTextBox rtb)
            {
            rtb.SaveFile (rtb.Tag.ToString (), RichTextBoxStreamType.PlainText);
            rtb.Parent.BackColor = this.BackColor;
            }

        private void OpenRtb(string file)
            {
            if(String.IsNullOrEmpty (file) || !System.IO.File.Exists (file) || String.IsNullOrEmpty (Configuration.Settings.ConfigFileEditor))
                return;
            System.Diagnostics.Process.Start (Configuration.Settings.ConfigFileEditor, file);
            }

        private void ScratchPadRichTextBox_TextChanged(object sender, EventArgs e)
            {
            UpdateTextBoxSaveState (ScratchPadTabPage);
            }

        private void CodeSnippetsRichTextBox_TextChanged(object sender, EventArgs e)
            {
            UpdateTextBoxSaveState (CodeSnippetsTabPage);
            }
        private void UpdateTextBoxSaveState(TabPage tb)
            {
            if(InUpdateForm)
                {
                tb.BackColor = this.BackColor;
                return;
                }
            tb.BackColor = Color.Red;
            }

        private void CodeSnippetsRichTextBox_KeyDown(object sender, KeyEventArgs e)
            {
            if(e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
                SaveRtb (CodeSnippetsRichTextBox);
            }

        private void ScratchPadRichTextBox_KeyDown(object sender, KeyEventArgs e)
            {
            if(e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
                SaveRtb (ScratchPadRichTextBox);
            }

        public TabControl TabListsCtrl
            {
            get { return tabControlLists; }
            set { this.tabControlLists = value; }
            }
        public TreeView PartsTreeViewCtrl
            {
            get { return PartsTreeView; }
            set { this.PartsTreeView = value; }
            }
        public TreeView LocationsTreeViewCtrl
            {
            get { return LocationsTreeView; }
            set { this.LocationsTreeView = value; }
            }
        public TreeView FilesTreeViewCtrl
            {
            get { return FilesTreeView; }
            set { this.FilesTreeView = value; }
            }
        public ComboBox ComboBoxSearchCtrl
            {
            get { return comboBoxSearch; }
            set { this.comboBoxSearch = value; }
            }

        private void buttonSearch_Click(object sender, EventArgs e)
            {
            m_listSearcher.DoIndexSearch ();
            }

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
            {
            m_listSearcher.ResetNodes ();
            m_listSearcher.SearchTrees ();
            }

        private void comboBoxSearch_KeyUp(object sender, KeyEventArgs e)
            {
            if(e.KeyCode != Keys.Enter)
                return;
            m_listSearcher.ResetNodes ();
            m_listSearcher.SearchTrees ();
            }

        private void comboBoxSearch_TextChanged(object sender, EventArgs e)
            {
            m_listSearcher.ResetNodes ();
            }

        private void buttonSPFind_Click(object sender, EventArgs e)
            {
            HighlightText (ScratchPadRichTextBox, this.textBoxSPSearch.Text, Color.Red);
            }

        private void HighlightText(RichTextBox myRtb, string word, Color color)
            {

            InUpdateForm = true;
            try
                {
                m_richNextCnt = 0;
                m_richTextIndexesSearchList = new List<int> ();
                Font ft = new Font (myRtb.Font, FontStyle.Regular);
                myRtb.SelectAll ();
                myRtb.SelectionColor = Color.Black;
                myRtb.SelectionFont = ft;

                buttonNext.Enabled = false;
                if(word == string.Empty)
                    return;

                buttonNext.Enabled = true;
                int s_start = myRtb.SelectionStart, startIndex = 0, index;
                ft = new Font (myRtb.Font, FontStyle.Bold);

                m_richTextIndexesSearchList = new List<int> ();
                bool found = false;
                while((index = WordIndex (myRtb, word, startIndex)) != -1)
                    {
                    m_richTextIndexesSearchList.Add (index);
                    myRtb.Select (index, word.Length);
                    myRtb.SelectionColor = color;
                    myRtb.SelectionFont = ft;
                    startIndex = index + word.Length;
                    found = true;
                    }

                myRtb.SelectionStart = s_start;
                myRtb.SelectionLength = 0;
                myRtb.SelectionColor = Color.Black;
                if(found)
                    textBoxSPSearch.ForeColor = Color.DarkGreen;
                else
                    textBoxSPSearch.ForeColor = Color.Red;

                }
            finally
                {
                InUpdateForm = false;
                }
            }

        private int WordIndex(RichTextBox myRtb, string word, int startIndex)
            {
            if(m_RichtextboxIgnoreCase)
                return myRtb.Text.IndexOf (word, startIndex, StringComparison.InvariantCultureIgnoreCase);

            return myRtb.Text.IndexOf (word, startIndex);
            }

        private void textBoxSPSearch_KeyUp(object sender, KeyEventArgs e)
            {
            if(e.KeyCode == Keys.Enter)
                HighlightText (ScratchPadRichTextBox, this.textBoxSPSearch.Text, Color.OrangeRed);
            }

        private void buttonMatch_Click(object sender, EventArgs e)
            {
            if(m_RichtextboxIgnoreCase)
                {
                m_RichtextboxIgnoreCase = false;
                buttonMatch.FlatStyle = FlatStyle.Popup;
                }
            else
                {
                m_RichtextboxIgnoreCase = true;
                buttonMatch.FlatStyle = FlatStyle.Standard;
                }
            HighlightText (ScratchPadRichTextBox, this.textBoxSPSearch.Text, Color.Red);
            }

        private void buttonNext_Click(object sender, EventArgs e)
            {
            SearchNext (ScratchPadRichTextBox);
            }

        private void SearchNext(RichTextBox myRtb)
            {
            if(m_richTextIndexesSearchList == null || m_richTextIndexesSearchList.Count == 0)
                return;
            if(m_richNextCnt + 1 > m_richTextIndexesSearchList.Count)
                m_richNextCnt = 0;

            try
                {
                InUpdateForm = true;
                int loc = 0;
                if(m_richNextCnt > 0)
                    {
                    loc = m_richTextIndexesSearchList[m_richNextCnt - 1];
                    Font ft = new Font (ScratchPadRichTextBox.Font, FontStyle.Regular);
                    myRtb.SelectionFont = ft;
                    myRtb.Select (loc, textBoxSPSearch.Text.Length);
                    myRtb.SelectionColor = System.Drawing.Color.Black;
                    myRtb.SelectionBackColor = System.Drawing.Color.White;
                    }
                loc = m_richTextIndexesSearchList[m_richNextCnt];
                myRtb.SelectionStart = loc;
                myRtb.ScrollToCaret ();
                myRtb.Select (loc, textBoxSPSearch.Text.Length);
                myRtb.SelectionColor = System.Drawing.Color.Green;
                myRtb.SelectionBackColor = System.Drawing.Color.LightBlue;
                m_richNextCnt++;
                }
            finally
                {
                InUpdateForm = false;
                }
            }

        private void buttonSaveScratch_Click(object sender, EventArgs e)
            {
            SaveRtb (ScratchPadRichTextBox);
            }

        private void listViewHistoryBrowserParts_DoubleClick(object sender, EventArgs e)
            {

            if(this.listViewHistoryBrowserParts.SelectedItems.Count == 0)
                return;
            selectedSender = sender;
            ExecutePartCommandAtSelectedPartsTreeNode ("rebuild");
            }

        private void listViewHistoryBrowserParts_MouseUp(object sender, MouseEventArgs e)
            {
            if(e.Button == MouseButtons.Right && Control.ModifierKeys == Keys.Shift)
                {
                if(RunMultiPartBuild ())
                    return;

                Point p = new Point (e.X, e.Y);

                // Get the node that the user has clicked.
                ListViewItem selectedItem = listViewHistoryBrowserParts.GetItemAt (e.X, e.Y);
                if(selectedItem != null)
                    {
                    if(String.IsNullOrEmpty (selectedItem.Text))
                        return;

                    Part part = (Part)selectedItem.Tag;
                    if(part == null)
                        return;

                    ExecutePartCommand (part, "rebuild");
                    }
                }
            }

        private bool RunMultiPartBuild()
            {
            if(listViewHistoryBrowserParts.Items.Count == 0)
                return false;

            int cnt = 0;
            foreach(ListViewItem li in listViewHistoryBrowserParts.Items)
                {
                if(li.Checked)
                    cnt++;
                }

            if(cnt <= 1)
                return false;

            if(MessageBox.Show ("Build all items that are checked?", "Build All",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                foreach(ListViewItem li in listViewHistoryBrowserParts.Items)
                    {
                    if(!li.Checked)
                        continue;

                    Part part = (Part)li.Tag;
                    if(part != null)
                        ExecutePartCommand (part, "rebuild");
                    }
                return true;
                }
            return false;
            }

        private void buttonClearHistory_Click(object sender, EventArgs e)
            {
            listViewHistoryBrowserParts.Items.Clear ();
            }

        private void SavePartHistory ()
            {
            string parts = "";
            if(listViewHistoryBrowserParts.Items.Count > 0)
                foreach(ListViewItem li in listViewHistoryBrowserParts.Items)
                    {
                    Part part = li.Tag as Part;
                    if (part != null)
                        parts = String.Format ("{0}{1}|{2};", parts, li.Text, part.Pieces);
                    else
                        parts = String.Format ("{0}{1};", parts, li.Text);
                    }

            OpenPlantCommandConsoleUI.Settings.Default.PartHistory = parts;
            }
        private void RestorePartHistory()
            {
            listViewHistoryBrowserParts.Items.Clear ();
            string savedHistoryParts = OpenPlantCommandConsoleUI.Settings.Default.PartHistory;
            if(string.IsNullOrEmpty (savedHistoryParts))
                return;

            IList<string> hparts = null;
            if(!String.IsNullOrEmpty (savedHistoryParts))
                {
                hparts = savedHistoryParts.Split (';').ToList<string> ();
                }

            if(savedHistoryParts != null)
                {
                foreach(string part in hparts)
                    {
                    try
                        {
                        string[] parts = part.Split ('|');
                        string bb = parts[0];
                        if(string.IsNullOrEmpty (bb))
                            continue;
                        string[] pieces = parts[1].Split (',');
                        Part p = new Part (pieces[0], pieces[1]);
                        ListViewItem li = new ListViewItem (p.PartName);
                        p.SubFolder = pieces[2];
                        li.Tag = p;
                        if(listViewHistoryBrowserParts.FindItemWithText (p.PartName) == null)
                            listViewHistoryBrowserParts.Items.Add (li);
                        }
                    catch { }
                    }
                }
            }

        private void RemoveHistoryItem_Click(object sender, EventArgs e)
            {
            if(this.listViewHistoryBrowserParts.SelectedItems.Count == 0)
                return;

            if(MessageBox.Show ("Remove Selected Item?", "Remove item", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                return;

            ListViewItem lvi = this.listViewHistoryBrowserParts.SelectedItems[0];
            this.listViewHistoryBrowserParts.Items.Remove (lvi);

            }

        private void KillCurrentProcessButton_Click(object sender, EventArgs e)
            {
            Utilities.Instance.KillCurrentProcess ();
            KillCurrentProcessButton.Enabled = false;
            }

        private void listViewHistoryBrowserParts_MouseEnter(object sender, EventArgs e)
            {
            EnableDisableKillCurrentProcess ();
            }

        private void PartsTreeView_MouseEnter(object sender, EventArgs e)
            {
            EnableDisableKillCurrentProcess ();
            }

        private void ConfigurationTabControl_MouseEnter(object sender, EventArgs e)
            {
            EnableDisableKillCurrentProcess ();
            }
        private void EnableDisableKillCurrentProcess ()
            {
            if(Utilities.Instance.CurrentProcess != null && !Utilities.Instance.CurrentProcess.HasExited)
                KillCurrentProcessButton.Enabled = true;
            else
                KillCurrentProcessButton.Enabled = false;
            }

        private void ExecutePartCommand(Part part, string cmdName)
            {
            if((part == null) || String.IsNullOrEmpty (cmdName))
                return;

            System.Environment.SetEnvironmentVariable ("OP_PartName", part.PartName);
            Command cmd = Utilities.Instance.FindCommandByName (Configuration.Commands, cmdName);

            if((cmd == null) || String.IsNullOrEmpty (cmd.Cmd))
                return;

            string pasteCmd = System.Environment.ExpandEnvironmentVariables (cmd.Cmd);
            ExecuteCommand (cmd);

            System.Environment.SetEnvironmentVariable ("OP_PartName", null);

            CreateListViewBuildPartsHistory (pasteCmd, part);
            Clipboard.SetText (pasteCmd);
            }

        private void ExecutePartCommand(IList<Part> parts, string cmdName)
            {
            if((parts == null) || (parts.Count ==0) || String.IsNullOrEmpty (cmdName))
                return;

            string pa = string.Empty;
            foreach (Part part in parts)
                {
                pa = pa + " " + part.PartName;
                }

            System.Environment.SetEnvironmentVariable ("OP_PartName", pa);
            Command cmd = Utilities.Instance.FindCommandByName (Configuration.Commands, cmdName);

            if((cmd == null) || String.IsNullOrEmpty (cmd.Cmd))
                return;

            string pasteCmd = System.Environment.ExpandEnvironmentVariables (cmd.Cmd);
            ExecuteCommand (cmd);

            System.Environment.SetEnvironmentVariable ("OP_PartName", null);

            }

        private void buttonAll_Click(object sender, EventArgs e)
            {
            
            IList<Part> parts = new List<Part> ();
            foreach (ListViewItem li in this.listViewHistoryBrowserParts.Items)
                {
                if (li.Checked)
                    {
                    parts.Add(li.Tag as Part);
                    }
                }
            ExecutePartCommand(parts, "rebuild");

            }

        private void listViewHistoryBrowserParts_ItemChecked(object sender, ItemCheckedEventArgs e)
            {
            foreach (ListViewItem li in this.listViewHistoryBrowserParts.Items)
                {
                if (li.Checked)
                    {
                    buttonAll.Enabled = true;
                    return;
                    }
                }
            buttonAll.Enabled = false;
            }

        private void openAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = FilesTreeView.SelectedNode;
            if (selectedNode.Nodes == null || selectedNode.Nodes.Count < 1)
                return;

            IList<string> fileNames = new List<string>();
            foreach (TreeNode fileNode in selectedNode.Nodes)
            {
                File file = fileNode.Tag as File;
                if ((file == null) || String.IsNullOrEmpty(file.Name) || String.IsNullOrEmpty(file.Path))
                    continue;
                string path = file.ExpandedPath;
                bool pathFound = !String.IsNullOrEmpty(path) && System.IO.Directory.Exists(path);
                string fileName = file.ExpandedFileName;
                if (fileNames.Contains(fileName))
                    continue;
                fileNames.Add(fileName);
            }
            OpenSession(fileNames);
        }
    }
    }
