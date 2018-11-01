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
            this.enemyStats = new System.Windows.Forms.GroupBox();
            this.EnemyS = new System.Windows.Forms.Label();
            this.EnemyD = new System.Windows.Forms.Label();
            this.EnemyB = new System.Windows.Forms.Label();
            this.EnemyP = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.EnemyA = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EnemyRemain = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MyS = new System.Windows.Forms.Label();
            this.MyD = new System.Windows.Forms.Label();
            this.MyB = new System.Windows.Forms.Label();
            this.MyP = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.MyA = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.LogBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.enemyStats.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // LogText
            // 
            this.LogText.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.LogText.Location = new System.Drawing.Point(16, 18);
            this.LogText.Name = "LogText";
            this.LogText.Size = new System.Drawing.Size(374, 84);
            this.LogText.TabIndex = 0;
            this.LogText.Text = "Choose location for Aircraft";
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
            this.RestartBtn.Text = "Reset";
            this.RestartBtn.UseVisualStyleBackColor = true;
            this.RestartBtn.Click += new System.EventHandler(this.RestartBtn_Click);
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
            // enemyStats
            // 
            this.enemyStats.Controls.Add(this.EnemyS);
            this.enemyStats.Controls.Add(this.EnemyD);
            this.enemyStats.Controls.Add(this.EnemyB);
            this.enemyStats.Controls.Add(this.EnemyP);
            this.enemyStats.Controls.Add(this.label6);
            this.enemyStats.Controls.Add(this.label7);
            this.enemyStats.Controls.Add(this.EnemyA);
            this.enemyStats.Controls.Add(this.label9);
            this.enemyStats.Controls.Add(this.label12);
            this.enemyStats.Controls.Add(this.label16);
            this.enemyStats.Controls.Add(this.label2);
            this.enemyStats.Controls.Add(this.EnemyRemain);
            this.enemyStats.Location = new System.Drawing.Point(750, 12);
            this.enemyStats.Name = "enemyStats";
            this.enemyStats.Size = new System.Drawing.Size(110, 307);
            this.enemyStats.TabIndex = 6;
            this.enemyStats.TabStop = false;
            this.enemyStats.Text = "Enemy Remain";
            // 
            // EnemyS
            // 
            this.EnemyS.AutoSize = true;
            this.EnemyS.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.EnemyS.Location = new System.Drawing.Point(71, 162);
            this.EnemyS.Name = "EnemyS";
            this.EnemyS.Size = new System.Drawing.Size(32, 14);
            this.EnemyS.TabIndex = 24;
            this.EnemyS.Text = "Live";
            // 
            // EnemyD
            // 
            this.EnemyD.AutoSize = true;
            this.EnemyD.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.EnemyD.Location = new System.Drawing.Point(71, 202);
            this.EnemyD.Name = "EnemyD";
            this.EnemyD.Size = new System.Drawing.Size(32, 14);
            this.EnemyD.TabIndex = 25;
            this.EnemyD.Text = "Live";
            // 
            // EnemyB
            // 
            this.EnemyB.AutoSize = true;
            this.EnemyB.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.EnemyB.Location = new System.Drawing.Point(71, 122);
            this.EnemyB.Name = "EnemyB";
            this.EnemyB.Size = new System.Drawing.Size(32, 14);
            this.EnemyB.TabIndex = 23;
            this.EnemyB.Text = "Live";
            // 
            // EnemyP
            // 
            this.EnemyP.AutoSize = true;
            this.EnemyP.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.EnemyP.Location = new System.Drawing.Point(71, 242);
            this.EnemyP.Name = "EnemyP";
            this.EnemyP.Size = new System.Drawing.Size(32, 14);
            this.EnemyP.TabIndex = 26;
            this.EnemyP.Text = "Live";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.label6.Location = new System.Drawing.Point(6, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 14);
            this.label6.TabIndex = 20;
            this.label6.Text = "Patrol";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.label7.Location = new System.Drawing.Point(6, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 14);
            this.label7.TabIndex = 21;
            this.label7.Text = "Submarine";
            // 
            // EnemyA
            // 
            this.EnemyA.AutoSize = true;
            this.EnemyA.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.EnemyA.Location = new System.Drawing.Point(71, 82);
            this.EnemyA.Name = "EnemyA";
            this.EnemyA.Size = new System.Drawing.Size(32, 14);
            this.EnemyA.TabIndex = 22;
            this.EnemyA.Text = "Live";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.label9.Location = new System.Drawing.Point(6, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 14);
            this.label9.TabIndex = 17;
            this.label9.Text = "Aircraft";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.label12.Location = new System.Drawing.Point(6, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 18;
            this.label12.Text = "Battleship";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.label16.Location = new System.Drawing.Point(6, 202);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 14);
            this.label16.TabIndex = 19;
            this.label16.Text = "Destroyer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.label2.Location = new System.Drawing.Point(26, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total";
            // 
            // EnemyRemain
            // 
            this.EnemyRemain.AutoSize = true;
            this.EnemyRemain.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.EnemyRemain.Location = new System.Drawing.Point(35, 54);
            this.EnemyRemain.Name = "EnemyRemain";
            this.EnemyRemain.Size = new System.Drawing.Size(16, 16);
            this.EnemyRemain.TabIndex = 0;
            this.EnemyRemain.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MyS);
            this.groupBox2.Controls.Add(this.MyD);
            this.groupBox2.Controls.Add(this.MyB);
            this.groupBox2.Controls.Add(this.MyP);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.MyA);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(12, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(100, 212);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "My Remain";
            // 
            // MyS
            // 
            this.MyS.AutoSize = true;
            this.MyS.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.MyS.Location = new System.Drawing.Point(75, 95);
            this.MyS.Name = "MyS";
            this.MyS.Size = new System.Drawing.Size(14, 14);
            this.MyS.TabIndex = 14;
            this.MyS.Text = "0";
            // 
            // MyD
            // 
            this.MyD.AutoSize = true;
            this.MyD.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.MyD.Location = new System.Drawing.Point(75, 135);
            this.MyD.Name = "MyD";
            this.MyD.Size = new System.Drawing.Size(14, 14);
            this.MyD.TabIndex = 15;
            this.MyD.Text = "0";
            // 
            // MyB
            // 
            this.MyB.AutoSize = true;
            this.MyB.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.MyB.Location = new System.Drawing.Point(75, 55);
            this.MyB.Name = "MyB";
            this.MyB.Size = new System.Drawing.Size(14, 14);
            this.MyB.TabIndex = 13;
            this.MyB.Text = "0";
            // 
            // MyP
            // 
            this.MyP.AutoSize = true;
            this.MyP.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.MyP.Location = new System.Drawing.Point(75, 175);
            this.MyP.Name = "MyP";
            this.MyP.Size = new System.Drawing.Size(14, 14);
            this.MyP.TabIndex = 16;
            this.MyP.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.label10.Location = new System.Drawing.Point(10, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 14);
            this.label10.TabIndex = 10;
            this.label10.Text = "Patrol";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.label11.Location = new System.Drawing.Point(10, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 14);
            this.label11.TabIndex = 11;
            this.label11.Text = "Submarine";
            // 
            // MyA
            // 
            this.MyA.AutoSize = true;
            this.MyA.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.MyA.Location = new System.Drawing.Point(75, 15);
            this.MyA.Name = "MyA";
            this.MyA.Size = new System.Drawing.Size(14, 14);
            this.MyA.TabIndex = 12;
            this.MyA.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.label13.Location = new System.Drawing.Point(10, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 14);
            this.label13.TabIndex = 7;
            this.label13.Text = "Aircraft";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.label14.Location = new System.Drawing.Point(10, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 14);
            this.label14.TabIndex = 8;
            this.label14.Text = "Battleship";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.label15.Location = new System.Drawing.Point(10, 135);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 14);
            this.label15.TabIndex = 9;
            this.label15.Text = "Destroyer";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 511);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.enemyStats);
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
            this.enemyStats.ResumeLayout(false);
            this.enemyStats.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox enemyStats;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label MyS;
        private System.Windows.Forms.Label MyD;
        private System.Windows.Forms.Label MyB;
        private System.Windows.Forms.Label MyP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label MyA;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label EnemyRemain;
        private System.Windows.Forms.Label EnemyS;
        private System.Windows.Forms.Label EnemyD;
        private System.Windows.Forms.Label EnemyB;
        private System.Windows.Forms.Label EnemyP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label EnemyA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
    }
}

