using System;
using System.Collections.Generic;

namespace tries
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();
            trie.Add("word");
            trie.Add("whiskey");
            trie.Add("world");
            // Console.WriteLine(trie.Contains("word"));
            // Console.WriteLine(trie.Contains("Word"));
            // Console.WriteLine(trie.Contains("Cat"));
            // Console.WriteLine(trie.Contains("work"));
            // Console.WriteLine(trie.Contains("whiskey"));
            // Console.WriteLine(trie.Contains("World"));
            // Console.WriteLine(trie.Contains("wor"));
            trie.Autocomplete("wor");
        }
    }

    public class TrieNode
    {
        public string Value;
        public int Level;
        public bool IsWord;
        public List<TrieNode> Nexts;

        public TrieNode(string val,int lvl)
        {
            Value = val;
            Level = lvl;
            IsWord = false;
            Nexts = new List<TrieNode>();
        }
    }

    public class Trie
    {
        public static TrieNode root;

        public Trie()
        {
            root = new TrieNode("",0);
        }

        public void Add(string word)
        {
            word = word.ToLower();
            TrieNode runner = root;
            int lvl = 1;
            foreach (char letter in word)
            {
                bool inNexts = false;
                foreach (TrieNode node in runner.Nexts)
                {
                    if (node.Value == letter.ToString())
                    {
                        inNexts = true;
                    } 
                }
                if (!inNexts)
                {
                    runner.Nexts.Add(new TrieNode(letter.ToString(),lvl));
                    lvl++;
                }
                runner = runner.Nexts.Find(x => x.Value == letter.ToString());
            }
            runner.IsWord = true;
        }

        static TrieNode EndRunner(string str)
        {
            str = str.ToLower();
            TrieNode runner = root;
            int idx = 0;
            while (idx < str.Length)
            {
                bool fail = true;
                foreach (TrieNode node in runner.Nexts)
                {
                    if (node.Value == str[idx].ToString())
                    {
                        runner = runner.Nexts.Find(x => x.Value == str[idx].ToString());
                        fail = false;
                        break;
                    }
                }
                //the following conditional statement is a fast fail that stops the method from continuing to iterate through "str" immediately after no matching node is found
                //without this fast fail the method would keep iterating through "str" until it gets to the end of the string, running the foreach loop every time
                if (fail)
                {
                    break;
                }
                else
                {
                    idx++;
                }
            }
            return runner;
        }

        public bool Contains(string word)
        {
            return EndRunner(word).IsWord;
        }

        public List<string> Autocomplete(string prefix)
        {
            TrieNode runner = EndRunner(prefix);
            if (prefix.Length > runner.Level)
            {
                Console.WriteLine($"No words starting with '{prefix}' found.");
                return new List<string>();
            }
            else
            {
                string word = prefix;
                List<string> words = new List<string>();
                foreach (TrieNode node in runner.Nexts)
                {
                    Console.WriteLine(runner.Nexts.Count);
                    while (!runner.IsWord)
                    {
                        word += node.Value;
                        runner = node;
                        Console.WriteLine(runner.Value);
                    }
                    Console.WriteLine(word);
                    words.Add(word);
                }
                return words;
            }
        }
    }
}
