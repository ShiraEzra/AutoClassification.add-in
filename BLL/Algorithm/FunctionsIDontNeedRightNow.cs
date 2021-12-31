using HebrewNLP.Morphology;
using HebrewNLP.Names;
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

        /// <summary>
        /// get a dictionary & value, return is key.
        /// </summary>
        /// <param name="word_dictionary"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int FindKeyByValue(Dictionary<int, string> word_dictionary, String value)  
        {
            if (word_dictionary.ContainsValue(value))
            {
                foreach (int key in word_dictionary.Keys)
                {
                    if (word_dictionary[key].Equals(value))
                        return key;
                }
            }
            return -1;
        }

        /// <summary>
        /// Check if the sentence isn't empty
        /// </summary>
        /// <param name="sentence">sentence</param>
        /// <returns>true - if the sentence isn't empty.  false -if the sentence is empty</returns>
        public bool IsTherewordInSentence(string[] sentence)
        {
            if (sentence.Count() == 0)
                return false;
            foreach (var word in sentence)
            {
                if (word != "")
                    return true;
            }
            return false;
        }

        /// <summary>
        /// A function that removes prepositions and belonging from the list. (All irrelevant words will be removed from the email request)
        /// </summary>
        /// <param name="words_lst">words list</param>
        /// <returns>List of words without irrelevant words</returns>
        public List<string> RemoveIrrelevantWords(List<string> words_lst)
        {
            words_lst.RemoveAll(item => allWords.ContainsKey(item) && allWords[item].ID_wordType == 2);
            return words_lst;
            //problemmm
            //המילה אייטם מנוקדת ועם אותיות סופיות רגילות
            //איך אני יכולה לבדוק האם קיים לי ב-דטה בייס  מילה כזו ללא ניקוד ועם אותיות מנצפך.

            //bool result = root.Equals(root2, StringComparison.OrdinalIgnoreCase);
        }


        /// <summary>
        /// The function removes the list list names from the sentence list.
        /// </summary>
        /// <param name="sentence">sentence list</param>
        /// <param name="names">names list</param>
        /// <returns>Array containing the sentence list after mapping (after removal)</returns>
        public string[] RemoveNamesFromSentence(List<string> sentence, List<string> names)
        {
            sentence.RemoveAll(item => names.Contains(item));
            return sentence.ToArray();
        }


        /// <summary>
        /// The function converts a string to an array, each word in a string = cell in the array.
        /// </summary>
        /// <param name="sentence">any string</param>
        /// <returns>An array</returns>
        public string[] StringToArray(string sentence)
        {
            char[] separators = new char[] { ' ', '\n', '\t', '\r' };
            return sentence.Split(separators);     //take out the separators.
        }


        /// <summary>
        /// The function normalizes each word to its original form by using the HebrewNLP directory.
        /// </summary>
        /// <param name="words_arr">Receives an array of strings</param>
        /// <returns>A list of strings containing the words normalized</returns>
        public List<string> NormalizeWordsByHebrewNLP(string[] words_arr)
        {
            HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
            return HebrewMorphology.NormalizeWords(words_arr, NormalizationType.SEARCH);
        }


        /// <summary>
        /// The function analyzes the sentence and recognize names using the HebrewNLP library.
        /// </summary>
        /// <param name="sentence_arr">sentence (as an array)</param>
        /// <returns>A list of strings containing the names recognized in the sentence</returns>
        public List<string> NameRecognitionByHebrewNLP(string[] sentence_arr)
        {
            List<NameInfo> options = null;
            HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
            try
            {
                options = NameAnalyzer.Analyze(sentence_arr);
            }
            catch (Exception)
            {
                return ReturnOnlyNames(null, sentence_arr);
            }
            return ReturnOnlyNames(options, sentence_arr);
        }

        /// <summary>
        /// The function maps the names from the list.
        /// </summary>
        /// <param name="options">List of NameInfo</param>
        /// <param name="sentence_arr"></param>
        /// <returns>A list of strings containing the names from the sentence</returns>
        public List<string> ReturnOnlyNames(List<NameInfo> options, string[] sentence_arr)
        {
            int i = 0;
            List<string> onlyNames = new List<string>();
            if (options == null)
                return onlyNames;
            foreach (var word in options)
            {
                if (word.FirstName > 7 || word.LastName > 7)
                    onlyNames.Add(sentence_arr[i]);
                i++;
            }
            return onlyNames;
        }

    }
}
