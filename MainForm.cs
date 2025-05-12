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

        private void MainForm_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RegisterationForm newForm = new RegisterationForm(this.conn);
            newForm.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            LoginForm newForm = new LoginForm(this.conn);
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }
    }
}
