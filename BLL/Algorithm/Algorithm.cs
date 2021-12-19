using DAL;
using DTO;
using HebrewNLP.Morphology;
using HebrewNLP.Names;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Algorithm
    {
        AutomaticClassificationDBEntities db = new AutomaticClassificationDBEntities();

        //הסרת מילים לא רלוונטיותתת


        float[,] probability_mat;     //ניתן להצהיר בצורה כזו על משתנים? במקום לשלוח אותם מפונקציה לפונקציה
        List<string> namesInSubject, normalizedSubjectWords;
        BodyContent[] bodyContent;

        public void NewEmailRequest(string subject, string body, string sender, DateTime date)
        {
            EmailRequest request = new EmailRequest(subject, body, sender, date);
            request.ID_category = AssociateRequestToCategory(request);
            db.EmailRequest_tbl.Add(request.DtoTODal());
            db.SaveChanges();
        }

        public int AssociateRequestToCategory(EmailRequest request)
        {
            //SimplifySubjectWordsAndNamesLists(request.EmailSubject);
            SimplifyBodyWordsAndNamesLists(request.EmailContent);
            BuildProbabilityMat();

            return 1;
        }

        public void SimplifySubjectWordsAndNamesLists(string subject)
        {
            string[] subject_arr = StringToArray(subject);
            // namesInSubject = NameRecognitionByHebrewNLP(subject_arr);
            //להסיר מהמשפט את כל המילים שזוהו כשמות
            normalizedSubjectWords = NormalizeWordsByHebrewNLP(subject_arr);
            //if (normalizedSubjectWords[7]=="רכש")     //somthing wrong...
            //{
            //    Console.WriteLine("hiiiii");
            //}
        }

        public void SimplifyBodyWordsAndNamesLists(string body)
        {
            List<string> bodySplitToSentences = SplitToSentences(body);
            bodyContent = new BodyContent[bodySplitToSentences.Count()];
            int i = 0;
            foreach (var sentence in bodySplitToSentences)
            {
                //bodyContent[i].namesInBody = NameRecognitionByHebrewNLP(StringToArray(sentence));
                //צריך להסיר את כל השמות  שזוהו מהמשפט
                bodyContent[i] = new BodyContent(db.Category_tbl.Count());
                bodyContent[i++].normalizedBodyWords = NormalizeWordsByHebrewNLP(StringToArray(sentence));
            }
        }

        public string[] StringToArray(string sentence)
        {
            char[] separators = new char[] { ' ', '\n', '\t', '\r' };
            return sentence.Split(separators);     //take out the separators.
        }

        public List<string> SplitToSentences(string allBody)
        {
            HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
            List<string> bodySplitToSentences = HebrewNLP.Sentencer.Sentences(allBody);
            return bodySplitToSentences;
        }

        public List<string> NormalizeWordsByHebrewNLP(string[] words_arr)
        {
            HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
            return HebrewMorphology.NormalizeWords(words_arr, NormalizationType.SEARCH);
        }

        public List<string> NameRecognitionByHebrewNLP(string[] sentence_arr)
        {
            HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
            List<NameInfo> options = NameAnalyzer.Analyze(sentence_arr);
            return ReturnOnlyNames(options, sentence_arr);
        }

        public List<string> ReturnOnlyNames(List<NameInfo> options, string[] sentence_arr)
        {
            int i = 0;
            List<string> onlyNames = null;
            //if (options == null)
            //    return onlyNames;
            foreach (var word in options)
            {
                if (word.FirstName > 6 || word.LastName > 6)
                    onlyNames.Add(sentence_arr[i]);
                i++;
            }
            return onlyNames;
        }

        public void BuildProbabilityMat()
        {
            probability_mat = new float[db.Word_tbl.Count(), db.Category_tbl.Count()];
            List<WordPerCategory_tbl> wpc_lst = db.WordPerCategory_tbl.ToList();
            for (int i = 0; i < wpc_lst.Count(); i++)
                probability_mat[wpc_lst[i].ID_word - 1 , wpc_lst[i].ID_category - 1] = (float)wpc_lst[i].MatchPercentage; //קוד המילה/ הקטגוריה הוא המיקום של המילה/ הקטגוריה ברשימה שלהם- כי זה מספור אוטומטי רודף.
        }

        public float[] ReturnProbabilityForCategory(List<string> contentWords_lst)
        {
            float[] probability_arr = InitProbability_arr();
            Dictionary<int, string> words_dictionary = GetRelevantWordsAsDictionary(contentWords_lst);
            int key = -1;
            float prob_similiarWords = 0;
            //        //לבדוק האם מילה קיימת בדטה בייס. אם כן- להכפיל בערך של המיקום שלו במטריצה. אם לא- לבדוק באתר מילים דומות. ואם גם זה לא להכפיל ב- 0.0001
            foreach (var word in contentWords_lst)
            {
                key = FindKeyByValue(words_dictionary, word);
                for (int i = 0; i < probability_arr.Length; i++)
                {
                    if (key==-1 || probability_mat[key-1 , i]==0)
                    {
                        prob_similiarWords = SimiliarWords_probability(word);
                        if (prob_similiarWords == 0)
                            prob_similiarWords = 0.0001f;
                        probability_arr[i] *= prob_similiarWords;
                    }
                    else
                        probability_arr[i] *= probability_mat[key - 1, i];
                }
            }
            return probability_arr;
        }

        public float[] InitProbability_arr()
        {
            float[] probability_arr = new float[db.Category_tbl.Count()];
            for (int i = 0; i < probability_arr.Length; i++)
            {
                int numRequestsForCategory = db.EmailRequest_tbl.Where(e => e.ID_category == i).Count();
                probability_arr[i] = numRequestsForCategory;
            }
            return probability_arr;
        }

        public float SimiliarWords_probability(string word)  
        {
            //על המילים הדומות שמקבלים צריך לבדוק שוב האם קיימות ב-דטה בייס לקטגוריה זו, ולהחזיר את ההסתברות, אם לא קיימות  להחזיר 0
        }

        public int IndexMaxProbability(float []probability_arr)  //לא השתמשתי עדיין
        {
            //צריך להחזיר את המקס
            //אם יש כמה קטגוריות שקרובות למקס, צריך לבצע בדיקות נוספות לדוגמא: אנשי קשר
        }

       
        public Dictionary<int, string> GetRelevantWordsAsDictionary(List<string> words_lst)   //לשאול את המורה אם יש ענין להעביר לדיקישנירי מרשימה - האם היעילות של חיפוש מילה ברשימה ארוכה יותר?
        {
            var allWords_lst = db.Word_tbl.ToList();
            var dic= allWords_lst.ToDictionary(x => x.ID_word, x => x.Value_word).Where(y=> words_lst.Contains(y.Value));
            return (Dictionary<int, string>)dic;
        }

        public int FindKeyByValue(Dictionary<int, string> word_dictionary, String value)  //אין דרך טובה יותר מאשר לעבור על כל המפתחות?
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
    }
}
