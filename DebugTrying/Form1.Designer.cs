
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
            this.components = new System.ComponentModel.Container();
            this.btn_invokeFuncGetNewMail = new System.Windows.Forms.Button();
            this.btn_title = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnTryingDuplicateWord = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // btn_invokeFuncGetNewMail
            // 
            this.btn_invokeFuncGetNewMail.Location = new System.Drawing.Point(591, 96);
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
            this.btn_title.Size = new System.Drawing.Size(76, 17);
            this.btn_title.TabIndex = 1;
            this.btn_title.Text = "ניסויי הרצות";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(415, 96);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "בדיקת הסרה מרשימה ע\"י פרידיקייט";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(235, 96);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 59);
            this.button2.TabIndex = 3;
            this.button2.Text = "בדיקה האם יש כפולים בטבלת מילים";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTryingDuplicateWord
            // 
            this.btnTryingDuplicateWord.Location = new System.Drawing.Point(86, 96);
            this.btnTryingDuplicateWord.Name = "btnTryingDuplicateWord";
            this.btnTryingDuplicateWord.Size = new System.Drawing.Size(120, 59);
            this.btnTryingDuplicateWord.TabIndex = 4;
            this.btnTryingDuplicateWord.Text = "נסיון הכנסת מילה כפולה ל-DB";
            this.btnTryingDuplicateWord.UseVisualStyleBackColor = true;
            this.btnTryingDuplicateWord.Click += new System.EventHandler(this.btnTryingDuplicateWord_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(591, 175);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 59);
            this.button3.TabIndex = 5;
            this.button3.Text = "קריאה לפונקציית זהוי שמות מהספרייה..";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(415, 175);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 59);
            this.button4.TabIndex = 6;
            this.button4.Text = "שנוי כל ערכי התכונה isSimilarWord ל-שקר";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(235, 175);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 59);
            this.button5.TabIndex = 7;
            this.button5.Text = "הפעלת הפונקציה - מילים דומות\r\n";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(86, 175);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(120, 59);
            this.button6.TabIndex = 8;
            this.button6.Text = "הפעלת הפונקציה טרנזקציה";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(591, 269);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(120, 59);
            this.button7.TabIndex = 9;
            this.button7.Text = "מחיקת מייל אחרון";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(435, 269);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(120, 59);
            this.button8.TabIndex = 10;
            this.button8.Text = "הסתברות מילה";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(456, 350);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(99, 22);
            this.textBox1.TabIndex = 11;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnTryingDuplicateWord);
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
        private System.Windows.Forms.Button btnTryingDuplicateWord;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

