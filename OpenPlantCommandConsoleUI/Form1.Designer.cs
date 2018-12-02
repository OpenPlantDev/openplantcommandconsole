using System;

namespace OpenPlantCommandConsole
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StreamComboBox = new System.Windows.Forms.ComboBox();
            this.ApplicationComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PPVerTextBox = new System.Windows.Forms.TextBox();
            this.BuildStrategyTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CmdShellColorTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BootstrapButton = new System.Windows.Forms.Button();
            this.ConfigFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.IconList = new System.Windows.Forms.ImageList(this.components);
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonSPFind = new System.Windows.Forms.Button();
            this.ECFVerTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.DebugCheckBox = new System.Windows.Forms.CheckBox();
            this.ConfigurationToolStrip = new System.Windows.Forms.ToolStrip();
            this.ConfigurationToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.EditConfigurationToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EditUserConfigurationToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EditBaseConfigurationToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.AddConfigurationToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveConfigurationToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ExploreConfigurationToolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.CommandToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ProcessMantoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExplorer = new System.Windows.Forms.ToolStripButton();
            this.KillCurrentProcessButton = new System.Windows.Forms.ToolStripButton();
            this.StreamIconToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ApplicationExeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ApplicationIconPictureBox = new System.Windows.Forms.PictureBox();
            this.StreamIconPictureBox = new System.Windows.Forms.PictureBox();
            this.PartsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BuildPartContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExplorePartContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CmdShellAtPartContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HgWorkBenchPartContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BrowseRepositoryPartContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenPartFileContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PartContextMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyBuildCmdContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyLocalPathContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyRemotePathContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PartContextMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.PseudoLocalizePartContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MartianizePartContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RemoveHistoryItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LocationsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExploreLocationContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CmdShellAtLocationContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToClipboardLocationContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigurationTabControl = new System.Windows.Forms.TabControl();
            this.MainTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ShellCommandsTabControl = new System.Windows.Forms.TabControl();
            this.ShellCommandsTabPage1 = new System.Windows.Forms.TabPage();
            this.ListsGroupBox = new System.Windows.Forms.GroupBox();
            this.ShowAllPartsCheckBox = new System.Windows.Forms.CheckBox();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.tabControlLists = new System.Windows.Forms.TabControl();
            this.tabPageRepo = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PartsTreeView = new System.Windows.Forms.TreeView();
            this.buttonAll = new System.Windows.Forms.Button();
            this.buttonClearHistory = new System.Windows.Forms.Button();
            this.listViewHistoryBrowserParts = new OpenPlantCommandConsole.NoDoubleClickAutoCheckListview();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageFolders = new System.Windows.Forms.TabPage();
            this.LocationsTreeView = new System.Windows.Forms.TreeView();
            this.tabPageFiles = new System.Windows.Forms.TabPage();
            this.FilesTreeView = new System.Windows.Forms.TreeView();
            this.ApplicationLabel = new System.Windows.Forms.Label();
            this.StreamLabel = new System.Windows.Forms.Label();
            this.ScratchPadTabPage = new System.Windows.Forms.TabPage();
            this.buttonSaveScratch = new System.Windows.Forms.Button();
            this.groupBoxSPSearch = new System.Windows.Forms.GroupBox();
            this.buttonMatch = new System.Windows.Forms.Button();
            this.textBoxSPSearch = new System.Windows.Forms.TextBox();
            this.ScratchPadRichTextBox = new System.Windows.Forms.RichTextBox();
            this.CodeSnippetsTabPage = new System.Windows.Forms.TabPage();
            this.CodeSnippetsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ClipboardHistoryTabPage = new System.Windows.Forms.TabPage();
            this.ClipboardHistoryRichTextBox = new System.Windows.Forms.RichTextBox();
            this.CommandsImageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.FilesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenFileContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExploreFileContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CmdShellAtFileContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToClipboardFileContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CommandsImageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.FolderContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigurationToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationIconPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StreamIconPictureBox)).BeginInit();
            this.PartsContextMenuStrip.SuspendLayout();
            this.LocationsContextMenuStrip.SuspendLayout();
            this.ConfigurationTabControl.SuspendLayout();
            this.MainTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ShellCommandsTabControl.SuspendLayout();
            this.ListsGroupBox.SuspendLayout();
            this.tabControlLists.SuspendLayout();
            this.tabPageRepo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPageFolders.SuspendLayout();
            this.tabPageFiles.SuspendLayout();
            this.ScratchPadTabPage.SuspendLayout();
            this.groupBoxSPSearch.SuspendLayout();
            this.CodeSnippetsTabPage.SuspendLayout();
            this.ClipboardHistoryTabPage.SuspendLayout();
            this.FilesContextMenuStrip.SuspendLayout();
            this.FolderContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // StreamComboBox
            // 
            this.StreamComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StreamComboBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StreamComboBox.FormattingEnabled = true;
            this.StreamComboBox.Location = new System.Drawing.Point(16, 38);
            this.StreamComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StreamComboBox.Name = "StreamComboBox";
            this.StreamComboBox.Size = new System.Drawing.Size(332, 27);
            this.StreamComboBox.TabIndex = 21;
            this.StreamComboBox.SelectedIndexChanged += new System.EventHandler(this.StreamComboBox_SelectedIndexChanged);
            // 
            // ApplicationComboBox
            // 
            this.ApplicationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ApplicationComboBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationComboBox.FormattingEnabled = true;
            this.ApplicationComboBox.Location = new System.Drawing.Point(404, 38);
            this.ApplicationComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ApplicationComboBox.Name = "ApplicationComboBox";
            this.ApplicationComboBox.Size = new System.Drawing.Size(204, 27);
            this.ApplicationComboBox.TabIndex = 23;
            this.ApplicationComboBox.SelectedIndexChanged += new System.EventHandler(this.ApplicationComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(208, 76);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 21);
            this.label5.TabIndex = 21;
            this.label5.Text = "PowerPlatform Version:";
            // 
            // PPVerTextBox
            // 
            this.PPVerTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PPVerTextBox.Location = new System.Drawing.Point(212, 101);
            this.PPVerTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PPVerTextBox.Name = "PPVerTextBox";
            this.PPVerTextBox.Size = new System.Drawing.Size(208, 27);
            this.PPVerTextBox.TabIndex = 32;
            this.PPVerTextBox.TextChanged += new System.EventHandler(this.ApplicationOverrides_Changed);
            // 
            // BuildStrategyTextBox
            // 
            this.BuildStrategyTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildStrategyTextBox.Location = new System.Drawing.Point(16, 101);
            this.BuildStrategyTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BuildStrategyTextBox.Name = "BuildStrategyTextBox";
            this.BuildStrategyTextBox.Size = new System.Drawing.Size(188, 27);
            this.BuildStrategyTextBox.TabIndex = 31;
            this.BuildStrategyTextBox.TextChanged += new System.EventHandler(this.ApplicationOverrides_Changed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 76);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 21);
            this.label6.TabIndex = 24;
            this.label6.Text = "Build Strategy:";
            // 
            // CmdShellColorTextBox
            // 
            this.CmdShellColorTextBox.Enabled = false;
            this.CmdShellColorTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdShellColorTextBox.Location = new System.Drawing.Point(741, 100);
            this.CmdShellColorTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdShellColorTextBox.Name = "CmdShellColorTextBox";
            this.CmdShellColorTextBox.Size = new System.Drawing.Size(84, 27);
            this.CmdShellColorTextBox.TabIndex = 27;
            this.CmdShellColorTextBox.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(739, 76);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 21);
            this.label7.TabIndex = 26;
            this.label7.Text = "Shell Color:";
            // 
            // BootstrapButton
            // 
            this.BootstrapButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BootstrapButton.Location = new System.Drawing.Point(659, 34);
            this.BootstrapButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BootstrapButton.Name = "BootstrapButton";
            this.BootstrapButton.Size = new System.Drawing.Size(109, 36);
            this.BootstrapButton.TabIndex = 24;
            this.BootstrapButton.Text = "Bootstrap";
            this.BootstrapButton.UseVisualStyleBackColor = true;
            this.BootstrapButton.Click += new System.EventHandler(this.BootstrapButton_Click);
            // 
            // IconList
            // 
            this.IconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconList.ImageStream")));
            this.IconList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconList.Images.SetKeyName(0, "Edit.ico");
            this.IconList.Images.SetKeyName(1, "Refresh.ico");
            this.IconList.Images.SetKeyName(2, "fileopen.ico");
            this.IconList.Images.SetKeyName(3, "folder_explore.ico");
            this.IconList.Images.SetKeyName(4, "add-square-button.ico");
            this.IconList.Images.SetKeyName(5, "Delete.ico");
            this.IconList.Images.SetKeyName(6, "Open.ico");
            this.IconList.Images.SetKeyName(7, "cmdConsole.ico");
            this.IconList.Images.SetKeyName(8, "explorer.ico");
            this.IconList.Images.SetKeyName(9, "DBConnect.ico");
            this.IconList.Images.SetKeyName(10, "ClipboardOpen.ico");
            this.IconList.Images.SetKeyName(11, "ClipboardSave.ico");
            this.IconList.Images.SetKeyName(12, "ClipboardPaste.ico");
            this.IconList.Images.SetKeyName(13, "ClipboardCopy.ico");
            this.IconList.Images.SetKeyName(14, "ClipboardCut.ico");
            this.IconList.Images.SetKeyName(15, "Search2.png");
            this.IconList.Images.SetKeyName(16, "CollapseSize.png");
            this.IconList.Images.SetKeyName(17, "ExpandSize.png");
            this.IconList.Images.SetKeyName(18, "Part.png");
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.ImageKey = "Search2.png";
            this.buttonSearch.ImageList = this.IconList;
            this.buttonSearch.Location = new System.Drawing.Point(335, 14);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(32, 30);
            this.buttonSearch.TabIndex = 189;
            this.buttonSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ToolTip.SetToolTip(this.buttonSearch, "Search");
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.Enabled = false;
            this.buttonNext.ImageKey = "(none)";
            this.buttonNext.ImageList = this.IconList;
            this.buttonNext.Location = new System.Drawing.Point(539, 12);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(33, 27);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = ">";
            this.ToolTip.SetToolTip(this.buttonNext, "Next Search");
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonSPFind
            // 
            this.buttonSPFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSPFind.ImageKey = "Search2.png";
            this.buttonSPFind.ImageList = this.IconList;
            this.buttonSPFind.Location = new System.Drawing.Point(505, 12);
            this.buttonSPFind.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSPFind.Name = "buttonSPFind";
            this.buttonSPFind.Size = new System.Drawing.Size(33, 27);
            this.buttonSPFind.TabIndex = 0;
            this.buttonSPFind.Text = ".";
            this.ToolTip.SetToolTip(this.buttonSPFind, "Search");
            this.buttonSPFind.UseVisualStyleBackColor = true;
            this.buttonSPFind.Click += new System.EventHandler(this.buttonSPFind_Click);
            // 
            // ECFVerTextBox
            // 
            this.ECFVerTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ECFVerTextBox.Location = new System.Drawing.Point(431, 101);
            this.ECFVerTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ECFVerTextBox.Name = "ECFVerTextBox";
            this.ECFVerTextBox.Size = new System.Drawing.Size(204, 27);
            this.ECFVerTextBox.TabIndex = 33;
            this.ECFVerTextBox.TextChanged += new System.EventHandler(this.ApplicationOverrides_Changed);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(431, 76);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 21);
            this.label10.TabIndex = 60;
            this.label10.Text = "ECFramework Version:";
            // 
            // DebugCheckBox
            // 
            this.DebugCheckBox.AutoSize = true;
            this.DebugCheckBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DebugCheckBox.Location = new System.Drawing.Point(655, 101);
            this.DebugCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DebugCheckBox.Name = "DebugCheckBox";
            this.DebugCheckBox.Size = new System.Drawing.Size(80, 25);
            this.DebugCheckBox.TabIndex = 34;
            this.DebugCheckBox.Text = "Debug";
            this.DebugCheckBox.UseVisualStyleBackColor = true;
            this.DebugCheckBox.CheckedChanged += new System.EventHandler(this.ApplicationOverrides_Changed);
            // 
            // ConfigurationToolStrip
            // 
            this.ConfigurationToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ConfigurationToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ConfigurationToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConfigurationToolStripComboBox,
            this.EditConfigurationToolStripButton,
            this.EditUserConfigurationToolStripButton,
            this.EditBaseConfigurationToolStripButton,
            this.RefreshToolStripButton,
            this.AddConfigurationToolStripButton,
            this.RemoveConfigurationToolStripButton,
            this.ExploreConfigurationToolStripButton5,
            this.CommandToolStripButton,
            this.ProcessMantoolStripButton,
            this.toolStripButtonExplorer,
            this.KillCurrentProcessButton,
            this.StreamIconToolStripButton,
            this.ApplicationExeToolStripButton});
            this.ConfigurationToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ConfigurationToolStrip.Name = "ConfigurationToolStrip";
            this.ConfigurationToolStrip.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.ConfigurationToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ConfigurationToolStrip.Size = new System.Drawing.Size(904, 28);
            this.ConfigurationToolStrip.TabIndex = 133;
            this.ConfigurationToolStrip.Text = "ConfigurationToolStrip";
            // 
            // ConfigurationToolStripComboBox
            // 
            this.ConfigurationToolStripComboBox.BackColor = System.Drawing.SystemColors.Menu;
            this.ConfigurationToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConfigurationToolStripComboBox.DropDownWidth = 300;
            this.ConfigurationToolStripComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.ConfigurationToolStripComboBox.Name = "ConfigurationToolStripComboBox";
            this.ConfigurationToolStripComboBox.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ConfigurationToolStripComboBox.Size = new System.Drawing.Size(385, 28);
            this.ConfigurationToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.ConfigurationToolStripComboBox_SelectedIndexChanged);
            // 
            // EditConfigurationToolStripButton
            // 
            this.EditConfigurationToolStripButton.BackColor = System.Drawing.SystemColors.Control;
            this.EditConfigurationToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditConfigurationToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EditConfigurationToolStripButton.Image")));
            this.EditConfigurationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditConfigurationToolStripButton.Margin = new System.Windows.Forms.Padding(1);
            this.EditConfigurationToolStripButton.Name = "EditConfigurationToolStripButton";
            this.EditConfigurationToolStripButton.Size = new System.Drawing.Size(24, 26);
            this.EditConfigurationToolStripButton.ToolTipText = "Edit Configuration";
            this.EditConfigurationToolStripButton.Click += new System.EventHandler(this.CfgEditButton_Click);
            // 
            // EditUserConfigurationToolStripButton
            // 
            this.EditUserConfigurationToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditUserConfigurationToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EditUserConfigurationToolStripButton.Image")));
            this.EditUserConfigurationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditUserConfigurationToolStripButton.Name = "EditUserConfigurationToolStripButton";
            this.EditUserConfigurationToolStripButton.Size = new System.Drawing.Size(24, 25);
            this.EditUserConfigurationToolStripButton.Text = "Edit User Configuration";
            this.EditUserConfigurationToolStripButton.Click += new System.EventHandler(this.CfgEditUserButton_Click);
            // 
            // EditBaseConfigurationToolStripButton
            // 
            this.EditBaseConfigurationToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditBaseConfigurationToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EditBaseConfigurationToolStripButton.Image")));
            this.EditBaseConfigurationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditBaseConfigurationToolStripButton.Name = "EditBaseConfigurationToolStripButton";
            this.EditBaseConfigurationToolStripButton.Size = new System.Drawing.Size(24, 25);
            this.EditBaseConfigurationToolStripButton.Text = "Edit Base Configuration";
            this.EditBaseConfigurationToolStripButton.Click += new System.EventHandler(this.CfgEditBaseButton_Click);
            // 
            // RefreshToolStripButton
            // 
            this.RefreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshToolStripButton.Image")));
            this.RefreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshToolStripButton.Margin = new System.Windows.Forms.Padding(1);
            this.RefreshToolStripButton.Name = "RefreshToolStripButton";
            this.RefreshToolStripButton.Size = new System.Drawing.Size(24, 26);
            this.RefreshToolStripButton.ToolTipText = "Refresh";
            this.RefreshToolStripButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // AddConfigurationToolStripButton
            // 
            this.AddConfigurationToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddConfigurationToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddConfigurationToolStripButton.Image")));
            this.AddConfigurationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddConfigurationToolStripButton.Margin = new System.Windows.Forms.Padding(1);
            this.AddConfigurationToolStripButton.Name = "AddConfigurationToolStripButton";
            this.AddConfigurationToolStripButton.Size = new System.Drawing.Size(24, 26);
            this.AddConfigurationToolStripButton.ToolTipText = "Add Configuration";
            this.AddConfigurationToolStripButton.Click += new System.EventHandler(this.OpenConfigurationButton_Click);
            // 
            // RemoveConfigurationToolStripButton
            // 
            this.RemoveConfigurationToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveConfigurationToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RemoveConfigurationToolStripButton.Image")));
            this.RemoveConfigurationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveConfigurationToolStripButton.Margin = new System.Windows.Forms.Padding(1);
            this.RemoveConfigurationToolStripButton.Name = "RemoveConfigurationToolStripButton";
            this.RemoveConfigurationToolStripButton.Size = new System.Drawing.Size(24, 26);
            this.RemoveConfigurationToolStripButton.ToolTipText = "Remove Configuration";
            this.RemoveConfigurationToolStripButton.Click += new System.EventHandler(this.RemoveConfigurationButton_Click);
            // 
            // ExploreConfigurationToolStripButton5
            // 
            this.ExploreConfigurationToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExploreConfigurationToolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("ExploreConfigurationToolStripButton5.Image")));
            this.ExploreConfigurationToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExploreConfigurationToolStripButton5.Margin = new System.Windows.Forms.Padding(1);
            this.ExploreConfigurationToolStripButton5.Name = "ExploreConfigurationToolStripButton5";
            this.ExploreConfigurationToolStripButton5.Size = new System.Drawing.Size(24, 26);
            this.ExploreConfigurationToolStripButton5.ToolTipText = "Explore Configuration Folder";
            this.ExploreConfigurationToolStripButton5.Click += new System.EventHandler(this.ExploreConfigurationButton_Click);
            // 
            // CommandToolStripButton
            // 
            this.CommandToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CommandToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CommandToolStripButton.Image")));
            this.CommandToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CommandToolStripButton.Name = "CommandToolStripButton";
            this.CommandToolStripButton.Size = new System.Drawing.Size(24, 25);
            this.CommandToolStripButton.Text = "Command";
            this.CommandToolStripButton.Click += new System.EventHandler(this.CommandToolStripButton_Click);
            // 
            // ProcessMantoolStripButton
            // 
            this.ProcessMantoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ProcessMantoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ProcessMantoolStripButton.Image")));
            this.ProcessMantoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ProcessMantoolStripButton.Name = "ProcessMantoolStripButton";
            this.ProcessMantoolStripButton.Size = new System.Drawing.Size(24, 25);
            this.ProcessMantoolStripButton.Text = "Process Manager";
            this.ProcessMantoolStripButton.ToolTipText = "Process Manager";
            this.ProcessMantoolStripButton.Click += new System.EventHandler(this.ProcessMantoolStripButton_Click);
            // 
            // toolStripButtonExplorer
            // 
            this.toolStripButtonExplorer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExplorer.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExplorer.Image")));
            this.toolStripButtonExplorer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExplorer.Name = "toolStripButtonExplorer";
            this.toolStripButtonExplorer.Size = new System.Drawing.Size(24, 25);
            this.toolStripButtonExplorer.Text = "toolStripButtonExplorer";
            this.toolStripButtonExplorer.ToolTipText = "File Explorer Manager";
            this.toolStripButtonExplorer.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // KillCurrentProcessButton
            // 
            this.KillCurrentProcessButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.KillCurrentProcessButton.Enabled = false;
            this.KillCurrentProcessButton.Image = ((System.Drawing.Image)(resources.GetObject("KillCurrentProcessButton.Image")));
            this.KillCurrentProcessButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.KillCurrentProcessButton.Name = "KillCurrentProcessButton";
            this.KillCurrentProcessButton.Size = new System.Drawing.Size(24, 25);
            this.KillCurrentProcessButton.Text = "Size Toggle";
            this.KillCurrentProcessButton.ToolTipText = "Kill Current (or last) Cmd ";
            this.KillCurrentProcessButton.Click += new System.EventHandler(this.KillCurrentProcessButton_Click);
            // 
            // StreamIconToolStripButton
            // 
            this.StreamIconToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StreamIconToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("StreamIconToolStripButton.Image")));
            this.StreamIconToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StreamIconToolStripButton.Margin = new System.Windows.Forms.Padding(50, 1, 0, 2);
            this.StreamIconToolStripButton.Name = "StreamIconToolStripButton";
            this.StreamIconToolStripButton.Size = new System.Drawing.Size(24, 25);
            this.StreamIconToolStripButton.Text = "StreamIconToolStripButton";
            this.StreamIconToolStripButton.Visible = false;
            this.StreamIconToolStripButton.Click += new System.EventHandler(this.StreamIconToolStripButton_Click);
            // 
            // ApplicationExeToolStripButton
            // 
            this.ApplicationExeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ApplicationExeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ApplicationExeToolStripButton.Image")));
            this.ApplicationExeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ApplicationExeToolStripButton.Name = "ApplicationExeToolStripButton";
            this.ApplicationExeToolStripButton.Size = new System.Drawing.Size(24, 25);
            this.ApplicationExeToolStripButton.Text = "ApplicatoinExrtoolStripButton";
            this.ApplicationExeToolStripButton.Visible = false;
            this.ApplicationExeToolStripButton.Click += new System.EventHandler(this.ApplicationExetoolStripButton_Click);
            // 
            // ApplicationIconPictureBox
            // 
            this.ApplicationIconPictureBox.ErrorImage = ((System.Drawing.Image)(resources.GetObject("ApplicationIconPictureBox.ErrorImage")));
            this.ApplicationIconPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ApplicationIconPictureBox.Image")));
            this.ApplicationIconPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("ApplicationIconPictureBox.InitialImage")));
            this.ApplicationIconPictureBox.Location = new System.Drawing.Point(616, 37);
            this.ApplicationIconPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ApplicationIconPictureBox.Name = "ApplicationIconPictureBox";
            this.ApplicationIconPictureBox.Size = new System.Drawing.Size(32, 30);
            this.ApplicationIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ApplicationIconPictureBox.TabIndex = 136;
            this.ApplicationIconPictureBox.TabStop = false;
            this.ApplicationIconPictureBox.Click += new System.EventHandler(this.ApplicationIconPictureBox_Click);
            // 
            // StreamIconPictureBox
            // 
            this.StreamIconPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StreamIconPictureBox.ErrorImage = ((System.Drawing.Image)(resources.GetObject("StreamIconPictureBox.ErrorImage")));
            this.StreamIconPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("StreamIconPictureBox.Image")));
            this.StreamIconPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("StreamIconPictureBox.InitialImage")));
            this.StreamIconPictureBox.Location = new System.Drawing.Point(357, 37);
            this.StreamIconPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StreamIconPictureBox.Name = "StreamIconPictureBox";
            this.StreamIconPictureBox.Size = new System.Drawing.Size(31, 29);
            this.StreamIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StreamIconPictureBox.TabIndex = 137;
            this.StreamIconPictureBox.TabStop = false;
            this.StreamIconPictureBox.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // PartsContextMenuStrip
            // 
            this.PartsContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PartsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BuildPartContextMenuItem,
            this.ExplorePartContextMenuItem,
            this.CmdShellAtPartContextMenuItem,
            this.HgWorkBenchPartContextMenuItem,
            this.BrowseRepositoryPartContextMenuItem,
            this.OpenPartFileContextMenuItem,
            this.PartContextMenuSeparator1,
            this.CopyBuildCmdContextMenuItem,
            this.CopyLocalPathContextMenuItem,
            this.CopyRemotePathContextMenuItem,
            this.PartContextMenuSeparator2,
            this.PseudoLocalizePartContextMenuItem,
            this.MartianizePartContextMenuItem,
            this.toolStripSeparator1,
            this.RemoveHistoryItem});
            this.PartsContextMenuStrip.Name = "PartsContextMenuStrip";
            this.PartsContextMenuStrip.Size = new System.Drawing.Size(312, 310);
            // 
            // BuildPartContextMenuItem
            // 
            this.BuildPartContextMenuItem.Name = "BuildPartContextMenuItem";
            this.BuildPartContextMenuItem.Size = new System.Drawing.Size(311, 24);
            this.BuildPartContextMenuItem.Text = "Build Part";
            // 
            // ExplorePartContextMenuItem
            // 
            this.ExplorePartContextMenuItem.Name = "ExplorePartContextMenuItem";
            this.ExplorePartContextMenuItem.Size = new System.Drawing.Size(311, 24);
            this.ExplorePartContextMenuItem.Text = "Explore Local";
            // 
            // CmdShellAtPartContextMenuItem
            // 
            this.CmdShellAtPartContextMenuItem.Name = "CmdShellAtPartContextMenuItem";
            this.CmdShellAtPartContextMenuItem.Size = new System.Drawing.Size(311, 24);
            this.CmdShellAtPartContextMenuItem.Text = "Open Command Shell";
            // 
            // HgWorkBenchPartContextMenuItem
            // 
            this.HgWorkBenchPartContextMenuItem.Name = "HgWorkBenchPartContextMenuItem";
            this.HgWorkBenchPartContextMenuItem.Size = new System.Drawing.Size(311, 24);
            this.HgWorkBenchPartContextMenuItem.Text = "Hg WorkBench";
            // 
            // BrowseRepositoryPartContextMenuItem
            // 
            this.BrowseRepositoryPartContextMenuItem.Name = "BrowseRepositoryPartContextMenuItem";
            this.BrowseRepositoryPartContextMenuItem.Size = new System.Drawing.Size(311, 24);
            this.BrowseRepositoryPartContextMenuItem.Text = "Browse Remote Repository";
            // 
            // OpenPartFileContextMenuItem
            // 
            this.OpenPartFileContextMenuItem.Name = "OpenPartFileContextMenuItem";
            this.OpenPartFileContextMenuItem.Size = new System.Drawing.Size(311, 24);
            this.OpenPartFileContextMenuItem.Text = "Open Part File";
            // 
            // PartContextMenuSeparator1
            // 
            this.PartContextMenuSeparator1.Name = "PartContextMenuSeparator1";
            this.PartContextMenuSeparator1.Size = new System.Drawing.Size(308, 6);
            // 
            // CopyBuildCmdContextMenuItem
            // 
            this.CopyBuildCmdContextMenuItem.Name = "CopyBuildCmdContextMenuItem";
            this.CopyBuildCmdContextMenuItem.Size = new System.Drawing.Size(311, 24);
            this.CopyBuildCmdContextMenuItem.Text = "Copy Build Command to Clipboard";
            // 
            // CopyLocalPathContextMenuItem
            // 
            this.CopyLocalPathContextMenuItem.Name = "CopyLocalPathContextMenuItem";
            this.CopyLocalPathContextMenuItem.Size = new System.Drawing.Size(311, 24);
            this.CopyLocalPathContextMenuItem.Text = "Copy Local Path to Clipboard";
            // 
            // CopyRemotePathContextMenuItem
            // 
            this.CopyRemotePathContextMenuItem.Name = "CopyRemotePathContextMenuItem";
            this.CopyRemotePathContextMenuItem.Size = new System.Drawing.Size(311, 24);
            this.CopyRemotePathContextMenuItem.Text = "Copy Remote Path to Clipboard";
            // 
            // PartContextMenuSeparator2
            // 
            this.PartContextMenuSeparator2.Name = "PartContextMenuSeparator2";
            this.PartContextMenuSeparator2.Size = new System.Drawing.Size(308, 6);
            // 
            // PseudoLocalizePartContextMenuItem
            // 
            this.PseudoLocalizePartContextMenuItem.Name = "PseudoLocalizePartContextMenuItem";
            this.PseudoLocalizePartContextMenuItem.Size = new System.Drawing.Size(311, 24);
            this.PseudoLocalizePartContextMenuItem.Text = "PseudoLocalize Part";
            // 
            // MartianizePartContextMenuItem
            // 
            this.MartianizePartContextMenuItem.Name = "MartianizePartContextMenuItem";
            this.MartianizePartContextMenuItem.Size = new System.Drawing.Size(311, 24);
            this.MartianizePartContextMenuItem.Text = "Martianize Part";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(308, 6);
            // 
            // RemoveHistoryItem
            // 
            this.RemoveHistoryItem.Name = "RemoveHistoryItem";
            this.RemoveHistoryItem.Size = new System.Drawing.Size(311, 24);
            this.RemoveHistoryItem.Text = "Remove History Item";
            this.RemoveHistoryItem.Visible = false;
            this.RemoveHistoryItem.Click += new System.EventHandler(this.RemoveHistoryItem_Click);
            // 
            // LocationsContextMenuStrip
            // 
            this.LocationsContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.LocationsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExploreLocationContextMenuItem,
            this.CmdShellAtLocationContextMenuItem,
            this.CopyToClipboardLocationContextMenuItem});
            this.LocationsContextMenuStrip.Name = "LocationsContextMenuStrip";
            this.LocationsContextMenuStrip.Size = new System.Drawing.Size(224, 76);
            // 
            // ExploreLocationContextMenuItem
            // 
            this.ExploreLocationContextMenuItem.Name = "ExploreLocationContextMenuItem";
            this.ExploreLocationContextMenuItem.Size = new System.Drawing.Size(223, 24);
            this.ExploreLocationContextMenuItem.Text = "Explore Location";
            // 
            // CmdShellAtLocationContextMenuItem
            // 
            this.CmdShellAtLocationContextMenuItem.Name = "CmdShellAtLocationContextMenuItem";
            this.CmdShellAtLocationContextMenuItem.Size = new System.Drawing.Size(223, 24);
            this.CmdShellAtLocationContextMenuItem.Text = "Open Command Shell";
            // 
            // CopyToClipboardLocationContextMenuItem
            // 
            this.CopyToClipboardLocationContextMenuItem.Name = "CopyToClipboardLocationContextMenuItem";
            this.CopyToClipboardLocationContextMenuItem.Size = new System.Drawing.Size(223, 24);
            this.CopyToClipboardLocationContextMenuItem.Text = "Copy to Clipboard";
            // 
            // ConfigurationTabControl
            // 
            this.ConfigurationTabControl.Controls.Add(this.MainTabPage);
            this.ConfigurationTabControl.Controls.Add(this.ScratchPadTabPage);
            this.ConfigurationTabControl.Controls.Add(this.CodeSnippetsTabPage);
            this.ConfigurationTabControl.Controls.Add(this.ClipboardHistoryTabPage);
            this.ConfigurationTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigurationTabControl.Location = new System.Drawing.Point(0, 28);
            this.ConfigurationTabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConfigurationTabControl.Name = "ConfigurationTabControl";
            this.ConfigurationTabControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ConfigurationTabControl.SelectedIndex = 0;
            this.ConfigurationTabControl.ShowToolTips = true;
            this.ConfigurationTabControl.Size = new System.Drawing.Size(904, 510);
            this.ConfigurationTabControl.TabIndex = 153;
            this.ConfigurationTabControl.SelectedIndexChanged += new System.EventHandler(this.ConfigurationTabControl_SelectedIndexChanged);
            this.ConfigurationTabControl.MouseEnter += new System.EventHandler(this.ConfigurationTabControl_MouseEnter);
            // 
            // MainTabPage
            // 
            this.MainTabPage.BackColor = System.Drawing.Color.Transparent;
            this.MainTabPage.Controls.Add(this.splitContainer);
            this.MainTabPage.Controls.Add(this.ApplicationLabel);
            this.MainTabPage.Controls.Add(this.StreamLabel);
            this.MainTabPage.Controls.Add(this.StreamIconPictureBox);
            this.MainTabPage.Controls.Add(this.DebugCheckBox);
            this.MainTabPage.Controls.Add(this.ECFVerTextBox);
            this.MainTabPage.Controls.Add(this.ApplicationIconPictureBox);
            this.MainTabPage.Controls.Add(this.label10);
            this.MainTabPage.Controls.Add(this.BootstrapButton);
            this.MainTabPage.Controls.Add(this.CmdShellColorTextBox);
            this.MainTabPage.Controls.Add(this.label7);
            this.MainTabPage.Controls.Add(this.BuildStrategyTextBox);
            this.MainTabPage.Controls.Add(this.label6);
            this.MainTabPage.Controls.Add(this.PPVerTextBox);
            this.MainTabPage.Controls.Add(this.label5);
            this.MainTabPage.Controls.Add(this.ApplicationComboBox);
            this.MainTabPage.Controls.Add(this.StreamComboBox);
            this.MainTabPage.Location = new System.Drawing.Point(4, 25);
            this.MainTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainTabPage.Name = "MainTabPage";
            this.MainTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainTabPage.Size = new System.Drawing.Size(896, 481);
            this.MainTabPage.TabIndex = 0;
            this.MainTabPage.Text = "Main";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(7, 137);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer.Panel1MinSize = 250;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.ListsGroupBox);
            this.splitContainer.Panel2MinSize = 250;
            this.splitContainer.Size = new System.Drawing.Size(876, 328);
            this.splitContainer.SplitterDistance = 446;
            this.splitContainer.SplitterWidth = 8;
            this.splitContainer.TabIndex = 189;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ShellCommandsTabControl);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(446, 328);
            this.groupBox1.TabIndex = 185;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commands";
            // 
            // ShellCommandsTabControl
            // 
            this.ShellCommandsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShellCommandsTabControl.Controls.Add(this.ShellCommandsTabPage1);
            this.ShellCommandsTabControl.Location = new System.Drawing.Point(4, 20);
            this.ShellCommandsTabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ShellCommandsTabControl.Name = "ShellCommandsTabControl";
            this.ShellCommandsTabControl.SelectedIndex = 0;
            this.ShellCommandsTabControl.Size = new System.Drawing.Size(438, 298);
            this.ShellCommandsTabControl.TabIndex = 185;
            // 
            // ShellCommandsTabPage1
            // 
            this.ShellCommandsTabPage1.Location = new System.Drawing.Point(4, 25);
            this.ShellCommandsTabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ShellCommandsTabPage1.Name = "ShellCommandsTabPage1";
            this.ShellCommandsTabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ShellCommandsTabPage1.Size = new System.Drawing.Size(430, 269);
            this.ShellCommandsTabPage1.TabIndex = 0;
            this.ShellCommandsTabPage1.Text = "Tab 1";
            this.ShellCommandsTabPage1.UseVisualStyleBackColor = true;
            // 
            // ListsGroupBox
            // 
            this.ListsGroupBox.Controls.Add(this.ShowAllPartsCheckBox);
            this.ListsGroupBox.Controls.Add(this.comboBoxSearch);
            this.ListsGroupBox.Controls.Add(this.buttonSearch);
            this.ListsGroupBox.Controls.Add(this.tabControlLists);
            this.ListsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.ListsGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListsGroupBox.Name = "ListsGroupBox";
            this.ListsGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListsGroupBox.Size = new System.Drawing.Size(422, 328);
            this.ListsGroupBox.TabIndex = 188;
            this.ListsGroupBox.TabStop = false;
            this.ListsGroupBox.Text = "Lists";
            // 
            // ShowAllPartsCheckBox
            // 
            this.ShowAllPartsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowAllPartsCheckBox.AutoSize = true;
            this.ShowAllPartsCheckBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowAllPartsCheckBox.Location = new System.Drawing.Point(375, 15);
            this.ShowAllPartsCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.ShowAllPartsCheckBox.Name = "ShowAllPartsCheckBox";
            this.ShowAllPartsCheckBox.Size = new System.Drawing.Size(51, 25);
            this.ShowAllPartsCheckBox.TabIndex = 158;
            this.ShowAllPartsCheckBox.Text = "All";
            this.ShowAllPartsCheckBox.UseVisualStyleBackColor = true;
            this.ShowAllPartsCheckBox.CheckedChanged += new System.EventHandler(this.ShowAllPartsCheckBox_CheckedChanged);
            // 
            // comboBoxSearch
            // 
            this.comboBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSearch.FormattingEnabled = true;
            this.comboBoxSearch.Location = new System.Drawing.Point(227, 16);
            this.comboBoxSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.Size = new System.Drawing.Size(103, 24);
            this.comboBoxSearch.TabIndex = 189;
            this.comboBoxSearch.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearch_SelectedIndexChanged);
            this.comboBoxSearch.TextChanged += new System.EventHandler(this.comboBoxSearch_TextChanged);
            this.comboBoxSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBoxSearch_KeyUp);
            // 
            // tabControlLists
            // 
            this.tabControlLists.Controls.Add(this.tabPageRepo);
            this.tabControlLists.Controls.Add(this.tabPageFolders);
            this.tabControlLists.Controls.Add(this.tabPageFiles);
            this.tabControlLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlLists.Location = new System.Drawing.Point(4, 19);
            this.tabControlLists.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControlLists.Name = "tabControlLists";
            this.tabControlLists.SelectedIndex = 0;
            this.tabControlLists.Size = new System.Drawing.Size(414, 305);
            this.tabControlLists.TabIndex = 0;
            // 
            // tabPageRepo
            // 
            this.tabPageRepo.Controls.Add(this.splitContainer1);
            this.tabPageRepo.Location = new System.Drawing.Point(4, 25);
            this.tabPageRepo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageRepo.Name = "tabPageRepo";
            this.tabPageRepo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageRepo.Size = new System.Drawing.Size(406, 276);
            this.tabPageRepo.TabIndex = 0;
            this.tabPageRepo.Text = "Repositories";
            this.tabPageRepo.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.PartsTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonAll);
            this.splitContainer1.Panel2.Controls.Add(this.buttonClearHistory);
            this.splitContainer1.Panel2.Controls.Add(this.listViewHistoryBrowserParts);
            this.splitContainer1.Size = new System.Drawing.Size(398, 268);
            this.splitContainer1.SplitterDistance = 213;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // PartsTreeView
            // 
            this.PartsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PartsTreeView.Location = new System.Drawing.Point(0, 0);
            this.PartsTreeView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PartsTreeView.Name = "PartsTreeView";
            this.PartsTreeView.ShowNodeToolTips = true;
            this.PartsTreeView.Size = new System.Drawing.Size(213, 268);
            this.PartsTreeView.TabIndex = 158;
            this.PartsTreeView.MouseEnter += new System.EventHandler(this.PartsTreeView_MouseEnter);
            // 
            // buttonAll
            // 
            this.buttonAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAll.Enabled = false;
            this.buttonAll.Location = new System.Drawing.Point(5, 238);
            this.buttonAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(81, 27);
            this.buttonAll.TabIndex = 161;
            this.buttonAll.Text = "All";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.buttonAll_Click);
            // 
            // buttonClearHistory
            // 
            this.buttonClearHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearHistory.Location = new System.Drawing.Point(94, 238);
            this.buttonClearHistory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClearHistory.Name = "buttonClearHistory";
            this.buttonClearHistory.Size = new System.Drawing.Size(81, 27);
            this.buttonClearHistory.TabIndex = 160;
            this.buttonClearHistory.Text = "Clear";
            this.buttonClearHistory.UseVisualStyleBackColor = true;
            this.buttonClearHistory.Click += new System.EventHandler(this.buttonClearHistory_Click);
            // 
            // listViewHistoryBrowserParts
            // 
            this.listViewHistoryBrowserParts.AllowDrop = true;
            this.listViewHistoryBrowserParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewHistoryBrowserParts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewHistoryBrowserParts.CheckBoxes = true;
            this.listViewHistoryBrowserParts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewHistoryBrowserParts.FullRowSelect = true;
            this.listViewHistoryBrowserParts.GridLines = true;
            this.listViewHistoryBrowserParts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewHistoryBrowserParts.HideSelection = false;
            this.listViewHistoryBrowserParts.LabelWrap = false;
            this.listViewHistoryBrowserParts.Location = new System.Drawing.Point(3, 0);
            this.listViewHistoryBrowserParts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewHistoryBrowserParts.Name = "listViewHistoryBrowserParts";
            this.listViewHistoryBrowserParts.Size = new System.Drawing.Size(172, 230);
            this.listViewHistoryBrowserParts.SmallImageList = this.IconList;
            this.listViewHistoryBrowserParts.TabIndex = 159;
            this.listViewHistoryBrowserParts.UseCompatibleStateImageBehavior = false;
            this.listViewHistoryBrowserParts.View = System.Windows.Forms.View.Details;
            this.listViewHistoryBrowserParts.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewHistoryBrowserParts_ItemChecked);
            this.listViewHistoryBrowserParts.DoubleClick += new System.EventHandler(this.listViewHistoryBrowserParts_DoubleClick);
            this.listViewHistoryBrowserParts.MouseEnter += new System.EventHandler(this.listViewHistoryBrowserParts_MouseEnter);
            this.listViewHistoryBrowserParts.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listViewHistoryBrowserParts_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Build Parts History";
            this.columnHeader1.Width = 100;
            // 
            // tabPageFolders
            // 
            this.tabPageFolders.Controls.Add(this.LocationsTreeView);
            this.tabPageFolders.Location = new System.Drawing.Point(4, 25);
            this.tabPageFolders.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageFolders.Name = "tabPageFolders";
            this.tabPageFolders.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageFolders.Size = new System.Drawing.Size(407, 277);
            this.tabPageFolders.TabIndex = 1;
            this.tabPageFolders.Text = "Folders";
            this.tabPageFolders.UseVisualStyleBackColor = true;
            // 
            // LocationsTreeView
            // 
            this.LocationsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocationsTreeView.Location = new System.Drawing.Point(4, 4);
            this.LocationsTreeView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LocationsTreeView.Name = "LocationsTreeView";
            this.LocationsTreeView.ShowNodeToolTips = true;
            this.LocationsTreeView.Size = new System.Drawing.Size(399, 269);
            this.LocationsTreeView.TabIndex = 151;
            this.LocationsTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.LocationsTreeView_NodeMouseDoubleClick);
            // 
            // tabPageFiles
            // 
            this.tabPageFiles.Controls.Add(this.FilesTreeView);
            this.tabPageFiles.Location = new System.Drawing.Point(4, 25);
            this.tabPageFiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageFiles.Name = "tabPageFiles";
            this.tabPageFiles.Size = new System.Drawing.Size(406, 276);
            this.tabPageFiles.TabIndex = 2;
            this.tabPageFiles.Text = "Files";
            this.tabPageFiles.UseVisualStyleBackColor = true;
            // 
            // FilesTreeView
            // 
            this.FilesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilesTreeView.Location = new System.Drawing.Point(0, 0);
            this.FilesTreeView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FilesTreeView.Name = "FilesTreeView";
            this.FilesTreeView.ShowNodeToolTips = true;
            this.FilesTreeView.Size = new System.Drawing.Size(406, 276);
            this.FilesTreeView.TabIndex = 152;
            this.FilesTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FilesTreeView_NodeMouseDoubleClick);
            // 
            // ApplicationLabel
            // 
            this.ApplicationLabel.AutoSize = true;
            this.ApplicationLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationLabel.Location = new System.Drawing.Point(400, 11);
            this.ApplicationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ApplicationLabel.Name = "ApplicationLabel";
            this.ApplicationLabel.Size = new System.Drawing.Size(98, 21);
            this.ApplicationLabel.TabIndex = 187;
            this.ApplicationLabel.Text = "Application:";
            // 
            // StreamLabel
            // 
            this.StreamLabel.AutoSize = true;
            this.StreamLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StreamLabel.Location = new System.Drawing.Point(12, 11);
            this.StreamLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StreamLabel.Name = "StreamLabel";
            this.StreamLabel.Size = new System.Drawing.Size(69, 21);
            this.StreamLabel.TabIndex = 186;
            this.StreamLabel.Text = "Stream:";
            // 
            // ScratchPadTabPage
            // 
            this.ScratchPadTabPage.Controls.Add(this.buttonSaveScratch);
            this.ScratchPadTabPage.Controls.Add(this.groupBoxSPSearch);
            this.ScratchPadTabPage.Controls.Add(this.ScratchPadRichTextBox);
            this.ScratchPadTabPage.Location = new System.Drawing.Point(4, 25);
            this.ScratchPadTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ScratchPadTabPage.Name = "ScratchPadTabPage";
            this.ScratchPadTabPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ScratchPadTabPage.Size = new System.Drawing.Size(899, 485);
            this.ScratchPadTabPage.TabIndex = 2;
            this.ScratchPadTabPage.Text = "Scratch Pad";
            this.ScratchPadTabPage.UseVisualStyleBackColor = true;
            // 
            // buttonSaveScratch
            // 
            this.buttonSaveScratch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveScratch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSaveScratch.Location = new System.Drawing.Point(520, 22);
            this.buttonSaveScratch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSaveScratch.Name = "buttonSaveScratch";
            this.buttonSaveScratch.Size = new System.Drawing.Size(88, 27);
            this.buttonSaveScratch.TabIndex = 2;
            this.buttonSaveScratch.Text = "Save";
            this.buttonSaveScratch.UseVisualStyleBackColor = true;
            this.buttonSaveScratch.Click += new System.EventHandler(this.buttonSaveScratch_Click);
            // 
            // groupBoxSPSearch
            // 
            this.groupBoxSPSearch.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxSPSearch.Controls.Add(this.buttonNext);
            this.groupBoxSPSearch.Controls.Add(this.buttonMatch);
            this.groupBoxSPSearch.Controls.Add(this.textBoxSPSearch);
            this.groupBoxSPSearch.Controls.Add(this.buttonSPFind);
            this.groupBoxSPSearch.Location = new System.Drawing.Point(11, 7);
            this.groupBoxSPSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSPSearch.Name = "groupBoxSPSearch";
            this.groupBoxSPSearch.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSPSearch.Size = new System.Drawing.Size(616, 43);
            this.groupBoxSPSearch.TabIndex = 1;
            this.groupBoxSPSearch.TabStop = false;
            this.groupBoxSPSearch.Text = "Find";
            // 
            // buttonMatch
            // 
            this.buttonMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMatch.Location = new System.Drawing.Point(575, 12);
            this.buttonMatch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonMatch.Name = "buttonMatch";
            this.buttonMatch.Size = new System.Drawing.Size(33, 27);
            this.buttonMatch.TabIndex = 2;
            this.buttonMatch.Text = "M";
            this.buttonMatch.UseVisualStyleBackColor = true;
            this.buttonMatch.Click += new System.EventHandler(this.buttonMatch_Click);
            // 
            // textBoxSPSearch
            // 
            this.textBoxSPSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSPSearch.Location = new System.Drawing.Point(8, 15);
            this.textBoxSPSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSPSearch.Name = "textBoxSPSearch";
            this.textBoxSPSearch.Size = new System.Drawing.Size(484, 22);
            this.textBoxSPSearch.TabIndex = 1;
            this.textBoxSPSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSPSearch_KeyUp);
            // 
            // ScratchPadRichTextBox
            // 
            this.ScratchPadRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScratchPadRichTextBox.Location = new System.Drawing.Point(4, 58);
            this.ScratchPadRichTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ScratchPadRichTextBox.Name = "ScratchPadRichTextBox";
            this.ScratchPadRichTextBox.Size = new System.Drawing.Size(609, 182);
            this.ScratchPadRichTextBox.TabIndex = 0;
            this.ScratchPadRichTextBox.Text = "";
            this.ScratchPadRichTextBox.TextChanged += new System.EventHandler(this.ScratchPadRichTextBox_TextChanged);
            this.ScratchPadRichTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScratchPadRichTextBox_KeyDown);
            // 
            // CodeSnippetsTabPage
            // 
            this.CodeSnippetsTabPage.Controls.Add(this.CodeSnippetsRichTextBox);
            this.CodeSnippetsTabPage.Location = new System.Drawing.Point(4, 25);
            this.CodeSnippetsTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CodeSnippetsTabPage.Name = "CodeSnippetsTabPage";
            this.CodeSnippetsTabPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CodeSnippetsTabPage.Size = new System.Drawing.Size(899, 485);
            this.CodeSnippetsTabPage.TabIndex = 3;
            this.CodeSnippetsTabPage.Text = "Code Snippets";
            this.CodeSnippetsTabPage.UseVisualStyleBackColor = true;
            // 
            // CodeSnippetsRichTextBox
            // 
            this.CodeSnippetsRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeSnippetsRichTextBox.Location = new System.Drawing.Point(4, 4);
            this.CodeSnippetsRichTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CodeSnippetsRichTextBox.Name = "CodeSnippetsRichTextBox";
            this.CodeSnippetsRichTextBox.Size = new System.Drawing.Size(891, 477);
            this.CodeSnippetsRichTextBox.TabIndex = 0;
            this.CodeSnippetsRichTextBox.Text = "";
            this.CodeSnippetsRichTextBox.TextChanged += new System.EventHandler(this.CodeSnippetsRichTextBox_TextChanged);
            this.CodeSnippetsRichTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodeSnippetsRichTextBox_KeyDown);
            // 
            // ClipboardHistoryTabPage
            // 
            this.ClipboardHistoryTabPage.Controls.Add(this.ClipboardHistoryRichTextBox);
            this.ClipboardHistoryTabPage.Location = new System.Drawing.Point(4, 25);
            this.ClipboardHistoryTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ClipboardHistoryTabPage.Name = "ClipboardHistoryTabPage";
            this.ClipboardHistoryTabPage.Size = new System.Drawing.Size(899, 485);
            this.ClipboardHistoryTabPage.TabIndex = 4;
            this.ClipboardHistoryTabPage.Text = "Clipboard History";
            this.ClipboardHistoryTabPage.UseVisualStyleBackColor = true;
            // 
            // ClipboardHistoryRichTextBox
            // 
            this.ClipboardHistoryRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClipboardHistoryRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.ClipboardHistoryRichTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ClipboardHistoryRichTextBox.Name = "ClipboardHistoryRichTextBox";
            this.ClipboardHistoryRichTextBox.Size = new System.Drawing.Size(899, 485);
            this.ClipboardHistoryRichTextBox.TabIndex = 0;
            this.ClipboardHistoryRichTextBox.Text = "";
            // 
            // CommandsImageListLarge
            // 
            this.CommandsImageListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("CommandsImageListLarge.ImageStream")));
            this.CommandsImageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.CommandsImageListLarge.Images.SetKeyName(0, "cmdConsole.ico");
            this.CommandsImageListLarge.Images.SetKeyName(1, "Vs.ico");
            this.CommandsImageListLarge.Images.SetKeyName(2, "Pull.ico");
            this.CommandsImageListLarge.Images.SetKeyName(3, "Build.ico");
            this.CommandsImageListLarge.Images.SetKeyName(4, "DeleteFolder.ico");
            this.CommandsImageListLarge.Images.SetKeyName(5, "Status.ico");
            this.CommandsImageListLarge.Images.SetKeyName(6, "Folderrename.ico");
            this.CommandsImageListLarge.Images.SetKeyName(7, "DeleteLKGFolder.ico");
            this.CommandsImageListLarge.Images.SetKeyName(8, "Bundlebuild.ico");
            this.CommandsImageListLarge.Images.SetKeyName(9, "BundlebuildGet.ico");
            this.CommandsImageListLarge.Images.SetKeyName(10, "Buildinstallset.ico");
            this.CommandsImageListLarge.Images.SetKeyName(11, "pseudolocalize.ico");
            this.CommandsImageListLarge.Images.SetKeyName(12, "MergeOut.ico");
            this.CommandsImageListLarge.Images.SetKeyName(13, "MergeIn.ico");
            this.CommandsImageListLarge.Images.SetKeyName(14, "Merge.ico");
            this.CommandsImageListLarge.Images.SetKeyName(15, "ReportIconBase.ico");
            this.CommandsImageListLarge.Images.SetKeyName(16, "MartianBuild.ico");
            this.CommandsImageListLarge.Images.SetKeyName(17, "MartianRun.ico");
            this.CommandsImageListLarge.Images.SetKeyName(18, "OPIM.ico");
            this.CommandsImageListLarge.Images.SetKeyName(19, "OPM.ico");
            this.CommandsImageListLarge.Images.SetKeyName(20, "OPOM.ico");
            this.CommandsImageListLarge.Images.SetKeyName(21, "OPPA.ico");
            this.CommandsImageListLarge.Images.SetKeyName(22, "OPPID.ico");
            this.CommandsImageListLarge.Images.SetKeyName(23, "OPSE.ico");
            this.CommandsImageListLarge.Images.SetKeyName(24, "www.ico");
            // 
            // FilesContextMenuStrip
            // 
            this.FilesContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.FilesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileContextMenuItem,
            this.ExploreFileContextMenuItem,
            this.CmdShellAtFileContextMenuItem,
            this.CopyToClipboardFileContextMenuItem});
            this.FilesContextMenuStrip.Name = "FilesContextMenuStrip";
            this.FilesContextMenuStrip.Size = new System.Drawing.Size(224, 100);
            // 
            // OpenFileContextMenuItem
            // 
            this.OpenFileContextMenuItem.Name = "OpenFileContextMenuItem";
            this.OpenFileContextMenuItem.Size = new System.Drawing.Size(223, 24);
            this.OpenFileContextMenuItem.Text = "Open";
            // 
            // ExploreFileContextMenuItem
            // 
            this.ExploreFileContextMenuItem.Name = "ExploreFileContextMenuItem";
            this.ExploreFileContextMenuItem.Size = new System.Drawing.Size(223, 24);
            this.ExploreFileContextMenuItem.Text = "Explore Location";
            // 
            // CmdShellAtFileContextMenuItem
            // 
            this.CmdShellAtFileContextMenuItem.Name = "CmdShellAtFileContextMenuItem";
            this.CmdShellAtFileContextMenuItem.Size = new System.Drawing.Size(223, 24);
            this.CmdShellAtFileContextMenuItem.Text = "Open Command Shell";
            // 
            // CopyToClipboardFileContextMenuItem
            // 
            this.CopyToClipboardFileContextMenuItem.Name = "CopyToClipboardFileContextMenuItem";
            this.CopyToClipboardFileContextMenuItem.Size = new System.Drawing.Size(223, 24);
            this.CopyToClipboardFileContextMenuItem.Text = "Copy To Clipboard";
            // 
            // CommandsImageListSmall
            // 
            this.CommandsImageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("CommandsImageListSmall.ImageStream")));
            this.CommandsImageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.CommandsImageListSmall.Images.SetKeyName(0, "cmdConsole.ico");
            this.CommandsImageListSmall.Images.SetKeyName(1, "Vs.ico");
            this.CommandsImageListSmall.Images.SetKeyName(2, "Pull.ico");
            this.CommandsImageListSmall.Images.SetKeyName(3, "Build.ico");
            this.CommandsImageListSmall.Images.SetKeyName(4, "DeleteFolder.ico");
            this.CommandsImageListSmall.Images.SetKeyName(5, "Status.ico");
            this.CommandsImageListSmall.Images.SetKeyName(6, "Folderrename.ico");
            this.CommandsImageListSmall.Images.SetKeyName(7, "DeleteLKGFolder.ico");
            this.CommandsImageListSmall.Images.SetKeyName(8, "Bundlebuild.ico");
            this.CommandsImageListSmall.Images.SetKeyName(9, "BundlebuildGet.ico");
            this.CommandsImageListSmall.Images.SetKeyName(10, "Buildinstallset.ico");
            this.CommandsImageListSmall.Images.SetKeyName(11, "pseudolocalize.ico");
            this.CommandsImageListSmall.Images.SetKeyName(12, "MergeOut.ico");
            this.CommandsImageListSmall.Images.SetKeyName(13, "MergeIn.ico");
            this.CommandsImageListSmall.Images.SetKeyName(14, "Merge.ico");
            this.CommandsImageListSmall.Images.SetKeyName(15, "ReportIconBase.ico");
            this.CommandsImageListSmall.Images.SetKeyName(16, "MartianBuild.ico");
            this.CommandsImageListSmall.Images.SetKeyName(17, "MartianRun.ico");
            this.CommandsImageListSmall.Images.SetKeyName(18, "OPIM.ico");
            this.CommandsImageListSmall.Images.SetKeyName(19, "OPM.ico");
            this.CommandsImageListSmall.Images.SetKeyName(20, "OPOM.ico");
            this.CommandsImageListSmall.Images.SetKeyName(21, "OPPA.ico");
            this.CommandsImageListSmall.Images.SetKeyName(22, "OPPID.ico");
            this.CommandsImageListSmall.Images.SetKeyName(23, "OPSE.ico");
            this.CommandsImageListSmall.Images.SetKeyName(24, "www.ico");
            // 
            // FolderContextMenuStrip
            // 
            this.FolderContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.FolderContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openAllToolStripMenuItem});
            this.FolderContextMenuStrip.Name = "FolderContextMenuStrip";
            this.FolderContextMenuStrip.Size = new System.Drawing.Size(137, 28);
            // 
            // openAllToolStripMenuItem
            // 
            this.openAllToolStripMenuItem.Name = "openAllToolStripMenuItem";
            this.openAllToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.openAllToolStripMenuItem.Text = "Open All";
            this.openAllToolStripMenuItem.Click += new System.EventHandler(this.openAllToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = global::OpenPlantCommandConsoleUI.Settings.Default.Size;
            this.Controls.Add(this.ConfigurationTabControl);
            this.Controls.Add(this.ConfigurationToolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = global::OpenPlantCommandConsoleUI.Settings.Default.Location;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(922, 585);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OpenPlant Command Console";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Click += new System.EventHandler(this.MainForm_Clicked);
            this.ConfigurationToolStrip.ResumeLayout(false);
            this.ConfigurationToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationIconPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StreamIconPictureBox)).EndInit();
            this.PartsContextMenuStrip.ResumeLayout(false);
            this.LocationsContextMenuStrip.ResumeLayout(false);
            this.ConfigurationTabControl.ResumeLayout(false);
            this.MainTabPage.ResumeLayout(false);
            this.MainTabPage.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ShellCommandsTabControl.ResumeLayout(false);
            this.ListsGroupBox.ResumeLayout(false);
            this.ListsGroupBox.PerformLayout();
            this.tabControlLists.ResumeLayout(false);
            this.tabPageRepo.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPageFolders.ResumeLayout(false);
            this.tabPageFiles.ResumeLayout(false);
            this.ScratchPadTabPage.ResumeLayout(false);
            this.groupBoxSPSearch.ResumeLayout(false);
            this.groupBoxSPSearch.PerformLayout();
            this.CodeSnippetsTabPage.ResumeLayout(false);
            this.ClipboardHistoryTabPage.ResumeLayout(false);
            this.FilesContextMenuStrip.ResumeLayout(false);
            this.FolderContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox StreamComboBox;
        private System.Windows.Forms.ComboBox ApplicationComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PPVerTextBox;
        private System.Windows.Forms.TextBox BuildStrategyTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CmdShellColorTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BootstrapButton;
        private System.Windows.Forms.OpenFileDialog ConfigFileDialog;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ImageList IconList;
        private System.Windows.Forms.TextBox ECFVerTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox DebugCheckBox;
        private System.Windows.Forms.ToolStrip ConfigurationToolStrip;
        private System.Windows.Forms.ToolStripButton EditConfigurationToolStripButton;
        private System.Windows.Forms.ToolStripButton RefreshToolStripButton;
        private System.Windows.Forms.ToolStripButton AddConfigurationToolStripButton;
        private System.Windows.Forms.ToolStripButton RemoveConfigurationToolStripButton;
        private System.Windows.Forms.ToolStripButton ExploreConfigurationToolStripButton5;
        private System.Windows.Forms.PictureBox ApplicationIconPictureBox;
        private System.Windows.Forms.PictureBox StreamIconPictureBox;
        private System.Windows.Forms.ContextMenuStrip PartsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem BuildPartContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExplorePartContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CmdShellAtPartContextMenuItem;
        private System.Windows.Forms.ToolStripSeparator PartContextMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem PseudoLocalizePartContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MartianizePartContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HgWorkBenchPartContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BrowseRepositoryPartContextMenuItem;
        private System.Windows.Forms.ContextMenuStrip LocationsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ExploreLocationContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CmdShellAtLocationContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyToClipboardLocationContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenPartFileContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyBuildCmdContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyLocalPathContextMenuItem;
        private System.Windows.Forms.ToolStripSeparator PartContextMenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CopyRemotePathContextMenuItem;
        private System.Windows.Forms.TabControl ConfigurationTabControl;
        private System.Windows.Forms.TabPage MainTabPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage ScratchPadTabPage;
        private System.Windows.Forms.RichTextBox ScratchPadRichTextBox;
        private System.Windows.Forms.TabPage CodeSnippetsTabPage;
        private System.Windows.Forms.TabPage ClipboardHistoryTabPage;
        private System.Windows.Forms.RichTextBox CodeSnippetsRichTextBox;
        private System.Windows.Forms.RichTextBox ClipboardHistoryRichTextBox;
        private System.Windows.Forms.ToolStripButton ApplicationExeToolStripButton;
        private System.Windows.Forms.ToolStripComboBox ConfigurationToolStripComboBox;
        private System.Windows.Forms.ToolStripButton StreamIconToolStripButton;
        private System.Windows.Forms.Label ApplicationLabel;
        private System.Windows.Forms.Label StreamLabel;
        private System.Windows.Forms.TabControl ShellCommandsTabControl;
        private System.Windows.Forms.TabPage ShellCommandsTabPage1;
        private System.Windows.Forms.ImageList CommandsImageListLarge;
        private System.Windows.Forms.ToolStripButton CommandToolStripButton;
        private System.Windows.Forms.GroupBox ListsGroupBox;
        private System.Windows.Forms.TabControl tabControlLists;
        private System.Windows.Forms.TabPage tabPageRepo;
        private System.Windows.Forms.CheckBox ShowAllPartsCheckBox;
        private System.Windows.Forms.TabPage tabPageFolders;
        private System.Windows.Forms.TreeView LocationsTreeView;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ComboBox comboBoxSearch;
        private System.Windows.Forms.TabPage tabPageFiles;
        private System.Windows.Forms.TreeView FilesTreeView;
        private System.Windows.Forms.ContextMenuStrip FilesContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem OpenFileContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExploreFileContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CmdShellAtFileContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyToClipboardFileContextMenuItem;
        private System.Windows.Forms.ToolStripButton KillCurrentProcessButton;
        private System.Windows.Forms.GroupBox groupBoxSPSearch;
        private System.Windows.Forms.TextBox textBoxSPSearch;
        private System.Windows.Forms.Button buttonSPFind;
        private System.Windows.Forms.Button buttonMatch;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonSaveScratch;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ImageList CommandsImageListSmall;
        private System.Windows.Forms.ToolStripButton ProcessMantoolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButtonExplorer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView PartsTreeView;
        private System.Windows.Forms.ToolStripMenuItem RemoveHistoryItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.Button buttonClearHistory;
        public NoDoubleClickAutoCheckListview listViewHistoryBrowserParts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStripButton EditBaseConfigurationToolStripButton;
        private System.Windows.Forms.ToolStripButton EditUserConfigurationToolStripButton;
        private System.Windows.Forms.ContextMenuStrip FolderContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openAllToolStripMenuItem;
    }
}

