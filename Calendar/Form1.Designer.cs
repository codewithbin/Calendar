namespace Calendar
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
            this.daycontainer = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.labelMon = new System.Windows.Forms.Label();
            this.labelTue = new System.Windows.Forms.Label();
            this.labelWed = new System.Windows.Forms.Label();
            this.labelThu = new System.Windows.Forms.Label();
            this.labelFri = new System.Windows.Forms.Label();
            this.labelSat = new System.Windows.Forms.Label();
            this.labelSun = new System.Windows.Forms.Label();
            this.LBDATE = new System.Windows.Forms.Label();
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // daycontainer
            // 
            this.daycontainer.Location = new System.Drawing.Point(30, 127);
            this.daycontainer.Name = "daycontainer";
            this.daycontainer.Size = new System.Drawing.Size(1080, 640);
            this.daycontainer.TabIndex = 0;
            // 
            // buttonNext
            // 
            this.buttonNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNext.Location = new System.Drawing.Point(988, 775);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(111, 34);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrev.Location = new System.Drawing.Point(871, 775);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(111, 34);
            this.buttonPrev.TabIndex = 2;
            this.buttonPrev.Text = "Previous";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // labelMon
            // 
            this.labelMon.AutoSize = true;
            this.labelMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMon.Location = new System.Drawing.Point(207, 90);
            this.labelMon.Name = "labelMon";
            this.labelMon.Size = new System.Drawing.Size(89, 25);
            this.labelMon.TabIndex = 3;
            this.labelMon.Text = "Monday";
            // 
            // labelTue
            // 
            this.labelTue.AutoSize = true;
            this.labelTue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTue.Location = new System.Drawing.Point(354, 90);
            this.labelTue.Name = "labelTue";
            this.labelTue.Size = new System.Drawing.Size(96, 25);
            this.labelTue.TabIndex = 4;
            this.labelTue.Text = "Tuesday";
            // 
            // labelWed
            // 
            this.labelWed.AutoSize = true;
            this.labelWed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWed.Location = new System.Drawing.Point(498, 90);
            this.labelWed.Name = "labelWed";
            this.labelWed.Size = new System.Drawing.Size(127, 25);
            this.labelWed.TabIndex = 5;
            this.labelWed.Text = "Wednesday";
            // 
            // labelThu
            // 
            this.labelThu.AutoSize = true;
            this.labelThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThu.Location = new System.Drawing.Point(658, 90);
            this.labelThu.Name = "labelThu";
            this.labelThu.Size = new System.Drawing.Size(103, 25);
            this.labelThu.TabIndex = 6;
            this.labelThu.Text = "Thursday";
            // 
            // labelFri
            // 
            this.labelFri.AutoSize = true;
            this.labelFri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFri.Location = new System.Drawing.Point(834, 90);
            this.labelFri.Name = "labelFri";
            this.labelFri.Size = new System.Drawing.Size(72, 25);
            this.labelFri.TabIndex = 7;
            this.labelFri.Text = "Friday";
            // 
            // labelSat
            // 
            this.labelSat.AutoSize = true;
            this.labelSat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSat.Location = new System.Drawing.Point(966, 90);
            this.labelSat.Name = "labelSat";
            this.labelSat.Size = new System.Drawing.Size(99, 25);
            this.labelSat.TabIndex = 8;
            this.labelSat.Text = "Saturday";
            // 
            // labelSun
            // 
            this.labelSun.AutoSize = true;
            this.labelSun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSun.Location = new System.Drawing.Point(58, 90);
            this.labelSun.Name = "labelSun";
            this.labelSun.Size = new System.Drawing.Size(86, 25);
            this.labelSun.TabIndex = 9;
            this.labelSun.Text = "Sunday";
            // 
            // LBDATE
            // 
            this.LBDATE.AutoSize = true;
            this.LBDATE.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBDATE.ForeColor = System.Drawing.Color.Red;
            this.LBDATE.Location = new System.Drawing.Point(56, 24);
            this.LBDATE.Name = "LBDATE";
            this.LBDATE.Size = new System.Drawing.Size(296, 46);
            this.LBDATE.TabIndex = 10;
            this.LBDATE.Text = "MONTH YEAR";
            // 
            // cbUser
            // 
            this.cbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(778, 31);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(287, 39);
            this.cbUser.TabIndex = 11;
            this.cbUser.SelectedIndexChanged += new System.EventHandler(this.cbUser_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 826);
            this.Controls.Add(this.cbUser);
            this.Controls.Add(this.LBDATE);
            this.Controls.Add(this.labelSun);
            this.Controls.Add(this.labelSat);
            this.Controls.Add(this.labelFri);
            this.Controls.Add(this.labelThu);
            this.Controls.Add(this.labelWed);
            this.Controls.Add(this.labelTue);
            this.Controls.Add(this.labelMon);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.daycontainer);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel daycontainer;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Label labelMon;
        private System.Windows.Forms.Label labelTue;
        private System.Windows.Forms.Label labelWed;
        private System.Windows.Forms.Label labelThu;
        private System.Windows.Forms.Label labelFri;
        private System.Windows.Forms.Label labelSat;
        private System.Windows.Forms.Label labelSun;
        private System.Windows.Forms.Label LBDATE;
        private System.Windows.Forms.ComboBox cbUser;
    }
}

