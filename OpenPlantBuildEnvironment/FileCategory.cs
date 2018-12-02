using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class FileCategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string App { get; set; }
        public string Path { get; set; }
        public IList<File> Files { get; set; }

        public FileCategory(string name)
        {
            Name = name;
            Files = new List<File>();
        }

        public void UpdateFromJson(jsonFileCategory jFileCategory)
        {
            if (jFileCategory == null)
                return;

            Description = !String.IsNullOrEmpty(jFileCategory.Description) ? jFileCategory.Description : Description;

            Path = !String.IsNullOrEmpty(jFileCategory.Path) ? jFileCategory.Path : Path;
            App = !String.IsNullOrEmpty(jFileCategory.App) ? jFileCategory.App : App;
            if (jFileCategory.Files != null)
            {
                foreach (jsonFile jFile in jFileCategory.Files)
                {
                    string path = !String.IsNullOrEmpty(jFile.Path) ? jFile.Path : Path;
                    if (!String.IsNullOrEmpty(jFile.Name) && !String.IsNullOrEmpty(path))
                    {
                        File file = new File(jFile.Name, path);
                        file.UpdateFromJson(jFile);
                        Files.Add(file);
                    }
                }
            }
        }

        public override string ToString()
        {
            return !String.IsNullOrEmpty(Description) ? Description : Name;
        }

    }
}
