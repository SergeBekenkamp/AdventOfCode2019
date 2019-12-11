using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class December06
    {



        public IEnumerable<(string, string)> GetInput()
        {
            var input = File.ReadAllLines("Input06.txt");

            return input.Select(x => x.Split(")")).Select(x => (x[0], x[1])).ToList();
        }



        public int GetAnswer1()
        {
            var input = this.GetInput();
            var orbits = new Dictionary<string, TreeNode>();
            TreeNode parent = null;

            foreach (var inp in input)
            {
                orbits.TryAdd(inp.Item1, new TreeNode(inp.Item1));
                orbits.TryAdd(inp.Item2, new TreeNode(inp.Item2));

                var node1 = orbits[inp.Item1];
                var node2 = orbits[inp.Item2];
                node1.Add(node2);
            }

            parent = orbits.Values.Where(x => x.Parent == null).FirstOrDefault();


            return parent.CountAll();
        }

        public int GetAnswer2()
        {
            var input = this.GetInput();
            var orbits = new Dictionary<string, TreeNode>();
            TreeNode parent = null;

            foreach (var inp in input)
            {
                orbits.TryAdd(inp.Item1, new TreeNode(inp.Item1));
                orbits.TryAdd(inp.Item2, new TreeNode(inp.Item2));

                var node1 = orbits[inp.Item1];
                var node2 = orbits[inp.Item2];
                node1.Add(node2);
            }

            parent = orbits.Values.Where(x => x.Parent == null).FirstOrDefault();
            var san = orbits["SAN"];
            var you = orbits["YOU"];
            TreeNode.getLCA(parent, parent, san, you, out var ca);
            
            var dist2 = san.GetDistanceToParent(ca);
            var dist1 = you.GetDistanceToParent(ca);

            return dist2 + dist1;
        }

        public class TreeNode : IEnumerable<TreeNode>
        {
            private readonly Dictionary<string, TreeNode> _children = new Dictionary<string, TreeNode>();

            private readonly string _id;
            public TreeNode Parent { get; private set; }


            public string Id
            {
                get => _id; 
            }


            public TreeNode(string id)
            {
                _id = id;
            }

            public TreeNode GetChild(string id)
            {
                return this._children[id];
            }

            public void Add(TreeNode item)
            {
                if (item.Parent != null)
                {
                    item.Parent._children.Remove(item.Id);
                }

                item.Parent = this;
                this._children.Add(item.Id, item);
            }

            public IEnumerator<TreeNode> GetEnumerator()
            {
                return this._children.Values.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            public int Count
            {
                get { return this._children.Count; }
            }

            public int CountAll(int i = 0)
            {
                return i + this._children.Values.Sum(x => x.CountAll(i + 1));
            }

            public TreeNode GetCommonAncestor(string key1, string key2, TreeNode node = null)
            {
                if (node == null) node = this;



                if (node.Any(x => x.Id == key1) && node.Any(x => x.Id == key2))
                {
                    var ancestor = node.Where(x => x.Any(y => y.Id == key1) && x.Any(y => y.Id == key2)).FirstOrDefault();
                    if (ancestor == null) ancestor = node;
                    return node;
                }

                return this;
            }

            public int GetDistanceToParent(TreeNode node, int distance = 0)
            {
                if (this.Parent == node) return distance;
                return this.Parent.GetDistanceToParent(node, distance + 1);
            }

            private static TreeNode lca = null;
            public static bool getLCA(TreeNode node, TreeNode tree, TreeNode u, TreeNode v, out TreeNode outNode)
            {
                outNode = null;

                /* if current node is equal to one of the nodes whose lca 
                   we are finding, then it is a potential candidate for 
                   being the lca.
                 */
                bool self = node == u || node == v ? true : false;


                int count = 0;
                /* recurring for every child. and keeping a count of result
                  of how many times we are getting true.
                 */
                foreach (var child in node._children.Values)
                {
                    TreeNode test = null;
                    if (getLCA(child, tree, u, v, out test))
                    {
                        count++;
                        if (test != null) outNode = test;
                    }
                }

                /* this is the main check, if current node itself is one of 
                   the node whose lca is to be found and its getting true from 
                   any of its child, then surely it is LCA of given nodes.
                   also, if we get true from exactly two sides, this means 
                   that current node is the node after which the path for 
                   both nodes diverge, and hence it is the LCA for given nodes.
                 */
                if (((self && count == 1) || (count == 2)))
                {
                    /* lca will be set only once, as the parent of
                       lca will have the count==2 condition as true,
                       but that is not the correct answer.
                     */
                    if (lca == null)
                    {
                        outNode = node;
                    }
                    return true;
                }
                /* current node will return true only if either the 
                   current node is one of the given nodes, or one of its 
                   children return true for count == 2, we already handled it
                   while setting LCA.
                 */
                return self || count == 1;
            }

        }

    }
}
