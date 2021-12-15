using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using BLL;
using System.Windows.Forms;

namespace AutomaticClassification_Add_in
{
    public partial class ThisAddIn
    {
        void GetNewMail()
        {
            Outlook.NameSpace oNS = this.Application.GetNamespace("mapi");
            Outlook.MAPIFolder oInbox = oNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
            Outlook.Items oItems = oInbox.Items;
            Outlook.Items unReadItems = oItems.Restrict("[Unread]=true");
            foreach (var item in unReadItems)
            {
                string body = ((Outlook.MailItem)item).Body;
            }
            Outlook.MailItem lastMail = (Outlook.MailItem)unReadItems.GetLast();
            Algorithm algorithm = new Algorithm();
            algorithm.NewEmailRequest("רועי ספק - מעוניין לדבר עם אסתי רכש בהקדם", lastMail.Body/*, lastMail.SenderEmailAddress, lastMail.CreationTime*/);
        }


        private void ThisAddIn_Startup(object sender, System.EventArgs e)  //A function that is performed when opening the Outlook application
        {
            this.Application.NewMail += GetNewMail;    //Load function to be performed when receiving a new email
            GetNewMail();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
