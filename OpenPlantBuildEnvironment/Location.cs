using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class Location
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public Location(string name, string path)
        {
            Name = name;
            Path = path;
        }

        public string ExpandedPath
        {
            get
            {
                if (String.IsNullOrEmpty(Path))
                    return String.Empty;

                return (System.Environment.ExpandEnvironmentVariables(Path));
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }

}
