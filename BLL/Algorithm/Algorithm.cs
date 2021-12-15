using DAL;
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
    public class Algorithm
    {
        AutomaticClassificationDBEntities db = new AutomaticClassificationDBEntities();

        float[,] naiveBaseMat;
        public  void NewEmailRequest(string subject, string body/*, string sender, DateTime date*/)
        {
            string [] subject_withOutIrrelevnt = RemovingIrrelevantCharacters(subject);
            string [] body_withOutIrrelevnt = RemovingIrrelevantCharacters(body);
            //להתייחס לשמות של אנשים
            string[] namesInSubject = NameRecognition(subject_withOutIrrelevnt);
            string[] namesInBody = NameRecognition(body_withOutIrrelevnt);
            List<string> normalizedSubjectWords = NormalizeWordsByHebrewNLP(subject_withOutIrrelevnt);
            List<string> normalizedBodyWords = NormalizeWordsByHebrewNLP(body_withOutIrrelevnt);

            BuildMatrix();

        }

        public string [] RemovingIrrelevantCharacters(string sentence)   //A function that removes characters and spaces from the content.
        {
            string result = Regex.Replace(sentence, @"[!-@, [-`, {-~]", " "); // delete every char that suitable to the condition.
            char[] separators =new char[] { ' ', '\n', '\t', '\r' };
            string[] wordsSentence= result.Split(separators);     //take out the separators.
            //wordsSentence= wordsSentence.Where(w => w.Length > 1).ToArray(); //remove words with 1 character (=not words);
            //return ConnectingArrayItemsToSentence(wordsSentence);      //return the sentence with out IrrelevantCharacters.
            return wordsSentence.Where(w => w.Length > 1).ToArray();
        }

        //public string ConnectingArrayItemsToSentence(string[] arr)  
        //{
        //    string str = "";
        //    foreach (string item in arr)
        //        str += item + " ";
        //    return str;
        //}

        public List<string> NormalizeWordsByHebrewNLP(string [] words_arr)
        {
            HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
            return HebrewMorphology.NormalizeWords(words_arr, NormalizationType.SEARCH);
        }

        public string[] NameRecognition(string[] sentence_arr)
        {
            HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
            List<NameInfo> options = NameAnalyzer.Analyze(sentence_arr);

            return sentence_arr;
        }

        public void BuildMatrix()
        {
            naiveBaseMat = new float[db.Word_tbl.Count(),db.Category_tbl.Count()];
            List<WordPerCategory_tbl> wpc_lst = db.WordPerCategory_tbl.ToList();
            for (int i = 0; i < wpc_lst.Count(); i++)
                naiveBaseMat[wpc_lst[i].ID_word-1, wpc_lst[i].ID_category-1] = (float)wpc_lst[i].MatchPercentage; //קוד המילה/ הקטגוריה הוא המיקום של המילה/ הקטגוריה ברשימה שלהם- כי זה מספור אוטומטי רודף.
        }
    }
}
