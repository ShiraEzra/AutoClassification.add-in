using BLL;
using DAL;
using HebrewNLP.Names;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebugTrying
{
    public partial class Form1 : Form
    {
        AutomaticClassificationDBEntities db = AutomaticClassificationDBEntities.Instance;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_invokeFuncGetNewMail_Click(object sender, EventArgs e)
        {
            NaiveBaiseAlgorithm algorithm = new NaiveBaiseAlgorithm();
            algorithm.NewEmailRequest("העברה בנקאית – אישור", "מצב חשבונית מס כפי שביקשתם, על העברה הבנקאית שנעשתה אתמול עס  20,000₪ מחברת סולמות חגית יום טוב.", "רכעחולץףך", DateTime.Now, "36636520gfvhgj");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> sentence = new List<string>
            {
                "הי",
                "רועי",
                "מה",
                "קורה?"
            };
            List<string> names = new List<string>
            {
                "רועי"
            };
            sentence = RemoveNamesFromSentence(sentence, names);
        }

        public List<string> RemoveNamesFromSentence(List<string> sentence, List<string> names)
        {
            sentence.RemoveAll(item => names.Contains(item));
            return sentence;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Word_tbl> double_lst = new List<Word_tbl>();
            var allWords_lst = db.Word_tbl.ToList();
            foreach (var word in allWords_lst)
            {
                foreach (var w in allWords_lst)
                {
                    if (word != w && word.Value_word == w.Value_word && !double_lst.Contains(word))
                    {
                        double_lst.Add(word);
                        double_lst.Add(w);
                    }
                }
            }

            //נותן להוסיף ערכים כפולים למרות שהוא יוניקיו
            //Word_tbl wo = new Word_tbl() { Value_word = "עקב", ID_wordType = 2 };
            //db.Word_tbl.Add(wo);
            //db.SaveChanges();
        }

        private void btnTryingDuplicateWord_Click(object sender, EventArgs e)
        {
            Word_tbl w = AddDuplicateWord_tbl("דִּירָה");
        }


        public Word_tbl AddDuplicateWord_tbl(string w)
        {
            Word_tbl word = new Word_tbl { Value_word = w };
            try
            {
                db.Word_tbl.Add(word);
                db.SaveChanges();
            }
            catch (DbUpdateException e)
                   when (e.InnerException?.InnerException is SqlException sqlEx &&
                   (sqlEx.Number == 2601 || sqlEx.Number == 2627))
            {
                //catch this errors:
                // 2627- Unique constraint error
                //2601- Duplicated key row error
                return db.Word_tbl.FirstOrDefault(wt => wt.Value_word == word.Value_word);
            }
            return word;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] arrName = new string[] { "שרה" };
            List<NameInfo> options = null;
            HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
            options = NameAnalyzer.Analyze(arrName);
            //try
            //{
            //    options = NameAnalyzer.Analyze(arrName);
            //}
            //catch (Exception)
            //{
            //    //return null;
            //}
            ////return options.Firs
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var wpr_lst = db.WordPerRequest_tbl;
            foreach (var wpr in wpr_lst)
            {
                wpr.IsSimilarWord = false;
                db.SaveChanges();
            }



            //string str = null;
            //if (str.Contains("hii"))     //ייצור שגיאה בגלל שנאל
            //{
            //    MessageBox.Show("OK");
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var lst = SimilarWords.GetSimilarWords("קרצטועילךל");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //LikeTranzakia();




            //NaiveBaiseAlgorithm algorithm = new NaiveBaiseAlgorithm();
            //Conclusion c = new Conclusion();
            //List<string> lst = new List<string>() { "קַבְּלָנ" , "קַבְּלָנ" };
            //c.SavingConclusionsInDB(lst, 1);
        }


        public void LikeTranzakia()
        {
            EmailRequest_tbl request = db.EmailRequest_tbl.Single(x => x.ID_emailRequest == 53);
            var lst = db.WordPerRequest_tbl.Where(x => x.Request_id == request.ID_emailRequest).ToList();
            WordPerCategory_tbl wpr;
            foreach (var item in lst)
            {
                wpr = db.WordPerCategory_tbl.FirstOrDefault(x => x.ID_category == request.ID_category && x.ID_word == item.Word_id);
                if (wpr != null)
                {
                    if (item.IsSimilarWord == true)
                        wpr.AmountOfUse -= 0.3f;
                    else
                        wpr.AmountOfUse -= 1;
                    if (wpr.AmountOfUse == 0)
                        db.WordPerCategory_tbl.Remove(wpr);
                    db.SaveChanges();
                }
            }
            db.WordPerRequest_tbl.RemoveRange(lst);
            db.SaveChanges();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EmailRequest_tbl req = db.EmailRequest_tbl.Single(e1 => e1.ID_emailRequest == 124);
            //int sentFrom = (int)req.ID_category;
            //// req.ID_category = db.Category_tbl.Single(c => c.Name_category == newFolder).ID_category;


            //מחיקת מיילים פר קטגוריה
            List<WordPerRequest_tbl> requestWords = db.WordPerRequest_tbl.Where(w => w.Request_id == req.ID_emailRequest).ToList();
            ReducingProbability.ReduceProbability((int)req.ID_category, requestWords);


            //מחיקת מילים פר פנייה
            db.WordPerRequest_tbl.RemoveRange(requestWords);
            db.SaveChanges();

            //מחיקת הפנייה
            db.EmailRequest_tbl.Remove(req);
            db.SaveChanges();



            //var requests_lst = db.Word_tbl.ToList();
            //int i = 0;
            //foreach (var req in requests_lst)
            //{
            //    if (req.ID_word > 1370)
            //    {
            //        db.Word_tbl.Remove(req);
            //        db.SaveChanges();
            //        i++;
            //    }
            //}
            //int c = i;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NaiveBaiseAlgorithm algorithm = new NaiveBaiseAlgorithm();
            //   var mat = algorithm.BuildProbabilityMat();
            Word_tbl w = db.Word_tbl.FirstOrDefault(wt => wt.Value_word == textBox1.Text);
            if (w != null)
            {

                MessageBox.Show("קוד: "+ w.ID_word + "\n"+
                    "שירות לקוחות:" + algorithm.probability_mat[w.ID_word-1, 0] + "\n" +
                   "הנהלת חשבונות:" + algorithm.probability_mat[w.ID_word-1, 1] + "\n" +
                   "ביצוע:" + algorithm.probability_mat[w.ID_word-1, 2] + "\n" +
                   "הנדסה:" + algorithm.probability_mat[w.ID_word-1, 3] + "\n");


            }
            else
                MessageBox.Show("אין כזו מילה בDB");
        }
    }
}
