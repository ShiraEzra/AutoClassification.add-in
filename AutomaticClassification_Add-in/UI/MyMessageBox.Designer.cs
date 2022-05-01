
namespace AutomaticClassification_Add_in.UI
{
    partial class MyMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyMessageBox));
            this.btns_pl = new System.Windows.Forms.Panel();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.ok_btn = new System.Windows.Forms.Button();
            this.quest_lbl = new System.Windows.Forms.Label();
            this.btns_pl.SuspendLayout();
            this.SuspendLayout();
            // 
            // btns_pl
            // 
            this.btns_pl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btns_pl.Controls.Add(this.cancel_btn);
            this.btns_pl.Controls.Add(this.ok_btn);
            this.btns_pl.Location = new System.Drawing.Point(-2, 86);
            this.btns_pl.Name = "btns_pl";
            this.btns_pl.Size = new System.Drawing.Size(288, 70);
            this.btns_pl.TabIndex = 0;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(31, 17);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(80, 29);
            this.cancel_btn.TabIndex = 1;
            this.cancel_btn.Text = "לא";
            this.cancel_btn.UseVisualStyleBackColor = true;
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(139, 17);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(80, 29);
            this.ok_btn.TabIndex = 0;
            this.ok_btn.Text = "כן";
            this.ok_btn.UseVisualStyleBackColor = true;
            // 
            // quest_lbl
            // 
            this.quest_lbl.AutoSize = true;
            this.quest_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.quest_lbl.Location = new System.Drawing.Point(163, 36);
            this.quest_lbl.Name = "quest_lbl";
            this.quest_lbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.quest_lbl.Size = new System.Drawing.Size(58, 20);
            this.quest_lbl.TabIndex = 1;
            this.quest_lbl.Text = "השאלה";
            // 
            // MyMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 154);
            this.Controls.Add(this.quest_lbl);
            this.Controls.Add(this.btns_pl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MyMessageBox";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Form1";
            this.btns_pl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel btns_pl;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button ok_btn;
        private System.Windows.Forms.Label quest_lbl;
    }
}