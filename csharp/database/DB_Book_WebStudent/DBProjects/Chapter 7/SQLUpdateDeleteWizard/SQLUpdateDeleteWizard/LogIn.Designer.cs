namespace SQLUpdateDeleteWizard
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
            this.components = new System.ComponentModel.Container();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdLogIn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.logInBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cSE_DEPTDataSet = new SQLUpdateDeleteWizard.CSE_DEPTDataSet();
            this.logInTableAdapter = new SQLUpdateDeleteWizard.CSE_DEPTDataSetTableAdapters.LogInTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.logInBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSE_DEPTDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(179, 167);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(84, 28);
            this.cmdCancel.TabIndex = 13;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdLogIn
            // 
            this.cmdLogIn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLogIn.Location = new System.Drawing.Point(58, 167);
            this.cmdLogIn.Name = "cmdLogIn";
            this.cmdLogIn.Size = new System.Drawing.Size(84, 28);
            this.cmdLogIn.TabIndex = 12;
            this.cmdLogIn.Text = "LogIn";
            this.cmdLogIn.UseVisualStyleBackColor = false;
            this.cmdLogIn.Click += new System.EventHandler(this.cmdLogIn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Pass Word";
            // 
            // txtPassWord
            // 
            this.txtPassWord.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logInBindingSource, "pass_word", true));
            this.txtPassWord.Location = new System.Drawing.Point(123, 121);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(111, 20);
            this.txtPassWord.TabIndex = 11;
            // 
            // txtUserName
            // 
            this.txtUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logInBindingSource, "user_name", true));
            this.txtUserName.Location = new System.Drawing.Point(123, 81);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(111, 20);
            this.txtUserName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "User Name";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Welcome to CSE Department";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logInBindingSource
            // 
            this.logInBindingSource.DataMember = "LogIn";
            this.logInBindingSource.DataSource = this.cSE_DEPTDataSet;
            // 
            // cSE_DEPTDataSet
            // 
            this.cSE_DEPTDataSet.DataSetName = "CSE_DEPTDataSet";
            this.cSE_DEPTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // logInTableAdapter
            // 
            this.logInTableAdapter.ClearBeforeFill = true;
            // 
            // LogInForm
            // 
            this.AcceptButton = this.cmdLogIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 222);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdLogIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LogInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSE_DEPT LogIn Form";
            ((System.ComponentModel.ISupportInitialize)(this.logInBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSE_DEPTDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdLogIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource logInBindingSource;
        private CSE_DEPTDataSet cSE_DEPTDataSet;
        private SQLUpdateDeleteWizard.CSE_DEPTDataSetTableAdapters.LogInTableAdapter logInTableAdapter;
    }
}

