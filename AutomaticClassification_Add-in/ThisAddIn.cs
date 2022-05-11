﻿using System.Collections.Generic;
using Outlook = Microsoft.Office.Interop.Outlook;
using BLL;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using AutomaticClassification_Add_in.Forms;
using AutomaticClassification_Add_in.UI;
using BLL.DTO;
using System.Linq;
using System;

namespace AutomaticClassification_Add_in
{
    public partial class ThisAddIn
    {

        static Outlook.MAPIFolder oInbox;
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
                Marshal.ReleaseComObject(unReadItems);   //צריכה לעבור ולשחרר אחד אחד? או שמספיק את כל הרשימה ביחד.

                try
                {
                    foreach (var mail in unReadMails)
                    {
                        NaiveBaiseAlgorithm algorithm = new NaiveBaiseAlgorithm();
                        string nameFolder = algorithm.NewEmailRequest(mail.ConversationTopic, retrieval.RelevantBodyOnly(mail.Body), mail.SenderEmailAddress, mail.CreationTime, mail.ConversationID);
                        MoveDirectory(mail, nameFolder);
                    }
                }
                catch (System.Exception)
                {
                    MessageBox.Show("error!!  " + unReadMails);
                }
                finally
                {
                    Marshal.ReleaseComObject(unReadMails);
                }

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
            //https://stackoverflow.com/questions/42663830/outlook-2016-vsto-folder-add-event-fires-only-once
        }


        /// <summary>
        /// The function removes from the user's folders the loading method of entering a new email into the folder.
        /// </summary>
        private void UnLoadAddItemMethodToAllCategoryFolders()
        {
            var categoriesNames_lst = retrieval.GetAllCategoriesNames();
            Outlook.MAPIFolder destFolder = null;
            foreach (var categoryName in categoriesNames_lst)
            {
                destFolder = oInbox.Folders[categoryName];
                destFolder.Items.ItemAdd -= AddMailToDirectory;
            }
        }


        /// <summary>
        /// A method that occurs when creating a new folder.
        /// </summary>
        /// <param name="newFolder"></param>
        public void NewFolder(Outlook.MAPIFolder newFolder)
        {
            MessageBox.Show("hii - tryin notify when  new folder is openning");

        }


        /// <summary>
        /// A method that occurs when deleting a folder.
        /// </summary>
        public void DeleteFolder()
        {
            //עובד רק כשזה הפעולה הראשונה בפתיחת האאוטלוק
            MessageBox.Show("hii - tryin notify when  new folder is openning");

        }


