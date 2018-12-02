using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlantBuildEnvironment
{
    public class TextEditor
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string SingleFileParams { get; set; }
        public string MultipleFileParams { get; set; }

        public TextEditor(string name)
        {
            Name = name;

        }

        public void UpdateFromJson(jsonTextEditor jTextEditor)
        {
            if (jTextEditor == null)
                return;

            Name = !String.IsNullOrEmpty(jTextEditor.Name) ? jTextEditor.Name : Name;
            Path = !String.IsNullOrEmpty(jTextEditor.Path) ? jTextEditor.Path : Path;
            SingleFileParams = !String.IsNullOrEmpty(jTextEditor.SingleFileParams) ? jTextEditor.SingleFileParams : SingleFileParams;
            MultipleFileParams = !String.IsNullOrEmpty(jTextEditor.MultipleFileParams) ? jTextEditor.MultipleFileParams : MultipleFileParams;
        }

        public void OpenSingleFile(string fileName)
        {
            if(String.IsNullOrEmpty(Path) || !System.IO.File.Exists(Path) || String.IsNullOrEmpty(fileName))
                return;

            string args = !String.IsNullOrEmpty(SingleFileParams) ? SingleFileParams : "";
            args = string.Format("{0} \"{1}\"", args, fileName);
            System.Diagnostics.Process.Start(Path, args);
        }

        public void OpenMultipleFiles(IList<string> fileNames)
        {
            if(String.IsNullOrEmpty(Path) || !System.IO.File.Exists(Path) || (fileNames == null) || (fileNames.Count == 0))
                return;

            string files = !String.IsNullOrEmpty(MultipleFileParams) ? MultipleFileParams : "";
            foreach (string fileName in fileNames)
            {
                files = string.Format("{0} \"{1}\"", files, fileName);
            }
            System.Diagnostics.Process.Start(Path, files);
        }

    }
}
