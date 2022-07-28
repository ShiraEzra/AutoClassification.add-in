using AutomaticClassification_Add_in.UI;
using BLL;
using BLL.DTO;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace AutomaticClassification_Add_in
{
    public enum ManagerPl { GeneralManager = 1, DepartmentManager = 2 }

    public partial class UI_Pane : UserControl
    {
        static Retrieval retrieval;
        Manager manager;

        public delegate void EventHandler1(Manager m, bool isFirst = true);
        public event EventHandler1 GeneralManager;

        public delegate void EventHandler2(Manager m, bool isAdd);
        public event EventHandler2 WorkerDepartment;
        public event EventHandler2 AddNewCategory;

        public delegate float[] EventHandler3();
        public event EventHandler3 FirstTaggingLearning;


        public UI_Pane(Manager manager)
        {
            InitializeComponent();
            retrieval = new Retrieval();
            this.manager = manager;
            bool isExsistUser, isExsistCategory;
            if (!IsFirstTimeState(out isExsistUser, out isExsistCategory))
            {
                notFirstTimeState();
                if (manager != null)
                    LogInState();
            }
            else
            {
                firstTime_gb.Location = new Point(firstTime_gb.Location.X, firstTime_gb.Location.Y - 400);
                if (isExsistUser)
                    signInManager_rd.Enabled = false;
                if (isExsistCategory)
                    firstTagging_rd.Enabled = false;
            }
        }

        public static bool IsFirstTimeState(out bool isExsistUser, out bool isExsistCategory)
        {
            isExsistUser = User.IsExsistUser();
            isExsistCategory = retrieval.IsExsistCategories();
            if (isExsistUser && isExsistCategory)
                return false;
            return true;
        }


        private void notFirstTimeState()
        {
            password_pl.Visible = true;
            firstTime_gb.Visible = false;
        }

        public void LogInState()
        {
            welcome_lbl.Text = "שלום " + this.manager.Name_user;
            managerPwd_txt.Text = "";
            welcome_lbl.Visible = true;
            password_pl.Visible = false;
            GeneralManager_gb.Visible = true;
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            manager = Manager.DalToDto(retrieval.GetManagerByPassword(managerPwd_txt.Text));
            if (manager != null)
                LogInState();
            else
                errorProvider1.SetError(managerPwd_txt, "סיסמא שגויה");
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            GeneralManager_gb.Visible = false;
            ExitManagerState();
        }

        public void ExitManagerState()
        {
            welcome_lbl.Visible = false;
            password_pl.Visible = true;
            this.manager = null;
        }

        public bool IsDoneFirstTaggingLearning()
        {
            return retrieval.IsExsistCategories();
        }

        private void addNewCategory_rb_CheckedChanged(object sender, EventArgs e)
        {
            AddNewCategory?.Invoke(this.manager, true);  // טופס 3 - הוספת מחלקה חדשה
        }

        private void addNewDM_rd_CheckedChanged(object sender, EventArgs e)
        {
            WorkerDepartment?.Invoke(this.manager, true);    //טופס 2 - הוספה אחראי מחלקה
        }

        private void updateDetails_rb_CheckedChanged(object sender, EventArgs e)
        {
            WorkerDepartment?.Invoke(this.manager, false);    // טופס 2 - עדכון אחראי מחלקה
        }

        private void updateYourDetails_rb_CheckedChanged(object sender, EventArgs e)
        {
            GeneralManager?.Invoke(this.manager);    // טופס 4 - עדכון מנהל כללי
        }

        private void AddNewManager_rd_CheckedChanged(object sender, EventArgs e)
        {
            GeneralManager?.Invoke(this.manager, false);  //   טופס 4 - הוספת מנהל כללי חדש 
        }

        private void addTaggingToDepartment_rd_CheckedChanged(object sender, EventArgs e)
        {
            AddNewCategory?.Invoke(this.manager, false);  // טופס 3 - הוספת תיוג למחלקה קיימת
        }

        private void signInManager_rd_CheckedChanged(object sender, EventArgs e)
        {
            GeneralManager?.Invoke(null);  //   טופס 4 - הוספת מנהל כללי בפעם הראשונה 
        }

        private void firstTagging_rd_CheckedChanged(object sender, EventArgs e)
        {
            float[] precision = FirstTaggingLearning?.Invoke();  //  למידת המערכת = למידת הקטגוריות ותיוגם הראשוני
            CreateMyNotificationBox(precision);
        }

        public void CreateMyNotificationBox(float[] precision)
        {
            MyNotificationBox myMessageBox = new MyNotificationBox();
            myMessageBox.InsertValues(precision);
            myMessageBox.StartPosition = FormStartPosition.Manual;
            myMessageBox.Location = new Point(20, this.Height / 4 * 3);
            myMessageBox.ShowDialog();
        }
    }
}
