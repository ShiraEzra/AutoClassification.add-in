using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using BLL;
using System.Windows.Forms;
using DAL;

namespace AutomaticClassification_Add_in
{
    public partial class ThisAddIn
    {

        Outlook.MailItem currentMail = null;
        Outlook.MAPIFolder oInbox = null;
        AutoClassificationDBEntities db = AutoClassificationDBEntities.Instance;


        /// <summary>
        /// Function performed when entering a new email
        /// </summary>
        private void GetNewMail()
        {
            Outlook.Items oItems = oInbox.Items;
            Outlook.Items unReadItems = oItems.Restrict("[Unread]=true");
            //List<Outlook.MailItem> unReadMails = new List<Outlook.MailItem>();
            //foreach (var item in unReadItems)
            //    unReadMails.Add((Outlook.MailItem)item);
            currentMail = (Outlook.MailItem)unReadItems.GetLast();
            if (currentMail != null)
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
            int endBody = body.IndexOf("<https");
            return body.Substring(0, endBody);
        }


        /// <summary>
        /// The function moves the current e-mail to the requested folder. (The category selected by the algorithm.)
        /// </summary>
        /// <param name="nameFolder">The directory to which the email should be forwarded</param>
        private void MoveDirectory(string nameFolder)
        {
            Outlook.MAPIFolder destFolder = oInbox.Folders[nameFolder];
            currentMail?.Move(destFolder);
        }



        /// <summary>
        /// A function that is performed whenever an email enters this folder.
        /// </summary>
        /// <param name="item">The email added</param>
        private void AddMailToDirectory(object item)
        {
            MessageBox.Show("hii - tryin notify when new mail arrived to this directory");
          
            //EmailRequest_tbl req = db.EmailRequest_tbl.Single(e => e.entryId == ((Outlook.MailItem)item).EntryID);
            //if (req.numLookingFor == 0)
            //    req.numLookingFor=1;
            //else
            //{
            //    if (req.numLookingfor>0)
            //    {
            //        //צריך לבצע את פונקציות העברת תקיה בצורה ידנית.
            //        //להוריד את את כל אחוזי הסתברות שהוספנו לקטגוריה אחרונה שבה הייתה הפנייה
            //        //ולהוסיפם לקטגוריה שאליה הועברה הפנייה
            //    }
            //}
        }



        /// <summary>
        /// A function that is performed each time an email is deleted from this folder.
        /// </summary>
        private void ChangeMailFromDirectory()
        {
            MessageBox.Show("hii - tryin notify when  mail is deleting from this directory");
        }


        /// <summary>
        /// A function that is performed when opening the Outlook application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //העמסת מתודה שתתבצע בכל פעם שיכנס מייל חדש
            this.Application.NewMail += GetNewMail;

            Outlook.NameSpace oNS = this.Application.GetNamespace("mapi");
            oInbox = oNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);


            Outlook.MAPIFolder destFolder = oInbox.Folders["שירות לקוחות"];
            //העמסת המתודה לאירוע שיתרחש בכל פעם שיתווסף מייל חדש לתקיה זו
            destFolder.Items.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(AddMailToDirectory);

            ////העמסת המתודה לאירוע שיתרחש בכל פעם שימחק מייל  מתקיה זו
            //destFolder.Items.ItemRemove += ChangeMailFromDirectory;

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
