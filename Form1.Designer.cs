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
            this.textBox_BodyTraking = new System.Windows.Forms.TextBox();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button_SaveToTxt = new System.Windows.Forms.Button();
            this.textBox_Error = new System.Windows.Forms.TextBox();
            this.checkBox_Color = new System.Windows.Forms.CheckBox();
            this.checkBox_Depth = new System.Windows.Forms.CheckBox();
            this.checkBox_BodyTraking = new System.Windows.Forms.CheckBox();
            this.button_CameraCapture = new System.Windows.Forms.Button();
            this.button_SetFPS30 = new System.Windows.Forms.Button();
            this.button_SetFPS15 = new System.Windows.Forms.Button();
            this.button_SetFPS5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Color)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Depth)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Color
            // 
            this.pictureBox_Color.Location = new System.Drawing.Point(12, 70);
            this.pictureBox_Color.Name = "pictureBox_Color";
            this.pictureBox_Color.Size = new System.Drawing.Size(300, 300);
            this.pictureBox_Color.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Color.TabIndex = 0;
            this.pictureBox_Color.TabStop = false;
            // 
            // pictureBox_Depth
            // 
            this.pictureBox_Depth.Location = new System.Drawing.Point(12, 376);
            this.pictureBox_Depth.Name = "pictureBox_Depth";
            this.pictureBox_Depth.Size = new System.Drawing.Size(300, 300);
            this.pictureBox_Depth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Depth.TabIndex = 1;
            this.pictureBox_Depth.TabStop = false;
            // 
            // textBox_BodyTraking
            // 
            this.textBox_BodyTraking.Location = new System.Drawing.Point(318, 70);
            this.textBox_BodyTraking.Multiline = true;
            this.textBox_BodyTraking.Name = "textBox_BodyTraking";
            this.textBox_BodyTraking.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_BodyTraking.Size = new System.Drawing.Size(683, 464);
            this.textBox_BodyTraking.TabIndex = 2;
            this.textBox_BodyTraking.Text = "\r\n";
            // 
            // textBox_Path
            // 
            this.textBox_Path.Location = new System.Drawing.Point(80, 41);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(759, 23);
            this.textBox_Path.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(12, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(62, 16);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "Save Path -";
            // 
            // button_SaveToTxt
            // 
            this.button_SaveToTxt.Location = new System.Drawing.Point(845, 41);
            this.button_SaveToTxt.Name = "button_SaveToTxt";
            this.button_SaveToTxt.Size = new System.Drawing.Size(156, 23);
            this.button_SaveToTxt.TabIndex = 5;
            this.button_SaveToTxt.Text = "Save Body Traking Data";
            this.button_SaveToTxt.UseVisualStyleBackColor = true;
            this.button_SaveToTxt.Click += new System.EventHandler(this.button_SaveToTxt_Click);
            // 
            // textBox_Error
            // 
            this.textBox_Error.Location = new System.Drawing.Point(318, 540);
            this.textBox_Error.Multiline = true;
            this.textBox_Error.Name = "textBox_Error";
            this.textBox_Error.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Error.Size = new System.Drawing.Size(683, 136);
            this.textBox_Error.TabIndex = 6;
            this.textBox_Error.Text = "===Output===\r\n";
            // 
            // checkBox_Color
            // 
            this.checkBox_Color.AutoSize = true;
            this.checkBox_Color.Checked = true;
            this.checkBox_Color.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Color.Location = new System.Drawing.Point(12, 12);
            this.checkBox_Color.Name = "checkBox_Color";
            this.checkBox_Color.Size = new System.Drawing.Size(92, 19);
            this.checkBox_Color.TabIndex = 7;
            this.checkBox_Color.Text = "Active Color";
            this.checkBox_Color.UseVisualStyleBackColor = true;
            // 
            // checkBox_Depth
            // 
            this.checkBox_Depth.AutoSize = true;
            this.checkBox_Depth.Checked = true;
            this.checkBox_Depth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Depth.Location = new System.Drawing.Point(110, 12);
            this.checkBox_Depth.Name = "checkBox_Depth";
            this.checkBox_Depth.Size = new System.Drawing.Size(96, 19);
            this.checkBox_Depth.TabIndex = 8;
            this.checkBox_Depth.Text = "Active Depth";
            this.checkBox_Depth.UseVisualStyleBackColor = true;
            // 
            // checkBox_BodyTraking
            // 
            this.checkBox_BodyTraking.AutoSize = true;
            this.checkBox_BodyTraking.Checked = true;
            this.checkBox_BodyTraking.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_BodyTraking.Location = new System.Drawing.Point(212, 12);
            this.checkBox_BodyTraking.Name = "checkBox_BodyTraking";
            this.checkBox_BodyTraking.Size = new System.Drawing.Size(133, 19);
            this.checkBox_BodyTraking.TabIndex = 9;
            this.checkBox_BodyTraking.Text = "Active Body Traking";
            this.checkBox_BodyTraking.UseVisualStyleBackColor = true;
            // 
            // button_CameraCapture
            // 
            this.button_CameraCapture.Location = new System.Drawing.Point(845, 12);
            this.button_CameraCapture.Name = "button_CameraCapture";
            this.button_CameraCapture.Size = new System.Drawing.Size(156, 23);
            this.button_CameraCapture.TabIndex = 10;
            this.button_CameraCapture.Text = "Active Camera";
            this.button_CameraCapture.UseVisualStyleBackColor = true;
            this.button_CameraCapture.Click += new System.EventHandler(this.button_CameraCapture_Click);
            // 
            // button_SetFPS30
            // 
            this.button_SetFPS30.Location = new System.Drawing.Point(764, 12);
            this.button_SetFPS30.Name = "button_SetFPS30";
            this.button_SetFPS30.Size = new System.Drawing.Size(75, 23);
            this.button_SetFPS30.TabIndex = 11;
            this.button_SetFPS30.Text = "FPS 30";
            this.button_SetFPS30.UseVisualStyleBackColor = true;
            this.button_SetFPS30.Click += new System.EventHandler(this.button_SetFPS30_Click);
            // 
            // button_SetFPS15
            // 
            this.button_SetFPS15.Location = new System.Drawing.Point(683, 12);
            this.button_SetFPS15.Name = "button_SetFPS15";
            this.button_SetFPS15.Size = new System.Drawing.Size(75, 23);
            this.button_SetFPS15.TabIndex = 12;
            this.button_SetFPS15.Text = "FPS 15";
            this.button_SetFPS15.UseVisualStyleBackColor = true;
            this.button_SetFPS15.Click += new System.EventHandler(this.button_SetFPS15_Click);
            // 
            // button_SetFPS5
            // 
            this.button_SetFPS5.Location = new System.Drawing.Point(602, 12);
            this.button_SetFPS5.Name = "button_SetFPS5";
            this.button_SetFPS5.Size = new System.Drawing.Size(75, 23);
            this.button_SetFPS5.TabIndex = 13;
            this.button_SetFPS5.Text = "FPS 5";
            this.button_SetFPS5.UseVisualStyleBackColor = true;
            this.button_SetFPS5.Click += new System.EventHandler(this.button_SetFPS5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 690);
            this.Controls.Add(this.button_SetFPS5);
            this.Controls.Add(this.button_SetFPS15);
            this.Controls.Add(this.button_SetFPS30);
            this.Controls.Add(this.button_CameraCapture);
            this.Controls.Add(this.checkBox_BodyTraking);
            this.Controls.Add(this.checkBox_Depth);
            this.Controls.Add(this.checkBox_Color);
            this.Controls.Add(this.textBox_Error);
            this.Controls.Add(this.button_SaveToTxt);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox_Path);
            this.Controls.Add(this.textBox_BodyTraking);
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
        private System.Windows.Forms.TextBox textBox_BodyTraking;
        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button_SaveToTxt;
        private System.Windows.Forms.TextBox textBox_Error;
        private System.Windows.Forms.CheckBox checkBox_Color;
        private System.Windows.Forms.CheckBox checkBox_Depth;
        private System.Windows.Forms.CheckBox checkBox_BodyTraking;
        private System.Windows.Forms.Button button_CameraCapture;
        private System.Windows.Forms.Button button_SetFPS30;
        private System.Windows.Forms.Button button_SetFPS15;
        private System.Windows.Forms.Button button_SetFPS5;
    }
}

