using HebrewNLP.Morphology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Analysis
    {
        /// <summary>
        /// The function splits the string into a list of sentences by using the library HebrewNLP.
        /// </summary>
        /// <param name="allBody">email body</param>
        /// <returns>List of sentences</returns>
        public static List<string> SplitToSentences(string allBody)
        {
            try
            {
                HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
                List<string> bodySplitToSentences = HebrewNLP.Sentencer.Sentences(allBody);
                return bodySplitToSentences;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// The function analyzes the sentence.
        /// </summary>
        /// <param name="sentence">sentence</param>
        /// <returns>analyzed sentence   (as MorphInfo list)</returns>
        public static List<List<MorphInfo>> AnalyzeSentence(string sentence)
        {
            try
            {
                HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
                return HebrewMorphology.AnalyzeSentence(sentence);
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// The function analyzes the words.
        /// </summary>
        /// <param name="words"> list of words</param>
        /// <returns>analyzed words</returns>
        public static List<List<MorphInfo>> AnalyzeWords(string[] words)
        {
            try
            {
                HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
                return HebrewMorphology.AnalyzeWords(words);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
