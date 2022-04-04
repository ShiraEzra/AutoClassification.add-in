
namespace AutomaticClassification_Add_in.Forms
{
    partial class AddNewCategory
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewCategory));
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.detailsNewCategory_gb = new System.Windows.Forms.GroupBox();
            this.afterCreate_pl = new System.Windows.Forms.Panel();
            this.associateDM_lnkLbl = new System.Windows.Forms.LinkLabel();
            this.noteBold_lbl = new System.Windows.Forms.Label();
            this.requestsForExample_lnkLbl = new System.Windows.Forms.LinkLabel();
            this.note_lbl = new System.Windows.Forms.Label();
            this.createCategory_btn = new System.Windows.Forms.Button();
            this.categoryDesc_txt = new System.Windows.Forms.TextBox();
            this.DescCategory_lbl = new System.Windows.Forms.Label();
            this.nameCategory_txt = new System.Windows.Forms.TextBox();
            this.nameCategory_lbl = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.detailsNewCategory_gb.SuspendLayout();
            this.afterCreate_pl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_logo
            // 
            this.pb_logo.BackColor = System.Drawing.Color.Transparent;
            this.pb_logo.Image = ((System.Drawing.Image)(resources.GetObject("pb_logo.Image")));
            this.pb_logo.Location = new System.Drawing.Point(10, 15);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(290, 88);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_logo.TabIndex = 1;
            this.pb_logo.TabStop = false;
            this.pb_logo.Click += new System.EventHandler(this.pb_logo_Click);
            // 
            // detailsNewCategory_gb
            // 
            this.detailsNewCategory_gb.BackColor = System.Drawing.Color.Transparent;
            this.detailsNewCategory_gb.Controls.Add(this.afterCreate_pl);
            this.detailsNewCategory_gb.Controls.Add(this.createCategory_btn);
            this.detailsNewCategory_gb.Controls.Add(this.categoryDesc_txt);
            this.detailsNewCategory_gb.Controls.Add(this.DescCategory_lbl);
            this.detailsNewCategory_gb.Controls.Add(this.nameCategory_txt);
            this.detailsNewCategory_gb.Controls.Add(this.nameCategory_lbl);
            this.detailsNewCategory_gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.detailsNewCategory_gb.Location = new System.Drawing.Point(10, 135);
            this.detailsNewCategory_gb.Name = "detailsNewCategory_gb";
            this.detailsNewCategory_gb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.detailsNewCategory_gb.Size = new System.Drawing.Size(290, 526);
            this.detailsNewCategory_gb.TabIndex = 3;
            this.detailsNewCategory_gb.TabStop = false;
            this.detailsNewCategory_gb.Text = "הוספת קטגוריה חדשה";
            // 
            // afterCreate_pl
            // 
            this.afterCreate_pl.Controls.Add(this.associateDM_lnkLbl);
            this.afterCreate_pl.Controls.Add(this.noteBold_lbl);
            this.afterCreate_pl.Controls.Add(this.requestsForExample_lnkLbl);
            this.afterCreate_pl.Controls.Add(this.note_lbl);
            this.afterCreate_pl.Location = new System.Drawing.Point(26, 208);
            this.afterCreate_pl.Name = "afterCreate_pl";
            this.afterCreate_pl.Size = new System.Drawing.Size(244, 312);
            this.afterCreate_pl.TabIndex = 5;
            this.afterCreate_pl.Visible = false;
            // 
            // associateDM_lnkLbl
            // 
            this.associateDM_lnkLbl.AutoSize = true;
            this.associateDM_lnkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.associateDM_lnkLbl.Location = new System.Drawing.Point(89, 15);
            this.associateDM_lnkLbl.Name = "associateDM_lnkLbl";
            this.associateDM_lnkLbl.Size = new System.Drawing.Size(143, 18);
            this.associateDM_lnkLbl.TabIndex = 17;
            this.associateDM_lnkLbl.TabStop = true;
            this.associateDM_lnkLbl.Text = "לשיוך מנהל מחלקה";
            this.associateDM_lnkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.associateDM_lnkLbl_LinkClicked);
            // 
            // noteBold_lbl
            // 
            this.noteBold_lbl.AutoSize = true;
            this.noteBold_lbl.Location = new System.Drawing.Point(123, 84);
            this.noteBold_lbl.Name = "noteBold_lbl";
            this.noteBold_lbl.Size = new System.Drawing.Size(110, 20);
            this.noteBold_lbl.TabIndex = 16;
            this.noteBold_lbl.Text = "לתשומת לב: ";
            // 
            // requestsForExample_lnkLbl
            // 
            this.requestsForExample_lnkLbl.AutoSize = true;
            this.requestsForExample_lnkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.requestsForExample_lnkLbl.Location = new System.Drawing.Point(38, 221);
            this.requestsForExample_lnkLbl.Name = "requestsForExample_lnkLbl";
            this.requestsForExample_lnkLbl.Size = new System.Drawing.Size(194, 18);
            this.requestsForExample_lnkLbl.TabIndex = 15;
            this.requestsForExample_lnkLbl.TabStop = true;
            this.requestsForExample_lnkLbl.Text = "להוספה כעת פניות לדוגמא";
            this.requestsForExample_lnkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.requestsForExample_lnkLbl_LinkClicked);
            // 
            // note_lbl
            // 
            this.note_lbl.AutoSize = true;
            this.note_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.note_lbl.Location = new System.Drawing.Point(16, 106);
            this.note_lbl.Name = "note_lbl";
            this.note_lbl.Size = new System.Drawing.Size(222, 102);
            this.note_lbl.TabIndex = 14;
            this.note_lbl.Text = "המחלקה החדשה תוכל לפעול נכון רק\r\nלאחר שתקבל לפחות 10 פניות לדוגמא.\r\nאת הפניות לדו" +
    "גמא ניתן להכניס כך:\r\nכל פנייה בקובץ טקסט נפרד,\r\n2 שורות ראשונות בעבור הנושא\r\nושא" +
    "ר השורות בעבור גוף המייל.";
            // 
            // createCategory_btn
            // 
            this.createCategory_btn.Image = ((System.Drawing.Image)(resources.GetObject("createCategory_btn.Image")));
            this.createCategory_btn.Location = new System.Drawing.Point(26, 149);
            this.createCategory_btn.Name = "createCategory_btn";
            this.createCategory_btn.Size = new System.Drawing.Size(132, 29);
            this.createCategory_btn.TabIndex = 4;
            this.createCategory_btn.Text = "יצירת המחלקה";
            this.createCategory_btn.UseVisualStyleBackColor = true;
            this.createCategory_btn.Click += new System.EventHandler(this.createCategory_btn_Click);
            // 
            // categoryDesc_txt
            // 
            this.categoryDesc_txt.Location = new System.Drawing.Point(26, 89);
            this.categoryDesc_txt.Name = "categoryDesc_txt";
            this.categoryDesc_txt.Size = new System.Drawing.Size(139, 27);
            this.categoryDesc_txt.TabIndex = 3;
            // 
            // DescCategory_lbl
            // 
            this.DescCategory_lbl.AutoSize = true;
            this.DescCategory_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DescCategory_lbl.Location = new System.Drawing.Point(168, 92);
            this.DescCategory_lbl.Name = "DescCategory_lbl";
            this.DescCategory_lbl.Size = new System.Drawing.Size(106, 20);
            this.DescCategory_lbl.TabIndex = 2;
            this.DescCategory_lbl.Text = "תיאור מחלקה:";
            // 
            // nameCategory_txt
            // 
            this.nameCategory_txt.Location = new System.Drawing.Point(26, 38);
            this.nameCategory_txt.Name = "nameCategory_txt";
            this.nameCategory_txt.Size = new System.Drawing.Size(139, 27);
            this.nameCategory_txt.TabIndex = 1;
            // 
            // nameCategory_lbl
            // 
            this.nameCategory_lbl.AutoSize = true;
            this.nameCategory_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.nameCategory_lbl.Location = new System.Drawing.Point(186, 42);
            this.nameCategory_lbl.Name = "nameCategory_lbl";
            this.nameCategory_lbl.Size = new System.Drawing.Size(88, 20);
            this.nameCategory_lbl.TabIndex = 0;
            this.nameCategory_lbl.Text = "שם מחלקה:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.ReadOnlyChecked = true;
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.ShowReadOnly = true;
            this.openFileDialog1.Title = "Browse email requests Files";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddNewCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.detailsNewCategory_gb);
            this.Controls.Add(this.pb_logo);
            this.Name = "AddNewCategory";
            this.Size = new System.Drawing.Size(307, 689);
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.detailsNewCategory_gb.ResumeLayout(false);
            this.detailsNewCategory_gb.PerformLayout();
            this.afterCreate_pl.ResumeLayout(false);
            this.afterCreate_pl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_logo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox detailsNewCategory_gb;
        private System.Windows.Forms.Button createCategory_btn;
        private System.Windows.Forms.TextBox categoryDesc_txt;
        private System.Windows.Forms.Label DescCategory_lbl;
        private System.Windows.Forms.TextBox nameCategory_txt;
        private System.Windows.Forms.Label nameCategory_lbl;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel afterCreate_pl;
        private System.Windows.Forms.LinkLabel associateDM_lnkLbl;
        private System.Windows.Forms.Label noteBold_lbl;
        private System.Windows.Forms.LinkLabel requestsForExample_lnkLbl;
        private System.Windows.Forms.Label note_lbl;
    }
}
