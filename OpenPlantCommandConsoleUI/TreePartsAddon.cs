using OpenPlantBuildEnvironment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenPlantCommandConsole
    {
    public class TreePartsAddon
        {

        private TreeView m_partsTreeView = null;
        private HashSet<string> m_excludeParts = null;

        public TreePartsAddon(TreeView tv)
            {
            m_partsTreeView = tv;
            }
        public bool OverrideBuildPartCheck(TreeNode selectedNode)
            {
            Part part = selectedNode.Tag as Part;
            if(part == null)
                return false;

            return part.OverrideBuildPartCheck;
            }

        public bool OverrideBuildPartCheck(ListViewItem selectedNode)
            {
            Part part = selectedNode.Tag as Part;
            if(part == null)
                return false;

            return part.OverrideBuildPartCheck;
            }

        public void AddTreePartsFromPartsFileRead(SourceTree sourceTree)
            {
            //This should be in the main source folder :C:\CONNECT\Current\CurrDev\OPSE\src
            //bb debug --partbuildcmds > buildparts.txt

            string fileName = System.IO.Path.Combine (sourceTree.SourceFolder, "buildparts.txt");
            if(!System.IO.File.Exists (fileName))
                return;

            const Int32 BufferSize = 128;
            using(var fileStream = System.IO.File.OpenRead (fileName))
            using(var streamReader = new System.IO.StreamReader (fileStream, Encoding.UTF8, true, BufferSize))
                {
                String line;
                while((line = streamReader.ReadLine ()) != null)
                    {
                    if(!line.StartsWith ("bb "))
                        continue;

                    if(ExcludePart (line))
                        continue;

                    string[] splits = line.Split (' ');
                    string header = splits[2];
                    string part = splits[6];
                    Part p = new Part (part);
                    p.Description = part;
                    p.SubFolder = part;
                    TreeNode treeHeader = null;
                    TreeNode treePart = null;

                    string treePath = header;
                    //
                    if(m_partsTreeView.Nodes.ContainsKey (header))
                        {
                        treeHeader = m_partsTreeView.Nodes[header];

                        if(!DoesParentContainPart (treeHeader, part))
                            {
                            treePart = treeHeader.Nodes.Add (part, part);
                            p.OverrideBuildPartCheck = true;
                            treePart.Tag = p;
                            }
                        }
                    else
                        {
                        treeHeader = m_partsTreeView.Nodes.Add (header, header);
                        Repository repo = new Repository (header, "plant/" + header, treePath);
                        treeHeader.Tag = repo;
                        treePart = treeHeader.Nodes.Add (part, part);
                        treePart.Tag = p;
                        }
                    }
                }
            m_partsTreeView.Sort ();
            }

        private bool DoesParentContainPart(TreeNode parent, string PartName)
            {
            if(parent.Nodes.ContainsKey (PartName))
                return true;

            foreach(TreeNode part in parent.Nodes)
                {
                Part p = part.Tag as Part;
                if(p == null)
                    continue;
                if(p.PartName.Equals (PartName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
                }
            return false;
            }
        private bool ExcludePart(string part)
            {
            if(m_excludeParts == null)
                {
                m_excludeParts = new HashSet<string> ();
                m_excludeParts.Add ("Bin-IronPython");
                m_excludeParts.Add ("Bin-JsonNet");
                m_excludeParts.Add ("BoostHeaders");
                m_excludeParts.Add ("BoostHeaders_1.57");
                m_excludeParts.Add ("DgnDomains-Plant");
                m_excludeParts.Add ("Mergemodule-Microsoft_VC_");
                m_excludeParts.Add ("Miscdev");
                m_excludeParts.Add ("PowerPlatform");
                m_excludeParts.Add ("SdkDistribution");
                m_excludeParts.Add ("TranskitTools");
                m_excludeParts.Add ("Realdwg");
                }

            foreach(string p in m_excludeParts)
                {
                if(part.Contains (p))
                    return true;
                }
            return false;
            }
        }

public class NoDoubleClickAutoCheckListview : ListView
{
    private bool checkFromDoubleClick = false;

    protected override void OnItemCheck(ItemCheckEventArgs ice)
    {
        if (this.checkFromDoubleClick)
        {
            ice.NewValue = ice.CurrentValue;
            this.checkFromDoubleClick = false;
        }
        else
            base.OnItemCheck(ice);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        // Is this a double-click?
        if ((e.Button == MouseButtons.Left) && (e.Clicks > 1)) {
            this.checkFromDoubleClick = true;
        }
        base.OnMouseDown(e);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        this.checkFromDoubleClick = false;
        base.OnKeyDown(e);
    }
}
    }
