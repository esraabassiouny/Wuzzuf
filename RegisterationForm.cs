using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;



namespace wuzzuf
{
    public partial class RegisterationForm : Form
    {
        private OracleConnection _conn;
        private string _profileImagePath = string.Empty; 

        public RegisterationForm(OracleConnection connection)
        {
            InitializeComponent();
            this._conn = connection;        }

        private void btnBrowseImage_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _profileImagePath = openFileDialog.FileName; 
                    picProfileImage.Image = Image.FromFile(openFileDialog.FileName);
                }
                Console.WriteLine(openFileDialog.ToString());
            }
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string phone = txtPhone.Text.Trim();
            string userType = cmbUserType.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(userType))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Additional validation for employers
            if (userType == "employer" && string.IsNullOrEmpty(txtCompanyName.Text.Trim()))
            {
                MessageBox.Show("Company Name is required for employers.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal max_id, user_id;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = _conn;
                cmd.CommandText = "GetUserID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userID", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.ExecuteNonQuery();

                try
                {
                    max_id = Convert.ToDecimal(cmd.Parameters[0].Value.ToString());
                    user_id = max_id + 1;
                }
                catch
                {
                    user_id = 1;
                }
                OracleCommand cmd1 = new OracleCommand();
                cmd1.Connection = _conn;
                cmd1.CommandText = "insert into users values (:id,:firstName,:lastName,:email,:Phone,:User_type,:profile,:password)";
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.Add("id", user_id);
                cmd1.Parameters.Add("firstName", firstName);
                cmd1.Parameters.Add("lastName", lastName);
                cmd1.Parameters.Add("email", email);
                cmd1.Parameters.Add("Phone", phone);
                cmd1.Parameters.Add("User_type", userType);
                cmd1.Parameters.Add("profile", string.IsNullOrEmpty(_profileImagePath) ? "default_profile.jpg" : _profileImagePath);
                cmd1.Parameters.Add("password", password);

                int r = cmd1.ExecuteNonQuery();

                if (r != -1)
                {
                    if (userType == "job_seeker")
                    {
                        OracleCommand cmdSeeker = new OracleCommand();
                        cmdSeeker.Connection = _conn;
                        cmdSeeker.CommandText = @"INSERT INTO Job_Seekers 
                                    (seeker_id, birth_date, gender, current_job_title, 
                                     years_of_experience, highest_education_level, skills) 
                                    VALUES 
                                    (:seeker_id, :birth_date, :gender, :job_title, 
                                     :experience, :education, :skills)";

                        cmdSeeker.Parameters.Add("seeker_id", user_id);
                        cmdSeeker.Parameters.Add("birth_date", dtpBirthDate.Checked ? dtpBirthDate.Value : (object)DBNull.Value);
                        cmdSeeker.Parameters.Add("gender", string.IsNullOrEmpty(cmbGender.Text) ? (object)DBNull.Value : cmbGender.Text);
                        cmdSeeker.Parameters.Add("job_title", string.IsNullOrEmpty(txtJobTitle.Text) ? (object)DBNull.Value : txtJobTitle.Text);

                        decimal experience;
                        cmdSeeker.Parameters.Add("experience", decimal.TryParse(txtExperience.Text, out experience) ? experience : (object)DBNull.Value);

                        cmdSeeker.Parameters.Add("education", string.IsNullOrEmpty(txtEducation.Text) ? (object)DBNull.Value : txtEducation.Text);
                        cmdSeeker.Parameters.Add("skills", string.IsNullOrEmpty(txtSkills.Text) ? (object)DBNull.Value : txtSkills.Text);

                        cmdSeeker.ExecuteNonQuery();
                    }
                    else if (userType == "employer")
                    {
                        OracleCommand cmdEmployer = new OracleCommand();
                        cmdEmployer.Connection = _conn;
                        cmdEmployer.CommandText = @"INSERT INTO Employers 
                                      (employer_id, company_name, industry, company_description, 
                                       website_url, founded_year, company_size) 
                                      VALUES 
                                      (:employer_id, :company_name, :industry, :company_desc, 
                                       :website, :founded_year, :company_size)";

                        cmdEmployer.Parameters.Add("employer_id", user_id);
                        cmdEmployer.Parameters.Add("company_name", txtCompanyName.Text.Trim());
                        cmdEmployer.Parameters.Add("industry", string.IsNullOrEmpty(txtIndustry.Text) ? (object)DBNull.Value : txtIndustry.Text);
                        cmdEmployer.Parameters.Add("company_desc", string.IsNullOrEmpty(txtCompanyDesc.Text) ? (object)DBNull.Value : txtCompanyDesc.Text);
                        cmdEmployer.Parameters.Add("website", string.IsNullOrEmpty(txtWebsite.Text) ? (object)DBNull.Value : txtWebsite.Text);

                        decimal foundedYear;
                        cmdEmployer.Parameters.Add("founded_year", decimal.TryParse(txtFoundedYear.Text, out foundedYear) ? foundedYear : (object)DBNull.Value);

                        cmdEmployer.Parameters.Add("company_size", string.IsNullOrEmpty(txtCompanySize.Text) ? (object)DBNull.Value : txtCompanySize.Text);

                        cmdEmployer.ExecuteNonQuery();
                    }

                    MessageBox.Show($"User Registered:\n\nName: {firstName} {lastName}\nEmail: {email}\nPhone: {phone}\nUser Type: {userType}",
                                  "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (OracleException ex) when (ex.Number == 1) // ORA-00001: unique constraint violated
            {
                if (ex.Message.Contains("SCOTT.SYS_C0022003"))
                {
                    MessageBox.Show("This email address is already registered. Please use a different email.",
                                  "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Database error: {ex.Message}",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbUserType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbUserType.SelectedItem != null)
            {
                string selectedType = cmbUserType.SelectedItem.ToString();

                pnlJobSeekerFields.Visible = (selectedType == "job_seeker");
                pnlEmployerFields.Visible = (selectedType == "employer");

                if (pnlJobSeekerFields.Visible || pnlEmployerFields.Visible)
                {
                    this.Height = 800; 
                    btnSubmit.Location = new System.Drawing.Point(150, 700);
                }
                else
                {
                    this.Height = 470; 
                    btnSubmit.Location = new System.Drawing.Point(150, 400);
                }
            }
        }
    }
}
