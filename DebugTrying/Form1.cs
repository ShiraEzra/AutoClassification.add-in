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
            algorithm.FirstInitDB_NewMail("מצב חשבון", "היי מיכל, תשלחי לי בבקשה מצב חשבון עדכני תודה ויום טוב טל גרנדה זייגרמן 0502915246", "shira0556791045@gmail.com", DateTime.Now, "36636520gfvhgj", "שירות לקוחות");
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
            Word_tbl w= AddDuplicateWord_tbl("דִּירָה");
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
    }
}
