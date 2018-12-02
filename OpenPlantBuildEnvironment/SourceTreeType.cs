using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class SourceTreeType
    {
        public string Name { get; set; }
        public string FolderName { get; set; }
        public string Description { get; set; }
        public string PowerPlatformVersion { get; set; }
        public string BackgroundColor { get; set; }
        public string ForegroundColor { get; set; }

        public SourceTreeType(string name)
        {
            Name = name;
            FolderName = Name.ToUpper();
        }

        public override string ToString()
        {
            return !String.IsNullOrEmpty(Description) ? Description : Name;
        }

    }
}
