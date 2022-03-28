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


namespace AutomaticClassification_Add_in.Forms
{
    public partial class AddNewCategory : UserControl
    {
        public delegate void EventHandler(User user);
        public event EventHandler UI_PaneToShow;
        public event EventHandler AddNewUserMToShow;
        User user;

        public AddNewCategory(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void requestsForExample_lnkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = dlg.FileName;
                MessageBox.Show(fileName);
            }
        }

        private void createCategory_btn_Click(object sender, EventArgs e)
        {

        }

        private void pb_logo_Click(object sender, EventArgs e)
        {
            UI_PaneToShow?.Invoke(this.user);

        }

        private void associateDM_lnkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNewUserMToShow?.Invoke(this.user, true);
        }
    }
}
