
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewCategory));
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.detailsNewCategory_gb = new System.Windows.Forms.GroupBox();
            this.associateDM_lnkLbl = new System.Windows.Forms.LinkLabel();
            this.requestsForExample_lnkLbl = new System.Windows.Forms.LinkLabel();
            this.note_lbl = new System.Windows.Forms.Label();
            this.createCategory_btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DescCategory_lbl = new System.Windows.Forms.Label();
            this.nameCategory_txt = new System.Windows.Forms.TextBox();
            this.nameCategory_lbl = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.detailsNewCategory_gb.SuspendLayout();
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
            this.detailsNewCategory_gb.Controls.Add(this.associateDM_lnkLbl);
            this.detailsNewCategory_gb.Controls.Add(this.requestsForExample_lnkLbl);
            this.detailsNewCategory_gb.Controls.Add(this.note_lbl);
            this.detailsNewCategory_gb.Controls.Add(this.createCategory_btn);
            this.detailsNewCategory_gb.Controls.Add(this.textBox1);
            this.detailsNewCategory_gb.Controls.Add(this.DescCategory_lbl);
            this.detailsNewCategory_gb.Controls.Add(this.nameCategory_txt);
            this.detailsNewCategory_gb.Controls.Add(this.nameCategory_lbl);
            this.detailsNewCategory_gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.detailsNewCategory_gb.Location = new System.Drawing.Point(10, 135);
            this.detailsNewCategory_gb.Name = "detailsNewCategory_gb";
            this.detailsNewCategory_gb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.detailsNewCategory_gb.Size = new System.Drawing.Size(290, 422);
            this.detailsNewCategory_gb.TabIndex = 3;
            this.detailsNewCategory_gb.TabStop = false;
            this.detailsNewCategory_gb.Text = "הוספת קטגוריה חדשה";
            // 
            // associateDM_lnkLbl
            // 
            this.associateDM_lnkLbl.AutoSize = true;
            this.associateDM_lnkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.associateDM_lnkLbl.Location = new System.Drawing.Point(51, 146);
            this.associateDM_lnkLbl.Name = "associateDM_lnkLbl";
            this.associateDM_lnkLbl.Size = new System.Drawing.Size(222, 18);
            this.associateDM_lnkLbl.TabIndex = 8;
            this.associateDM_lnkLbl.TabStop = true;
            this.associateDM_lnkLbl.Text = "שיוך מנהל מחלקה לקטגוריה זו";
            // 
            // requestsForExample_lnkLbl
            // 
            this.requestsForExample_lnkLbl.AutoSize = true;
            this.requestsForExample_lnkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.requestsForExample_lnkLbl.Location = new System.Drawing.Point(79, 318);
            this.requestsForExample_lnkLbl.Name = "requestsForExample_lnkLbl";
            this.requestsForExample_lnkLbl.Size = new System.Drawing.Size(194, 18);
            this.requestsForExample_lnkLbl.TabIndex = 6;
            this.requestsForExample_lnkLbl.TabStop = true;
            this.requestsForExample_lnkLbl.Text = "להוספה כעת פניות לדוגמא";
            this.requestsForExample_lnkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.requestsForExample_lnkLbl_LinkClicked);
            // 
            // note_lbl
            // 
            this.note_lbl.AutoSize = true;
            this.note_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.note_lbl.Location = new System.Drawing.Point(51, 185);
            this.note_lbl.Name = "note_lbl";
            this.note_lbl.Size = new System.Drawing.Size(222, 119);
            this.note_lbl.TabIndex = 5;
            this.note_lbl.Text = "לתשומת לב: \r\nהמחלקה החדשה תוכל לפעול רק\r\nלאחר שתקבל לפחות 10 פניות לדוגמא.\r\nאת הפ" +
    "ניות לדוגמא ניתן להכניס כך:\r\nכל פנייה בקובץ טקסט נפרד,\r\n2 שורות ראשונות בעבור הנ" +
    "ושא\r\nושאר השורות בעבור גוף המייל.";
            // 
            // createCategory_btn
            // 
            this.createCategory_btn.Image = ((System.Drawing.Image)(resources.GetObject("createCategory_btn.Image")));
            this.createCategory_btn.Location = new System.Drawing.Point(15, 371);
            this.createCategory_btn.Name = "createCategory_btn";
            this.createCategory_btn.Size = new System.Drawing.Size(132, 29);
            this.createCategory_btn.TabIndex = 4;
            this.createCategory_btn.Text = "יצירת המחלקה";
            this.createCategory_btn.UseVisualStyleBackColor = true;
            this.createCategory_btn.Click += new System.EventHandler(this.createCategory_btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 89);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 27);
            this.textBox1.TabIndex = 3;
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
            this.openFileDialog1.FileName = "openFileDialog1";
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_logo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox detailsNewCategory_gb;
        private System.Windows.Forms.Label note_lbl;
        private System.Windows.Forms.Button createCategory_btn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label DescCategory_lbl;
        private System.Windows.Forms.TextBox nameCategory_txt;
        private System.Windows.Forms.Label nameCategory_lbl;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.LinkLabel requestsForExample_lnkLbl;
        private System.Windows.Forms.LinkLabel associateDM_lnkLbl;
    }
}
