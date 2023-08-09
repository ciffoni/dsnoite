using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;//chamo o projeto controller
namespace testando
{
    public partial class FrmProduto : Form
    {
        public FrmProduto()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            //instanciar o objeto produto
            ProdutoModelo pmodelo = new ProdutoModelo();
            pmodelo.descricao = txtDescricao.Text;
            pmodelo.preco = Convert.ToDecimal(txtPreco.Text);
            if( chkData.Checked )
            pmodelo.perecivel = true;
            else
             pmodelo.perecivel = false;
            pmodelo.quantidade = Convert.ToInt32(txtQuantidade.Text);
            pmodelo.data_val=data_validade.Value;
            ProdutoController pController = new ProdutoController();
            if (pController.cadastrarProduto(pmodelo) == true)
                MessageBox.Show("Cadastro com sucesso");
            else
                MessageBox.Show("Erro no cadastro");
        }
    }
}
