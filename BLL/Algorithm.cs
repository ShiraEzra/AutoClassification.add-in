using DAL;
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
            List<string> SubjectDividedToWords = CutSentencesToWords(subject);
            List<string> BodyDividedToWords = CutSentencesToWords(body);
            BuildMatrix();

        }

        public  List<string> CutSentencesToWords(string sentence)   //cuts the content of the email into words and delete non-letter characters
        {
            var result = Regex.Replace(sentence, @"[!-@, [-`, {-~]", ""); // delete every char that suitable to the condition
            char[] separators =new char[] { ' ', '\n', '\t', '\r' };
            List<string> wordsSentence= result.Split(separators).ToList();     //cuts the content of the email into words
            return wordsSentence.Where(w => w.Length > 1).ToList();
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
