using BLL.DTO;
using System;
using System.Windows.Forms;

namespace AutomaticClassification_Add_in.UI
{
    public partial class GeneralManager : UserControl
    {
        public delegate void EventHandler(Manager m);
        public event EventHandler Main_UI;
        Manager manager, LoggedInM;
        bool isAdd;

        public GeneralManager(Manager m, bool isFirst = true)
        {
            InitializeComponent();
            if (isFirst)
            {
                this.manager = m;
                if (this.manager == null)
                    this.isAdd = true;
                else
                {
                    this.isAdd = false;
                    updateState();
                }
            }
            else
            {
                this.LoggedInM = m;
                this.isAdd = true;
            }
        }

        private void updateState()
        {
            name_txt.Text = this.manager.Name_user;
            id_txt.Text = this.manager.ID_user;
            pwd_txt.Text = this.manager.Password;
        }

        private void pb_logo_Click(object sender, EventArgs e)
        {
            if (this.LoggedInM != null)
                Main_UI?.Invoke(this.LoggedInM);
            else
                Main_UI?.Invoke(this.manager);
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            clearControls();
            if (!isAdd)
                updateState();
        }

        private void clearControls()
        {
            name_txt.Text = "";
            id_txt.Text = "";
            pwd_txt.Text = "";
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (isAdd)
                addNewManager();
            else
                updateManager();
        }

        public void updateManager()
        {
            if (!isConrolsEmpty() && checkValidate())
            {
                this.manager.Update();
                timerOn();
            }
        }

        public void addNewManager()
        {
            this.manager = new Manager();
            if (!isConrolsEmpty() && checkValidate())
            {
                manager.Add();
                timerOn();
                clearControls();
            }
        }

        private bool isConrolsEmpty()
        {
            if (name_txt.Text.Trim() == "" || id_txt.Text.Trim() == "" || pwd_txt.Text.Trim() == "")
                return true;
            return false;
        }

        private bool checkValidate()
        {
            bool ok = true;
            errorProvider1.Clear();
            try
            {
                this.manager.Name_user = name_txt.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(name_txt, ex.Message);
                ok = false;
            }
            try
            {
                this.manager.ID_user = id_txt.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(id_txt, ex.Message);
                ok = false;
            }
            try
            {
                this.manager.Password = pwd_txt.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(pwd_txt, ex.Message);
                ok = false;
            }
            return ok;
        }

        private void timerOn()
        {
            timer1.Enabled = true;
            ok_lbl.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ok_lbl.Visible = false;
            timer1.Enabled = false;
        }
    }
}
