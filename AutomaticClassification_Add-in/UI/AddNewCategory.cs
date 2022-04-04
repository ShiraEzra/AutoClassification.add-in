using BLL;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AutomaticClassification_Add_in.Forms
{
    public partial class AddNewCategory : UserControl
    {
        //public static AddNewCategory Instance { get; } = new AddNewCategory(null, true);

        public delegate void EventHandler(Manager m);
        public event EventHandler Main_UI;

        public delegate void EventHandler1(Manager m, Category c);
        public event EventHandler1 WorkerDepartment;

        Retrieval retrieval;
        Manager manager;
        Category categoryToadd;


        public AddNewCategory(Manager m)
        {
            InitializeComponent();
            this.retrieval = new Retrieval();
            this.manager = m;
        }

        private void createCategory_btn_Click(object sender, EventArgs e)
        {
            categoryToadd = null;
            if (checkValidate(categoryToadd))
            {
                categoryToadd.Add();
                //להדפיס שתהליך ההוספה בוצע בהצלחה
                afterCreate_pl.Visible = true;
            }
        }

        private bool checkValidate(Category categoryToadd)
        {
            bool ok = true;
            errorProvider1.Clear();
            try
            {
                categoryToadd.Name_category = nameCategory_txt.Text;
                //בדיקה ששם הקטגוריה עוד לא קיים במערכת- אילוץ ייחודיות
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(nameCategory_txt, ex.Message);
                ok = false;
            }
            try
            {
                categoryToadd.Descriptiopn_category = categoryDesc_txt.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(categoryDesc_txt, ex.Message);
                ok = false;
            }
            return ok;
        }

        private void pb_logo_Click(object sender, EventArgs e)
        {
            Main_UI.Invoke(this.manager);
        }

        private void associateDM_lnkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WorkerDepartment?.Invoke(this.manager, categoryToadd);  //טופס 2  - הוספת אחראי מחלקה לקטגוריה זו.
        }


        //לטפל בפונקציה שלוקחת קובץ ומכניסה אותו כפניית מייל לדוגמא לקטגוריה זו
        private void requestsForExample_lnkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog
            //{
            //    InitialDirectory = @"C:\",
            //    Title = "Browse email requests Files",

            //    CheckFileExists = true,
            //    CheckPathExists = true,

            //    DefaultExt = "txt",
            //    Filter = "txt files (*.txt)|*.txt",
            //    FilterIndex = 2,
            //    RestoreDirectory = true,

            //    Multiselect = true,
            //    ReadOnlyChecked = true,
            //    ShowReadOnly = true
            //};

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string pathToFile in openFileDialog1.FileNames)
                {
                    if (File.Exists(pathToFile))// only executes if the file at pathtofile exists//you need to add the using System.IO reference at the top of te code to use this
                    {
                        ////method1
                        //string firstLine = File.ReadAllLines(pathToFile).Skip(0).Take(1).First();//selects first line of the file
                        //string secondLine = File.ReadAllLines(pathToFile).Skip(1).Take(1).First();

                        //method2
                        string text = "";
                        using (StreamReader sr = new StreamReader(pathToFile))
                        {
                            text = sr.ReadToEnd();//all text wil be saved in text enters are also saved
                        }
                    }
                }
            }
        }
    }
}
