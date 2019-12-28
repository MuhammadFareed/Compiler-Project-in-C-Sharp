namespace Compiler_Final_Project
{
    partial class Output_Window
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
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.ForeColor = System.Drawing.SystemColors.Info;
            this.richTextBox2.Location = new System.Drawing.Point(0, 0);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(664, 470);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Output_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(664, 470);
            this.Controls.Add(this.richTextBox2);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Output_Window";
            this.Text = "Output Window";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}