namespace EDModel
{
    partial class EDModelForm
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
            this.cmdShow = new System.Windows.Forms.Button();
            this.FacultyList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cmdShow
            // 
            this.cmdShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.cmdShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShow.Location = new System.Drawing.Point(89, 208);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(180, 36);
            this.cmdShow.TabIndex = 0;
            this.cmdShow.Text = "Show Faculty";
            this.cmdShow.UseVisualStyleBackColor = false;
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // FacultyList
            // 
            this.FacultyList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FacultyList.FormattingEnabled = true;
            this.FacultyList.ItemHeight = 16;
            this.FacultyList.Location = new System.Drawing.Point(80, 20);
            this.FacultyList.Name = "FacultyList";
            this.FacultyList.Size = new System.Drawing.Size(198, 164);
            this.FacultyList.TabIndex = 1;
            // 
            // EDModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 271);
            this.Controls.Add(this.FacultyList);
            this.Controls.Add(this.cmdShow);
            this.Name = "EDModelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entity Data Model Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdShow;
        private System.Windows.Forms.ListBox FacultyList;
    }
}

