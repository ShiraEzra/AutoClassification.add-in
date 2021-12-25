using BLL;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_invokeFuncGetNewMail_Click(object sender, EventArgs e)
        {
            Algorithm algorithm = new Algorithm();
            algorithm.NewEmailRequest("", "רועי ספק - מעוניין לדבר עם אסתי רכש בהקדם", "shira0556791045@gmail.com", DateTime.Now);
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
    }
}
