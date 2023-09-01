using Controller;
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

namespace testando
{
    public partial class FrmPrincipal : Form
    {
        int idUsu;//crio a variavel do id usuario local
        //passo  oID pelo paramentro do
        //declaro os objeto para instanciar o usuario
        UsuarioController usController = new UsuarioController();
        UsuarioModelo usmodelo = new UsuarioModelo();
        public FrmPrincipal(int codigo)
        {
            idUsu = codigo;//atribui a variavel local
            MessageBox.Show("Seja bem vindo Id" + codigo);
            InitializeComponent();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FrmUsuario usuario = new FrmUsuario();
            usuario.MdiParent = this;
            usuario.Show();
        }

        private void usuárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmListarUsuario frmlistar= new FrmListarUsuario(); 
            frmlistar.MdiParent=this;
            frmlistar.Show();

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //carrego no usuario as informações
            usmodelo = usController.CarregaUsuario(idUsu);
            label1.Text = usmodelo.nome;
            if (usmodelo.idperfil == 1)
            {
                //deixar o menu invisivel
                usuárioToolStripMenuItem.Visible = false;
            }else
                if(usmodelo.idperfil == 2)
            {
                usuárioToolStripMenuItem.Visible = true;
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //result guarda a resposta do botao
           var result= MessageBox.Show("Deseja sair do sistema?","Sair do sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
           if(result == DialogResult.Yes)
            {
                this.Close();
                FrmLogn login = new FrmLogn();
              login.ShowDialog();
               
            }
           
          
               
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //chamar o produto
            FrmProduto prod = new FrmProduto();
            prod.MdiParent = this;//integrar a janela
            prod.Show();//mostrar a tela
        }

        private void listarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListarProduto Lprod = new FrmListarProduto();
            Lprod.MdiParent = this;
            Lprod.Show();
        }

        private void painelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPainel painel = new FrmPainel();
            painel.MdiParent = this;
            painel.Show();
        }
    }
}
