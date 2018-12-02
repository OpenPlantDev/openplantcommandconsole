using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class Repository
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Path { get; set; }
        public string App { get; set; }
        public IList<Part> Parts { get; set; }

        public string ExpandedPath
        {
            get
            {
                if (String.IsNullOrEmpty(Path))
                    return String.Empty;

                return (System.Environment.ExpandEnvironmentVariables(Path));
            }
        }

        public Repository(string name)
        {
            Name = name;
        }

        public Repository(string name, string url, string path)
        {
            Name = name;
            Url = url;
            Path = path;
        }
        
        public void UpdateFromJson(jsonRepository jRepo)
        {
            Url = !String.IsNullOrEmpty(jRepo.Url) ? jRepo.Url : Url;
            Path = !String.IsNullOrEmpty(jRepo.Path) ? jRepo.Path : Path;
            App = !String.IsNullOrEmpty(jRepo.App) ? jRepo.App : App;
            Parts = Parts != null ? Parts : new List<Part>();
            if (jRepo.Parts != null)
            {
                foreach (jsonPart jPart in jRepo.Parts)
                {
                    Part part = Utilities.Instance.FindPart(Parts, jPart.PartName);
                    bool existingPart = (part != null);

                    if(!existingPart)
                       part = new Part(jPart.PartName);
                    part.UpdateFromJson(jPart);

                    if(!existingPart)
                        Parts.Add(part);
                }
            }

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
