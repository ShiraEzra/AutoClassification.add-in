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

namespace AutomaticClassification_Add_in.UI
{
    public partial class MyNotificationBox : Form
    {
        Retrieval retrieval;
        public MyNotificationBox()
        {
            InitializeComponent();
            retrieval = new Retrieval();
            ok_btn.DialogResult = DialogResult.OK;
            this.AcceptButton = ok_btn;
        }

        internal void InsertValues(float[] precision)
        {
            string categoryName = null;
            notification_richTxt.Text += Environment.NewLine + "אחוזי דיוק המערכת בשלב ראשוני זה:";
            for (int i = 0; i < precision.Length; i++)
            {
                if (i==precision.Length-1)
                {
                    //total
                    notification_richTxt.Text += Environment.NewLine + "";
                    notification_richTxt.Text += Environment.NewLine + "לסיכום כללי,";
                    notification_richTxt.Text += Environment.NewLine + "המערכת עומדת כעת על: " + precision[i] + " אחוזי הדיוק.";

                }
                else
                {
                    categoryName = retrieval.GetCategoryByID(i + 1).Name_category;
                    notification_richTxt.Text += Environment.NewLine + categoryName+": " + precision[i];
                }
            }
        }
    }
}
