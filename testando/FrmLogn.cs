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
            UsuarioModelo us = new UsuarioModelo();
            UsuarioController uscontrole= new UsuarioController();
            us.nome = txtUsuario.Text;
            us.senha = txtSenha.Text;
           if( string.IsNullOrEmpty(us.nome))
            {
                    MessageBox.Show("Nome vazio");
                txtUsuario.Focus();
            }
            if (string.IsNullOrEmpty(us.senha))
            {
                MessageBox.Show("Senha vazio");
                txtSenha.Focus();
            }
              if (uscontrole.logar(us) == true)
                {
                   this.Hide();//oculta a janela
                FrmPrincipal principal= new FrmPrincipal();
                 
                principal.ShowDialog();
               
            }
            else{
                MessageBox.Show("Usuario ou senha invalidos");    
            }
            
        }
    }
}
