
namespace AutomaticClassification_Add_in.UI
{
    partial class GeneralManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralManager));
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.managerDetails_gb = new System.Windows.Forms.GroupBox();
            this.save_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.pwd_txt = new System.Windows.Forms.TextBox();
            this.id_txt = new System.Windows.Forms.TextBox();
            this.name_txt = new System.Windows.Forms.TextBox();
            this.pwd_lbl = new System.Windows.Forms.Label();
            this.id_lbl = new System.Windows.Forms.Label();
            this.name_lbl = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.managerDetails_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            // managerDetails_gb
            // 
            this.managerDetails_gb.BackColor = System.Drawing.Color.Transparent;
            this.managerDetails_gb.Controls.Add(this.save_btn);
            this.managerDetails_gb.Controls.Add(this.cancel_btn);
            this.managerDetails_gb.Controls.Add(this.pwd_txt);
            this.managerDetails_gb.Controls.Add(this.id_txt);
            this.managerDetails_gb.Controls.Add(this.name_txt);
            this.managerDetails_gb.Controls.Add(this.pwd_lbl);
            this.managerDetails_gb.Controls.Add(this.id_lbl);
            this.managerDetails_gb.Controls.Add(this.name_lbl);
            this.managerDetails_gb.Location = new System.Drawing.Point(21, 175);
            this.managerDetails_gb.Name = "managerDetails_gb";
            this.managerDetails_gb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.managerDetails_gb.Size = new System.Drawing.Size(277, 229);
            this.managerDetails_gb.TabIndex = 6;
            this.managerDetails_gb.TabStop = false;
            this.managerDetails_gb.Text = "פרטי המנהל";
            this.managerDetails_gb.Visible = false;
            // 
            // save_btn
            // 
            this.save_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("save_btn.BackgroundImage")));
            this.save_btn.Location = new System.Drawing.Point(86, 173);
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
            this.cancel_btn.Location = new System.Drawing.Point(14, 173);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(66, 36);
            this.cancel_btn.TabIndex = 11;
            this.cancel_btn.Text = "ביטול";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // pwd_txt
            // 
            this.pwd_txt.Location = new System.Drawing.Point(19, 113);
            this.pwd_txt.Name = "pwd_txt";
            this.pwd_txt.Size = new System.Drawing.Size(120, 22);
            this.pwd_txt.TabIndex = 10;
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
            this.pwd_lbl.Location = new System.Drawing.Point(197, 113);
            this.pwd_lbl.Name = "pwd_lbl";
            this.pwd_lbl.Size = new System.Drawing.Size(57, 20);
            this.pwd_lbl.TabIndex = 5;
            this.pwd_lbl.Text = "סיסמא:";
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // GeneralManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.managerDetails_gb);
            this.Controls.Add(this.pb_logo);
            this.Name = "GeneralManager";
            this.Size = new System.Drawing.Size(305, 722);
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.managerDetails_gb.ResumeLayout(false);
            this.managerDetails_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.GroupBox managerDetails_gb;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.TextBox pwd_txt;
        private System.Windows.Forms.TextBox id_txt;
        private System.Windows.Forms.TextBox name_txt;
        private System.Windows.Forms.Label pwd_lbl;
        private System.Windows.Forms.Label id_lbl;
        private System.Windows.Forms.Label name_lbl;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
