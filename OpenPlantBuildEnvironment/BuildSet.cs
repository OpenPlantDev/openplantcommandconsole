using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class BuildSet
    {
        public string Name { get; set; }
        public IList<string> PartNames { get; set; }
        public bool Enabled { get; set; }

        public BuildSet (string name)
        {
            Name = name;
            PartNames = new List<string>();
            Enabled = true;
        }

        public void UpdateFromJson(jsonBuildSet jBuildSet)
        {
            if (jBuildSet == null)
                return;

            PartNames = (jBuildSet.PartNames != null) ? jBuildSet.PartNames : PartNames;
            Enabled = (jBuildSet.Enabled != null) ? (bool)jBuildSet.Enabled : Enabled;
        }
    }
}
