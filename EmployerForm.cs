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
    public partial class EmployerForm : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;

        public EmployerForm()
        {
            InitializeComponent();
        }
        private void EmployerForm_Load_1(object sender, EventArgs e)
        {
            string conStr = "data source = orcl; user id = scott; password = tiger;";
            string cmdStr = "SELECT DISTINCT title FROM jobs";
            adapter = new OracleDataAdapter(cmdStr, conStr);
            ds = new DataSet();
            adapter.Fill(ds, "jobs");
            dataGridView2.DataSource = ds.Tables["jobs"];
            //dataGridView2.Columns["job_id"].Visible = false;
        }


        //private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    string jobTitle = dataGridView2.Rows[e.RowIndex].Cells["title"].Value.ToString();
        //    //string conStr = "data source = orcl; user id = scott; password = tiger;";
        //    //string cmdStr = "select job_id from jobs where job_title = :jobTitle";
        //    //adapter = new OracleDataAdapter(cmdStr, conStr);
        //    string conStr = "data source = orcl; user id = scott; password = tiger;";
        //    string cmdStr = @"select APPLICATION_ID, first_name, last_name, years_of_experience, highest_education_level, skills, 
        //                    application_date, status from applications, jobs, users, job_seekers where applications.job_id
        //                    = jobs.job_id and applications.seeker_id = users.user_id and job_seekers.seeker_id  = applications.seeker_id and jobs.title =:jobTitle";
        //    adapter = new OracleDataAdapter(cmdStr, conStr);
        //    adapter.SelectCommand.Parameters.Add("jobTitle", jobTitle);
        //    ds = new DataSet();
        //    adapter.Fill(ds);
        //    dataGridView1.DataSource = ds.Tables[0];
        //}
        //private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int jobId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["job_id"].Value);

        //    string conStr = "data source = orcl; user id = scott; password = tiger;";
        //    string cmdStr = "SELECT * FROM applications WHERE job_id = :jobId";

        //    adapter = new OracleDataAdapter(cmdStr, conStr);
        //    adapter.SelectCommand.Parameters.Add("jobId", jobId);

        //    builder = new OracleCommandBuilder(adapter); // needed for save

        //    ds = new DataSet();
        //    adapter.Fill(ds, "applications");
        //    dataGridView1.DataSource = ds.Tables["applications"];
        //}

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            ds.Tables.Clear();
            //dataGridView1.ClearSelection();
            string jobTitle = dataGridView2.Rows[e.RowIndex].Cells["title"].Value.ToString();
            string conStr = "data source = orcl; user id = scott; password = tiger;";

            string displayQuery = @"SELECT a.application_id, u.first_name, u.last_name, js.years_of_experience, js.highest_education_level,
                                    js.skills, a.application_date, a.status, a.job_id
                                    FROM applications a
                                    JOIN jobs j ON a.job_id = j.job_id
                                    JOIN users u ON a.seeker_id = u.user_id
                                    JOIN job_seekers js ON js.seeker_id = a.seeker_id
                                    WHERE j.title = :jobTitle";

            OracleDataAdapter displayAdapter = new OracleDataAdapter(displayQuery, conStr);
            displayAdapter.SelectCommand.Parameters.Add("jobTitle", jobTitle);
            displayAdapter.Fill(ds, "display");

            dataGridView1.DataSource = ds.Tables["display"];
            dataGridView1.ReadOnly = false;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.ReadOnly = col.Name != "STATUS";

            string appQuery = "SELECT * FROM applications WHERE job_id = (SELECT job_id FROM jobs WHERE title = :jobTitle)";
            adapter = new OracleDataAdapter(appQuery, conStr);
            adapter.SelectCommand.Parameters.Add("jobTitle", jobTitle);
            builder = new OracleCommandBuilder(adapter);
            adapter.Fill(ds, "applications");
        }
        private void savebutton_Click_1(object sender, EventArgs e)
        {
            foreach (DataRow displayRow in ds.Tables["display"].Rows)
            {
                int appId = Convert.ToInt32(displayRow["application_id"]);
                string newStatus = displayRow["status"].ToString();

                DataRow[] appRows = ds.Tables["applications"].Select("application_id = " + appId);
                if (appRows.Length > 0)
                    appRows[0]["status"] = newStatus;
            }

            adapter.Update(ds.Tables["applications"]);
            MessageBox.Show("Changes saved successfully.");
        }

    }
}
