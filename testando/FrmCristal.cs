using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using Controller;
using MySql.Data.MySqlClient;
using CrystalDecisions.Windows.Forms;

namespace testando
{
    public partial class FrmCristal : Form
    {
       //ReportDocument rprt = new ReportDocument();
        public FrmCristal()
        {
            InitializeComponent();
        }

        private void FrmCristal_Load(object sender, EventArgs e)
        {
            Conexao com = new Conexao();
            MySqlConnection con = com.getConexao();
            CrystalReportViewer cr = new CrystalReportViewer();
           // rprt.Load(@"C:\Users\Nilesh\Documents\visual studio 2010\Projects\WindowsFormsApplication5\WindowsFormsApplication5\CrystalReport1.rpt");
            MySqlCommand cmd = new MySqlCommand("Select * from usuario", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Newtbl_data");
            rprt.SetDataSource(ds);
            cr.ReportSource = rprt;

        }
    }
}
