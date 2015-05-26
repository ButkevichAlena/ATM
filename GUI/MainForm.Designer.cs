namespace GUI
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btEnglish = new System.Windows.Forms.Button();
            this.btRussian = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(107, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose language";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btEnglish
            // 
            this.btEnglish.Location = new System.Drawing.Point(26, 74);
            this.btEnglish.Name = "btEnglish";
            this.btEnglish.Size = new System.Drawing.Size(91, 32);
            this.btEnglish.TabIndex = 1;
            this.btEnglish.Text = "English";
            this.btEnglish.UseVisualStyleBackColor = true;
            this.btEnglish.Click += new System.EventHandler(this.btEnglish_Click);
            // 
            // btRussian
            // 
            this.btRussian.Location = new System.Drawing.Point(193, 74);
            this.btRussian.Name = "btRussian";
            this.btRussian.Size = new System.Drawing.Size(94, 32);
            this.btRussian.TabIndex = 2;
            this.btRussian.Text = "Russian";
            this.btRussian.UseVisualStyleBackColor = true;
            this.btRussian.Click += new System.EventHandler(this.btRussian_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 137);
            this.Controls.Add(this.btRussian);
            this.Controls.Add(this.btEnglish);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ATM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btEnglish;
        private System.Windows.Forms.Button btRussian;
    }
}