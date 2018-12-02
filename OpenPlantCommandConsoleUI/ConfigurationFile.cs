using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantCommandConsole
{
    public class ConfigurationFile
    {
        public string FileName { get; set; }

        public ConfigurationFile(string fileName)
        {
            FileName = fileName;
        }

        public override string ToString()
        {
            return System.IO.Path.GetFileNameWithoutExtension(FileName);
        }
    }
}
