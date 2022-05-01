
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
            this.ok_lbl = new System.Windows.Forms.Label();
            this.createCategory_btn = new System.Windows.Forms.Button();
            this.categoryDesc_txt = new System.Windows.Forms.TextBox();
            this.DescCategory_lbl = new System.Windows.Forms.Label();
            this.nameCategory_txt = new System.Windows.Forms.TextBox();
            this.nameCategory_lbl = new System.Windows.Forms.Label();
            this.afterCreate_pl = new System.Windows.Forms.Panel();
            this.okAddingRequests_lbl = new System.Windows.Forms.Label();
            this.associateDM_lnkLbl = new System.Windows.Forms.LinkLabel();
            this.noteBold_lbl = new System.Windows.Forms.Label();
            this.requestsForExample_lnkLbl = new System.Windows.Forms.LinkLabel();
            this.note_lbl = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.exsistsCategory_lbl = new System.Windows.Forms.Label();
            this.exsistsCategory_cmb = new System.Windows.Forms.ComboBox();
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
            this.detailsNewCategory_gb.Controls.Add(this.ok_lbl);
            this.detailsNewCategory_gb.Controls.Add(this.createCategory_btn);
            this.detailsNewCategory_gb.Controls.Add(this.categoryDesc_txt);
            this.detailsNewCategory_gb.Controls.Add(this.DescCategory_lbl);
            this.detailsNewCategory_gb.Controls.Add(this.nameCategory_txt);
            this.detailsNewCategory_gb.Controls.Add(this.nameCategory_lbl);
            this.detailsNewCategory_gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.detailsNewCategory_gb.Location = new System.Drawing.Point(10, 187);
            this.detailsNewCategory_gb.Name = "detailsNewCategory_gb";
            this.detailsNewCategory_gb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.detailsNewCategory_gb.Size = new System.Drawing.Size(290, 185);
            this.detailsNewCategory_gb.TabIndex = 3;
            this.detailsNewCategory_gb.TabStop = false;
            this.detailsNewCategory_gb.Text = "הוספת קטגוריה חדשה";
            // 
            // ok_lbl
            // 
            this.ok_lbl.AutoSize = true;
            this.ok_lbl.Font = new System.Drawing.Font("Microsoft Yi Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ok_lbl.Location = new System.Drawing.Point(22, 149);
            this.ok_lbl.Name = "ok_lbl";
            this.ok_lbl.Size = new System.Drawing.Size(139, 17);
            this.ok_lbl.TabIndex = 15;
            this.ok_lbl.Text = "המחלקה נוצרה בהצלחה";
            this.ok_lbl.Visible = false;
            // 
            // createCategory_btn
            // 
            this.createCategory_btn.Image = ((System.Drawing.Image)(resources.GetObject("createCategory_btn.Image")));
            this.createCategory_btn.Location = new System.Drawing.Point(22, 119);
            this.createCategory_btn.Name = "createCategory_btn";
            this.createCategory_btn.Size = new System.Drawing.Size(132, 29);
            this.createCategory_btn.TabIndex = 4;
            this.createCategory_btn.Text = "יצירת המחלקה";
            this.createCategory_btn.UseVisualStyleBackColor = true;
            this.createCategory_btn.Click += new System.EventHandler(this.createCategory_btn_Click);
            // 
            // categoryDesc_txt
            // 
            this.categoryDesc_txt.Location = new System.Drawing.Point(22, 79);
            this.categoryDesc_txt.Name = "categoryDesc_txt";
            this.categoryDesc_txt.Size = new System.Drawing.Size(139, 24);
            this.categoryDesc_txt.TabIndex = 3;
            // 
            // DescCategory_lbl
            // 
            this.DescCategory_lbl.AutoSize = true;
            this.DescCategory_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DescCategory_lbl.Location = new System.Drawing.Point(168, 82);
            this.DescCategory_lbl.Name = "DescCategory_lbl";
            this.DescCategory_lbl.Size = new System.Drawing.Size(106, 20);
            this.DescCategory_lbl.TabIndex = 2;
            this.DescCategory_lbl.Text = "תיאור מחלקה:";
            // 
            // nameCategory_txt
            // 
            this.nameCategory_txt.Location = new System.Drawing.Point(22, 38);
            this.nameCategory_txt.Name = "nameCategory_txt";
            this.nameCategory_txt.Size = new System.Drawing.Size(139, 24);
            this.nameCategory_txt.TabIndex = 1;
            this.nameCategory_txt.TextChanged += new System.EventHandler(this.nameCategory_txt_TextChanged);
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
            // afterCreate_pl
            // 
            this.afterCreate_pl.BackColor = System.Drawing.Color.Transparent;
            this.afterCreate_pl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.afterCreate_pl.Controls.Add(this.okAddingRequests_lbl);
            this.afterCreate_pl.Controls.Add(this.associateDM_lnkLbl);
            this.afterCreate_pl.Controls.Add(this.noteBold_lbl);
            this.afterCreate_pl.Controls.Add(this.requestsForExample_lnkLbl);
            this.afterCreate_pl.Controls.Add(this.note_lbl);
            this.afterCreate_pl.Location = new System.Drawing.Point(32, 383);
            this.afterCreate_pl.Name = "afterCreate_pl";
            this.afterCreate_pl.Size = new System.Drawing.Size(248, 306);
            this.afterCreate_pl.TabIndex = 5;
            this.afterCreate_pl.Visible = false;
            // 
            // okAddingRequests_lbl
            // 
            this.okAddingRequests_lbl.AutoSize = true;
            this.okAddingRequests_lbl.Font = new System.Drawing.Font("Microsoft Yi Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okAddingRequests_lbl.Location = new System.Drawing.Point(40, 258);
            this.okAddingRequests_lbl.Name = "okAddingRequests_lbl";
            this.okAddingRequests_lbl.Size = new System.Drawing.Size(128, 17);
            this.okAddingRequests_lbl.TabIndex = 18;
            this.okAddingRequests_lbl.Text = "הפניות נוספו בהצלחה";
            this.okAddingRequests_lbl.Visible = false;
            // 
            // associateDM_lnkLbl
            // 
            this.associateDM_lnkLbl.AutoSize = true;
            this.associateDM_lnkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.associateDM_lnkLbl.Location = new System.Drawing.Point(95, 15);
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
            this.noteBold_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.noteBold_lbl.Location = new System.Drawing.Point(127, 62);
            this.noteBold_lbl.Name = "noteBold_lbl";
            this.noteBold_lbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.noteBold_lbl.Size = new System.Drawing.Size(110, 20);
            this.noteBold_lbl.TabIndex = 16;
            this.noteBold_lbl.Text = "לתשומת לב: ";
            // 
            // requestsForExample_lnkLbl
            // 
            this.requestsForExample_lnkLbl.AutoSize = true;
            this.requestsForExample_lnkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.requestsForExample_lnkLbl.Location = new System.Drawing.Point(47, 221);
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
            this.note_lbl.Location = new System.Drawing.Point(3, 85);
            this.note_lbl.Name = "note_lbl";
            this.note_lbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.note_lbl.Size = new System.Drawing.Size(233, 136);
            this.note_lbl.TabIndex = 14;
            this.note_lbl.Text = resources.GetString("note_lbl.Text");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Plain text files (*.msg;*.txt)|*.msg;*.txt";
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
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // exsistsCategory_lbl
            // 
            this.exsistsCategory_lbl.AutoSize = true;
            this.exsistsCategory_lbl.BackColor = System.Drawing.Color.Transparent;
            this.exsistsCategory_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.exsistsCategory_lbl.Location = new System.Drawing.Point(184, 146);
            this.exsistsCategory_lbl.Name = "exsistsCategory_lbl";
            this.exsistsCategory_lbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.exsistsCategory_lbl.Size = new System.Drawing.Size(112, 18);
            this.exsistsCategory_lbl.TabIndex = 6;
            this.exsistsCategory_lbl.Text = "קטגוריות קיימות:";
            this.exsistsCategory_lbl.Visible = false;
            // 
            // exsistsCategory_cmb
            // 
            this.exsistsCategory_cmb.FormattingEnabled = true;
            this.exsistsCategory_cmb.Location = new System.Drawing.Point(29, 143);
            this.exsistsCategory_cmb.Name = "exsistsCategory_cmb";
            this.exsistsCategory_cmb.Size = new System.Drawing.Size(144, 24);
            this.exsistsCategory_cmb.TabIndex = 7;
            this.exsistsCategory_cmb.Visible = false;
            this.exsistsCategory_cmb.SelectedIndexChanged += new System.EventHandler(this.exsistsCategory_cmb_SelectedIndexChanged);
            // 
            // AddNewCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.exsistsCategory_cmb);
            this.Controls.Add(this.exsistsCategory_lbl);
            this.Controls.Add(this.detailsNewCategory_gb);
            this.Controls.Add(this.afterCreate_pl);
            this.Controls.Add(this.pb_logo);
            this.Name = "AddNewCategory";
            this.Size = new System.Drawing.Size(307, 741);
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.detailsNewCategory_gb.ResumeLayout(false);
            this.detailsNewCategory_gb.PerformLayout();
            this.afterCreate_pl.ResumeLayout(false);
            this.afterCreate_pl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label ok_lbl;
        private System.Windows.Forms.Label okAddingRequests_lbl;
        private System.Windows.Forms.ComboBox exsistsCategory_cmb;
        private System.Windows.Forms.Label exsistsCategory_lbl;
    }
}
