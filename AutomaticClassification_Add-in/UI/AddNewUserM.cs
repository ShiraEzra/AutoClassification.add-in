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
    public partial class AddNewUserM : UserControl
    {
        public delegate void EventHandler(User user);
        public event EventHandler UI_PaneToShow;
        Retrieval retrieval;
        User user;

        public AddNewUserM(User user)
        {
            InitializeComponent();
            this.user = user;
            this.retrieval = new Retrieval();
            var user_lst = this.retrieval.GetAllUsers();
            exsistWorkers_cmb.DataSource = user_lst.ToList();
            //exsistWorkers_cmb.Items.AddRange(retrieval.GetAllUsers());
            //גורם לשגיאה באאוטלוק
        }

        private void pb_logo_Click(object sender, EventArgs e)
        {
            UI_PaneToShow?.Invoke(this.user);
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            clearControls();
            WorkerDetails_gb.Visible = false;
        }

        private void clearControls()
        {
            name_txt.Text = "";
            id_txt.Text = "";
            pl_cmb.Text = "";
            category_cmb.Text = "";
            pwd_txt.Text = "";
        }

        private void AddNewWorker_lnkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WorkerDetails_gb.Visible = true;
            pl_cmb.DataSource = this.retrieval.GetAllPL().ToList();
            category_cmb.DataSource = this.retrieval.GetAllCategories().ToList();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (checkValidate())
            {
                //tidyyy
                User user = new User() { Name_user = name_txt.Text };
            }

        }

        private bool checkValidate()
        {
            //error prvider

            return false;
        }

      
    }
}
