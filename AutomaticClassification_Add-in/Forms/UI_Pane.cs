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

namespace AutomaticClassification_Add_in
{
    public enum ManagerPl { GeneralManager = 1, DepartmentManager = 2 }

    public partial class UI_Pane : UserControl
    {
        Retrieval retrieval;
        int managerCode;
        public delegate void EventHandler(int managerID);
        public event EventHandler AddNewCategory_PaneToShow;

        public UI_Pane()  //להפוך את זה לסינגלטון
        {
            InitializeComponent();
            this.retrieval = new Retrieval();
        }

        public UI_Pane(int managerCode)  //להפוך את זה לסינגלטון
        {
            InitializeComponent();
            this.retrieval = new Retrieval();
            this.managerCode = managerCode;
            GetBackFirstState();
        }

        public void GetBackFirstState()
        {
            retrieval.GetManagerNameAndPL(managerCode, out int permissionLevel, out string managerName);
            LogInstate(managerCode, permissionLevel, managerName);
        }

        public void LogInstate(int managerCode, int pl, string name)
        {
            if (managerCode != -1)
            {
                welcome_lbl.Text = "שלום " + name;
                managerPwd_txt.Text = "";
                welcome_lbl.Visible = true;
                password_pl.Visible = false;
                switch (pl)
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
            else
                errorProvider1.SetError(managerPwd_txt, "סיסמא שגויה");
        }
        private void ok_btn_Click(object sender, EventArgs e)
        {
            managerCode = retrieval.GetManagerCode(managerPwd_txt.Text, out int permissionLevel, out string managerName);
            LogInstate(managerCode, permissionLevel, managerName);
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
            this.managerCode = -1;
        }

        private void addNewCategory_rb_CheckedChanged(object sender, EventArgs e)
        {
            AddNewCategory_PaneToShow?.Invoke(managerCode);
        }
    }
}
