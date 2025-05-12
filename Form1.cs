using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.Shared;
using System.Windows.Forms;

namespace wuzzuf
{
    public partial class Form1 : Form
    {
        CrystalReport1 cr;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cr.SetParameterValue(0, comboBox1.Text);
            crystalReportViewer1.ReportSource = cr;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cr = new CrystalReport1();
            foreach (ParameterDiscreteValue v in cr.ParameterFields[0].DefaultValues) 
            {
                comboBox1.Items.Add(v.Value);
            }
        }

       
    }
}
