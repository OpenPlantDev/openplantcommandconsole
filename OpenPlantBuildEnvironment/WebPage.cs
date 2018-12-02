using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class WebPage
    {
        public string  Name { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
        public bool Enabled { get; set; }

        public WebPage(string name)
        {
            Name = name;
        }

        public void UpdateFromJson(jsonWebPage jWebPage)
        {
            if ((jWebPage == null) || String.IsNullOrEmpty(jWebPage.Name))
                return;

            Label = !String.IsNullOrEmpty(jWebPage.Label) ? jWebPage.Label : Label;
            Url = !String.IsNullOrEmpty(jWebPage.Url) ? jWebPage.Url : Url;
            Enabled = (jWebPage.Enabled != null) ? (bool)jWebPage.Enabled : Enabled;


        }

    }
}
