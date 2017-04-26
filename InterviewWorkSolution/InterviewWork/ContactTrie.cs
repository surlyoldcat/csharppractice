using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewWork
{
    public class ContactTrie
    {
        Dictionary<string, TrieNode> Nodes { get; set; }

        public ContactTrie()
        {
            Nodes = new Dictionary<string, TrieNode>();
        }

        public void Add(string contact)
        {
            string firstletter = contact.Substring(0, 1);
            if (Nodes.ContainsKey(firstletter))
            {
                Nodes[firstletter].Add(contact.Substring(1));
            }
            else
            {
                Nodes.Add(firstletter, new TrieNode(contact, null));
            }
        }

        public List<TrieNode> Find(string value)
        {
            List<TrieNode> result = new List<TrieNode>();
            if (String.IsNullOrEmpty(value) && null != Nodes)
            {
                foreach(var node in Nodes.Values)
                {
                    result.AddRange(node.Find(String.Empty));
                }
            }
            else
            {
                string firstletter = value.Substring(0, 1);
                if (Nodes.ContainsKey(firstletter))
                {
                    string searchterm = value.Length == 1 ? String.Empty
                        : value.Substring(1);
                    result.AddRange(Nodes[firstletter].Find(searchterm));
                }
            }            
            return result;   
        }

        public void Print()
        {
            Console.WriteLine("Trie Nodes:");
            foreach (var k in Nodes)
            {
                Console.WriteLine("Key: " + k.Key);
                k.Value.Print();
            }

        }
    }

    public class TrieNode
    {
        public Dictionary<string, TrieNode> Children { get; private set; }
        public string Value { get; private set; }
        public bool IsWord { get; private set; }
        public TrieNode Parent { get; private set; }

        public TrieNode(string s, TrieNode parent)
        {
            Value = s.Substring(0, 1);
            Parent = parent;
            Children = new Dictionary<string, TrieNode>();
            if (s.Length == 1)
            {
                IsWord = true;
            }
            else
            {
                Add(s.Substring(1));
                IsWord = false;
            }
        }

        public void Add(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                IsWord = true;
                return;
            }

            string firstletter = s.Substring(0, 1);
            string remainder = s.Length > 1 ? s.Substring(1) : null;
            if (Children.ContainsKey(firstletter))
            {
                Children[firstletter].Add(remainder);
            }
            else
            {
                Children.Add(firstletter, new TrieNode(s, this));
            }
        }

        public List<TrieNode> Find(string searchterm)
        {
            /*
             * 1. search term should already have the letter that matches
             * this node removed. if this node is "g" and we're searching for
             * "guitar", when we get here the input string should be "uitar"
             * 2. given 1, if the input string has length > 0, we need to
             * keep digging. grab the first letter, see if we have a matching
             * child, and pass it the new search term ("itar" in this case)
             * 3. if the input string is empty, this node represents the end
             * of the search term. for "guitar", this node would be "r". So
             * we return this node if it is a word, and any child nodes (or
             * descendants) that are words.
             *  
             * 
             */
            List<TrieNode> results = new List<TrieNode>();
            if (null != searchterm)
            {


                if (searchterm.Length > 0)
                {
                    string firstletter = searchterm.Substring(0, 1);
                    if (Children.ContainsKey(firstletter))
                    {
                        string newsearchterm = searchterm.Length == 1 ? String.Empty
                            : searchterm.Substring(1);
                        results.AddRange(Children[firstletter].Find(newsearchterm));
                    }
                }
                else
                {

                    results.AddRange(GetWordsFromTree(this));
                }
            }
            return results;
        }

        static List<TrieNode> GetWordsFromTree(TrieNode node)
        {
            List<TrieNode> results = new List<TrieNode>();
            if (node.IsWord)
            {
                results.Add(node);
            }
            if (null != node.Children && node.Children.Count > 0)
            {
                foreach (var child in node.Children.Values)
                {
                    results.AddRange(GetWordsFromTree(child));
                }
            }
            return results;
        }

        public void Print()
        {
            string indents = GetIndents(this);
            Console.WriteLine(String.Format("{0}Value: {1}", indents, Value));
            Console.WriteLine(String.Format("{0}IsWord: {1}", indents, IsWord));
            Console.WriteLine(indents + "Children:");
            foreach(var k in Children)
            {
                k.Value.Print();
            }
        }

        static string GetIndents(TrieNode n)
        {
            TrieNode thisNode = n;
            const string indent = "--";
            StringBuilder sb = new StringBuilder(indent);
            while(null != thisNode.Parent)
            {
                sb.Append(indent);
                thisNode = thisNode.Parent;
            }
            return sb.ToString();

        }
    }

    
}
