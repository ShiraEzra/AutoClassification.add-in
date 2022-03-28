
namespace AutomaticClassification_Add_in.UI
{
    partial class AddNewUserM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewUserM));
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.title_lbl = new System.Windows.Forms.Label();
            this.exsistWorkers_cmb = new System.Windows.Forms.ComboBox();
            this.AddNewWorker_lnkLbl = new System.Windows.Forms.LinkLabel();
            this.WorkerDetails_gb = new System.Windows.Forms.GroupBox();
            this.save_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.pwd_txt = new System.Windows.Forms.TextBox();
            this.category_cmb = new System.Windows.Forms.ComboBox();
            this.pl_cmb = new System.Windows.Forms.ComboBox();
            this.id_txt = new System.Windows.Forms.TextBox();
            this.name_txt = new System.Windows.Forms.TextBox();
            this.pwd_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pl_lbl = new System.Windows.Forms.Label();
            this.id_lbl = new System.Windows.Forms.Label();
            this.name_lbl = new System.Windows.Forms.Label();
            this.associateToCategory_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.WorkerDetails_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_logo
            // 
            this.pb_logo.BackColor = System.Drawing.Color.Transparent;
            this.pb_logo.Image = ((System.Drawing.Image)(resources.GetObject("pb_logo.Image")));
            this.pb_logo.Location = new System.Drawing.Point(8, 11);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(290, 88);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_logo.TabIndex = 2;
            this.pb_logo.TabStop = false;
            this.pb_logo.Click += new System.EventHandler(this.pb_logo_Click);
            // 
            // title_lbl
            // 
            this.title_lbl.AutoSize = true;
            this.title_lbl.BackColor = System.Drawing.Color.Transparent;
            this.title_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.title_lbl.Location = new System.Drawing.Point(183, 182);
            this.title_lbl.Name = "title_lbl";
            this.title_lbl.Size = new System.Drawing.Size(113, 20);
            this.title_lbl.TabIndex = 3;
            this.title_lbl.Text = ":עובדים קיימים";
            // 
            // exsistWorkers_cmb
            // 
            this.exsistWorkers_cmb.FormattingEnabled = true;
            this.exsistWorkers_cmb.Location = new System.Drawing.Point(19, 178);
            this.exsistWorkers_cmb.Name = "exsistWorkers_cmb";
            this.exsistWorkers_cmb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.exsistWorkers_cmb.Size = new System.Drawing.Size(136, 24);
            this.exsistWorkers_cmb.TabIndex = 4;
            // 
            // AddNewWorker_lnkLbl
            // 
            this.AddNewWorker_lnkLbl.AutoSize = true;
            this.AddNewWorker_lnkLbl.BackColor = System.Drawing.Color.Transparent;
            this.AddNewWorker_lnkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.AddNewWorker_lnkLbl.Location = new System.Drawing.Point(161, 238);
            this.AddNewWorker_lnkLbl.Name = "AddNewWorker_lnkLbl";
            this.AddNewWorker_lnkLbl.Size = new System.Drawing.Size(137, 20);
            this.AddNewWorker_lnkLbl.TabIndex = 5;
            this.AddNewWorker_lnkLbl.TabStop = true;
            this.AddNewWorker_lnkLbl.Text = "להוספת עובד חדש";
            this.AddNewWorker_lnkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddNewWorker_lnkLbl_LinkClicked);
            // 
            // WorkerDetails_gb
            // 
            this.WorkerDetails_gb.BackColor = System.Drawing.Color.Transparent;
            this.WorkerDetails_gb.Controls.Add(this.save_btn);
            this.WorkerDetails_gb.Controls.Add(this.cancel_btn);
            this.WorkerDetails_gb.Controls.Add(this.pwd_txt);
            this.WorkerDetails_gb.Controls.Add(this.category_cmb);
            this.WorkerDetails_gb.Controls.Add(this.pl_cmb);
            this.WorkerDetails_gb.Controls.Add(this.id_txt);
            this.WorkerDetails_gb.Controls.Add(this.name_txt);
            this.WorkerDetails_gb.Controls.Add(this.pwd_lbl);
            this.WorkerDetails_gb.Controls.Add(this.label1);
            this.WorkerDetails_gb.Controls.Add(this.pl_lbl);
            this.WorkerDetails_gb.Controls.Add(this.id_lbl);
            this.WorkerDetails_gb.Controls.Add(this.name_lbl);
            this.WorkerDetails_gb.Location = new System.Drawing.Point(19, 284);
            this.WorkerDetails_gb.Name = "WorkerDetails_gb";
            this.WorkerDetails_gb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.WorkerDetails_gb.Size = new System.Drawing.Size(277, 265);
            this.WorkerDetails_gb.TabIndex = 6;
            this.WorkerDetails_gb.TabStop = false;
            this.WorkerDetails_gb.Text = "פרטי העובד";
            this.WorkerDetails_gb.Visible = false;
            // 
            // save_btn
            // 
            this.save_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("save_btn.BackgroundImage")));
            this.save_btn.Location = new System.Drawing.Point(91, 223);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(66, 36);
            this.save_btn.TabIndex = 12;
            this.save_btn.Text = "שמירה";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancel_btn.BackgroundImage")));
            this.cancel_btn.Location = new System.Drawing.Point(19, 223);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(66, 36);
            this.cancel_btn.TabIndex = 11;
            this.cancel_btn.Text = "ביטול";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // pwd_txt
            // 
            this.pwd_txt.Location = new System.Drawing.Point(19, 185);
            this.pwd_txt.Name = "pwd_txt";
            this.pwd_txt.Size = new System.Drawing.Size(120, 22);
            this.pwd_txt.TabIndex = 10;
            // 
            // category_cmb
            // 
            this.category_cmb.FormattingEnabled = true;
            this.category_cmb.Location = new System.Drawing.Point(19, 148);
            this.category_cmb.Name = "category_cmb";
            this.category_cmb.Size = new System.Drawing.Size(120, 24);
            this.category_cmb.TabIndex = 9;
            // 
            // pl_cmb
            // 
            this.pl_cmb.FormattingEnabled = true;
            this.pl_cmb.Location = new System.Drawing.Point(19, 109);
            this.pl_cmb.Name = "pl_cmb";
            this.pl_cmb.Size = new System.Drawing.Size(120, 24);
            this.pl_cmb.TabIndex = 8;
            // 
            // id_txt
            // 
            this.id_txt.Location = new System.Drawing.Point(19, 72);
            this.id_txt.Name = "id_txt";
            this.id_txt.Size = new System.Drawing.Size(120, 22);
            this.id_txt.TabIndex = 7;
            // 
            // name_txt
            // 
            this.name_txt.Location = new System.Drawing.Point(19, 31);
            this.name_txt.Name = "name_txt";
            this.name_txt.Size = new System.Drawing.Size(120, 22);
            this.name_txt.TabIndex = 6;
            // 
            // pwd_lbl
            // 
            this.pwd_lbl.AutoSize = true;
            this.pwd_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pwd_lbl.Location = new System.Drawing.Point(197, 185);
            this.pwd_lbl.Name = "pwd_lbl";
            this.pwd_lbl.Size = new System.Drawing.Size(57, 20);
            this.pwd_lbl.TabIndex = 5;
            this.pwd_lbl.Text = "סיסמא:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(193, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "מחלקה:";
            // 
            // pl_lbl
            // 
            this.pl_lbl.AutoSize = true;
            this.pl_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pl_lbl.Location = new System.Drawing.Point(157, 110);
            this.pl_lbl.Name = "pl_lbl";
            this.pl_lbl.Size = new System.Drawing.Size(97, 20);
            this.pl_lbl.TabIndex = 3;
            this.pl_lbl.Text = "רמת הרשאה:";
            // 
            // id_lbl
            // 
            this.id_lbl.AutoSize = true;
            this.id_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.id_lbl.Location = new System.Drawing.Point(223, 68);
            this.id_lbl.Name = "id_lbl";
            this.id_lbl.Size = new System.Drawing.Size(31, 20);
            this.id_lbl.TabIndex = 2;
            this.id_lbl.Text = "תז:";
            // 
            // name_lbl
            // 
            this.name_lbl.AutoSize = true;
            this.name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.name_lbl.Location = new System.Drawing.Point(218, 31);
            this.name_lbl.Name = "name_lbl";
            this.name_lbl.Size = new System.Drawing.Size(36, 20);
            this.name_lbl.TabIndex = 0;
            this.name_lbl.Text = "שם:";
            // 
            // associateToCategory_lbl
            // 
            this.associateToCategory_lbl.AutoSize = true;
            this.associateToCategory_lbl.BackColor = System.Drawing.Color.Transparent;
            this.associateToCategory_lbl.Location = new System.Drawing.Point(63, 136);
            this.associateToCategory_lbl.Name = "associateToCategory_lbl";
            this.associateToCategory_lbl.Size = new System.Drawing.Size(233, 17);
            this.associateToCategory_lbl.TabIndex = 7;
            this.associateToCategory_lbl.Text = "בחר את העובד שברצונך לשייך לקטגוריה";
            this.associateToCategory_lbl.Visible = false;
            // 
            // AddNewUserM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.associateToCategory_lbl);
            this.Controls.Add(this.WorkerDetails_gb);
            this.Controls.Add(this.AddNewWorker_lnkLbl);
            this.Controls.Add(this.exsistWorkers_cmb);
            this.Controls.Add(this.title_lbl);
            this.Controls.Add(this.pb_logo);
            this.Name = "AddNewUserM";
            this.Size = new System.Drawing.Size(305, 722);
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.WorkerDetails_gb.ResumeLayout(false);
            this.WorkerDetails_gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.Label title_lbl;
        private System.Windows.Forms.ComboBox exsistWorkers_cmb;
        private System.Windows.Forms.LinkLabel AddNewWorker_lnkLbl;
        private System.Windows.Forms.GroupBox WorkerDetails_gb;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.TextBox pwd_txt;
        private System.Windows.Forms.ComboBox category_cmb;
        private System.Windows.Forms.ComboBox pl_cmb;
        private System.Windows.Forms.TextBox id_txt;
        private System.Windows.Forms.TextBox name_txt;
        private System.Windows.Forms.Label pwd_lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pl_lbl;
        private System.Windows.Forms.Label id_lbl;
        private System.Windows.Forms.Label name_lbl;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Label associateToCategory_lbl;
    }
}
