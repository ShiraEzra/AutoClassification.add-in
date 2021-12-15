
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
            this.SuspendLayout();
            // 
            // btn_invokeFuncGetNewMail
            // 
            this.btn_invokeFuncGetNewMail.Location = new System.Drawing.Point(590, 96);
            this.btn_invokeFuncGetNewMail.Name = "btn_invokeFuncGetNewMail";
            this.btn_invokeFuncGetNewMail.Size = new System.Drawing.Size(130, 59);
            this.btn_invokeFuncGetNewMail.TabIndex = 0;
            this.btn_invokeFuncGetNewMail.Text = "מפעיל את הפונקציה קבלת מייל חדש";
            this.btn_invokeFuncGetNewMail.UseVisualStyleBackColor = true;
            this.btn_invokeFuncGetNewMail.Click += new System.EventHandler(this.btn_invokeFuncGetNewMail_Click);
            // 
            // btn_title
            // 
            this.btn_title.AutoSize = true;
            this.btn_title.Location = new System.Drawing.Point(364, 35);
            this.btn_title.Name = "btn_title";
            this.btn_title.Size = new System.Drawing.Size(80, 16);
            this.btn_title.TabIndex = 1;
            this.btn_title.Text = "ניסויי הרצות";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_title);
            this.Controls.Add(this.btn_invokeFuncGetNewMail);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_invokeFuncGetNewMail;
        private System.Windows.Forms.Label btn_title;
    }
}

