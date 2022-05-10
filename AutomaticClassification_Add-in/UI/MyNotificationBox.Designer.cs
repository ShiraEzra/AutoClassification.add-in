
namespace AutomaticClassification_Add_in.UI
{
    partial class MyNotificationBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyNotificationBox));
            this.notification_richTxt = new System.Windows.Forms.RichTextBox();
            this.ok_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notification_richTxt
            // 
            this.notification_richTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.notification_richTxt.Location = new System.Drawing.Point(30, 42);
            this.notification_richTxt.Name = "notification_richTxt";
            this.notification_richTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.notification_richTxt.Size = new System.Drawing.Size(200, 219);
            this.notification_richTxt.TabIndex = 0;
            this.notification_richTxt.Text = "";
            // 
            // ok_btn
            // 
            this.ok_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ok_btn.BackgroundImage")));
            this.ok_btn.Location = new System.Drawing.Point(30, 283);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(75, 30);
            this.ok_btn.TabIndex = 1;
            this.ok_btn.Text = "אוקיי";
            this.ok_btn.UseVisualStyleBackColor = true;
            // 
            // MyNotificationBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 352);
            this.Controls.Add(this.ok_btn);
            this.Controls.Add(this.notification_richTxt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MyNotificationBox";
            this.Text = "אחוזי דיוק המערכת ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox notification_richTxt;
        private System.Windows.Forms.Button ok_btn;
    }
}