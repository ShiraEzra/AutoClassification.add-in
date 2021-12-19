using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    class FunctionsIDontNeedRightNow
    {

        /// <summary>
        /// function that add "toAdd" list to "dest" list
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="toAdd"></param>
        public void AddRangeToList(List<string> dest, List<string> toAdd)
        {
            dest.AddRange(toAdd);
        }

        /// <summary>
        /// Removes characters and spaces from the content.
        /// </summary>
        /// <param name="sentence">content</param>
        /// <returns></returns>
        public string[] RemovingIrrelevantCharacters(string sentence)
        {
            string result = Regex.Replace(sentence, @"[!-@, [-`, {-~]", " "); // delete every char that suitable to the condition.
            char[] separators = new char[] { ' ', '\n', '\t', '\r' };
            string[] wordsSentence = result.Split(separators);     //take out the separators.
            //wordsSentence= wordsSentence.Where(w => w.Length > 1).ToArray(); //remove words with 1 character (=not words);
            //return ConnectingArrayItemsToSentence(wordsSentence);      //return the sentence with out IrrelevantCharacters.
            return wordsSentence.Where(w => w.Length > 1).ToArray();
        }

        /// <summary>
        /// connecting array items to one sentence, every item is word.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public string ConnectingArrayItemsToSentence(string[] arr)
        {
            string str = "";
            foreach (string item in arr)
                str += item + " ";
            return str;
        }
    }
}
