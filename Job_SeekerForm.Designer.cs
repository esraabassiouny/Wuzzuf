namespace wuzzuf
{
    partial class Job_SeekerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label job_titleLabel;
        private System.Windows.Forms.ComboBox job_titleBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.TextBox RequirementsBox;
        private System.Windows.Forms.TextBox respomsibiltiesBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox typeBox;
        private System.Windows.Forms.TextBox locationBox;
        private System.Windows.Forms.TextBox experienceBox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Label jobPositionLabel;
        private System.Windows.Forms.Button apply_allbutton;
        private System.Windows.Forms.Button applicationsbutton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.job_titleLabel = new System.Windows.Forms.Label();
            this.job_titleBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.RequirementsBox = new System.Windows.Forms.TextBox();
            this.respomsibiltiesBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.TextBox();
            this.locationBox = new System.Windows.Forms.TextBox();
            this.experienceBox = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.jobPositionLabel = new System.Windows.Forms.Label();
            this.apply_allbutton = new System.Windows.Forms.Button();
            this.applicationsbutton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // job_titleLabel
            // 
            this.job_titleLabel.AutoSize = true;
            this.job_titleLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.job_titleLabel.Location = new System.Drawing.Point(50, 80);
            this.job_titleLabel.Name = "job_titleLabel";
            this.job_titleLabel.Size = new System.Drawing.Size(85, 28);
            this.job_titleLabel.TabIndex = 0;
            this.job_titleLabel.Text = "Job Title";
            // 
            // job_titleBox
            // 
            this.job_titleBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.job_titleBox.FormattingEnabled = true;
            this.job_titleBox.Location = new System.Drawing.Point(150, 77);
            this.job_titleBox.Name = "job_titleBox";
            this.job_titleBox.Size = new System.Drawing.Size(300, 36);
            this.job_titleBox.TabIndex = 1;
            this.job_titleBox.SelectedIndexChanged += new System.EventHandler(this.job_titleBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(50, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(50, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Requirements";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(50, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Responsibilties";
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.DescriptionBox.Location = new System.Drawing.Point(150, 127);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.ReadOnly = true;
            this.DescriptionBox.Size = new System.Drawing.Size(600, 60);
            this.DescriptionBox.TabIndex = 5;
            // 
            // RequirementsBox
            // 
            this.RequirementsBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.RequirementsBox.Location = new System.Drawing.Point(150, 207);
            this.RequirementsBox.Multiline = true;
            this.RequirementsBox.Name = "RequirementsBox";
            this.RequirementsBox.ReadOnly = true;
            this.RequirementsBox.Size = new System.Drawing.Size(600, 60);
            this.RequirementsBox.TabIndex = 6;
            // 
            // respomsibiltiesBox
            // 
            this.respomsibiltiesBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.respomsibiltiesBox.Location = new System.Drawing.Point(150, 287);
            this.respomsibiltiesBox.Multiline = true;
            this.respomsibiltiesBox.Name = "respomsibiltiesBox";
            this.respomsibiltiesBox.ReadOnly = true;
            this.respomsibiltiesBox.Size = new System.Drawing.Size(600, 60);
            this.respomsibiltiesBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(50, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "Job Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(50, 410);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "Location";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.Location = new System.Drawing.Point(50, 450);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 28);
            this.label6.TabIndex = 10;
            this.label6.Text = "Experience Level";
            // 
            // typeBox
            // 
            this.typeBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.typeBox.Location = new System.Drawing.Point(150, 367);
            this.typeBox.Name = "typeBox";
            this.typeBox.ReadOnly = true;
            this.typeBox.Size = new System.Drawing.Size(300, 34);
            this.typeBox.TabIndex = 11;
            // 
            // locationBox
            // 
            this.locationBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.locationBox.Location = new System.Drawing.Point(150, 407);
            this.locationBox.Name = "locationBox";
            this.locationBox.ReadOnly = true;
            this.locationBox.Size = new System.Drawing.Size(300, 34);
            this.locationBox.TabIndex = 12;
            // 
            // experienceBox
            // 
            this.experienceBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.experienceBox.Location = new System.Drawing.Point(150, 447);
            this.experienceBox.Name = "experienceBox";
            this.experienceBox.ReadOnly = true;
            this.experienceBox.Size = new System.Drawing.Size(300, 34);
            this.experienceBox.TabIndex = 13;
            // 
            // applyButton
            // 
            this.applyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.applyButton.FlatAppearance.BorderSize = 0;
            this.applyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.applyButton.ForeColor = System.Drawing.Color.White;
            this.applyButton.Location = new System.Drawing.Point(150, 500);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(150, 40);
            this.applyButton.TabIndex = 14;
            this.applyButton.Text = "Apply For Job";
            this.applyButton.UseVisualStyleBackColor = false;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click_1);
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.nextButton.FlatAppearance.BorderSize = 0;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.nextButton.ForeColor = System.Drawing.Color.White;
            this.nextButton.Location = new System.Drawing.Point(600, 500);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(150, 40);
            this.nextButton.TabIndex = 15;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click_1);
            // 
            // prevButton
            // 
            this.prevButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.prevButton.FlatAppearance.BorderSize = 0;
            this.prevButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.prevButton.ForeColor = System.Drawing.Color.White;
            this.prevButton.Location = new System.Drawing.Point(400, 500);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(150, 40);
            this.prevButton.TabIndex = 16;
            this.prevButton.Text = "Previous";
            this.prevButton.UseVisualStyleBackColor = false;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click_1);
            // 
            // jobPositionLabel
            // 
            this.jobPositionLabel.AutoSize = true;
            this.jobPositionLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.jobPositionLabel.Location = new System.Drawing.Point(50, 50);
            this.jobPositionLabel.Name = "jobPositionLabel";
            this.jobPositionLabel.Size = new System.Drawing.Size(118, 28);
            this.jobPositionLabel.TabIndex = 17;
            this.jobPositionLabel.Text = "Job Position";
            // 
            // apply_allbutton
            // 
            this.apply_allbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.apply_allbutton.FlatAppearance.BorderSize = 0;
            this.apply_allbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.apply_allbutton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.apply_allbutton.ForeColor = System.Drawing.Color.White;
            this.apply_allbutton.Location = new System.Drawing.Point(150, 550);
            this.apply_allbutton.Name = "apply_allbutton";
            this.apply_allbutton.Size = new System.Drawing.Size(200, 40);
            this.apply_allbutton.TabIndex = 18;
            this.apply_allbutton.Text = "Apply For All Jobs";
            this.apply_allbutton.UseVisualStyleBackColor = false;
            this.apply_allbutton.Click += new System.EventHandler(this.apply_allbutton_Click_1);
            // 
            // applicationsbutton
            // 
            this.applicationsbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.applicationsbutton.FlatAppearance.BorderSize = 0;
            this.applicationsbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applicationsbutton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.applicationsbutton.ForeColor = System.Drawing.Color.White;
            this.applicationsbutton.Location = new System.Drawing.Point(400, 550);
            this.applicationsbutton.Name = "applicationsbutton";
            this.applicationsbutton.Size = new System.Drawing.Size(200, 40);
            this.applicationsbutton.TabIndex = 19;
            this.applicationsbutton.Text = "View Applications";
            this.applicationsbutton.UseVisualStyleBackColor = false;
            this.applicationsbutton.Click += new System.EventHandler(this.applicationsbutton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 50);
            this.panel1.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(20, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 32);
            this.label7.TabIndex = 0;
            this.label7.Text = "Job Seeker";
            // 
            // Job_SeekerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.applicationsbutton);
            this.Controls.Add(this.apply_allbutton);
            this.Controls.Add(this.jobPositionLabel);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.experienceBox);
            this.Controls.Add(this.locationBox);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.respomsibiltiesBox);
            this.Controls.Add(this.RequirementsBox);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.job_titleBox);
            this.Controls.Add(this.job_titleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Job_SeekerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wuzzuf - Job Seeker";
            this.Load += new System.EventHandler(this.Job_SeekerForm_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}