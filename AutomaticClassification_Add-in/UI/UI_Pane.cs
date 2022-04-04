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


namespace AutomaticClassification_Add_in
{
    public enum ManagerPl { GeneralManager = 1, DepartmentManager = 2 }

    public partial class UI_Pane : UserControl
    {
        Retrieval retrieval;
        Manager manager;
        public delegate void EventHandler(Manager m);
        public event EventHandler AddNewCategory;
        public event EventHandler GeneralManager;

        public delegate void EventHandler1(Manager m, bool isAdd);
        public event EventHandler1 WorkerDepartment;


        public UI_Pane()  
        {
            InitializeComponent();
            this.retrieval = new Retrieval();
            if (User.IsExsistUser())
                notFirstTimeState();
        }

        public UI_Pane(Manager manager)  
        {
            InitializeComponent();
            this.retrieval = new Retrieval();
            this.manager = manager;
            notFirstTimeState();
            LogInState();
        }

        private void notFirstTimeState()
        {
            signIn_lnkLbl.Visible = false;
            password_pl.Visible = true;
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
            manager=Manager.DalToDto(retrieval.GetManagerByPassword(managerPwd_txt.Text));
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
            this.manager =null;
        }

        private void addNewCategory_rb_CheckedChanged(object sender, EventArgs e)
        {
            AddNewCategory?.Invoke(this.manager);  // טופס 3 - הוספת מחלקה חדשה
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

        private void signIn_lnkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GeneralManager?.Invoke(null);  //   טופס 4 - הוספת מנהל כללי בפעם הראשונה 
        }
    }
}
