namespace Calendar
{
    partial class UserControlDays
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbdays = new System.Windows.Forms.Label();
            this.txtevent = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbdays
            // 
            this.lbdays.AutoSize = true;
            this.lbdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdays.Location = new System.Drawing.Point(15, 13);
            this.lbdays.Name = "lbdays";
            this.lbdays.Size = new System.Drawing.Size(41, 29);
            this.lbdays.TabIndex = 0;
            this.lbdays.Text = "00";
            // 
            // txtevent
            // 
            this.txtevent.BackColor = System.Drawing.Color.White;
            this.txtevent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtevent.Enabled = false;
            this.txtevent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtevent.ForeColor = System.Drawing.Color.Black;
            this.txtevent.Location = new System.Drawing.Point(20, 45);
            this.txtevent.Multiline = true;
            this.txtevent.Name = "txtevent";
            this.txtevent.Size = new System.Drawing.Size(104, 34);
            this.txtevent.TabIndex = 3;
            // 
            // UserControlDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtevent);
            this.Controls.Add(this.lbdays);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "UserControlDays";
            this.Size = new System.Drawing.Size(146, 98);
            this.Click += new System.EventHandler(this.UserControlDays_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbdays;
        private System.Windows.Forms.TextBox txtevent;
    }
}
