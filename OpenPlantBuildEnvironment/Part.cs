using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class Part
    {
        public string PartName { get; set; }
        public string Description { get; set; }
        public string SubFolder { get; set; }
        public string App { get; set; }

        public Part(string name,  string desc = null)
        {
            PartName = name;
            Description = !String.IsNullOrEmpty(desc) ? desc : PartName;
        }
        public bool OverrideBuildPartCheck { get; set; }

        public override string ToString()
        {
            return Description;
        }
        public string Pieces
            {
            get
                {
                return string.Format ("{0},{1},{2},{3}", PartName, Description, SubFolder, OverrideBuildPartCheck);
                }
            }

        public void UpdateFromJson(jsonPart jPart)
        {
            if (jPart == null)
                return;

            Description = !String.IsNullOrEmpty(jPart.Description) ? jPart.Description : Description;
            SubFolder = !String.IsNullOrEmpty(jPart.SubFolder) ? jPart.SubFolder : SubFolder;
            App = !String.IsNullOrEmpty(jPart.App) ? jPart.App : App;
        }
    }
}
