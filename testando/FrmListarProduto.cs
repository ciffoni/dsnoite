using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using Controller;
namespace testando
{
    public partial class FrmListarProduto : Form
    {
        Conexao com = new Conexao();
        public FrmListarProduto()
        {
            InitializeComponent();
        }

        private void FrmListarProduto_Load(object sender, EventArgs e)
        {
            //tabela de dados
            DataTable dt = new DataTable();
            //buscando e populando da datatable
            dt = com.obterdados("select * from produto");
            int registros;//ler a quantidade de dados
            //varrer os registros da table produto
            for (registros = 0; registros < dt.Rows.Count; registros++)
            {
                //criando manualmente
                Panel produto= new Panel();//criando o painel de produto
                produto.Location = new Point(0, 0);//defino o local
                Label idproduto=   new Label();//crio uma label
                idproduto.Name = "cod_prod";
                idproduto.Text = dt.Rows[registros][0].ToString();//mostra o registro
                PictureBox foto=new PictureBox();//crio a area de foto
                foto.Location=new Point(10, 0);
                foto.SizeMode = PictureBoxSizeMode.StretchImage;
                foto.Name = "foto";
                foto.Image = Image.FromFile(dt.Rows[registros][6].ToString());
                Label preco = new Label();
                preco.Name = "preco";
                preco.Text = dt.Rows[registros][2].ToString();
                preco.Location=new Point(20, 0);

                //adicionando os componentes ao painel
                produto.Controls.Add(preco);
                produto.Controls.Add(foto);
                produto.Controls.Add(idproduto);
                //painel criado da caixa de ferramenta
                //adiciono cada produto da consulta ao painel 
                panel1.Controls.Add(produto);


            }

        }
    }
}
