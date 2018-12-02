using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class ApplicationOverride
    {
        public string StreamName { get; set; }
        public string ApplicationName { get; set; }
        public string PowerPlatformVersion { get; set; }
        public string ECFrameworkVersion { get; set; }
        public string BuildStrategy { get; set; }
        public bool? Debug { get; set; }

        public ApplicationOverride(string streamName, string appName)
        {
            StreamName = streamName;
            ApplicationName = appName;

        }

    }
}
