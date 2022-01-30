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

        //Outlook.MailItem currentMail = null;
        Outlook.MAPIFolder oInbox = null;
        AutomaticClassificationDBEntities db = AutomaticClassificationDBEntities.Instance;


        /// <summary>
        /// Function performed when entering a new email
        /// </summary>
        void GetNewMail()
        {
            MessageBox.Show("understood");
            Outlook.Items oItems = oInbox.Items;
            Outlook.Items unReadItems = oItems.Restrict("[Unread]=true");
            List<Outlook.MailItem> unReadMails = new List<Outlook.MailItem>();
            foreach (var unRead in unReadItems)
                unReadMails.Add((Outlook.MailItem)unRead);
            foreach (var mail in unReadMails)
            {
                MessageBox.Show("got a new mail.  Activates the algorithm.\n "+ mail.Subject);
                NaiveBaiseAlgorithm algorithm = new NaiveBaiseAlgorithm();

                //הכנסה  ל-דטה בייס בעבור לימוד ראשוני
                 string nameFolder = algorithm.FirstInitDB_NewMail(mail.Subject, RelevantBodyOnly(mail.Body), mail.SenderEmailAddress, mail.CreationTime, mail.EntryID, "שירות לקוחות");
                 MessageBox.Show(nameFolder);

                //לאחר הלימוד הראשוני - פניות יכנסו בצורה כזו
                //string nameFolder= algorithm.NewEmailRequest(currentMail.Subject, RelevantBodyOnly(currentMail.Body), currentMail.SenderEmailAddress, currentMail.CreationTime, currentMail.EntryID);

                  MoveDirectory(mail,nameFolder);
            }

            //currentMail = (Outlook.MailItem)unReadItems.GetLast();
            //if (currentMail != null)
            //{
            //    MessageBox.Show("got a new mail.  Activates the algorithm");
            //    NaiveBaiseAlgorithm algorithm = new NaiveBaiseAlgorithm();
            //    //הכנסה  ל-דטה בייס בעבור לימוד ראשוני

            //    string nameFolder = algorithm.FirstInitDB_NewMail(currentMail.Subject, RelevantBodyOnly(currentMail.Body), currentMail.SenderEmailAddress, currentMail.CreationTime, currentMail.EntryID, "שירות לקוחות");
            //    MessageBox.Show(nameFolder);

            //    //לאחר הלימוד הראשוני - פניות יכנסו בצורה כזו
            //    //string nameFolder= algorithm.NewEmailRequest(currentMail.Subject, RelevantBodyOnly(currentMail.Body), currentMail.SenderEmailAddress, currentMail.CreationTime, currentMail.EntryID);

            //    MoveDirectory(nameFolder);
            //}
        }


        /// <summary>
        /// Function that removes irrelevant things from the body of the email.
        /// </summary>
        /// <param name="body">The body of the email</param>
        /// <returns>Relevant email body only</returns>
        private string RelevantBodyOnly(string body)
        {
            int startFirstTag = body.IndexOf("<https");
            string relevantBody = body.Substring(0, startFirstTag);
            MessageBox.Show("Body: " + relevantBody);
            return relevantBody;


            //לטפל במקרה שהמייל מועבר/ מתקבל בצורה שונה עם תוספות בתחילה
            //body= body.Substring(startFirstTag, body.Length);
            //int endFirstTag = body.IndexOf(">");
            //return body.Substring(endFirstTag, body.Length);
        }


        /// <summary>
        /// The function moves the current e-mail to the requested folder. (The category selected by the algorithm.)
        /// </summary>
        /// <param name="nameFolder">The directory to which the email should be forwarded</param>
        private void MoveDirectory(Outlook.MailItem mail, string nameFolder)
        {
            Outlook.MAPIFolder destFolder = oInbox.Folders[nameFolder];
            mail.Move(destFolder);
        }


        /// <summary>
        /// A function that is performed whenever an email enters this folder.
        /// </summary>
        /// <param name="item">The email added</param>
        void AddMailToDirectory(object item)
        {
            MessageBox.Show("hii - tryin notify when new mail arrived to this directory");
            var p = ((Outlook.MailItem)item).Parent;

            if (p is Outlook.MAPIFolder folder)
            {
                //EmailRequest_tbl req = db.EmailRequest_tbl.Single(e => e.EntryId == ((Outlook.MailItem)item).EntryID);
                //if (folder.Name != req.Category_tbl.Name_category)
                //    ReducingProbability.ChangeCategory(req, folder.Name);

                //שם התקיה יהיה שם התקיה החדשה שאליה הועבר המייל
            }

            //לראות אם לאפשר העברת מייל לדואר נכנס - ז"א להוריד את אחוזי ההסתברות ולא להוסיף לשום קטגוריה= להשאיר בדואר הנכנס
        }


        /// <summary>
        /// A function that is performed each time an email is deleted from this folder.
        /// </summary>
        private void ChangeMailFromDirectory()
        {
            MessageBox.Show("hii - tryin notify when  mail is deleting from this directory");
        }


        /// <summary>
        /// The function goes through the folders of the categories.
        ///And loads  AddMailToDirectory method for each category.
        ///To allow manual change of address to another category.
        /// </summary>
        private void LoadAddItemMethodToAllCategoryFolders()
        {
            var categories_lst = db.Category_tbl.ToList();
            Outlook.MAPIFolder destFolder;
            foreach (var category in categories_lst)
            {
                destFolder = oInbox.Folders[category.Name_category];
                //העמסת המתודה לאירוע שיתרחש בכל פעם שיתווסף מייל חדש לתקיה זו
                destFolder.Items.ItemAdd += AddMailToDirectory;
            }
        }


        /// <summary>
        /// A function that is performed when opening the Outlook application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //העמסת מתודה שתתבצע בכל פעם שיכנס מייל חדש
            this.Application.NewMail += GetNewMail;   //מה הההבדל בין שני הסוגים?
            //this.Application.NewMail += new Microsoft.Office.Interop.Outlook.ApplicationEvents_11_NewMailEventHandler(GetNewMail);

            Outlook.NameSpace oNS = this.Application.GetNamespace("mapi");
            oInbox = oNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

            //oInbox.Items.ItemAdd += GetNewMail;

            LoadAddItemMethodToAllCategoryFolders();

            ////העמסת המתודה לאירוע שיתרחש בכל פעם שימחק מייל  מתקיה זו
            //destFolder.Items.ItemRemove += ChangeMailFromDirectory;

            //GetNewMail();
            //MoveDirectory("שירות לקוחות");
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
