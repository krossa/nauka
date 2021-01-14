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
            List<string> wordsList = new List<string>{
            "a", "b", "ba", "bca", "bda", "bdca"
        };
            int a = longest_chain(wordsList);
            Console.WriteLine(a);
        }


        static int longest_chain(List<string> w)
        {
            if (w is null || w.Count < 1)
            {
                return 0;
            }

            var maxChainLen = 0;

            var words = new HashSet<string>(w);
            var wordToLongestChain = new Dictionary<string, int>();

            foreach (var word in w)
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
            int curChainLen = 0;

            for (int i = 0; i < word.Length; i++)
            {
                String nextWord = word.Substring(0, i) + word.Substring(i + 1);
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

        // public static int longestChain(List<string> words)
        // {
        //     var max = int.MinValue;
        //     foreach (var word in words)
        //     {
        //         var c = CountWord(word, words);
        //         if (max < c)
        //         {
        //             max = c;
        //         }
        //     }
        //     return max;
        // }

        // static int CountWord(String word, List<String> allWords)
        //         {
        //             if (word.Length == 1)
        //                 return 1;

        //             Stack<String> wordsStack = new Stack<String>();
        //             wordsStack.Push(word);

        //             // start and end indices which hold character is dropped from the current word
        //             int startIndex = 0;
        //             int endIndex = 1;

        //             while (wordsStack.Any())
        //             {
        //                 String currentWord = wordsStack.Peek();

        //                 if ( endIndex >= currentWord.Length)
        //                 {
        //                     break;
        //                 }

        //                 if (allWords.Contains(currentWord))
        //                 {
        //                     StringBuilder wordBuilder = new StringBuilder(currentWord);
        //                     wordBuilder.Remove(startIndex, endIndex);
        //                     wordsStack.Push(wordBuilder.ToString());
        //                 }
        //                 else
        //                 {
        //                     wordsStack.Pop();
        //                     startIndex++;
        //                     endIndex++;
        //                 }
        //             }

        //             return wordsStack.Count;
        //         }

        // public static int CountWord(string word, List<string> words)
        // {
        //     if (word.Length == 1)
        //         return 1;

        //     var stack = new Stack<string>();
        //     stack.Push(word);
        //     int start = 0; int end = 1;
        //     while (stack.Count > 0)
        //     {
        //         foreach (var a in stack)
        //         {
        //             Console.Write(a); Console.Write(" ");
        //         }
        //         Console.Write(stack.Count);
        //         string tempWord = stack.Peek();

        //         if (end > tempWord.Length)
        //         {
        //             if (!words.Contains(tempWord))
        //             {
        //                 stack.Pop();
        //             }
        //             Console.WriteLine("--------");
        //             break;
        //         }

        //         if (words.Contains(tempWord))
        //         {
        //             StringBuilder sb = new StringBuilder(tempWord);
        //             sb.Remove(start, 1);
        //             stack.Push(sb.ToString());
        //         }
        //         else
        //         {
        //             stack.Pop();
        //             start++;
        //             end++;
        //         }
        //     }

        //     return stack.Count;
        // }
    }
}

// public class Author
// {
//     public int Id { get; set; }
//     public string Username { get; set; }
//     public int MyProperty { get; set; }
//     public string About { get; set; }
//     public int Submitted { get; set; }
//     [JsonProperty("updated_at")]
//     public DateTime UpdatedAt { get; set; }
//     [JsonProperty("submission_count")]
//     public int SubmissionCount { get; set; }
//     [JsonProperty("comment_count")]
//     public int CommentCount { get; set; }
//     [JsonProperty("created_at")]
//     public int CreatedAt { get; set; }
// }

// public class ClientRsponse
// {
//     public int Page { get; set; }
//     public int Per_Page { get; set; }
//     public int Total { get; set; }
//     public int Total_Pages { get; set; }
//     public List<Author> Data { get; set; }
// }
