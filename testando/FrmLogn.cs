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
    public partial class FrmLogn : Form
    {
        public FrmLogn()
        {
            InitializeComponent();
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            int codigoUsuario;
            UsuarioModelo us = new UsuarioModelo();
            UsuarioController uscontrole= new UsuarioController();
            us.nome = txtUsuario.Text;
            us.senha = txtSenha.Text;
           if( string.IsNullOrEmpty(us.nome))
            {
                    MessageBox.Show("Nome vazio");
                txtUsuario.Focus();//retorna ao campo vazio
            }
            if (string.IsNullOrEmpty(us.senha))
            {
                MessageBox.Show("Senha vazio");
                txtSenha.Focus();//retorna ao campo vazio
            }
            //guarda o idUsuario retornado da consulta
            codigoUsuario = uscontrole.logar(us);
            MessageBox.Show("Usuario ID=" + codigoUsuario.ToString());
              if (codigoUsuario >=1)
                {

                   this.Hide();//oculta a janela
                FrmPrincipal principal= new FrmPrincipal(codigoUsuario);
                 
                principal.ShowDialog();
               
            }
            else{
                MessageBox.Show("Usuario ou senha invalidos");    
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
           // if (Keys.Enter)
           // {

           // }
        }

        private void btnRecuperarSenha_Click(object sender, EventArgs e)
        {
            Conexao com= new Conexao();
          lblMensagem.Text= com.recuperaremail(txtUsuario.Text);

        }
    }
}
