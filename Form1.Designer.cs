namespace AzureKineticTest_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_Color = new System.Windows.Forms.PictureBox();
            this.pictureBox_Depth = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Color)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Depth)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Color
            // 
            this.pictureBox_Color.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_Color.Name = "pictureBox_Color";
            this.pictureBox_Color.Size = new System.Drawing.Size(386, 303);
            this.pictureBox_Color.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Color.TabIndex = 0;
            this.pictureBox_Color.TabStop = false;
            // 
            // pictureBox_Depth
            // 
            this.pictureBox_Depth.Location = new System.Drawing.Point(12, 343);
            this.pictureBox_Depth.Name = "pictureBox_Depth";
            this.pictureBox_Depth.Size = new System.Drawing.Size(386, 303);
            this.pictureBox_Depth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Depth.TabIndex = 1;
            this.pictureBox_Depth.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(413, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(588, 634);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 658);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox_Depth);
            this.Controls.Add(this.pictureBox_Color);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Color)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Depth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Color;
        private System.Windows.Forms.PictureBox pictureBox_Depth;
        private System.Windows.Forms.TextBox textBox1;
    }
}

