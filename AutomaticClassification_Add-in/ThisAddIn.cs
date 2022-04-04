using System.Collections.Generic;
using Outlook = Microsoft.Office.Interop.Outlook;
using BLL;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using AutomaticClassification_Add_in.Forms;
using AutomaticClassification_Add_in.UI;
using BLL.DTO;

namespace AutomaticClassification_Add_in
{
    public partial class ThisAddIn
    {

        Outlook.MAPIFolder oInbox;
        Retrieval retrieval;
        static List<Outlook.MAPIFolder> allFolders;

        private UserControl control;
        private Microsoft.Office.Tools.CustomTaskPane taskpane;


        /// <summary>
        /// Function performed when entering a new email
        /// </summary>
        void GetNewMail()
        {
            Task task = Task.Run(() =>
            {
                Thread.Sleep(3000);
                Outlook.Items oItems = oInbox.Items;
                Outlook.Items unReadItems = oItems.Restrict("[Unread]=true");
                List<Outlook.MailItem> unReadMails = new List<Outlook.MailItem>();
                foreach (var unRead in unReadItems)
                    unReadMails.Add((Outlook.MailItem)unRead);

                Marshal.ReleaseComObject(oItems);
                Marshal.ReleaseComObject(unReadItems);

                foreach (var mail in unReadMails)
                {
                    NaiveBaiseAlgorithm algorithm = new NaiveBaiseAlgorithm();
                    string nameFolder = algorithm.NewEmailRequest(mail.ConversationTopic, retrieval.RelevantBodyOnly(mail.Body), mail.SenderEmailAddress, mail.CreationTime, mail.ConversationID);
                    MoveDirectory(mail, nameFolder);
                }
                Marshal.ReleaseComObject(unReadMails);
            });
            //Task t = Task.Run(() =>
            // {
            //     Thread.Sleep(12000);
            //     UnLoadAddItemMethodToAllCategoryFolders();
            //     LoadAddItemMethodToAllCategoryFolders();
            // });
        }


        /// <summary>
        /// The function moves the current e-mail to the requested folder. (The category selected by the algorithm.)
        /// </summary>
        /// <param name="nameFolder">The directory to which the email should be forwarded</param>
        private void MoveDirectory(Outlook.MailItem mail, string nameFolder)
        {
            Outlook.MAPIFolder destFolder = oInbox.Folders[nameFolder];
            mail.Move(destFolder);
            Marshal.ReleaseComObject(destFolder);
        }


        /// <summary>
        /// A function that is performed whenever an email enters this folder.
        /// </summary>
        /// <param name="item">The email added</param>
        void AddMailToDirectory(object item)
        {
            MessageBox.Show("hii - tryin notify when new mail arrived to this directory");
            var p = ((Outlook.MailItem)item).Parent;
            if (p is Outlook.MAPIFolder folder && item is Outlook.MailItem)
            {
                //int reqID = retrieval.GetIdEmailRequestByConversationID(((Outlook.MailItem)item).ConversationID);
                //string categoryName = retrieval.GetCategoryNameOfEmailRequest(reqID);
                //if (reqID != -1 && folder.Name != categoryName)
                //    ReducingProbability.ChangeCategory(reqID, folder.Name);
            }
            Marshal.ReleaseComObject(p);
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
            var categoriesNames_lst = retrieval.GetAllCategoriesNames();
            Outlook.MAPIFolder destFolder = null;
            foreach (var categoryName in categoriesNames_lst)
            {
                destFolder = oInbox.Folders[categoryName];
                //העמסת המתודה לאירוע שיתרחש בכל פעם שיתווסף מייל חדש לתקיה זו
                destFolder.Items.ItemAdd += AddMailToDirectory;
                allFolders.Add(destFolder);
            }
            Marshal.ReleaseComObject(destFolder);
        //https://stackoverflow.com/questions/42663830/outlook-2016-vsto-folder-add-event-fires-only-once
        }

        //private void UnLoadAddItemMethodToAllCategoryFolders()
        //{
        //    var categoriesNames_lst = retrieval.GetAllCategoriesNames();
        //    Outlook.MAPIFolder destFolder = null;
        //    foreach (var categoryName in categoriesNames_lst)
        //    {
        //        destFolder = oInbox.Folders[categoryName];
        //        destFolder.Items.ItemAdd -= AddMailToDirectory;
        //    }
        //}

