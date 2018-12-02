using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class Stream
    {
        public string Name { get; set; }
        public string IconName { get; set; }
        public string FolderName { get; set; }
        public string RepositoryRoot { get; set; }
        public bool Enabled { get; set; }
        public string Description { get; set; }
        public string PowerPlatformVersion { get; set; }
        public string ECFrameworkVersion { get; set; }
        public string MergeToStream { get; set; }
        public bool? Debug { get; set; }

        //public string MappedDrive { get; set; }

        public Stream(string name)
        {
            Name = name;
            FolderName = Name.ToUpper();
            IconName = Name;
            Description = String.Empty;
            Enabled = true;
        }

        public void UpdateFromJson(jsonStream jStream)
        {
            if ((jStream == null) || String.IsNullOrEmpty(jStream.Name))
                return;

            IconName = !String.IsNullOrEmpty(jStream.IconName) ? jStream.IconName : IconName;
            FolderName = !String.IsNullOrEmpty(jStream.FolderName) ? jStream.FolderName : FolderName;
            RepositoryRoot = !String.IsNullOrEmpty(jStream.RepositoryRoot) ? jStream.RepositoryRoot : RepositoryRoot;
            Enabled = (jStream.Enabled != null) ? (bool)jStream.Enabled : Enabled;
            Description = !String.IsNullOrEmpty(jStream.Description) ? jStream.Description : Description;
            PowerPlatformVersion = !String.IsNullOrEmpty(jStream.PowerPlatformVersion) ? jStream.PowerPlatformVersion : PowerPlatformVersion;
            ECFrameworkVersion = !String.IsNullOrEmpty(jStream.ECFrameworkVersion) ? jStream.ECFrameworkVersion : ECFrameworkVersion;
            MergeToStream = !String.IsNullOrEmpty(jStream.MergeToStream) ? jStream.MergeToStream : MergeToStream;
            Debug = (jStream.Debug != null) ? (bool)jStream.Debug : Debug;


        }

        public override string ToString()
        {
            //if (!String.IsNullOrEmpty(MappedDrive))
            //    return String.Format("{0} ({1})", Name, MappedDrive);
            if (!String.IsNullOrEmpty(FolderName))
                return String.Format("{0} ({1})", Name, FolderName);
            return Name;
        }

    }
}
