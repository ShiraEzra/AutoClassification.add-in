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

        Outlook.MailItem currentMail = null;
        Outlook.MAPIFolder oInbox = null;


        /// <summary>
        /// Function performed when entering a new email
        /// </summary>
        void GetNewMail()
        {
            Outlook.Items oItems = oInbox.Items;
            Outlook.Items unReadItems = oItems.Restrict("[Unread]=true");
            //List<Outlook.MailItem> unReadMails = new List<Outlook.MailItem>();
            //foreach (var item in unReadItems)
            //    unReadMails.Add((Outlook.MailItem)item);
            currentMail = (Outlook.MailItem)unReadItems.GetLast();
            if (currentMail!=null)
            {
                Algorithm algorithm = new Algorithm();
                algorithm.NewEmailRequest(currentMail.Subject, RelevantBodyOnly(currentMail.Body), currentMail.SenderEmailAddress, currentMail.CreationTime);
            }
        }



        /// <summary>
        /// Function that removes irrelevant things from the body of the email.
        /// </summary>
        /// <param name="body">The body of the email</param>
        /// <returns>Relevant email body only</returns>
        private string RelevantBodyOnly(string body)
        {
            int endBody =body.IndexOf("<https");
            return body.Substring(0, endBody);
        }


        /// <summary>
        /// The function moves the current e-mail to the requested folder. (The category selected by the algorithm.)
        /// </summary>
        /// <param name="nameFolder">The directory to which the email should be forwarded</param>
        private void MoveDirectory(string nameFolder)
        {
            Outlook.MAPIFolder destFolder = oInbox.Folders[nameFolder];
            currentMail.Move(destFolder);
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)  //A function that is performed when opening the Outlook application
        {
            this.Application.NewMail += GetNewMail;    //Load function to be performed when receiving a new email
            Outlook.NameSpace oNS = this.Application.GetNamespace("mapi");
            oInbox = oNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

            GetNewMail();
            MoveDirectory("שירות לקוחות");
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
