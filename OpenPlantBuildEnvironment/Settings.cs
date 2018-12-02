using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class Settings
    {
        public const string DefaultPowerPlatformVersion = "10.8.0.34";
        public const string DefaultBackgroundColor = "0";
        public const string DefaultForegroundColor = "7";

        public string RootFolder { get; set; }
        public string LocalBuildStrategiesFolder { get; set; }
        public string BatFolder { get; set; }

        [DefaultValue("src")]
        public string SourceFolder { get; set; }

        [DefaultValue("out")]
        public string OutFolder { get; set; }
        public string BaseEnvBatFile { get; set; }
        public string PowerPlatformVersion { get; set; }
        public string ConfigFileEditor { get; set; }
        public string HgWorkBenchExe { get; set; }
        public string ApplicationBackgroundColor { get; set; }

        [DefaultValue(true)]
        public bool Debug { get; set; }

        [DefaultValue(false)]
        public bool ConfirmCommand { get; set; }

        [DefaultValue(true)]
        public bool EnableSeeding { get; set; }
        public string SeedRootFolder { get; set; }
        public string SeedAppFolder { get; set; }

        public bool ShowLocationsToolTips { get; set; }
        public bool ShowPartsToolTips { get; set; }


        public string CmdShellBackgroundColor { get; set; }
        public string CmdShellForegroundColor { get; set; }

        public string CodeSnippetsFileName { get; set; }

        public string ScratchPadFileName { get; set; }
        public string IconsPath { get; set; }

        public bool MonitorClipboard { get; set; }

        public LocationsDoubleClickActionOption LocationsDoubleClickAction { get; set;}
        public LocationsDoubleClickActionOption FilesDoubleClickAction { get; set; }
        public PartsDoubleClickActionOption PartsDoubleClickAction { get; set; }

        public bool CommandSingleClickOption { get; set; }

        public string DefaultCmdStartPath { get; set; } = @"d:\";

        public enum LocationsDoubleClickActionOption
        {
            Explorer,
            CmdShell,
            CopyToClipboard,
            Open,
            Unknown
        }

        public enum PartsDoubleClickActionOption
        {
            BuildPart,
            Explorer,
            CmdShell,
            HgWorkBench,
            CopyToClipboard,
            Unknown
        }

        public Settings()
        {
            SourceFolder = "src";
            OutFolder = "out";
            PowerPlatformVersion = DefaultPowerPlatformVersion;
            CmdShellBackgroundColor = DefaultBackgroundColor;
            CmdShellForegroundColor = DefaultForegroundColor;
            ConfigFileEditor = "C:\\Windows\\System32\\notepad.exe";
            HgWorkBenchExe = "C:\\Program Files\\TortoiseHg\\thg.exe";
            Debug = true;
            ConfirmCommand = false;
            ShowLocationsToolTips = true;
            ShowPartsToolTips = true;
            LocationsDoubleClickAction = LocationsDoubleClickActionOption.Explorer;
            PartsDoubleClickAction = PartsDoubleClickActionOption.Explorer;
            MonitorClipboard = false;

            //EnableBackgroundCommands = false;
        }

        public void UpdateFromJson(jsonSettings jSettings)
        {

            if (jSettings == null)
                return ;


            RootFolder = !String.IsNullOrEmpty(jSettings.RootFolder) ? jSettings.RootFolder : RootFolder;
            LocalBuildStrategiesFolder = !String.IsNullOrEmpty(jSettings.LocalBuildStrategiesFolder) ? jSettings.LocalBuildStrategiesFolder : LocalBuildStrategiesFolder;
            SourceFolder = !String.IsNullOrEmpty(jSettings.SourceFolder) ? jSettings.SourceFolder : SourceFolder;
            OutFolder = !String.IsNullOrEmpty(jSettings.OutFolder) ? jSettings.OutFolder : OutFolder;
            BatFolder = !String.IsNullOrEmpty(jSettings.BatFolder) ? jSettings.BatFolder : BatFolder;
            BaseEnvBatFile = !String.IsNullOrEmpty(jSettings.BaseEnvBatFile) ? jSettings.BaseEnvBatFile : BaseEnvBatFile;
            PowerPlatformVersion = !String.IsNullOrEmpty(jSettings.PowerPlatformVersion) ? jSettings.PowerPlatformVersion : PowerPlatformVersion;
            ApplicationBackgroundColor = !String.IsNullOrEmpty(jSettings.AppBackgroundColor) ? jSettings.AppBackgroundColor : ApplicationBackgroundColor;

            CmdShellBackgroundColor = !String.IsNullOrEmpty(jSettings.CmdShellBackgroundColor) ? jSettings.CmdShellBackgroundColor : CmdShellBackgroundColor;
            CmdShellForegroundColor = !String.IsNullOrEmpty(jSettings.CmdShellForegroundColor) ? jSettings.CmdShellForegroundColor : CmdShellForegroundColor;

            ConfigFileEditor = !String.IsNullOrEmpty(jSettings.ConfigFileEditor) ? jSettings.ConfigFileEditor : ConfigFileEditor;
            HgWorkBenchExe = !String.IsNullOrEmpty(jSettings.HgWorkBenchExe) ? jSettings.HgWorkBenchExe : HgWorkBenchExe;

            Debug = (jSettings.Debug != null) ? (bool)jSettings.Debug : Debug;

            ConfirmCommand = (jSettings.ConfirmCommand != null) ? (bool)jSettings.ConfirmCommand : ConfirmCommand;

            EnableSeeding = (jSettings.EnableSeeding != null) ? (bool)jSettings.EnableSeeding : EnableSeeding;
            //EnableBackgroundCommands = (jSettings.EnableBackgroundCommands != null) ? (bool)jSettings.EnableBackgroundCommands : EnableBackgroundCommands;
            SeedRootFolder = !String.IsNullOrEmpty(jSettings.SeedRootFolder) ? jSettings.SeedRootFolder : SeedRootFolder;
            SeedAppFolder = !String.IsNullOrEmpty(jSettings.SeedAppFolder) ? jSettings.SeedAppFolder : SeedAppFolder;

            ShowLocationsToolTips = (jSettings.ShowLocationsToolTips != null) ? (bool)jSettings.ShowLocationsToolTips : ShowLocationsToolTips;
            ShowPartsToolTips = (jSettings.ShowPartsToolTips != null) ? (bool)jSettings.ShowPartsToolTips : ShowPartsToolTips;

            LocationsDoubleClickAction = (jSettings.LocationsDoubleClickAction != null) ? GetLocationsDoubleClickOption(jSettings.LocationsDoubleClickAction) : LocationsDoubleClickAction;
            FilesDoubleClickAction = (jSettings.FilesDoubleClickAction != null) ? GetLocationsDoubleClickOption(jSettings.FilesDoubleClickAction) : FilesDoubleClickAction;
            PartsDoubleClickAction = (jSettings.PartsDoubleClickAction != null) ? GetPartsDoubleClickOption(jSettings.PartsDoubleClickAction) : PartsDoubleClickAction;

            CodeSnippetsFileName = !String.IsNullOrEmpty(jSettings.CodeSnippetsFileName) ? jSettings.CodeSnippetsFileName : CodeSnippetsFileName;
            ScratchPadFileName = !String.IsNullOrEmpty(jSettings.ScratchPadFileName) ? jSettings.ScratchPadFileName : ScratchPadFileName;
            DefaultCmdStartPath = !String.IsNullOrEmpty (jSettings.DefaultCmdStartPath) ? jSettings.DefaultCmdStartPath : DefaultCmdStartPath;


            IconsPath = !String.IsNullOrEmpty (jSettings.IconsPath) ? jSettings.IconsPath : IconsPath;

            MonitorClipboard = (jSettings.MonitorClipboard != null) ? (bool)jSettings.MonitorClipboard : MonitorClipboard;

            CommandSingleClickOption = (jSettings.CommandSingleClickOption != null) ? (bool)jSettings.CommandSingleClickOption : CommandSingleClickOption;

        }


        public LocationsDoubleClickActionOption GetLocationsDoubleClickOption(string option)
        {
            if (String.IsNullOrEmpty(option))
                return LocationsDoubleClickActionOption.Unknown;

            try
            {
                LocationsDoubleClickActionOption dco = (LocationsDoubleClickActionOption)Enum.Parse(typeof(LocationsDoubleClickActionOption), option);
                return dco;
            }
            catch
            {
                return LocationsDoubleClickActionOption.Unknown;
            }
        }

        public PartsDoubleClickActionOption GetPartsDoubleClickOption(string option)
        {
            if (String.IsNullOrEmpty(option))
                return PartsDoubleClickActionOption.Unknown;

            try
            {
                PartsDoubleClickActionOption dco = (PartsDoubleClickActionOption)Enum.Parse(typeof(PartsDoubleClickActionOption), option);
                return dco;
            }
            catch
            {
                return PartsDoubleClickActionOption.Unknown;
            }
        }
    }
}
