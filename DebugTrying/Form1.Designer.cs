
namespace DebugTrying
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_invokeFuncGetNewMail = new System.Windows.Forms.Button();
            this.btn_title = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_invokeFuncGetNewMail
            // 
            this.btn_invokeFuncGetNewMail.Location = new System.Drawing.Point(443, 78);
            this.btn_invokeFuncGetNewMail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_invokeFuncGetNewMail.Name = "btn_invokeFuncGetNewMail";
            this.btn_invokeFuncGetNewMail.Size = new System.Drawing.Size(98, 48);
            this.btn_invokeFuncGetNewMail.TabIndex = 0;
            this.btn_invokeFuncGetNewMail.Text = "מפעיל את הפונקציה קבלת מייל חדש";
            this.btn_invokeFuncGetNewMail.UseVisualStyleBackColor = true;
            this.btn_invokeFuncGetNewMail.Click += new System.EventHandler(this.btn_invokeFuncGetNewMail_Click);
            // 
            // btn_title
            // 
            this.btn_title.AutoSize = true;
            this.btn_title.Location = new System.Drawing.Point(273, 28);
            this.btn_title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btn_title.Name = "btn_title";
            this.btn_title.Size = new System.Drawing.Size(74, 13);
            this.btn_title.TabIndex = 1;
            this.btn_title.Text = "ניסויי הרצות";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(311, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "בדיקת הסרה מרשימה ע\"י פרידיקייט";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(176, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 48);
            this.button2.TabIndex = 3;
            this.button2.Text = "בדיקה האם יש כפולים בטבלת מילים";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_title);
            this.Controls.Add(this.btn_invokeFuncGetNewMail);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_invokeFuncGetNewMail;
        private System.Windows.Forms.Label btn_title;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