        /// <summary>
        /// A method that creates a new folder.
        /// </summary>
        /// <param name="nameFolder">The name of thr folder</param>
        public void CreateNewFolder(string nameFolder)
        {
            try
            {
                oInbox.Folders.Add(nameFolder, Outlook.OlDefaultFolders.olFolderInbox);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }


        /// <summary>
        /// A method that performs the initial system labeling. The method goes through the user folders and learns the emails of each folder.
        /// </summary>
        /// <returns>The method returns the initial system accuracy percentages for each category. And - the general accuracy percentages of the system.</returns>
        public float[] FirstTaggingLearningFunc()
        {
            Outlook.Items folderItems = null;
            Outlook.MailItem mail = null;
            EmailRequest emailRequest = null;
            int i = 0;
            float[] preccisionArr = new float[allFolders.Count() + 1]; //תא נוסף בעבור הסה"כ
            FirstTaggingLearning ftl = new FirstTaggingLearning();
            List<EmailRequest> folderEmailRequests = null;
            try
            {
                foreach (var folder in allFolders)
                {
                    if (folder is Outlook.MAPIFolder)
                    {
                        folderItems = folder.Items;
                        folderEmailRequests = new List<EmailRequest>();
                        foreach (var item in folderItems)
                        {
                            mail = (Outlook.MailItem)item;
                            emailRequest = new EmailRequest() { Subject = mail.ConversationTopic, Body = retrieval.RelevantBodyOnly(mail.Body), Sender = mail.SenderEmailAddress, Date = mail.CreationTime, EntryID = mail.ConversationID };
                            folderEmailRequests.Add(emailRequest);
                        }
                        preccisionArr[i++] = ftl.LearningFolderRequests(folderEmailRequests, folder.Name);
                    }
                }
                preccisionArr[preccisionArr.Length - 1] = FirstTaggingLearning.totalPrecision;
            }
            catch (Exception ex)
            {
                MessageBox.Show("First tagging doesn't succeed...  " + ex.Message);
            }
            finally
            {
                if (folderItems != null)
                    Marshal.ReleaseComObject(folderItems);
                if (mail != null)
                    Marshal.ReleaseComObject(mail);
            }
            return preccisionArr;
        }


        /// <summary>
        /// The function gets a path to the file with a msg extension, and returns the subject of the email, and the body of the email.
        /// </summary>
        /// <param name="path">the file extention</param>
        /// <param name="subjet">return subject from the msg file</param>
        /// <param name="body">return body from the msg file</param>
        private void GetContentFromMsgFile(string path, ref string subjet, ref string body)
        {
            Outlook.MailItem mail = null;
            try
            {
                mail = (Outlook.MailItem)this.Application.CreateItemFromTemplate(path);
                subjet = mail?.ConversationTopic;
                body = retrieval.RelevantBodyOnly(mail?.Body);
            }
            finally
            {
                Marshal.ReleaseComObject(mail);
            }
        }






        //GUI


        /// <summary>
        /// A method that brings up the AddNewCategory display pane.
        /// </summary>
        /// <param name="m">A logged in user manager</param>
        /// <param name="isAdd">Whether to open in insert or update and delete mode</param>
        public void AddNewCategory_paneShow(Manager m, bool isAdd)
        {
            //אם אמת- הוספת מחלקה חדשה
            //אם שקר - הוספת תיוג למחלקה קיימת
            this.control = new AddNewCategory(m, isAdd);
            AddNewCategoryDelegates();
        }


        /// <summary>
        /// A method that brings up back the AddNewCategory display pane.
        /// </summary>
        /// <param name="m">A logged in user manager</param>
        /// <param name="c">The category that should be displayed in the form that will open.</param>
        public void BackToNewCategoty_paneShow(Manager m, Category c)
        {
            this.control = new AddNewCategory(m, c);
            AddNewCategoryDelegates();
        }


        /// <summary>
        /// The method loads all the required delegates from AddNewCategory pane
        /// </summary>
        public void AddNewCategoryDelegates()
        {
            (this.control as AddNewCategory).Main_UI += UI_paneShow;
            (this.control as AddNewCategory).WorkerDepartment += AssociateWorkerToCategory;
            (this.control as AddNewCategory).GetContentFromMsgFile += GetContentFromMsgFile;
            (this.control as AddNewCategory).CreateNewfolder += CreateNewFolder;
            GUI();
        }


        /// <summary>
        /// A method that brings up the WorkerDepartment display pane.
        /// </summary>
        /// <param name="m">A logged in user manager</param>
        /// <param name="category">To which category to assign the employee</param>
        public void AssociateWorkerToCategory(Manager m, Category category)
        {
            //הפונקציה צריכה לקרוא לפעולה בונה בטופס 2 -הוספת אחראי מחלקה, עם מצב הוספה ומחלקה זו.
            this.control = new WorkerDepartment(m, category);
            (this.control as WorkerDepartment).Main_UI += UI_paneShow;
            (this.control as WorkerDepartment).BackToNewCategoty += BackToNewCategoty_paneShow;
            GUI();
        }


        /// <summary>
        /// A method that brings up the WorkerDepartment display pane.
        /// </summary>
        /// <param name="m">A logged in user manager</param>
        /// <param name="flag">Whether to open in insert or update and delete mode</param>
        public void WorkerDepartment_paneShow(Manager m, bool flag)
        {
            //אם מקבל אמת - מצב הוספת אחראי מחלקה
            //אם מקבל שקר - מצב עדכון/מחיקת אחראי מחלקה
            this.control = new WorkerDepartment(m, flag);
            (this.control as WorkerDepartment).Main_UI += UI_paneShow;
            GUI();
        }


        /// <summary>
        /// A method that brings up the GeneralManager display pane.
        /// </summary>
        /// <param name="m">A logged in user manager</param>
        /// <param name="isFirst">Is this the first administrator who wants to sign up for the system</param>
        public void GeneralManager_paneShow(Manager m, bool isFirst)
        {
            //אם מקבל נאל - הוספת מנהל כללי חדש
            //אם מקבל מנהל - עדכון פרטיו 
            this.control = new GeneralManager(m, isFirst);
            (this.control as GeneralManager).Main_UI += UI_paneShow;
            GUI();
        }


        /// <summary>
        /// A method that brings up to display thw mainly pane.
        /// </summary>
        /// <param name="m">A logged in user manager</param>
        public void UI_paneShow(Manager m)
        {
            this.control = new UI_Pane(m);
            this.CustomTaskPanes.Remove(this.taskpane);
            UI_pane();
        }


        /// <summary>
        ///  A method that brings up to display thw mainly pane.
        /// </summary>
        public void UI_paneShow()
        {
            this.control = new UI_Pane(null);
            UI_pane();
        }


        /// <summary>
        ///  The method loads all the required delegates from the mainly pane
        /// </summary>
        public void UI_pane()
        {
            (this.control as UI_Pane).AddNewCategory += AddNewCategory_paneShow;
            (this.control as UI_Pane).GeneralManager += GeneralManager_paneShow;
            (this.control as UI_Pane).WorkerDepartment += WorkerDepartment_paneShow;
            (this.control as UI_Pane).FirstTaggingLearning += FirstTaggingLearningFunc;

            this.taskpane = this.CustomTaskPanes.Add(this.control, "Auto classification");
            this.taskpane.Width = 325;
            this.taskpane.Visible = true;
        }


        /// <summary>
        /// The method arranges the display pane (size, title, etc.)
        /// </summary>
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
            oInbox = this.Application.GetNamespace("mapi").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

            //העמסת מתודה שתתבצע בכל פעם שיכנס מייל חדש
            this.Application.NewMail += GetNewMail;


            retrieval = new Retrieval();


            allFolders = new List<Outlook.MAPIFolder>();
            LoadAddItemMethodToAllCategoryFolders();

            ////העמסת המתודה לאירוע שיתרחש בכל פעם שימחק מייל  מתקיה זו
            //destFolder.Items.ItemRemove += ChangeMailFromDirectory;



            //העמסת מתודה שתתבצע בכל פעם שיוסיפו תקייה חדשה= קטגוריה חדשה
            oInbox.Folders.FolderAdd += NewFolder;
            oInbox.Folders.FolderRemove += DeleteFolder;


            //user interface
            UI_paneShow();
        }


        /// <summary>
        /// A function that is performed when closing the Outlook application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            if (oInbox != null)
                Marshal.ReleaseComObject(oInbox);
            if (allFolders != null)
            {
                foreach (var folder in allFolders)
                    Marshal.ReleaseComObject(folder);
                Marshal.ReleaseComObject(allFolders);
            }
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
