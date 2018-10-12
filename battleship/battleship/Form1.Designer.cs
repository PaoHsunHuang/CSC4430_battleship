namespace battleship
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
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.LogText = new System.Windows.Forms.Label();
            this.LogBox = new System.Windows.Forms.GroupBox();
            this.RestartBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Horizontal = new System.Windows.Forms.RadioButton();
            this.Vertical = new System.Windows.Forms.RadioButton();
            this.ExitBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.LogBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // LogText
            // 
            this.LogText.Location = new System.Drawing.Point(16, 18);
            this.LogText.Name = "LogText";
            this.LogText.Size = new System.Drawing.Size(374, 84);
            this.LogText.TabIndex = 0;
            this.LogText.Text = "123";
            // 
            // LogBox
            // 
            this.LogBox.Controls.Add(this.LogText);
            this.LogBox.Location = new System.Drawing.Point(196, 356);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(396, 114);
            this.LogBox.TabIndex = 1;
            this.LogBox.TabStop = false;
            this.LogBox.Text = "Log";
            // 
            // RestartBtn
            // 
            this.RestartBtn.Location = new System.Drawing.Point(616, 365);
            this.RestartBtn.Name = "RestartBtn";
            this.RestartBtn.Size = new System.Drawing.Size(97, 93);
            this.RestartBtn.TabIndex = 2;
            this.RestartBtn.Text = "Restart";
            this.RestartBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Horizontal);
            this.groupBox1.Controls.Add(this.Vertical);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(86, 86);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Direction";
            // 
            // Horizontal
            // 
            this.Horizontal.AutoSize = true;
            this.Horizontal.Location = new System.Drawing.Point(6, 55);
            this.Horizontal.Name = "Horizontal";
            this.Horizontal.Size = new System.Drawing.Size(72, 16);
            this.Horizontal.TabIndex = 1;
            this.Horizontal.TabStop = true;
            this.Horizontal.Text = "Horizontal";
            this.Horizontal.UseVisualStyleBackColor = true;
            // 
            // Vertical
            // 
            this.Vertical.AutoSize = true;
            this.Vertical.Checked = true;
            this.Vertical.Location = new System.Drawing.Point(6, 21);
            this.Vertical.Name = "Vertical";
            this.Vertical.Size = new System.Drawing.Size(59, 16);
            this.Vertical.TabIndex = 0;
            this.Vertical.TabStop = true;
            this.Vertical.Text = "Vertical";
            this.Vertical.UseVisualStyleBackColor = true;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(719, 365);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(97, 93);
            this.ExitBtn.TabIndex = 4;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 511);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RestartBtn);
            this.Controls.Add(this.LogBox);
            this.Name = "Form1";
            this.Text = "Battleship";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.LogBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.GroupBox LogBox;
        private System.Windows.Forms.Label LogText;
        private System.Windows.Forms.Button RestartBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Horizontal;
        private System.Windows.Forms.RadioButton Vertical;
        private System.Windows.Forms.Button ExitBtn;
    }
}

