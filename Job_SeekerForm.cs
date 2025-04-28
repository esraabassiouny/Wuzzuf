using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace wuzzuf
{
    public partial class Job_SeekerForm : Form
    {
        private OracleConnection _conn;
        private List<Dictionary<string, string>> jobsList = new List<Dictionary<string, string>>();
        private int currentJobIndex = -1;
        private string _seeker_id;
        public Job_SeekerForm(OracleConnection connection, string seeker_id)
        {
            InitializeComponent();
            _conn = connection;
            _seeker_id = seeker_id;
        }

        private void Job_SeekerForm_Load(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "select distinct title from jobs";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                job_titleBox.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void job_titleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            jobsList.Clear();
            string jobTitle = job_titleBox.Text;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "select * from jobs where title = :job_title";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("job_title", jobTitle);
            OracleDataReader jobs_dr = cmd.ExecuteReader();
            while (jobs_dr.Read())
            {
                var job = new Dictionary<string, string>();
                job["job_id"] = jobs_dr["job_id"].ToString();
                job["description"] = jobs_dr["description"].ToString();
                job["responsibilities"] = jobs_dr["responsibilities"].ToString();
                job["requirements"] = jobs_dr["requirements"].ToString();
                job["location"] = jobs_dr["location"].ToString();
                job["experience_level"] = jobs_dr["experience_level"].ToString();
                job["job_type"] = jobs_dr["job_type"].ToString();
                jobsList.Add(job);
            }
            jobs_dr.Close();

            if (jobsList.Count > 0)
            {
                currentJobIndex = 0;
                DisplayCurrentJob();
            }
        }

        private void DisplayCurrentJob()
        {
            if (currentJobIndex >= 0 && currentJobIndex < jobsList.Count)
            {
                var currentJob = jobsList[currentJobIndex];

                DescriptionBox.Text = currentJob["description"];
                respomsibiltiesBox.Text = currentJob["responsibilities"];
                RequirementsBox.Text = currentJob["requirements"];
                locationBox.Text = currentJob["location"];
                experienceBox.Text = currentJob["experience_level"];
                typeBox.Text = currentJob["job_type"];

                prevButton.Enabled = currentJobIndex > 0;
                nextButton.Enabled = currentJobIndex < jobsList.Count - 1;

                if (jobPositionLabel != null)
                {
                    jobPositionLabel.Text = $"Job {currentJobIndex + 1} of {jobsList.Count}";
                }
            }
        }
        private void nextButton_Click(object sender, EventArgs e)
        {
            if (currentJobIndex < jobsList.Count - 1)
            {
                currentJobIndex++;
                DisplayCurrentJob();
            }
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if (currentJobIndex > 0)
            {
                currentJobIndex--;
                DisplayCurrentJob();
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            // Get the next application ID
            decimal max_id, app_id;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "GetAppID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("appID", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.ExecuteNonQuery();

            try
            {
                max_id = Convert.ToDecimal(cmd.Parameters[0].Value.ToString());
                app_id = max_id + 1;
            }
            catch
            {
                app_id = 1;
            }

            var currentJob = jobsList[currentJobIndex];

            try
            {
                OracleCommand insertCmd = new OracleCommand();
                insertCmd.Connection = _conn;
                insertCmd.CommandText = @"INSERT INTO applications 
                        (application_id, job_id, seeker_id, application_date, status) 
                        VALUES (:app_id, :job_id, :seeker_id, :app_date, 'submitted')";

                insertCmd.Parameters.Add(":app_id", OracleDbType.Decimal).Value = app_id;
                insertCmd.Parameters.Add(":job_id", OracleDbType.Varchar2).Value = currentJob["job_id"];
                insertCmd.Parameters.Add(":seeker_id", OracleDbType.Varchar2).Value = _seeker_id;

                OracleParameter dateParam = new OracleParameter(":app_date", OracleDbType.TimeStamp);
                dateParam.Value = DateTime.Now;
                insertCmd.Parameters.Add(dateParam);

                int rowsAffected = insertCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // 2. Update application count in jobs table
                    OracleCommand updateCmd = new OracleCommand();
                    updateCmd.Connection = _conn;
                    updateCmd.CommandText = @"UPDATE jobs 
                                           SET APPLICATION_COUNT = APPLICATION_COUNT + 1 
                                           WHERE job_id = :job_id";
                    updateCmd.Parameters.Add(":job_id", OracleDbType.Decimal).Value = currentJob["job_id"];
                    int r = updateCmd.ExecuteNonQuery();

                    // Get the updated application count
                    OracleCommand countCmd = new OracleCommand();
                    countCmd.Connection = _conn;
                    countCmd.CommandText = "GetAppCount";
                    countCmd.CommandType = CommandType.StoredProcedure;

                    countCmd.Parameters.Add("p_job_id", OracleDbType.Decimal).Value =
                        currentJob["job_id"];

                    OracleParameter outputParam = new OracleParameter("appCount", OracleDbType.Decimal);
                    outputParam.Direction = ParameterDirection.Output;
                    countCmd.Parameters.Add(outputParam);
                    int r1 = countCmd.ExecuteNonQuery();
                    decimal applicationCount = Convert.ToDecimal(outputParam.Value.ToString());

                    MessageBox.Show($"Successfully applied to the job!\nTotal applications: {applicationCount}",
                                  "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to apply to the job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1)
                {
                    MessageBox.Show("You have already applied to this job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Error applying to job: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void apply_allbutton_Click(object sender, EventArgs e)
        {
            decimal max_id, app_id;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "GetAppID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("appID", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.ExecuteNonQuery();

            try
            {
                max_id = Convert.ToDecimal(cmd.Parameters[0].Value.ToString());
                app_id = max_id + 1;
            }
            catch
            {
                app_id = 1;
            }

            OracleCommand insertCmd = new OracleCommand();
            insertCmd.Connection = _conn;
            insertCmd.CommandText = @"INSERT INTO applications 
                            (application_id, job_id, seeker_id, application_date, status) 
                            VALUES (:app_id, :job_id, :seeker_id, :app_date, 'submitted')";

            OracleParameter appIdParam = new OracleParameter(":app_id", OracleDbType.Decimal);
            OracleParameter jobIdParam = new OracleParameter(":job_id", OracleDbType.Varchar2);
            OracleParameter jobIdParam1 = new OracleParameter(":job_id", OracleDbType.Varchar2);

            insertCmd.Parameters.Add(appIdParam);
            insertCmd.Parameters.Add(jobIdParam);

            insertCmd.Parameters.Add(":seeker_id", OracleDbType.Varchar2).Value = _seeker_id;

            OracleParameter dateParam = new OracleParameter(":app_date", OracleDbType.TimeStamp);
            dateParam.Value = DateTime.Now;
            insertCmd.Parameters.Add(dateParam);

            // 2. Update application count in jobs table
            OracleCommand updateCmd = new OracleCommand();
            updateCmd.Connection = _conn;
            updateCmd.CommandText = @"UPDATE jobs 
                                           SET APPLICATION_COUNT = APPLICATION_COUNT + 1 
                                           WHERE job_id = :job_id";

            updateCmd.Parameters.Add(jobIdParam1);

            // Get the updated application count
            OracleCommand countCmd = new OracleCommand();
            countCmd.Connection = _conn;
            countCmd.CommandText = "GetAppCount";
            countCmd.CommandType = CommandType.StoredProcedure;

            countCmd.Parameters.Add("p_job_id", OracleDbType.Decimal);
            OracleParameter outputParam = new OracleParameter("appCount", OracleDbType.Decimal);
            outputParam.Direction = ParameterDirection.Output;
            countCmd.Parameters.Add(outputParam);

            decimal [] applicationCount = new decimal[jobsList.Count];
            int index = 0;
            try
            {
                foreach (var job in jobsList)
                {
                    appIdParam.Value = app_id++;
                    jobIdParam.Value = job["job_id"];
                    jobIdParam1.Value = job["job_id"];

                    insertCmd.ExecuteNonQuery();
                    
                    updateCmd.ExecuteNonQuery();

                    countCmd.Parameters["p_job_id"].Value = job["job_id"];

                    countCmd.ExecuteNonQuery();
                    applicationCount[index] = Convert.ToDecimal(outputParam.Value.ToString());
                    index++;

                }
                var message = $"Successfully applied to {jobsList.Count} jobs!\n\n";
                for (int i = 0; i < jobsList.Count; i++)
                {
                    message += $"Job{i + 1} application count: {applicationCount[i]}\n";
                }

                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying to jobs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Job_SeekerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_conn.Dispose();
        }

        private void applicationsbutton_Click(object sender, EventArgs e)
        {
            ApplicationsForm newForm = new ApplicationsForm(_conn,_seeker_id);
            newForm.Show();
        }
    }
}
