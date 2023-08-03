﻿using Controller;
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
    }
}
