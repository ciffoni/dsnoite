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
            int x = 0, y = 0;//posição da tela
            //varrer os registros da table produto
            for (registros = 0; registros < dt.Rows.Count; registros++)
            {
                //criando manualmente
                Panel produto= new Panel();//criando o painel de produto
                //borda do produto
                produto.BorderStyle = BorderStyle.FixedSingle;
                produto.Location = new Point(x, y);//defino o local
                //altura e largura da borda
                produto.Height = 250;
                produto.Width = 250;
                Label idproduto=   new Label();//crio uma label
                idproduto.Name = "cod_prod";
               // idproduto.Location=new Point(5, 85);
                idproduto.Text = dt.Rows[registros][0].ToString();//mostra o registro
                PictureBox foto=new PictureBox();//crio a area de foto
                foto.Location=new Point(20, 0);
                foto.SizeMode = PictureBoxSizeMode.StretchImage;
                foto.Name = "foto";
                foto.Image = Image.FromFile(dt.Rows[registros][6].ToString());
                Label preco = new Label();
                preco.Name = "preco";
                preco.Text = dt.Rows[registros][2].ToString();
                preco.Location=new Point(20, 85);
                Label descproduto= new Label();
                descproduto.Name = "desc_prod";
                descproduto.Text = dt.Rows[registros][1].ToString();
                descproduto.Location=new Point(20, 55);
                TextBox qtde = new TextBox();
                qtde.Name = "qtde";
                qtde.Location = new Point(20, 120);
                //adicionando os componentes ao painel
                Button registrar = new Button();
                registrar.Name = "Selecionar";
                registrar.Text = "Selecionar";
                registrar.Font=new Font("Arial",8,FontStyle.Bold);
                registrar.Click += new EventHandler((sender1, e1) => SelecionarClick(sender1, e1, idproduto.Text));
                registrar.Location = new Point(20, 150);

                produto.Controls.Add(descproduto);
                produto.Controls.Add(preco);
                produto.Controls.Add(foto);
                produto.Controls.Add(idproduto);
                produto.Controls.Add(qtde);
                produto.Controls.Add(registrar);
                //painel criado da caixa de ferramenta
                //adiciono cada produto da consulta ao painel 
                flowLayoutPanel1.Controls.Add(produto);
                //somando 100 a y
                y += 100;
                x = 0;


            }

        }
        private void SelecionarClick(object sender,EventArgs e,string Id)
        {
            MessageBox.Show("Produto selecionado" + Id);
        }
    }
}
