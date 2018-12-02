using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class File
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public string App { get; set; }

        public File(string name, string path)
        {
            Name = name;
            Path = path;
        }

        public string ExpandedPath
        {
            get
            {
                if (String.IsNullOrEmpty(Path))
                    Path = String.Empty;

                return (System.Environment.ExpandEnvironmentVariables(Path));
            }
        }
        public string ExpandedFileName
        {
            get
            {
                if (String.IsNullOrEmpty(Path))
                    Path = String.Empty;

                if (String.IsNullOrEmpty(Name))
                    return null;

                string fullpath = System.IO.Path.Combine(Path, Name);

                return (System.Environment.ExpandEnvironmentVariables(fullpath));
            }
        }

        public void UpdateFromJson (jsonFile jFile)
        {
            if (jFile == null)
                return;

            Description = jFile.Description;
            App = jFile.App;

        }


        public override string ToString()
        {
            if (!String.IsNullOrEmpty(Description))
                return Description;

            string fullPath = ExpandedFileName;

            if (String.IsNullOrEmpty(fullPath))
                return String.Empty;

            return System.IO.Path.GetFileName(fullPath);
        }
    }

}
