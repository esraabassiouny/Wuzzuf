namespace wuzzuf
{
    partial class ApplicationsForm
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.applicationPanel = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.txtAppDate = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblJobType = new System.Windows.Forms.Label();
            this.txtJobType = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.navPanel = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.scrollPanel.SuspendLayout();
            this.applicationPanel.SuspendLayout();
            this.navPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.scrollPanel);
            this.mainPanel.Controls.Add(this.navPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 480);
            this.mainPanel.TabIndex = 0;
            // 
            // scrollPanel
            // 
            this.scrollPanel.AutoScroll = true;
            this.scrollPanel.BackColor = System.Drawing.Color.White;
            this.scrollPanel.Controls.Add(this.applicationPanel);
            this.scrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollPanel.Location = new System.Drawing.Point(0, 0);
            this.scrollPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Padding = new System.Windows.Forms.Padding(18, 16, 18, 16);
            this.scrollPanel.Size = new System.Drawing.Size(800, 432);
            this.scrollPanel.TabIndex = 0;
            // 
            // applicationPanel
            // 
            this.applicationPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.applicationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.applicationPanel.Controls.Add(this.lblStatus);
            this.applicationPanel.Controls.Add(this.txtStatus);
            this.applicationPanel.Controls.Add(this.lblAppDate);
            this.applicationPanel.Controls.Add(this.txtAppDate);
            this.applicationPanel.Controls.Add(this.lblLocation);
            this.applicationPanel.Controls.Add(this.txtLocation);
            this.applicationPanel.Controls.Add(this.lblCompany);
            this.applicationPanel.Controls.Add(this.txtCompany);
            this.applicationPanel.Controls.Add(this.lblJobType);
            this.applicationPanel.Controls.Add(this.txtJobType);
            this.applicationPanel.Controls.Add(this.lblTitle);
            this.applicationPanel.Controls.Add(this.txtTitle);
            this.applicationPanel.Location = new System.Drawing.Point(27, 24);
            this.applicationPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.applicationPanel.Name = "applicationPanel";
            this.applicationPanel.Size = new System.Drawing.Size(729, 320);
            this.applicationPanel.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(27, 240);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(65, 23);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Status:";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.White;
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStatus.Location = new System.Drawing.Point(133, 238);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(267, 30);
            this.txtStatus.TabIndex = 10;
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAppDate.Location = new System.Drawing.Point(27, 200);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(151, 23);
            this.lblAppDate.TabIndex = 9;
            this.lblAppDate.Text = "Application Date:";
            // 
            // txtAppDate
            // 
            this.txtAppDate.BackColor = System.Drawing.Color.White;
            this.txtAppDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAppDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAppDate.Location = new System.Drawing.Point(178, 198);
            this.txtAppDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAppDate.Name = "txtAppDate";
            this.txtAppDate.ReadOnly = true;
            this.txtAppDate.Size = new System.Drawing.Size(222, 30);
            this.txtAppDate.TabIndex = 8;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLocation.Location = new System.Drawing.Point(27, 160);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(83, 23);
            this.lblLocation.TabIndex = 7;
            this.lblLocation.Text = "Location:";
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.Color.White;
            this.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLocation.Location = new System.Drawing.Point(133, 158);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(267, 30);
            this.txtLocation.TabIndex = 6;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCompany.Location = new System.Drawing.Point(27, 120);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(91, 23);
            this.lblCompany.TabIndex = 5;
            this.lblCompany.Text = "Company:";
            // 
            // txtCompany
            // 
            this.txtCompany.BackColor = System.Drawing.Color.White;
            this.txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompany.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCompany.Location = new System.Drawing.Point(133, 118);
            this.txtCompany.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.ReadOnly = true;
            this.txtCompany.Size = new System.Drawing.Size(267, 30);
            this.txtCompany.TabIndex = 4;
            // 
            // lblJobType
            // 
            this.lblJobType.AutoSize = true;
            this.lblJobType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblJobType.Location = new System.Drawing.Point(27, 80);
            this.lblJobType.Name = "lblJobType";
            this.lblJobType.Size = new System.Drawing.Size(87, 23);
            this.lblJobType.TabIndex = 3;
            this.lblJobType.Text = "Job Type:";
            // 
            // txtJobType
            // 
            this.txtJobType.BackColor = System.Drawing.Color.White;
            this.txtJobType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJobType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtJobType.Location = new System.Drawing.Point(133, 78);
            this.txtJobType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtJobType.Name = "txtJobType";
            this.txtJobType.ReadOnly = true;
            this.txtJobType.Size = new System.Drawing.Size(267, 30);
            this.txtJobType.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(27, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(85, 23);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Job Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.White;
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTitle.Location = new System.Drawing.Point(133, 38);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(445, 30);
            this.txtTitle.TabIndex = 0;
            // 
            // navPanel
            // 
            this.navPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.navPanel.Controls.Add(this.btnPrev);
            this.navPanel.Controls.Add(this.btnNext);
            this.navPanel.Controls.Add(this.lblPageInfo);
            this.navPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navPanel.Location = new System.Drawing.Point(0, 432);
            this.navPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.navPanel.Name = "navPanel";
            this.navPanel.Size = new System.Drawing.Size(800, 48);
            this.navPanel.TabIndex = 1;
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrev.Location = new System.Drawing.Point(206, 12);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(89, 24);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click_1);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNext.Location = new System.Drawing.Point(504, 13);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(89, 24);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(359, 16);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(50, 16);
            this.lblPageInfo.TabIndex = 2;
            this.lblPageInfo.Text = "Page 1";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ApplicationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.mainPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ApplicationsForm";
            this.Text = "My Applications";
            this.Load += new System.EventHandler(this.ApplicationsForm_Load);
            this.mainPanel.ResumeLayout(false);
            this.scrollPanel.ResumeLayout(false);
            this.applicationPanel.ResumeLayout(false);
            this.applicationPanel.PerformLayout();
            this.navPanel.ResumeLayout(false);
            this.navPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel scrollPanel;
        private System.Windows.Forms.Panel applicationPanel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.TextBox txtAppDate;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label lblJobType;
        private System.Windows.Forms.TextBox txtJobType;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Panel navPanel;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPageInfo;
    }
}