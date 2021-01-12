using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RedGate
{
    class WordFrequency 
    {
        public Dictionary<string, int> WordsDict = new Dictionary<string, int>();//dictionary to hold the words
        public Dictionary<string, int> OrderedDict = new Dictionary<string, int>(); //dictionary to hold the ordered words
        string create_text;
        char[] separator = new char[] { ' ', ',', '\n','\r', ';', '-', '.' }; //will eliminate connectors
        

        public WordFrequency(SimpleCharacterReader character)
        {
            DoFrequencyCount(character); 
        }

        public void DoFrequencyCount(SimpleCharacterReader character)
        {
            try
            {
                while (true)
                {
                    char letter;
                    letter = character.GetNextChar(); //read each letter from string
                    create_text = create_text + letter; //add letters together
                }
            }
            catch (System.IO.EndOfStreamException)
            {
                PopulatingDictionary(WordsDict); //populate dictionary
                SortedDictionary(WordsDict); //sort dictionary
            }
        }

        public Dictionary<string,int> PopulatingDictionary(Dictionary<string, int> WordsDict)
        {
            var words = create_text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //split text where separator appears, creating words
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != "")//if string not null
                {
                    if (WordsDict.ContainsKey(words[i].ToLower()))//if the dictionary already has the specified word
                    {
                        WordsDict[words[i].ToLower()] = WordsDict[words[i].ToLower()] + 1; //add + 1 to count 
                    }
                    else
                    {
                        WordsDict.Add(words[i].ToLower(), 1); //else, add word to dictionary with starting value = 1
                    }

                }
            }
            return WordsDict;
        }

        public void SortedDictionary(Dictionary<string, int> WordsDict)
        {
            
            var list = WordsDict.Keys.ToList(); //convert dictionary to list
            list.Sort(); //sot list alphabetically
            
            foreach (var entry in list) //for each element in the list
            {
                OrderedDict.Add(entry, WordsDict[entry]); //add it to the now alphabetically ordered dictionary
            }
            var Log = from entry in OrderedDict orderby entry.Value descending select entry; //order by descending counter value

            foreach (var element in Log)
            {
                Console.WriteLine("{0} - {1}", element.Key, element.Value);//display words and couters
            }
        }

        
    }
}
