namespace OracleInsertRTObjectSP
{
    partial class LogInForm
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
            this.cmdReadLogIn = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdTabLogIn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdReadLogIn
            // 
            this.cmdReadLogIn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdReadLogIn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReadLogIn.Location = new System.Drawing.Point(122, 162);
            this.cmdReadLogIn.Name = "cmdReadLogIn";
            this.cmdReadLogIn.Size = new System.Drawing.Size(84, 28);
            this.cmdReadLogIn.TabIndex = 22;
            this.cmdReadLogIn.Text = "ReadLogIn";
            this.cmdReadLogIn.UseVisualStyleBackColor = false;
            this.cmdReadLogIn.Click += new System.EventHandler(this.cmdReadLogIn_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(212, 162);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(84, 28);
            this.cmdCancel.TabIndex = 21;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(128, 76);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(111, 20);
            this.txtUserName.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "User Name";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 32);
            this.label1.TabIndex = 15;
            this.label1.Text = "Welcome to CSE Department";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdTabLogIn
            // 
            this.cmdTabLogIn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdTabLogIn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTabLogIn.Location = new System.Drawing.Point(32, 162);
            this.cmdTabLogIn.Name = "cmdTabLogIn";
            this.cmdTabLogIn.Size = new System.Drawing.Size(84, 28);
            this.cmdTabLogIn.TabIndex = 20;
            this.cmdTabLogIn.Text = "TabLogIn";
            this.cmdTabLogIn.UseVisualStyleBackColor = false;
            this.cmdTabLogIn.Click += new System.EventHandler(this.cmdTabLogIn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Pass Word";
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(128, 116);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(111, 20);
            this.txtPassWord.TabIndex = 19;
            // 
            // LogInForm
            // 
            this.AcceptButton = this.cmdTabLogIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 212);
            this.Controls.Add(this.cmdReadLogIn);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdTabLogIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassWord);
            this.Name = "LogInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSE DEPT LogIn Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdReadLogIn;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdTabLogIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassWord;
    }
}

