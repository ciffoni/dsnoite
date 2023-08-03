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
    public partial class FrmUsuario : Form
    {
        int codigo;
        int idperfil;//declaro o perfil publico
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            UsuarioController controller = new UsuarioController(); 
            UsuarioModelo usmodelo= new UsuarioModelo();
            usmodelo.nome = txtNome.Text;
            usmodelo.senha = txtSenha.Text;
            usmodelo.idperfil = idperfil;
            if( usmodelo.nome != "" && usmodelo.senha != "")
            {
                if (controller.cadastrar(usmodelo) == true)
                {
                    MessageBox.Show("cadastro com sucesso!");
                  
                }
                else
                {
                    MessageBox.Show("Erro no cadastro d ousuário");
                }
            }
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            UsuarioController uscontroller= new UsuarioController();
            dtUsuario.DataSource = uscontroller.obterdados("select usuario.idusuario,usuario.nome,usuario.senha,perfil.perfil from usuario inner join perfil on usuario.id_perfil=perfil.id_perfil;");
            cboPerfil.DataSource = uscontroller.obterdados("select * from perfil");
            cboPerfil.DisplayMember = "perfil";
            cboPerfil.ValueMember = "id_perfil";
        }

        private void dtUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            codigo = Convert.ToInt32(dtUsuario.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            MessageBox.Show("Codigo " + codigo.ToString());
            txtNome.Text = dtUsuario.Rows[e.RowIndex].Cells["nome"].Value.ToString();
            txtSenha.Text = dtUsuario.Rows[e.RowIndex].Cells["senha"].Value.ToString();
            cboPerfil.Text = dtUsuario.Rows[e.RowIndex].Cells["perfil"].Value.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            UsuarioController uscontroller = new UsuarioController();
           //chamo o metodo excluir do usuario controler se verdade
            if (uscontroller.excluir(codigo) == true)
            { //excluir o usuario
                MessageBox.Show("codigo do Usuário "+codigo+" excluido com sucesso");
             
            }
            else
            {//falso erro ao excluir
                MessageBox.Show("Erro ao excluir o usuário");
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            //instancio o objeto usuario controle
            UsuarioController uscontroler = new UsuarioController();
            UsuarioModelo usmodelo = new UsuarioModelo();
           //populando o objeto usuario modelo
            usmodelo.nome= txtNome.Text;
            usmodelo.senha = txtSenha.Text;
            usmodelo.idusuario = codigo;
            usmodelo.idperfil = idperfil;
            if( uscontroler.editar(usmodelo) == true)
            {
                MessageBox.Show("Usuario atualizado com sucesso");
            }
            else
            {
                MessageBox.Show("Erro ao atualizar usuário");
            }

        }

        private void btnListarUsuario_Click(object sender, EventArgs e)
        {
            //instancio o novo formulario
            FrmListarUsuario frmListar = new FrmListarUsuario();
            frmListar.ShowDialog();//mostro o formulario listar
        }

        private void cboPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            //variavel perfil convert para inteiro
             idperfil = Convert.ToInt32(((DataRowView)cboPerfil.SelectedItem)["id_perfil"]);
        }

        private void txtSenha_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtSenha, "Tamanho 8 caracter letras e numeros");
        }
    }
}
