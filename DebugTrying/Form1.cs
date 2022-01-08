using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebugTrying
{
    public partial class Form1 : Form
    {
        AutoClassificationDBEntities db = AutoClassificationDBEntities.Instance;
  
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_invokeFuncGetNewMail_Click(object sender, EventArgs e)
        {
            Algorithm algorithm = new Algorithm();
            algorithm.NewEmailRequest("בהקדם", "רועי ספק - מעוניין לדבר עם אסתי רכש בהקדם", "shira0556791045@gmail.com", DateTime.Now);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> sentence = new List<string>();
            sentence.Add("הי");
            sentence.Add("רועי");
            sentence.Add("מה");
            sentence.Add("קורה?");
            List<string> names = new List<string>();
            names.Add("רועי");
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
    }
}
