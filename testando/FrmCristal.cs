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
using System.Configuration;
using System.IO;
using Controller;
using System.Xml.Linq;

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
            

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string endereco = "relatorioUsuario.csv";
        
                /*
                "C:\\relatorio.csv";
            */
            Conexao com= new Conexao();

            using (StreamWriter writer = new StreamWriter(endereco, false, Encoding.GetEncoding("iso-8859-15")))

            {

                // Cabeçalho 

                writer.WriteLine("Nome;Email");


                // Conexão com o banco de dados

                MySqlConnection conexao = com.getConexao();


               
                    string query = "SELECT NOME,email FROM usuario";


                    MySqlCommand sqlComand = new MySqlCommand(query, conexao);


                    conexao.Open();


                    using (IDataReader reader = sqlComand.ExecuteReader())

                    {

                        while (reader.Read())

                        {

                            // escrevendo os registros

                            writer.WriteLine(Convert.ToString(reader["nome"]) + ";" + Convert.ToString(reader["email"]));

                        }

                    }

                    conexao.Close();
                // mensagem de arquivo gerado com sucesso.

                MessageBox.Show("Relatório gerado com sucesso.", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

       


         }
    }

