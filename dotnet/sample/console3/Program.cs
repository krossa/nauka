using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace console3
{
    public class Program
    {
        public static void Main()
        {
            var wordsList = new List<string>{
            "a", "b", "ba", "bca", "bda", "bdca"
        };
            var a = LongestChain(wordsList);
            Console.WriteLine(a);
        }


        static int LongestChain(List<string> input)
        {
            if (input is null || input.Count < 1)
            {
                return 0;
            }

            var maxChainLen = 0;

            var words = new HashSet<string>(input);
            var wordToLongestChain = new Dictionary<string, int>();

            foreach (var word in input)
            {
                if (maxChainLen > word.Length)
                    continue;

                var curChainLen = FindChainLenght(word, words, wordToLongestChain) + 1;
                wordToLongestChain[word] = curChainLen;
                maxChainLen = Math.Max(maxChainLen, curChainLen);
            }
            return maxChainLen;
        }

        static int FindChainLenght(string word, HashSet<string> words, Dictionary<string, int> wordToLongestChain)
        {
            var curChainLen = 0;

            for (var i = 0; i < word.Length; i++)
            {
                var nextWord = word.Substring(0, i) + word.Substring(i + 1);
                if (words.Contains(nextWord))
                {
                    if (wordToLongestChain.ContainsKey(nextWord))
                    {
                        curChainLen = Math.Max(curChainLen, wordToLongestChain[nextWord]);
                    }
                    else
                    {
                        int nextWordChainLen = FindChainLenght(nextWord, words, wordToLongestChain);
                        curChainLen = Math.Max(curChainLen, nextWordChainLen + 1);
                    }
                }
            }

            return curChainLen;
        }

    }
}
