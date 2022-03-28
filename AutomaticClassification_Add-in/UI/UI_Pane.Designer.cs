
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
            this.updateDetails_rb = new System.Windows.Forms.RadioButton();
            this.updateYourDetails_rb = new System.Windows.Forms.RadioButton();
            this.addNewCategory_rb = new System.Windows.Forms.RadioButton();
            this.addNewDM_rd = new System.Windows.Forms.RadioButton();
            this.exit_btn = new System.Windows.Forms.Button();
            this.DepartmentManager_gb = new System.Windows.Forms.GroupBox();
            this.updateYourDetailsDM_rb = new System.Windows.Forms.RadioButton();
            this.addRequestsForExample_rb = new System.Windows.Forms.RadioButton();
            this.exitDM_btn = new System.Windows.Forms.Button();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.password_pl = new System.Windows.Forms.Panel();
            this.welcome_lbl = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.GeneralManager_gb.SuspendLayout();
            this.DepartmentManager_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.password_pl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.managerPwd_lbl.Location = new System.Drawing.Point(146, 19);
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
            this.GeneralManager_gb.BackColor = System.Drawing.Color.Transparent;
            this.GeneralManager_gb.Controls.Add(this.updateDetails_rb);
            this.GeneralManager_gb.Controls.Add(this.updateYourDetails_rb);
            this.GeneralManager_gb.Controls.Add(this.addNewCategory_rb);
            this.GeneralManager_gb.Controls.Add(this.addNewDM_rd);
            this.GeneralManager_gb.Controls.Add(this.exit_btn);
            this.GeneralManager_gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.GeneralManager_gb.ForeColor = System.Drawing.Color.Black;
            this.GeneralManager_gb.Location = new System.Drawing.Point(15, 262);
            this.GeneralManager_gb.Name = "GeneralManager_gb";
            this.GeneralManager_gb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GeneralManager_gb.Size = new System.Drawing.Size(290, 217);
            this.GeneralManager_gb.TabIndex = 6;
            this.GeneralManager_gb.TabStop = false;
            this.GeneralManager_gb.Text = "פעולות מנהל כללי";
            this.GeneralManager_gb.Visible = false;
            // 
            // updateDetails_rb
            // 
            this.updateDetails_rb.AutoSize = true;
            this.updateDetails_rb.Location = new System.Drawing.Point(115, 107);
            this.updateDetails_rb.Name = "updateDetails_rb";
            this.updateDetails_rb.Size = new System.Drawing.Size(164, 22);
            this.updateDetails_rb.TabIndex = 11;
            this.updateDetails_rb.TabStop = true;
            this.updateDetails_rb.Text = "עדכון פרטי עובד קיים";
            this.updateDetails_rb.UseVisualStyleBackColor = true;
            // 
            // updateYourDetails_rb
            // 
            this.updateYourDetails_rb.AutoSize = true;
            this.updateYourDetails_rb.Location = new System.Drawing.Point(172, 140);
            this.updateYourDetails_rb.Name = "updateYourDetails_rb";
            this.updateYourDetails_rb.Size = new System.Drawing.Size(106, 22);
            this.updateYourDetails_rb.TabIndex = 10;
            this.updateYourDetails_rb.TabStop = true;
            this.updateYourDetails_rb.Text = "עדכון פרטיך";
            this.updateYourDetails_rb.UseVisualStyleBackColor = true;
            // 
            // addNewCategory_rb
            // 
            this.addNewCategory_rb.AutoSize = true;
            this.addNewCategory_rb.Location = new System.Drawing.Point(121, 72);
            this.addNewCategory_rb.Name = "addNewCategory_rb";
            this.addNewCategory_rb.Size = new System.Drawing.Size(157, 22);
            this.addNewCategory_rb.TabIndex = 9;
            this.addNewCategory_rb.TabStop = true;
            this.addNewCategory_rb.Text = "הוספת מחלקה חדשה";
            this.addNewCategory_rb.UseVisualStyleBackColor = true;
            this.addNewCategory_rb.CheckedChanged += new System.EventHandler(this.addNewCategory_rb_CheckedChanged);
            // 
            // addNewDM_rd
            // 
            this.addNewDM_rd.AutoSize = true;
            this.addNewDM_rd.Location = new System.Drawing.Point(96, 38);
            this.addNewDM_rd.Name = "addNewDM_rd";
            this.addNewDM_rd.Size = new System.Drawing.Size(183, 22);
            this.addNewDM_rd.TabIndex = 8;
            this.addNewDM_rd.TabStop = true;
            this.addNewDM_rd.Text = "הוספת מנהל מחלקה חדש";
            this.addNewDM_rd.UseVisualStyleBackColor = true;
            this.addNewDM_rd.CheckedChanged += new System.EventHandler(this.addNewDM_rd_CheckedChanged);
            // 
            // exit_btn
            // 
            this.exit_btn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exit_btn.Image = ((System.Drawing.Image)(resources.GetObject("exit_btn.Image")));
            this.exit_btn.Location = new System.Drawing.Point(12, 178);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(52, 27);
            this.exit_btn.TabIndex = 7;
            this.exit_btn.Text = "יציאה";
            this.exit_btn.UseVisualStyleBackColor = false;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // DepartmentManager_gb
            // 
            this.DepartmentManager_gb.BackColor = System.Drawing.Color.Transparent;
            this.DepartmentManager_gb.Controls.Add(this.updateYourDetailsDM_rb);
            this.DepartmentManager_gb.Controls.Add(this.addRequestsForExample_rb);
            this.DepartmentManager_gb.Controls.Add(this.exitDM_btn);
            this.DepartmentManager_gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DepartmentManager_gb.ForeColor = System.Drawing.Color.Black;
            this.DepartmentManager_gb.Location = new System.Drawing.Point(15, 485);
            this.DepartmentManager_gb.Name = "DepartmentManager_gb";
            this.DepartmentManager_gb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DepartmentManager_gb.Size = new System.Drawing.Size(290, 136);
            this.DepartmentManager_gb.TabIndex = 10;
            this.DepartmentManager_gb.TabStop = false;
            this.DepartmentManager_gb.Text = "פעולות מנהל";
            this.DepartmentManager_gb.Visible = false;
            // 
            // updateYourDetailsDM_rb
            // 
            this.updateYourDetailsDM_rb.AutoSize = true;
            this.updateYourDetailsDM_rb.Location = new System.Drawing.Point(171, 69);
            this.updateYourDetailsDM_rb.Name = "updateYourDetailsDM_rb";
            this.updateYourDetailsDM_rb.Size = new System.Drawing.Size(106, 22);
            this.updateYourDetailsDM_rb.TabIndex = 9;
            this.updateYourDetailsDM_rb.TabStop = true;
            this.updateYourDetailsDM_rb.Text = "עדכון פרטיך";
            this.updateYourDetailsDM_rb.UseVisualStyleBackColor = true;
            // 
            // addRequestsForExample_rb
            // 
            this.addRequestsForExample_rb.AutoSize = true;
            this.addRequestsForExample_rb.Location = new System.Drawing.Point(68, 38);
            this.addRequestsForExample_rb.Name = "addRequestsForExample_rb";
            this.addRequestsForExample_rb.Size = new System.Drawing.Size(209, 22);
            this.addRequestsForExample_rb.TabIndex = 8;
            this.addRequestsForExample_rb.TabStop = true;
            this.addRequestsForExample_rb.Text = "הוספת פניות לדוגמא למחלקה";
            this.addRequestsForExample_rb.UseVisualStyleBackColor = true;
            // 
            // exitDM_btn
            // 
            this.exitDM_btn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exitDM_btn.Image = ((System.Drawing.Image)(resources.GetObject("exitDM_btn.Image")));
            this.exitDM_btn.Location = new System.Drawing.Point(7, 101);
            this.exitDM_btn.Name = "exitDM_btn";
            this.exitDM_btn.Size = new System.Drawing.Size(52, 27);
            this.exitDM_btn.TabIndex = 7;
            this.exitDM_btn.Text = "יציאה";
            this.exitDM_btn.UseVisualStyleBackColor = false;
            this.exitDM_btn.Click += new System.EventHandler(this.exitDM_btn_Click);
            // 
            // pb_logo
            // 
            this.pb_logo.BackColor = System.Drawing.Color.Transparent;
            this.pb_logo.Image = ((System.Drawing.Image)(resources.GetObject("pb_logo.Image")));
            this.pb_logo.Location = new System.Drawing.Point(15, 11);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(290, 88);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_logo.TabIndex = 0;
            this.pb_logo.TabStop = false;
            this.pb_logo.Click += new System.EventHandler(this.pb_logo_Click);
            // 
            // password_pl
            // 
            this.password_pl.BackColor = System.Drawing.Color.Transparent;
            this.password_pl.Controls.Add(this.managerPwd_lbl);
            this.password_pl.Controls.Add(this.managerPwd_txt);
            this.password_pl.Controls.Add(this.ok_btn);
            this.password_pl.Location = new System.Drawing.Point(15, 113);
            this.password_pl.Name = "password_pl";
            this.password_pl.Size = new System.Drawing.Size(290, 83);
            this.password_pl.TabIndex = 7;
            // 
            // welcome_lbl
            // 
            this.welcome_lbl.AutoSize = true;
            this.welcome_lbl.BackColor = System.Drawing.Color.Transparent;
            this.welcome_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.welcome_lbl.Location = new System.Drawing.Point(209, 210);
            this.welcome_lbl.Name = "welcome_lbl";
            this.welcome_lbl.Size = new System.Drawing.Size(87, 20);
            this.welcome_lbl.TabIndex = 8;
            this.welcome_lbl.Text = "שלום ------";
            this.welcome_lbl.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // UI_Pane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.DepartmentManager_gb);
            this.Controls.Add(this.welcome_lbl);
            this.Controls.Add(this.password_pl);
            this.Controls.Add(this.GeneralManager_gb);
            this.Controls.Add(this.pb_logo);
            this.Name = "UI_Pane";
            this.Size = new System.Drawing.Size(319, 681);
            this.GeneralManager_gb.ResumeLayout(false);
            this.GeneralManager_gb.PerformLayout();
            this.DepartmentManager_gb.ResumeLayout(false);
            this.DepartmentManager_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.password_pl.ResumeLayout(false);
            this.password_pl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private System.Windows.Forms.GroupBox DepartmentManager_gb;
        private System.Windows.Forms.RadioButton addRequestsForExample_rb;
        private System.Windows.Forms.Button exitDM_btn;
        private System.Windows.Forms.RadioButton updateDetails_rb;
        private System.Windows.Forms.RadioButton updateYourDetails_rb;
        private System.Windows.Forms.RadioButton updateYourDetailsDM_rb;
    }
}
