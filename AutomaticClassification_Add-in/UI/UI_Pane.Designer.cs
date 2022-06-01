
namespace AutomaticClassification_Add_in
{
    partial class UI_Pane
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Pane));
            this.managerPwd_txt = new System.Windows.Forms.TextBox();
            this.managerPwd_lbl = new System.Windows.Forms.Label();
            this.ok_btn = new System.Windows.Forms.Button();
            this.GeneralManager_gb = new System.Windows.Forms.GroupBox();
            this.addTaggingToDepartment_rd = new System.Windows.Forms.RadioButton();
            this.AddNewManager_rd = new System.Windows.Forms.RadioButton();
            this.updateDetails_rb = new System.Windows.Forms.RadioButton();
            this.updateYourDetails_rb = new System.Windows.Forms.RadioButton();
            this.addNewCategory_rb = new System.Windows.Forms.RadioButton();
            this.addNewDM_rd = new System.Windows.Forms.RadioButton();
            this.exit_btn = new System.Windows.Forms.Button();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.password_pl = new System.Windows.Forms.Panel();
            this.welcome_lbl = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.firstTime_gb = new System.Windows.Forms.GroupBox();
            this.firstTagging_rd = new System.Windows.Forms.RadioButton();
            this.signInManager_rd = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.GeneralManager_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.password_pl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.firstTime_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // managerPwd_txt
            // 
            this.managerPwd_txt.Location = new System.Drawing.Point(8, 17);
            this.managerPwd_txt.Multiline = true;
            this.managerPwd_txt.Name = "managerPwd_txt";
            this.managerPwd_txt.PasswordChar = '*';
            this.managerPwd_txt.Size = new System.Drawing.Size(123, 25);
            this.managerPwd_txt.TabIndex = 3;
            // 
            // managerPwd_lbl
            // 
            this.managerPwd_lbl.AutoSize = true;
            this.managerPwd_lbl.BackColor = System.Drawing.Color.Transparent;
            this.managerPwd_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.managerPwd_lbl.Location = new System.Drawing.Point(136, 19);
            this.managerPwd_lbl.Name = "managerPwd_lbl";
            this.managerPwd_lbl.Size = new System.Drawing.Size(131, 20);
            this.managerPwd_lbl.TabIndex = 4;
            this.managerPwd_lbl.Text = ":הקש סיסמת מנהל";
            // 
            // ok_btn
            // 
            this.ok_btn.BackColor = System.Drawing.Color.Transparent;
            this.ok_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ok_btn.Image = ((System.Drawing.Image)(resources.GetObject("ok_btn.Image")));
            this.ok_btn.Location = new System.Drawing.Point(8, 48);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(52, 27);
            this.ok_btn.TabIndex = 5;
            this.ok_btn.Text = "OK";
            this.ok_btn.UseVisualStyleBackColor = false;
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // GeneralManager_gb
            // 
            this.GeneralManager_gb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GeneralManager_gb.BackColor = System.Drawing.Color.Transparent;
            this.GeneralManager_gb.Controls.Add(this.addTaggingToDepartment_rd);
            this.GeneralManager_gb.Controls.Add(this.AddNewManager_rd);
            this.GeneralManager_gb.Controls.Add(this.updateDetails_rb);
            this.GeneralManager_gb.Controls.Add(this.updateYourDetails_rb);
            this.GeneralManager_gb.Controls.Add(this.addNewCategory_rb);
            this.GeneralManager_gb.Controls.Add(this.addNewDM_rd);
            this.GeneralManager_gb.Controls.Add(this.exit_btn);
            this.GeneralManager_gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.GeneralManager_gb.ForeColor = System.Drawing.Color.Black;
            this.GeneralManager_gb.Location = new System.Drawing.Point(15, 300);
            this.GeneralManager_gb.Name = "GeneralManager_gb";
            this.GeneralManager_gb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GeneralManager_gb.Size = new System.Drawing.Size(274, 254);
            this.GeneralManager_gb.TabIndex = 6;
            this.GeneralManager_gb.TabStop = false;
            this.GeneralManager_gb.Text = " פעולות מנהל";
            this.GeneralManager_gb.Visible = false;
            // 
            // addTaggingToDepartment_rd
            // 
            this.addTaggingToDepartment_rd.AutoSize = true;
            this.addTaggingToDepartment_rd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.addTaggingToDepartment_rd.Location = new System.Drawing.Point(41, 127);
            this.addTaggingToDepartment_rd.Name = "addTaggingToDepartment_rd";
            this.addTaggingToDepartment_rd.Size = new System.Drawing.Size(214, 24);
            this.addTaggingToDepartment_rd.TabIndex = 13;
            this.addTaggingToDepartment_rd.TabStop = true;
            this.addTaggingToDepartment_rd.Text = "הוספת נתוני אימון למחלקה";
            this.addTaggingToDepartment_rd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addTaggingToDepartment_rd.UseVisualStyleBackColor = true;
            this.addTaggingToDepartment_rd.CheckedChanged += new System.EventHandler(this.addTaggingToDepartment_rd_CheckedChanged);
            // 
            // AddNewManager_rd
            // 
            this.AddNewManager_rd.AutoSize = true;
            this.AddNewManager_rd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.AddNewManager_rd.Location = new System.Drawing.Point(111, 70);
            this.AddNewManager_rd.Name = "AddNewManager_rd";
            this.AddNewManager_rd.Size = new System.Drawing.Size(148, 24);
            this.AddNewManager_rd.TabIndex = 12;
            this.AddNewManager_rd.TabStop = true;
            this.AddNewManager_rd.Text = "הוספת מנהל חדש";
            this.AddNewManager_rd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AddNewManager_rd.UseVisualStyleBackColor = true;
            this.AddNewManager_rd.CheckedChanged += new System.EventHandler(this.AddNewManager_rd_CheckedChanged);
            // 
            // updateDetails_rb
            // 
            this.updateDetails_rb.AutoSize = true;
            this.updateDetails_rb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.updateDetails_rb.Location = new System.Drawing.Point(55, 156);
            this.updateDetails_rb.Name = "updateDetails_rb";
            this.updateDetails_rb.Size = new System.Drawing.Size(205, 24);
            this.updateDetails_rb.TabIndex = 11;
            this.updateDetails_rb.TabStop = true;
            this.updateDetails_rb.Text = "עדכון / מחיקת עובד קיים";
            this.updateDetails_rb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.updateDetails_rb.UseVisualStyleBackColor = true;
            this.updateDetails_rb.CheckedChanged += new System.EventHandler(this.updateDetails_rb_CheckedChanged);
            // 
            // updateYourDetails_rb
            // 
            this.updateYourDetails_rb.AutoSize = true;
            this.updateYourDetails_rb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.updateYourDetails_rb.Location = new System.Drawing.Point(143, 186);
            this.updateYourDetails_rb.Name = "updateYourDetails_rb";
            this.updateYourDetails_rb.Size = new System.Drawing.Size(119, 24);
            this.updateYourDetails_rb.TabIndex = 10;
            this.updateYourDetails_rb.TabStop = true;
            this.updateYourDetails_rb.Text = "עדכון פרטיך";
            this.updateYourDetails_rb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.updateYourDetails_rb.UseVisualStyleBackColor = true;
            this.updateYourDetails_rb.CheckedChanged += new System.EventHandler(this.updateYourDetails_rb_CheckedChanged);
            // 
            // addNewCategory_rb
            // 
            this.addNewCategory_rb.AutoSize = true;
            this.addNewCategory_rb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.addNewCategory_rb.Location = new System.Drawing.Point(87, 100);
            this.addNewCategory_rb.Name = "addNewCategory_rb";
            this.addNewCategory_rb.Size = new System.Drawing.Size(170, 24);
            this.addNewCategory_rb.TabIndex = 9;
            this.addNewCategory_rb.TabStop = true;
            this.addNewCategory_rb.Text = "הוספת מחלקה חדשה";
            this.addNewCategory_rb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addNewCategory_rb.UseVisualStyleBackColor = true;
            this.addNewCategory_rb.CheckedChanged += new System.EventHandler(this.addNewCategory_rb_CheckedChanged);
            // 
            // addNewDM_rd
            // 
            this.addNewDM_rd.AutoSize = true;
            this.addNewDM_rd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.addNewDM_rd.Location = new System.Drawing.Point(84, 40);
            this.addNewDM_rd.Name = "addNewDM_rd";
            this.addNewDM_rd.Size = new System.Drawing.Size(173, 24);
            this.addNewDM_rd.TabIndex = 8;
            this.addNewDM_rd.TabStop = true;
            this.addNewDM_rd.Text = "הוספת אחראי מחלקה";
            this.addNewDM_rd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addNewDM_rd.UseVisualStyleBackColor = true;
            this.addNewDM_rd.CheckedChanged += new System.EventHandler(this.addNewDM_rd_CheckedChanged);
            // 
            // exit_btn
            // 
            this.exit_btn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exit_btn.Image = ((System.Drawing.Image)(resources.GetObject("exit_btn.Image")));
            this.exit_btn.Location = new System.Drawing.Point(12, 212);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(60, 31);
            this.exit_btn.TabIndex = 7;
            this.exit_btn.Text = "יציאה";
            this.exit_btn.UseVisualStyleBackColor = false;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // pb_logo
            // 
            this.pb_logo.BackColor = System.Drawing.Color.Transparent;
            this.pb_logo.Image = ((System.Drawing.Image)(resources.GetObject("pb_logo.Image")));
            this.pb_logo.Location = new System.Drawing.Point(15, 11);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(274, 88);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_logo.TabIndex = 0;
            this.pb_logo.TabStop = false;
            // 
            // password_pl
            // 
            this.password_pl.BackColor = System.Drawing.Color.Transparent;
            this.password_pl.Controls.Add(this.managerPwd_lbl);
            this.password_pl.Controls.Add(this.managerPwd_txt);
            this.password_pl.Controls.Add(this.ok_btn);
            this.password_pl.Location = new System.Drawing.Point(15, 142);
            this.password_pl.Name = "password_pl";
            this.password_pl.Size = new System.Drawing.Size(274, 83);
            this.password_pl.TabIndex = 7;
            this.password_pl.Visible = false;
            // 
            // welcome_lbl
            // 
            this.welcome_lbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.welcome_lbl.AutoSize = true;
            this.welcome_lbl.BackColor = System.Drawing.Color.Transparent;
            this.welcome_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.welcome_lbl.Location = new System.Drawing.Point(205, 228);
            this.welcome_lbl.Name = "welcome_lbl";
            this.welcome_lbl.Size = new System.Drawing.Size(84, 20);
            this.welcome_lbl.TabIndex = 8;
            this.welcome_lbl.Text = "שלום ----";
            this.welcome_lbl.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // firstTime_gb
            // 
            this.firstTime_gb.BackColor = System.Drawing.Color.Transparent;
            this.firstTime_gb.Controls.Add(this.firstTagging_rd);
            this.firstTime_gb.Controls.Add(this.signInManager_rd);
            this.firstTime_gb.Location = new System.Drawing.Point(15, 585);
            this.firstTime_gb.Name = "firstTime_gb";
            this.firstTime_gb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.firstTime_gb.Size = new System.Drawing.Size(274, 101);
            this.firstTime_gb.TabIndex = 10;
            this.firstTime_gb.TabStop = false;
            this.firstTime_gb.Text = "להפעלת התוסף - בצע פעולות אלו";
            // 
            // firstTagging_rd
            // 
            this.firstTagging_rd.AutoSize = true;
            this.firstTagging_rd.Location = new System.Drawing.Point(37, 63);
            this.firstTagging_rd.Name = "firstTagging_rd";
            this.firstTagging_rd.Size = new System.Drawing.Size(223, 21);
            this.firstTagging_rd.TabIndex = 14;
            this.firstTagging_rd.TabStop = true;
            this.firstTagging_rd.Text = " תיוג ראשוני - למידת המחלקות-----";
            this.firstTagging_rd.UseVisualStyleBackColor = true;
            this.firstTagging_rd.CheckedChanged += new System.EventHandler(this.firstTagging_rd_CheckedChanged);
            // 
            // signInManager_rd
            // 
            this.signInManager_rd.AutoSize = true;
            this.signInManager_rd.Location = new System.Drawing.Point(157, 36);
            this.signInManager_rd.Name = "signInManager_rd";
            this.signInManager_rd.Size = new System.Drawing.Size(102, 21);
            this.signInManager_rd.TabIndex = 13;
            this.signInManager_rd.TabStop = true;
            this.signInManager_rd.Text = "רישום מנהל -";
            this.signInManager_rd.UseVisualStyleBackColor = true;
            this.signInManager_rd.CheckedChanged += new System.EventHandler(this.signInManager_rd_CheckedChanged);
            // 
            // UI_Pane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.firstTime_gb);
            this.Controls.Add(this.welcome_lbl);
            this.Controls.Add(this.password_pl);
            this.Controls.Add(this.GeneralManager_gb);
            this.Controls.Add(this.pb_logo);
            this.Name = "UI_Pane";
            this.Size = new System.Drawing.Size(306, 851);
            this.GeneralManager_gb.ResumeLayout(false);
            this.GeneralManager_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.password_pl.ResumeLayout(false);
            this.password_pl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.firstTime_gb.ResumeLayout(false);
            this.firstTime_gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox managerPwd_txt;
        private System.Windows.Forms.Label managerPwd_lbl;
        private System.Windows.Forms.Button ok_btn;
        private System.Windows.Forms.GroupBox GeneralManager_gb;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.Panel password_pl;
        private System.Windows.Forms.Label welcome_lbl;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.RadioButton addNewCategory_rb;
        private System.Windows.Forms.RadioButton addNewDM_rd;
        private System.Windows.Forms.RadioButton updateDetails_rb;
        private System.Windows.Forms.RadioButton updateYourDetails_rb;
        private System.Windows.Forms.RadioButton AddNewManager_rd;
        private System.Windows.Forms.RadioButton addTaggingToDepartment_rd;
        private System.Windows.Forms.GroupBox firstTime_gb;
        private System.Windows.Forms.RadioButton firstTagging_rd;
        private System.Windows.Forms.RadioButton signInManager_rd;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
