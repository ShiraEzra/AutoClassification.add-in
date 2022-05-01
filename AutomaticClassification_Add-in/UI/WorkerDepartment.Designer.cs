
namespace AutomaticClassification_Add_in.UI
{
    partial class WorkerDepartment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerDepartment));
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.exsistWorkers_cmb = new System.Windows.Forms.ComboBox();
            this.title_lbl = new System.Windows.Forms.Label();
            this.WorkerDetails_gb = new System.Windows.Forms.GroupBox();
            this.ok_lbl = new System.Windows.Forms.Label();
            this.delete_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.category_cmb = new System.Windows.Forms.ComboBox();
            this.name_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.name_lbl = new System.Windows.Forms.Label();
            this.update_pl = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.back_lnkLbl = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.WorkerDetails_gb.SuspendLayout();
            this.update_pl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_logo
            // 
            this.pb_logo.BackColor = System.Drawing.Color.Transparent;
            this.pb_logo.Image = ((System.Drawing.Image)(resources.GetObject("pb_logo.Image")));
            this.pb_logo.Location = new System.Drawing.Point(11, 10);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(290, 88);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_logo.TabIndex = 1;
            this.pb_logo.TabStop = false;
            this.pb_logo.Click += new System.EventHandler(this.pb_logo_Click);
            // 
            // exsistWorkers_cmb
            // 
            this.exsistWorkers_cmb.FormattingEnabled = true;
            this.exsistWorkers_cmb.Location = new System.Drawing.Point(10, 24);
            this.exsistWorkers_cmb.Name = "exsistWorkers_cmb";
            this.exsistWorkers_cmb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.exsistWorkers_cmb.Size = new System.Drawing.Size(136, 24);
            this.exsistWorkers_cmb.TabIndex = 16;
            this.exsistWorkers_cmb.SelectedIndexChanged += new System.EventHandler(this.exsistWorkers_cmb_SelectedIndexChanged);
            // 
            // title_lbl
            // 
            this.title_lbl.AutoSize = true;
            this.title_lbl.BackColor = System.Drawing.Color.Transparent;
            this.title_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.title_lbl.Location = new System.Drawing.Point(161, 28);
            this.title_lbl.Name = "title_lbl";
            this.title_lbl.Size = new System.Drawing.Size(113, 20);
            this.title_lbl.TabIndex = 15;
            this.title_lbl.Text = ":עובדים קיימים";
            // 
            // WorkerDetails_gb
            // 
            this.WorkerDetails_gb.BackColor = System.Drawing.Color.Transparent;
            this.WorkerDetails_gb.Controls.Add(this.ok_lbl);
            this.WorkerDetails_gb.Controls.Add(this.delete_btn);
            this.WorkerDetails_gb.Controls.Add(this.save_btn);
            this.WorkerDetails_gb.Controls.Add(this.cancel_btn);
            this.WorkerDetails_gb.Controls.Add(this.category_cmb);
            this.WorkerDetails_gb.Controls.Add(this.name_txt);
            this.WorkerDetails_gb.Controls.Add(this.label1);
            this.WorkerDetails_gb.Controls.Add(this.name_lbl);
            this.WorkerDetails_gb.Location = new System.Drawing.Point(8, 14);
            this.WorkerDetails_gb.Name = "WorkerDetails_gb";
            this.WorkerDetails_gb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.WorkerDetails_gb.Size = new System.Drawing.Size(257, 240);
            this.WorkerDetails_gb.TabIndex = 17;
            this.WorkerDetails_gb.TabStop = false;
            this.WorkerDetails_gb.Text = "פרטי העובד";
            // 
            // ok_lbl
            // 
            this.ok_lbl.AutoSize = true;
            this.ok_lbl.Font = new System.Drawing.Font("Microsoft Yi Baiti", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ok_lbl.Location = new System.Drawing.Point(11, 209);
            this.ok_lbl.Name = "ok_lbl";
            this.ok_lbl.Size = new System.Drawing.Size(164, 19);
            this.ok_lbl.TabIndex = 14;
            this.ok_lbl.Text = "הפעולה בוצעה בהצלחה";
            this.ok_lbl.Visible = false;
            // 
            // delete_btn
            // 
            this.delete_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delete_btn.BackgroundImage")));
            this.delete_btn.Location = new System.Drawing.Point(155, 162);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(66, 36);
            this.delete_btn.TabIndex = 13;
            this.delete_btn.Text = "מחיקה";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Visible = false;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("save_btn.BackgroundImage")));
            this.save_btn.Location = new System.Drawing.Point(83, 162);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(66, 36);
            this.save_btn.TabIndex = 12;
            this.save_btn.Text = "הוספה";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancel_btn.BackgroundImage")));
            this.cancel_btn.Location = new System.Drawing.Point(11, 162);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(66, 36);
            this.cancel_btn.TabIndex = 11;
            this.cancel_btn.Text = "ביטול";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // category_cmb
            // 
            this.category_cmb.FormattingEnabled = true;
            this.category_cmb.Location = new System.Drawing.Point(19, 70);
            this.category_cmb.Name = "category_cmb";
            this.category_cmb.Size = new System.Drawing.Size(120, 24);
            this.category_cmb.TabIndex = 9;
            // 
            // name_txt
            // 
            this.name_txt.Location = new System.Drawing.Point(19, 31);
            this.name_txt.Name = "name_txt";
            this.name_txt.Size = new System.Drawing.Size(120, 22);
            this.name_txt.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(193, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "מחלקה:";
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
            // update_pl
            // 
            this.update_pl.BackColor = System.Drawing.Color.Transparent;
            this.update_pl.Controls.Add(this.title_lbl);
            this.update_pl.Controls.Add(this.exsistWorkers_cmb);
            this.update_pl.Location = new System.Drawing.Point(24, 139);
            this.update_pl.Name = "update_pl";
            this.update_pl.Size = new System.Drawing.Size(277, 71);
            this.update_pl.TabIndex = 18;
            this.update_pl.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.WorkerDetails_gb);
            this.panel1.Location = new System.Drawing.Point(24, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 450);
            this.panel1.TabIndex = 19;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // back_lnkLbl
            // 
            this.back_lnkLbl.AutoSize = true;
            this.back_lnkLbl.BackColor = System.Drawing.Color.Transparent;
            this.back_lnkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.back_lnkLbl.Location = new System.Drawing.Point(164, 107);
            this.back_lnkLbl.Name = "back_lnkLbl";
            this.back_lnkLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.back_lnkLbl.Size = new System.Drawing.Size(126, 20);
            this.back_lnkLbl.TabIndex = 20;
            this.back_lnkLbl.TabStop = true;
            this.back_lnkLbl.Text = "חזרה לדף הקודם";
            this.back_lnkLbl.Visible = false;
            this.back_lnkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.back_lnkLbl_LinkClicked);
            // 
            // WorkerDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.back_lnkLbl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.update_pl);
            this.Controls.Add(this.pb_logo);
            this.Name = "WorkerDepartment";
            this.Size = new System.Drawing.Size(310, 742);
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.WorkerDetails_gb.ResumeLayout(false);
            this.WorkerDetails_gb.PerformLayout();
            this.update_pl.ResumeLayout(false);
            this.update_pl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.ComboBox exsistWorkers_cmb;
        private System.Windows.Forms.Label title_lbl;
        private System.Windows.Forms.GroupBox WorkerDetails_gb;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.ComboBox category_cmb;
        private System.Windows.Forms.TextBox name_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label name_lbl;
        private System.Windows.Forms.Panel update_pl;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ok_lbl;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.LinkLabel back_lnkLbl;
    }
}
