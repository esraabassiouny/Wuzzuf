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
            string userType = cmbUserType.SelectedItem.ToString();
            //string profilePicURL = 

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(userType))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            cmd1.Parameters.Add("firstName", txtFirstName.Text.ToString());
            cmd1.Parameters.Add("lastName", txtLastName.Text.ToString());
            cmd1.Parameters.Add("email", txtEmail.Text.ToString());
            cmd1.Parameters.Add("Phone", txtPhone.Text.ToString());
            cmd1.Parameters.Add("User_type", userType);
            cmd1.Parameters.Add("profile", "hhhhhhhhhhhbdk");
            cmd1.Parameters.Add("password", txtPassword.Text.ToString());
            int r = cmd1.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show($"User Registered:\n\nName: {firstName} {lastName}\nEmail: {email}\nPhone: {phone}\nUser Type: {userType}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void RegisterationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_conn.Dispose();
        }
    }
}
