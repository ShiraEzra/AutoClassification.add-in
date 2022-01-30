using HebrewNLP.Morphology;
using HebrewNLP.Names;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Analysis
    {

        /// <summary>
        /// The function receives a sentence, activates the AnalyzeSentence function on it. And returns it analyzed without any irrelevant words.
        /// </summary>
        /// <param name="sentence">sentence to analysis</param>
        /// <returns>list of the analyzed words without any irrelevant words.</returns>
        public static List<string> AnalysisSentece(this string sentence)
        {
            List<List<MorphInfo>> analyzedSentence = AnalyzeSentence(sentence);
            //לטפל במקרה שחוזר נאל= לא מצליח לגשת לספריית אןאלפי
            return RemoveIrrelevantWords(analyzedSentence);
        }


        /// <summary>
        /// The function receives an array of words , activates the AnalyzeSentence function on it. And returns it analyzed without any irrelevant words.
        /// </summary>
        /// <param name="words">word to analysis</param>
        /// <returns>list of the analyzed words without any irrelevant words.</returns>
        public static List<string> AnalysisWords(this string[] words)
        {
            List<List<MorphInfo>> analyzedWords = AnalyzeWords(words);
            //לטפל במקרה שחוזר נאל= לא מצליח לגשת לספריית אןאלפי
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
        public static List<List<MorphInfo>> AnalyzeWords(this string[] words)
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


        /// <summary>
        /// The function analyzes this string and recognize if it's a name using the HebrewNLP library.
        /// </summary>
        /// <param name="maybeName">string</param>
        /// <returns>NameIfo - analysis of maybeName</returns>
        public static NameInfo NameRecognition(string maybeName)
        {
            string[] arrName = new string[] { maybeName };
            List<NameInfo> options = null;
            HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
            try
            {
                options = NameAnalyzer.Analyze(arrName);
            }
            catch (Exception)
            {
                return null;
            }
            return options.FirstOrDefault();
        }


        /// <summary>
        /// The function removes the irrelevant words from the sentence.
        /// </summary>
        /// <param name="analyzedSentence">Analyzed sentence. (In addition - the word is normalized to the base form)</param>
        /// <returns>A list of strings containing the words relevant to the classification.</returns>
        public static List<string> RemoveIrrelevantWords(List<List<MorphInfo>> analyzedSentence)
        {
            //לסדר תיעוד
            List<string> rellevantWords = new List<string>();
            bool isLastwasfirstName = true;
            if (analyzedSentence != null)
                foreach (var item in analyzedSentence)
                {
                    //לראות איך אפשר לייעל את הבחירה מבין האופציות שחוזרות לי מהספרייה
                    if (IsRrelavantPartOfSpeach(item.FirstOrDefault()))  //אם המילה רלוונטית
                    {
                        MorphInfo word = CheckName(item);
                        if (word != null)
                        {
                            if (isLastwasfirstName)  //אם המילה הקודמת הייתה שם פרטי, ועכשיו המילה היא שם משפחה
                            {
                                string fullName = rellevantWords.Last() + word.BaseWordMenukad == null ? word.BaseWord : word.BaseWordMenukad;
                                rellevantWords[rellevantWords.Count() - 1] = fullName;   //מוסיפים את השם משפחה לשם הפרטי כמילה אחת
                                isLastwasfirstName = false;
                            }
                            else
                            {
                                rellevantWords.Add(word.BaseWordMenukad == null ? word.BaseWord : word.BaseWordMenukad);
                                isLastwasfirstName = false;
                            }
                        }
                        else
                        {
                            word = CheckParticle(item);   //מילת הקריאה אם קיימת באופציות, אחרת - נאל
                            if (!OpeningAndclosingWords(word))   //אם לא קיימת אופציה של מילת קריאה, או שהמילה אינה באמת מילת קריאה - ניקח באופן שרירותי את האופציה הראשונה ברשימה
                            {
                                word = item.FirstOrDefault();
                                rellevantWords.Add(word.BaseWordMenukad == null ? word.BaseWord : word.BaseWordMenukad);
                                isLastwasfirstName = word.PartOfSpeech == PartOfSpeech.PROPER_NOUN ? true : false;
                            }
                            else
                                isLastwasfirstName = false;
                        }
                    }
                }
            return rellevantWords;
        }


        /// <summary>
        /// The function checks whether the word is relevant according to the analysis of the word.
        /// </summary>
        /// <param name="morphInfo">Analyzed word</param>
        /// <returns>True- If the word is captivating and relevant. Otherwise - False</returns>
        public static bool IsRrelavantPartOfSpeach(MorphInfo morphInfo)
        {
            //לראות איך להתייחס למספר
            //MODAL
            return morphInfo.PartOfSpeech == PartOfSpeech.VERB || morphInfo.PartOfSpeech == PartOfSpeech.NOUN || morphInfo.PartOfSpeech == PartOfSpeech.ADJECTIVE || morphInfo.PartOfSpeech == PartOfSpeech.PROPER_NOUN;
        }


        /// <summary>
        /// The function gets a list of analysis options for a particular word.
        ///The function checks if one of the options contains a name.
        ///If so - sends to a name identification function.If not returns NULL
        /// </summary>
        /// <param name="wordsOptions">a list of options of analyzed words</param>
        /// <returns>word / null</returns>
        public static MorphInfo CheckName(List<MorphInfo> wordsOptions)
        {
            foreach (var word in wordsOptions)
            {
                if (word.PartOfSpeech == PartOfSpeech.PROPER_NOUN)
                {
                    NameInfo nameInfo = NameRecognition(word.BaseWord);
                    if (nameInfo == null)
                        return null;
                    if (nameInfo.FirstName > 8 || nameInfo.LastName > 8 || (nameInfo.FirstName >= 5 && nameInfo.LastName >= 5))
                        return word;
                }
            }
            return null;
        }


        /// <summary>
        /// The function receives a list of options of analyzed words and returns true if one of all the options is a word, otherwise false.
        /// </summary>
        /// <param name="wordsOptions">a list of options of analyzed words</param>
        /// <returns>word / null</returns>
        public static MorphInfo CheckParticle(List<MorphInfo> wordsOptions)
        {
            foreach (var word in wordsOptions)
            {
                if (word.PartOfSpeech == PartOfSpeech.PARTICLE || word.PartOfSpeech == PartOfSpeech.INTERJECTION || word.PartOfSpeech == PartOfSpeech.PROPER_NOUN)
                    return word;
            }
            return null;
        }


        /// <summary>
        /// The function builds a list of opening words and ending words.
        ///Returns whether the word she received is an opening / closing word or not.
        /// </summary>
        /// <param name="word">word (as MorphInfo)</param>
        /// <returns>whether the word she received is an opening / closing word or not.</returns>
        public static bool OpeningAndclosingWords(MorphInfo word)
        {
            if (word != null)
            {
                List<string> commonWords = new List<string>() { "הי", "היי", "שלומ", "תודה", "בבקשה", "ברכה", "רב", "רבה" };
                //List<string> commonPairWords = new List<string>() { "תודה רבה", "שבת שלום", "בוקר טוב", "בוקר אור", "צהריים טובים", "ערב טוב" };
                if (commonWords.Contains(word.BaseWord))
                    return true;
            }
            return false;
        }
    }
}
