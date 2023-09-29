using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace testando
{
    public partial class FrmBackup : Form
    {
        Conexao com = new Conexao();
        public FrmBackup()
        {
            InitializeComponent();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            //nome do arquivo a ser salvo
            String nomeArquivo="c:\\backup.sql";
           
            MySqlCommand cmd= new MySqlCommand();
            MySqlConnection con=  com.getConexao();
            using (MySqlBackup mb = new MySqlBackup(cmd))
            {
                cmd.Connection = con;
                con.Open();
                mb.ExportInfo.AddCreateDatabase = true;
                mb.ExportInfo.ExportProcedures = true;
                mb.ExportInfo.ExportRows = true;
                mb.ExportToFile(nomeArquivo);
                con.Close();

            }

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            //nome do arquivo a ser salvo
            String nomeArquivo = "c:\\backup.sql";
            string StrCon = "server=localhost;user=root;pwd=''";

            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection con = new MySqlConnection(StrCon);
            using (MySqlBackup mb = new MySqlBackup(cmd))
            {
                cmd.Connection = con;
                con.Open();
               mb.ImportFromFile(nomeArquivo);
                con.Close();

            }
        }
    }
}
