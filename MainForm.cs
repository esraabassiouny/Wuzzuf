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
    public partial class MainForm : Form
    {
        OracleConnection conn;
        string ordb = "data source = orcl; user id =scott; password=tiger;";
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterationForm newForm = new RegisterationForm(this.conn);
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm newForm = new LoginForm(this.conn);
            newForm.Show();
        }
    }
}
