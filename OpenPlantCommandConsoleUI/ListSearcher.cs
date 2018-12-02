using OpenPlantBuildEnvironment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenPlantCommandConsole
    {
    public class ListSearcher
        {

        private MainForm m_mainForm = null;
        private List<TreeNode> m_nodes = null;
        private int m_searchNodeCount = 0;


        public ListSearcher (MainForm mainForm)
            {
            m_mainForm = mainForm;
            }

        public void ResetNodes ()
            {
            m_nodes = null;
            }

        public void DoIndexSearch ()
            {
            if(m_nodes == null || m_nodes.Count <= 1)
                SearchTrees ();
            else
                DoNextSearch ();
            }

        public void SearchTrees()
            {
            string searchText = m_mainForm.ComboBoxSearchCtrl.Text;
            var nodes = FlattenTree ()
                .Where (n => n.Text.StartsWith (searchText, StringComparison.InvariantCultureIgnoreCase))
                .Distinct ().ToList ();

            var endsNodes = FlattenTree ().Where (n => n.Text.EndsWith (searchText, StringComparison.InvariantCultureIgnoreCase)).Distinct().ToList ();
            if(endsNodes.Count > 0)
                nodes.AddRange (endsNodes);

            var containsnodes = FlattenTree ().Where (n => n.Text.Contains (searchText)).Distinct ().ToList ();
            if(containsnodes.Count > 0)
                nodes.AddRange (containsnodes);

            var indexOfnodes = FlattenTree ().Where (n => n.Text.IndexOf(searchText) >= 0).Distinct ().ToList ();
            if(indexOfnodes.Count > 0)
                nodes.AddRange (indexOfnodes);

            if(nodes.Count == 0)
                {
                var snodes = FlattenTree ().ToList ();
                foreach(TreeNode n in snodes)
                    {
                    Part p = n.Tag as Part;
                    if(p != null)
                        {
                        if(p.Description.StartsWith (searchText, StringComparison.InvariantCultureIgnoreCase) ||
                            p.Description.EndsWith (searchText, StringComparison.InvariantCultureIgnoreCase) ||
                            p.Description.LastIndexOf(searchText, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                            p.PartName.Equals (searchText, StringComparison.InvariantCultureIgnoreCase) ||
                            p.PartName.StartsWith (searchText, StringComparison.InvariantCultureIgnoreCase) ||
                            p.PartName.LastIndexOf (searchText, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                            p.PartName.EndsWith (searchText, StringComparison.InvariantCultureIgnoreCase)
                            )
                            nodes.Add (n);
                        }
                    }
                }

            if(nodes.Count == 1)
                {
                GetCurrentTree.SelectedNode = nodes[0];
                GetCurrentTree.Focus ();
                if(!m_mainForm.ComboBoxSearchCtrl.Items.Contains (searchText))
                    m_mainForm.ComboBoxSearchCtrl.Items.Add (searchText);
                m_nodes = null;
                }
            else
                {
                nodes = nodes.Distinct ().ToList();
                if(nodes.Count <= 0)
                    return;
                GetCurrentTree.SelectedNode = nodes[0];
                GetCurrentTree.Focus ();
                if(!m_mainForm.ComboBoxSearchCtrl.Items.Contains (searchText))
                    m_mainForm.ComboBoxSearchCtrl.Items.Add (searchText);
                m_nodes = nodes;
                }
            }

        public void DoNextSearch()
            {
            if(m_nodes == null)
                return;
            if(m_searchNodeCount >= m_nodes.Count)
                m_searchNodeCount = 0;
            TreeNode currentNode = GetCurrentTree.SelectedNode;
            TreeNode indexNode = m_nodes[m_searchNodeCount];

            if(currentNode != null && currentNode.Equals (indexNode) &&
                m_nodes.Count < m_searchNodeCount + 1)
                indexNode = m_nodes[m_searchNodeCount + 1];

            GetCurrentTree.SelectedNode = indexNode;
            GetCurrentTree.Focus ();
            m_searchNodeCount++;
            }


        private void buttonSearch_Click(object sender, EventArgs e)
            {
            if(m_nodes == null)
                SearchTrees ();
            else
                DoNextSearch ();
            }

        private TreeView GetCurrentTree
            {
            get
                {
                switch(m_mainForm.TabListsCtrl.SelectedIndex)
                    {
                    case 0:
                        return m_mainForm.PartsTreeViewCtrl;
                    case 1:
                        return m_mainForm.LocationsTreeViewCtrl;
                    case 2:
                        return m_mainForm.FilesTreeViewCtrl;
                    }
                return m_mainForm.PartsTreeViewCtrl;
                }
            }

        private IEnumerable<TreeNode> FlattenTree()
            {
            return FlattenTree (GetCurrentTree.Nodes);
            }

        private IEnumerable<TreeNode> FlattenTree(TreeNodeCollection coll)
            {
            return coll.Cast<TreeNode> ()
                        .Concat (coll.Cast<TreeNode> ()
                                    .SelectMany (x => FlattenTree (x.Nodes)));
            }
        }
    }
