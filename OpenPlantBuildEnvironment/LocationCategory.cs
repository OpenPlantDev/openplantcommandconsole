using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class LocationCategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Location> Locations { get; set; }

        public LocationCategory(string name)
        {
            Name = name;
            Locations = new List<Location>();
        }

        public void UpdateFromJson(jsonLocationCategory jLocCategory)
        {
            if (jLocCategory == null)
                return;

            Description = !String.IsNullOrEmpty(jLocCategory.Description) ? jLocCategory.Description : Description;
            if (jLocCategory.Locations != null)
            {
                foreach (jsonLocation jLoc in jLocCategory.Locations)
                {
                    if (!String.IsNullOrEmpty(jLoc.Name) && !String.IsNullOrEmpty(jLoc.Path))
                    {
                        Location loc = new Location(jLoc.Name, jLoc.Path);
                        Locations.Add(loc);
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
