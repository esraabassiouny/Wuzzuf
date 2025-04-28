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
    public partial class LoginForm : Form
    {
        private OracleConnection _conn;
        public LoginForm(OracleConnection connection)
        {
            InitializeComponent();
            _conn = connection;
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // check email and password 
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "select * from users where email = :email AND user_password = :password";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("email", email);
            cmd.Parameters.Add("password", password);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string userType = dr["user_type"].ToString();
                string seeker_id = dr["user_ID"].ToString();
                if (userType == "job_seeker")
                {
                    Job_SeekerForm newForm = new Job_SeekerForm(this._conn, seeker_id);
                    newForm.Show();
                }
                else
                {
                    EmployerForm newForm = new EmployerForm();
                    newForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_conn.Dispose();
        }
    }
}