        public void NewFolder(Outlook.MAPIFolder newFolder)
        {
            MessageBox.Show("hii - tryin notify when  new folder is openning");

        }

        public void DeleteFolder()
        {
            MessageBox.Show("hii - tryin notify when  new folder is openning");

        }


















        public void AddNewCategory_paneShow(Manager m)
        {
            this.control = new AddNewCategory(m);
            (this.control as AddNewCategory).Main_UI += UI_paneShow;
            (this.control as AddNewCategory).WorkerDepartment += AssociateWorkerToCategory;
            GUI();
        }

        public void AssociateWorkerToCategory(Manager m, Category category)
        {
            //לטפל בפונקציה זו
            //הפונקציה צריכה לקרוא לפעולה בונה בטופס 2 -הוספת אחראי מחלקה, עם מצב הוספה ומחלקה זו.
        }

        //public void AddNewUserM_paneShow(User user)
        //{
        //    this.control = new AddNewUserM(user,KindsOfStatesUserPane.AddNewUser);
        //    (this.control as AddNewUserM).UI_PaneToShow += UI_paneShow;
        //    GUI();
        //}

        //public void UpdateUser(User user)
        //{
        //    this.control = new AddNewUserM(user, KindsOfStatesUserPane.UpdateUserDetails);
        //    (this.control as AddNewUserM).UI_PaneToShow += UI_paneShow;
        //    GUI();
        //}

        //public void UpdateYourdetails(User user)
        //{
        //    this.control = new AddNewUserM(user, KindsOfStatesUserPane.UpdateYourDetails);
        //    (this.control as AddNewUserM).UI_PaneToShow += UI_paneShow;
        //    GUI();
        //}

        public void GeneralManager_paneShow(Manager m)
        {
            //אם מקבל נאל - הוספת מנהל כללי חדש
            //אם מקבל מנהל - עדכון פרטיו 
            this.control = new GeneralManager(m);
            (this.control as GeneralManager).Main_UI += UI_paneShow;
            GUI();
        }

        public void WorkerDepartment_paneShow(Manager m, bool flag)
        {
           //אם מקבל אמת - מצב הוספת אחראי מחלקה
           //אם מקבל שקר - מצב עדכון אחראי מחלקה
        }

        public void UI_paneShow(Manager m)
        {
            this.control = new UI_Pane(m);
            this.CustomTaskPanes.Remove(this.taskpane);
            UI_pane();
        }

        public void UI_paneShow()
        {
            this.control = new UI_Pane();
            UI_pane();
        }

        public void UI_pane()
        {
            (this.control as UI_Pane).AddNewCategory += AddNewCategory_paneShow;
            (this.control as UI_Pane).GeneralManager += GeneralManager_paneShow;
            (this.control as UI_Pane).WorkerDepartment += WorkerDepartment_paneShow;

            this.taskpane = this.CustomTaskPanes.Add(this.control, "Auto classification");
            this.taskpane.Width = 325;
            this.taskpane.Visible = true;
        }

        public void GUI()
        {
            this.CustomTaskPanes.Remove(this.taskpane);
            this.taskpane = this.CustomTaskPanes.Add(this.control, "Auto classification");
            this.taskpane.Width = 325;
            this.taskpane.Visible = true;
        }

        /// <summary>
        /// A function that is performed when opening the Outlook application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Outlook.NameSpace oNS = this.Application.GetNamespace("mapi");
            oInbox = oNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

            //העמסת מתודה שתתבצע בכל פעם שיכנס מייל חדש
            this.Application.NewMail += GetNewMail;


            retrieval = new Retrieval();

           
            allFolders = new List<Outlook.MAPIFolder>();
            LoadAddItemMethodToAllCategoryFolders();

            ////העמסת המתודה לאירוע שיתרחש בכל פעם שימחק מייל  מתקיה זו
            //destFolder.Items.ItemRemove += ChangeMailFromDirectory;

            //Marshal.ReleaseComObject(oNS);


            //העמסת מתודה שתתבצע בכל פעם שיוסיפו תקייה חדשה= קטגוריה חדשה
            oInbox.Folders.FolderAdd += NewFolder;
            oInbox.Folders.FolderRemove += DeleteFolder;


            //user interface
            UI_paneShow();
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
