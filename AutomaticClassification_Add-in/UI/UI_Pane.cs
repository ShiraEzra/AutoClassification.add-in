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
        User user;
        public delegate void EventHandler(User user);
        public event EventHandler AddNewCategory_PaneToShow;
        public event EventHandler AddNewUserM_PaneToShow;


        public UI_Pane()  //להפוך את זה לסינגלטון
        {
            InitializeComponent();
            this.retrieval = new Retrieval();
        }

        public UI_Pane(User user)  //להפוך את זה לסינגלטון
        {
            InitializeComponent();
            this.retrieval = new Retrieval();
            this.user = user;
            LogInState();
        }

        public void LogInState()
        {
            welcome_lbl.Text = "שלום " + this.user.Name_user;
            managerPwd_txt.Text = "";
            welcome_lbl.Visible = true;
            password_pl.Visible = false;
            switch (this.user.ID_premissionLevel)
            {
                case (int)ManagerPl.DepartmentManager:
                    DepartmentManager_gb.Visible = true;
                    break;
                case (int)ManagerPl.GeneralManager:
                    GeneralManager_gb.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            user=User.DalToDto(retrieval.GetUserByPassword(managerPwd_txt.Text));
            if (user != null)
                LogInState();
            else
                errorProvider1.SetError(managerPwd_txt, "סיסמא שגויה");
        }


        private void exit_btn_Click(object sender, EventArgs e)
        {
            GeneralManager_gb.Visible = false;
            ExitManagerState();
        }

        private void exitDM_btn_Click(object sender, EventArgs e)
        {
            DepartmentManager_gb.Visible = false;
            ExitManagerState();
        }

        public void ExitManagerState()
        {
            welcome_lbl.Visible = false;
            password_pl.Visible = true;
            this.user =null;
        }

        private void addNewCategory_rb_CheckedChanged(object sender, EventArgs e)
        {
            AddNewCategory_PaneToShow?.Invoke(user);
        }

        private void addNewDM_rd_CheckedChanged(object sender, EventArgs e)
        {
            AddNewUserM_PaneToShow?.Invoke(user);
        }

        private void pb_logo_Click(object sender, EventArgs e)
        {

        }
    }
}
