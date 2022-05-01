using BLL;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomaticClassification_Add_in.UI
{
    public partial class WorkerDepartment : UserControl
    {
        public delegate void EventHandler(Manager m);
        public event EventHandler Main_UI;

        public delegate void EventHandler1(Manager m, Category c);
        public event EventHandler1 BackToNewCategoty;

        Retrieval retrieval;
        Manager manager;
        User user;
        Category category;
        bool isAdd;


        public WorkerDepartment(Manager m, bool flagIsAdd)
        {
            //אם מקבל אמת - מצב הוספת אחראי מחלקה
            //אם מקבל שקר - מצב עדכון/מחיקת אחראי מחלקה
            basicInitializing(m);
            this.isAdd = flagIsAdd;
            if (!this.isAdd)
                updateState();
        }
        public WorkerDepartment(Manager m, Category c)
        {
            //מצב הוספת אחראי מחלקה לקטגוריה מסוימת
            basicInitializing(m);
            this.isAdd = true;
            category = c;
            category_cmb.Text = category.Name_category;
            back_lnkLbl.Visible = true;
        }

        private void basicInitializing(Manager m)
        {
            InitializeComponent();
            this.retrieval = new Retrieval();
            this.manager = m;
            category_cmb.Items.AddRange(retrieval.GetAllCategories().ToArray());
        }

        private void updateState()
        {
            save_btn.Text = "שמירה";
            delete_btn.Visible = true;
            initExsistWorkersCmb();
            WorkerDetails_gb.Visible = false;
            update_pl.Visible = true;
        }

        private void pb_logo_Click(object sender, EventArgs e)
        {
            Main_UI?.Invoke(this.manager);
        }

        private void back_lnkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BackToNewCategoty?.Invoke(this.manager, category);
        }
        private void exsistWorkers_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            user = (User)exsistWorkers_cmb.SelectedItem;
            name_txt.Text = user.Name;
            category_cmb.Text = retrieval.GetCategoryByID(user.Categoty).ToString();
            WorkerDetails_gb.Visible = true;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (this.isAdd)
                addNewUser();
            else
                updateUser();
        }

        private void updateUser()
        {
            if (!isConrolsEmpty() && checkValidate())
            {
                if (CreateMyMessageBox("עדכון אשור", "האם לעדכן עובד זה?"))
                {
                    this.user.Update();
                    timerOn();
                    initExsistWorkersCmb();
                }
            }
        }

        private void addNewUser()
        {
            this.user = new User();
            if (!isConrolsEmpty() && checkValidate())
            {
                if (CreateMyMessageBox("הוספה אשור", "האם להוסיף עובד זה?"))
                {
                    user.Add();
                    timerOn();
                }
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (CreateMyMessageBox("מחיקה אשור", "האם למחוק עובד זה?"))
            {
                user.delete();
                timerOn();
                initExsistWorkersCmb();
            }
        }

        public bool CreateMyMessageBox(string title, string msg)
        {
            MyMessageBox myMessageBox = new MyMessageBox(title, msg);
            myMessageBox.StartPosition = FormStartPosition.Manual;
            myMessageBox.Location = new Point(25, this.Height / 4 * 3 + 50);
            myMessageBox.ShowDialog();

            if (myMessageBox.DialogResult == DialogResult.OK)
            {
                myMessageBox.Dispose();
                return true;
            }
            else
            {
                myMessageBox.Dispose();
                return false;
            }
        }

        private bool isConrolsEmpty()
        {
            if (name_txt.Text.Trim() == "" || category_cmb.SelectedItem == null)
                return true;
            return false;
        }

        private bool checkValidate()
        {
            bool ok = true;
            errorProvider1.Clear();
            try
            {
                this.user.Name = name_txt.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(name_txt, ex.Message);
                ok = false;
            }
            try
            {
                this.user.Categoty = ((Category)category_cmb.SelectedItem).ID_category;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(category_cmb, ex.Message);
                ok = false;
            }
            return ok;
        }

        private void timerOn()
        {
            timer1.Enabled = true;
            ok_lbl.Visible = true;
        }


        private void cancel_btn_Click(object sender, EventArgs e)
        {
            cleareControls();
        }

        private void cleareControls()
        {
            name_txt.Text = "";
            category_cmb.SelectedItem = null;
        }

        private void initExsistWorkersCmb()
        {
            exsistWorkers_cmb.Items.Clear();
            exsistWorkers_cmb.Items.AddRange(retrieval.GetAllUsers().ToArray());
            exsistWorkers_cmb.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cleareControls();
            ok_lbl.Visible = false;
            timer1.Enabled = false;
        }
    }
}

