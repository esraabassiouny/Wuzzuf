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
        string employer_id;
        public EmployerForm(string id)
        {
            InitializeComponent();
            employer_id = id;
        }
        private void EmployerForm_Load_1(object sender, EventArgs e)
        {
            string conStr = "data source = orcl; user id = scott; password = tiger;";
            string cmdStr = @"SELECT DISTINCT j.title 
                     FROM jobs j
                     JOIN employers e ON j.employer_id = e.employer_id
                     WHERE e.employer_id = :employer_id";
            adapter = new OracleDataAdapter(cmdStr, conStr);
            adapter.SelectCommand.Parameters.Add("employer_id", OracleDbType.Decimal).Value = decimal.Parse(employer_id);
            ds = new DataSet();
            adapter.Fill(ds, "jobs");
            dataGridView2.DataSource = ds.Tables["jobs"];
        }


        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            ds.Tables.Clear();
            string jobTitle = dataGridView2.Rows[e.RowIndex].Cells["title"].Value.ToString();
            string conStr = "data source = orcl; user id = scott; password = tiger;";

            string displayQuery = @"SELECT a.application_id, u.first_name, u.last_name, js.years_of_experience, js.highest_education_level,
                                    js.skills, a.application_date, a.status, a.job_id
                                    FROM applications a
                                    JOIN jobs j ON a.job_id = j.job_id
                                    JOIN users u ON a.seeker_id = u.user_id
                                    JOIN job_seekers js ON js.seeker_id = a.seeker_id
                                    JOIN employers e ON j.employer_id = e.employer_id
                                    WHERE j.title = :jobTitle
                                    AND e.employer_id = :employer_id";

            OracleDataAdapter displayAdapter = new OracleDataAdapter(displayQuery, conStr);
            displayAdapter.SelectCommand.Parameters.Add("jobTitle", jobTitle);
            displayAdapter.SelectCommand.Parameters.Add("employer_id", OracleDbType.Decimal).Value = decimal.Parse(employer_id);
            displayAdapter.Fill(ds, "display");

            dataGridView1.DataSource = ds.Tables["display"];
            dataGridView1.ReadOnly = false;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.ReadOnly = col.Name != "STATUS";

            string appQuery = @"SELECT * FROM applications WHERE job_id IN (SELECT job_id FROM jobs 
                              WHERE title = :jobTitle)"; 
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

            try
            {
                adapter.Update(ds.Tables["applications"]);
                MessageBox.Show("Changes saved successfully.");
            }
            catch
            {
                MessageBox.Show("Status must be choosen from ('submitted', 'under_review', 'shortlisted', 'rejected', 'hired')");

            }
        }

    }
}
