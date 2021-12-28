
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
            this.btn_invokeFuncGetNewMail.Location = new System.Drawing.Point(589, 96);
            this.btn_invokeFuncGetNewMail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_invokeFuncGetNewMail.Name = "btn_invokeFuncGetNewMail";
            this.btn_invokeFuncGetNewMail.Size = new System.Drawing.Size(131, 59);
            this.btn_invokeFuncGetNewMail.TabIndex = 0;
            this.btn_invokeFuncGetNewMail.Text = "מפעיל את הפונקציה קבלת מייל חדש";
            this.btn_invokeFuncGetNewMail.UseVisualStyleBackColor = true;
            this.btn_invokeFuncGetNewMail.Click += new System.EventHandler(this.btn_invokeFuncGetNewMail_Click);
            // 
            // btn_title
            // 
            this.btn_title.AutoSize = true;
            this.btn_title.Location = new System.Drawing.Point(364, 34);
            this.btn_title.Name = "btn_title";
            this.btn_title.Size = new System.Drawing.Size(80, 16);
            this.btn_title.TabIndex = 1;
            this.btn_title.Text = "ניסויי הרצות";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(415, 96);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "בדיקת הסרה מרשימה ע\"י פרידיקייט";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(234, 96);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 59);
            this.button2.TabIndex = 3;
            this.button2.Text = "בדיקה האם יש כפולים בטבלת מילים";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_title);
            this.Controls.Add(this.btn_invokeFuncGetNewMail);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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

