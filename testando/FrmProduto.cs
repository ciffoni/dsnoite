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
        //instancio o objeto produto
        ProdutoModelo pmodelo = new ProdutoModelo();
        ProdutoController pController = new ProdutoController();
        Conexao com = new Conexao();
        public FrmProduto()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            //instanciar o objeto produto
            try
            {


                pmodelo.descricao = txtDescricao.Text;

                pmodelo.preco = Convert.ToDecimal(txtPreco.Text);
                if (chkData.Checked)
                {

                    pmodelo.perecivel = true;

                }

                else
                {

                    pmodelo.perecivel = false;
                }

                pmodelo.quantidade = Convert.ToInt32(txtQuantidade.Text);
                pmodelo.data_val = data_validade.Value;
                pmodelo.foto = lblFoto.Text;
                 if (pController.cadastrarProduto(pmodelo,1) == true)
                    MessageBox.Show("Cadastro com sucesso");
                else
                    MessageBox.Show("Erro no cadastro");
            }catch(Exception ex)
            {
                MessageBox.Show("Erro: "+ ex.Message);
            }
           }


        private void btnFoto_Click(object sender, EventArgs e)
        {
           
        }

        private void chkData_Click(object sender, EventArgs e)
        {
            if (chkData.Checked)
            {
                data_validade.Visible = true;
            }

            else
            {
                data_validade.Visible = false;
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            //codigo ascii para o backspace
            char delete = (char)8;
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != delete;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //carrega as informações do form para o objeto
            pmodelo.descricao = txtDescricao.Text;
            pmodelo.preco = Convert.ToDecimal(txtPreco.Text);
            pmodelo.quantidade = Convert.ToInt32(txtQuantidade.Text);
            pmodelo.codigo = Convert.ToInt32(txtCodigo.Text);
            if(chkData.Checked)
                 pmodelo.perecivel=true;
            else
                pmodelo.perecivel = false;
            pmodelo.data_val=data_validade.Value;
            pmodelo.foto=lblFoto.Text;
            if (pController.cadastrarProduto(pmodelo, 2) == true)
            {
                MessageBox.Show("Atualizado com sucesso");
            }
            else
            {
                MessageBox.Show("Erro na atualização");
            }
        }

        private void btnFoto_Click_1(object sender, EventArgs e)
        {
            try
            {
                //chamo a caixa de dialogo para foto
                OpenFileDialog foto = new OpenFileDialog();
                foto.Filter = "Image File(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
                //verifica se apertou no OK do dialog
                if (foto.ShowDialog() == DialogResult.OK)
                { //mostra o nome da foto
                    lblFoto.Text = foto.FileName;
                    //caminho da imagem para ser exibida no form
                    Image arquivo = Image.FromFile(foto.FileName);
                    ptbfoto.Image = arquivo;//carrego a foto
                }
                else
                {
                    MessageBox.Show("Não escolheu a foto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                pmodelo.codigo = Convert.ToInt32(txtCodigo.Text);

                if (string.IsNullOrEmpty(pmodelo.codigo.ToString()))
                {
                    MessageBox.Show("Codigo está vazio");
                    txtCodigo.Focus();
                }
                else
                {
                    if (pmodelo.codigo > 0)
                    {
                        if (pController.cadastrarProduto(pmodelo, 3) == true)
                        {
                            MessageBox.Show("Produto " + pmodelo.descricao + " excluido com sucesso");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Favor escolher um produto");
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            dtProduto.DataSource = com.obterdados("Select * from produto");
        }
    }
}
