using BLL;
using BLL.DTO;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AutomaticClassification_Add_in.Forms
{
    enum KindTimer { NewCategory, AddingRequests }
    public partial class AddNewCategory : UserControl
    {
        public delegate void EventHandler(Manager m);
        public event EventHandler Main_UI;

        public delegate void EventHandler1(Manager m, Category c);
        public event EventHandler1 WorkerDepartment;

        public delegate void EventHandler2(string path, ref string subjet, ref string body);
        public event EventHandler2 GetContentFromMsgFile;

        public delegate void EventHandler3(string nameFoldery);
        public event EventHandler3 CreateNewfolder;

        Retrieval retrieval;
        Manager manager;
        Category category;
        bool isAddCategory;
        int LocationOfAfterCreate_pl;
        const int numRowsForSubject = 2;

        public AddNewCategory(Manager m, bool isAdd)
        {
            InitializeComponent();
            this.retrieval = new Retrieval();
            this.manager = m;
            this.isAddCategory = isAdd;
            if (!this.isAddCategory)
                addingTagging();
        }

        public AddNewCategory(Manager m, Category c)
        {
            InitializeComponent();
            this.retrieval = new Retrieval();
            this.manager = m;
            if (c != null)
            {
                nameCategory_txt.Text = c.Name_category;
                categoryDesc_txt.Text = c.Descriptiopn_category;
                afterCreate_pl.Visible = true;
            }
        }

        private void addingTagging()
        {
            detailsNewCategory_gb.Visible = false;
            exsistsCategory_lbl.Visible = true;
            exsistsCategory_cmb.Visible = true;
            exsistsCategory_cmb.Items.AddRange(retrieval.GetAllCategories().ToArray());
            this.LocationOfAfterCreate_pl = afterCreate_pl.Location.Y;
            associateDM_lnkLbl.Visible = false;
        }

        private void createCategory_btn_Click(object sender, EventArgs e)
        {
            category = new Category();
            if (!isConrolsEmpty() && checkValidate())
            {
                this.category.Add();
                timerOn(KindTimer.NewCategory);
                afterCreate_pl.Visible = true;
                createCategory_btn.Visible = false;
                //יצירת התקיה באאוטלוק
                CreateNewfolder?.Invoke(this.category.Name_category);
            }
        }

        private bool isConrolsEmpty()
        {
            bool ok = false;
            if (nameCategory_txt.Text.Trim() == "")
            {
                errorProvider1.SetError(nameCategory_txt, "שדה חובה");
                ok = true;
            }
            if (categoryDesc_txt.Text.Trim() == "")
            {
                errorProvider1.SetError(categoryDesc_txt, "שדה חובה");
                ok = true;
            }
            return ok;
        }

        private bool checkValidate()
        {
            bool ok = true;
            errorProvider1.Clear();
            try
            {
                category.Name_category = nameCategory_txt.Text;
                //בדיקה ששם הקטגוריה עוד לא קיים במערכת- אילוץ ייחודיות
                if (category.IfNameCategoryExsist(category.Name_category))
                {
                    errorProvider1.SetError(nameCategory_txt, "קיימת קטגוריה כזו כבר");
                    ok = false;
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(nameCategory_txt, ex.Message);
                ok = false;
            }
            try
            {
                category.Descriptiopn_category = categoryDesc_txt.Text;
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
            WorkerDepartment?.Invoke(this.manager, category);  //טופס 2  - הוספת אחראי מחלקה לקטגוריה זו.
        }


        //פונקציה שלוקחת קובץ ומכניסה אותו כפניית מייל לדוגמא לקטגוריה זו
        private void requestsForExample_lnkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Task task = Task.Run(() =>
                {
                    NaiveBaiseAlgorithm algorithm = new NaiveBaiseAlgorithm();
                    foreach (string pathToFile in openFileDialog1.FileNames)
                    {
                        if (File.Exists(pathToFile))
                        {
                            string subject = "", body = "";
                            if (Path.GetExtension(pathToFile) == ".msg")
                                GetContentFromMsgFile?.Invoke(pathToFile, ref subject, ref body);
                            else
                                if (Path.GetExtension(pathToFile) == ".txt")
                                getSubjectAndBodyFromTxtFile(pathToFile, ref subject, ref body);
                            if (subject != "" || body != "")
                                algorithm.InsertRequestToSystem(subject, body, category.ID_category);
                        }
                    }
                    timerOn(KindTimer.AddingRequests);
                });
            }
        }


        //הפונקציה מקבלת קובץ, ומכניסה לנושא את שתי השורות הראשונות של הקובץ, ואת כל השאר לגוף
        private void getSubjectAndBodyFromTxtFile(string pathToFile, ref string subject, ref string body)
        {
            using (StreamReader sr = new StreamReader(pathToFile))
            {
                string oneLine = null;
                for (int i = 0; i < numRowsForSubject; i++)
                {
                    oneLine = sr.ReadLine();
                    if (oneLine == null)
                        return;
                    subject += oneLine + " ";
                }
                oneLine = sr.ReadLine();
                while (oneLine != null)
                {
                    body += oneLine + " ";
                    oneLine = sr.ReadLine();
                }
            }
        }


        private void timerOn(KindTimer kt)
        {
            switch (kt)
            {

                case KindTimer.NewCategory:
                    ok_lbl.Visible = true;
                    timer1.Enabled = true;
                    break;
                case KindTimer.AddingRequests:
                    ChangeVisibilty();
                    break;
                default:
                    break;
            }
           
        }


        //מכיון שכשנמצאים בתוך תהליכון, שהוא אינו התהליכון הראשי א"א לשנות ממנו את תכונות הפקדים
        //Invoke -לכן משתמשים במתודה מיוחזת זו
        public void ChangeVisibilty()
        {
            this.Invoke(new MethodInvoker(delegate () { okAddingRequests_lbl.Visible = true; timer1.Enabled = true; }));
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            ok_lbl.Visible = false;
            okAddingRequests_lbl.Visible = false;
            timer1.Enabled = false;
        }

        private void exsistsCategory_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.category = (Category)exsistsCategory_cmb.SelectedItem;
            afterCreate_pl.Location = new Point(afterCreate_pl.Location.X, this.LocationOfAfterCreate_pl - 150);
            afterCreate_pl.Visible = true;
        }

        private void nameCategory_txt_TextChanged(object sender, EventArgs e)
        {
            createCategory_btn.Visible = true;
        }
    }
}

