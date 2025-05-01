using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wuzzuf
{
    public partial class ApplicationsForm : Form
    {
        private OracleConnection _conn;
        private string _seeker_id;
        private List<Dictionary<string, object>> _applications = new List<Dictionary<string, object>>();
        private int _currentApplicationIndex = 0;
        public ApplicationsForm(OracleConnection connection, string seeker_id)
        {
            InitializeComponent();
            _conn = connection;
            _seeker_id = seeker_id;
        }

        private void ApplicationsForm_Load_1(object sender, EventArgs e)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = _conn;
                cmd.CommandText = "getApplicationsBySeeker";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("seekerID", OracleDbType.Int32).Value = _seeker_id;

                OracleParameter applicationsCursor = new OracleParameter();
                applicationsCursor.ParameterName = "applications";
                applicationsCursor.OracleDbType = OracleDbType.RefCursor;
                applicationsCursor.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(applicationsCursor);

                OracleDataReader reader = null;
                try
                {
                    reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var app = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                app[reader.GetName(i)] = reader.GetValue(i);
                            }
                            _applications.Add(app);
                        }

                        if (_applications.Count > 0)
                        {
                            ShowCurrentApplication();
                        }
                        else
                        {
                            MessageBox.Show("No applications found for this user.", "Information",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No applications found for this user.", "Information",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                finally
                {
                    if (reader != null && !reader.IsClosed)
                        reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading applications: " + ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowCurrentApplication()
        {
            if (_applications.Count == 0) return;

            var currentApp = _applications[_currentApplicationIndex];

            txtTitle.Text = currentApp["TITLE"].ToString();
            txtJobType.Text = currentApp["JOB_TYPE"].ToString();
            txtCompany.Text = currentApp["COMPANY_NAME"].ToString();
            txtLocation.Text = currentApp["LOCATION"].ToString();
            txtAppDate.Text = Convert.ToDateTime(currentApp["APPLICATION_DATE"]).ToString("yyyy-MM-dd");
            txtStatus.Text = currentApp["STATUS"].ToString();

            lblPageInfo.Text = $"Application {_currentApplicationIndex + 1} of {_applications.Count}";

            btnPrev.Enabled = _currentApplicationIndex > 0;
            btnNext.Enabled = _currentApplicationIndex < _applications.Count - 1;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentApplicationIndex > 0)
            {
                _currentApplicationIndex--;
                ShowCurrentApplication();
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentApplicationIndex < _applications.Count - 1)
            {
                _currentApplicationIndex++;
                ShowCurrentApplication();
            }
        }
    }
}
