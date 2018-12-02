using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class TextEditorSession
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string App { get; set; }
        public bool Enabled { get; set; }

        public TextEditorSession(string name)
        {
            Name = name;
            Description = name;
            Enabled = true;
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

        public void UpdateFromJson(jsonTextEditorSession jSession)
        {
            Path = !String.IsNullOrEmpty(jSession.Path) ? jSession.Path : Path;
            Description = !String.IsNullOrEmpty(jSession.Description) ? jSession.Description : Description;
            App = !String.IsNullOrEmpty(jSession.App) ? jSession.App : App;
            Enabled = (jSession.Enabled != null) ? (bool)jSession.Enabled : Enabled;
        }



    }
}
