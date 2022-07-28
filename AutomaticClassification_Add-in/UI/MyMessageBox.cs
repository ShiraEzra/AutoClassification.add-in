using System.Drawing;
using System.Windows.Forms;

namespace AutomaticClassification_Add_in.UI
{
    public partial class MyMessageBox : Form
    {
        public MyMessageBox(string title, string msg)
        {
            InitializeComponent();
            quest_lbl.Text = msg;
            quest_lbl.Location = new Point(ok_btn.Location.X - (quest_lbl.Width - ok_btn.Width), ok_btn.Location.Y);
            ok_btn.DialogResult = DialogResult.OK;
            cancel_btn.DialogResult = DialogResult.Cancel;
            this.Text = title;
            this.AcceptButton = ok_btn;
            this.CancelButton = cancel_btn;
        }
    }
}
