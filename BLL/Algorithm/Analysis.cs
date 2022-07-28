using HebrewNLP.Morphology;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace BLL
{
    public static class Analysis
    {
        const string password = "3BGkxLKouDk3l7B";

        /// <summary>
        /// The function receives a sentence, activates the AnalyzeSentence function on it. And returns it analyzed without any irrelevant words.
        /// </summary>
        /// <param name="sentence">sentence to analysis</param>
        /// <returns>list of the analyzed words without any irrelevant words.</returns>
        public static List<string> AnalysisSentece(this string sentence)
        {
            List<List<MorphInfo>> analyzedSentence = AnalyzeSentence(sentence);
            return RemoveIrrelevantWords(analyzedSentence);
        }


        /// <summary>
        /// The function receives an array of words , activates the AnalyzeSentence function on it. And returns it analyzed without any irrelevant words.
        /// </summary>
        /// <param name="words">array of word to analysis</param>
        /// <returns>list of the analyzed words without any irrelevant words.</returns>
        public static List<string> AnalysisWords(this string[] words)
        {
            List<List<MorphInfo>> analyzedWords = AnalyzeWords(words);
            return RemoveIrrelevantWords(analyzedWords);
        }


        /// <summary>
        /// The function splits the string into a list of sentences by using the library HebrewNLP.
        /// </summary>
        /// <param name="allBody">email body</param>
        /// <returns>List of sentences</returns>
        public static List<string> SplitToSentences(this string allBody)
        {
            try
            {
                HebrewNLP.HebrewNLP.Password = password;
                List<string> bodySplitToSentences = HebrewNLP.Sentencer.Sentences(allBody);
                return bodySplitToSentences;
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }


        /// <summary>
        /// The function analyzes the sentence.
        /// </summary>
        /// <param name="sentence">sentence</param>
        /// <returns>List with analyzed words from the  sentence. (as MorphInfo list)</returns>
        public static List<List<MorphInfo>> AnalyzeSentence(string sentence)
        {
            try
            {
                HebrewNLP.HebrewNLP.Password = password;
                return HebrewMorphology.AnalyzeSentence(sentence);
            }
            catch (Exception)
            {
                return new List<List<MorphInfo>>();
            }
        }


        /// <summary>
        /// The function analyzes the words.
        /// </summary>
        /// <param name="words"> list of words</param>
        /// <returns>analyzed words</returns>
        public static List<List<MorphInfo>> AnalyzeWords(this string[] words)
        {
            try
            {
                HebrewNLP.HebrewNLP.Password = password;
                return HebrewMorphology.AnalyzeWords(words);
            }
            catch (Exception)
            {
                return new List<List<MorphInfo>>();
            }
        }


        /// <summary>
        /// The function removes the irrelevant words from the sentence.
        /// </summary>
        /// <param name="analyzedSentence">Analyzed sentence. (In addition - the word is normalized to the base form)</param>
        /// <returns>A list of strings containing the words relevant to the classification.</returns>
        public static List<string> RemoveIrrelevantWords(List<List<MorphInfo>> analyzedSentence)
        {
            List<string> rellevantWords = new List<string>();
            MorphInfo word = null;
            foreach (var item in analyzedSentence)
            {
                word = item.FirstOrDefault();
                if (word!=null && IsRrelavantPartOfSpeach(word))   
                    rellevantWords.Add(word.BaseWordMenukad != null ? word.BaseWordMenukad : word.BaseWord);
            }
            return rellevantWords;
        }


        /// <summary>
        /// The function checks whether the word is relevant according to the analysis of the word.
        /// </summary>
        /// <param name="morphInfo">Analyzed word</param>
        /// <returns>True- If the word is relevant. Otherwise - False</returns>
        public static bool IsRrelavantPartOfSpeach(MorphInfo morphInfo)
        {
            return morphInfo.PartOfSpeech == PartOfSpeech.VERB || morphInfo.PartOfSpeech == PartOfSpeech.NOUN ||
                morphInfo.PartOfSpeech == PartOfSpeech.ADJECTIVE || morphInfo.PartOfSpeech == PartOfSpeech.PROPER_NOUN;
        }


     
        static string openningPathWindows = @"\..\..\Data\openningWords.txt";
        static string openningPath = @"\Data\openningWords.txt";
        /// <summary>
        /// The function takes a list of opening words from a file.
        /// And delivery from the sentence that received the opening words existing in it.
        /// </summary>
        /// <param name="sentence">Sentence (subject / first sentence from the body of the email)</param>
        /// <returns>A sentence without opening words</returns>
        public static string RemoveOpeningWords(this string sentence)
        {
            string[] openningWords = null;
            try
            {
                openningWords = System.IO.File.ReadAllLines(Environment.CurrentDirectory + openningPath);
            }
            catch (Exception)
            {
                try
                {
                    openningWords = System.IO.File.ReadAllLines(Environment.CurrentDirectory + openningPathWindows);
                }
                catch (Exception)
                {
                }
            }
            return RemoveWords(sentence, openningWords);
        }


        static string endingPathWindows = @"\..\..\Data\endingWords.txt";
        static string endingPath = @"\Data\endingWords.txt";
        /// <summary>
        /// The function takes a list of ending words from a file.
        /// And delivery from the sentence that received the ending words existing in it.
        /// </summary>
        /// <param name="sentence">Sentence (from the subject / the last three sentences from the body of the email)</param>
        /// <returns>A sentence without ending words</returns>
        public static string RemoveEndingWords(this string sentence)
        {
            string[] endingWords = null;
            try
            {
                endingWords = File.ReadAllLines(Environment.CurrentDirectory + endingPathWindows);
            }
            catch (Exception)
            {
                try
                {
                    endingWords = File.ReadAllLines(Environment.CurrentDirectory + endingPath);
                }
                catch (Exception)
                {
                }
            }
            return RemoveWords(sentence, endingWords);
        }


        /// <summary>
        /// The function receives a sentence and a array of words to remove.
        ///The function returns a sentence without the words to be removed.
        /// </summary>
        /// <param name="sentence">sentence (string)</param>
        /// <param name="WordsToRemove">WordsToRemove (string[])</param>
        /// <returns>A sentence without the words to be removed.</returns>
        public static string RemoveWords(string sentence, string[] wordsToRemove)
        {
            if (wordsToRemove != null)
            {
                Array.Sort(wordsToRemove, Compare);
                foreach (var item in wordsToRemove)
                {
                    if (sentence.Contains(item))
                        sentence = sentence.Replace(item, "");
                }
            }
            return sentence;
        }


        /// <summary>
        /// The function compares the lengths of the strings.
        ///The function returns a number greater than 0 if the length of the x string is greater than the length of the y string.
        ///If the lengths of the strings are equal - the function returns 0.
        ///Otherwise - No. less than 0.
        /// </summary>
        /// <param name="x">string</param>
        /// <param name="y">string</param>
        /// <returns></returns>
        public static int Compare(string x, string y)
        {
            return y.Length - x.Length;
        }
    }
}
