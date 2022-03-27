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
        User user;

        public AddNewUserM(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void pb_logo_Click(object sender, EventArgs e)
        {
            UI_PaneToShow?.Invoke(this.user);
        }
    }
}
