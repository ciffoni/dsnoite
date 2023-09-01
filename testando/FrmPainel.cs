using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testando
{
    public partial class FrmPainel : Form
    {
        //definir a herarquia
        TreeNode parentNode = null;
        Conexao com = new Conexao();
        public FrmPainel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            // Criamos uma nova instância do frmAddLeitor
            FrmUsuario ad = new FrmUsuario();

            // Dizemos que não é o elemento principal/elemento pai
            ad.TopLevel = false;
            // Preenchemos o painel por completo
            ad.Dock = DockStyle.Fill;
            // Retiramos a borda
            ad.FormBorderStyle = FormBorderStyle.None;
            // Adiciona o formulário dentro do painel menu
            panel1.Controls.Add(ad);
            // Mostramos o formulário
            ad.Show();
            pictureBox1.Visible = false;
        }

        private void FrmPainel_Load(object sender, EventArgs e)
        {
            //chamo a conexao
          
            string sql = "select * from perfil";
            //carrega na tabela o perfil
            DataTable userperfil = com.obterdados(sql);
            //listar o perfil
            //pegar a linha o perfil a adiciona a linha
            foreach(DataRow dr in userperfil.Rows)
            {
                   //definindo cada no por perfil
                parentNode = treeView1.Nodes.Add(dr["perfil"].ToString());
                //chama o metodo preencher a arvore
                preencherTreeview(Convert.ToInt32(dr["id_perfil"]), parentNode);
            }
            treeView1.ExpandAll();//abrir a arvore
        }
        private void preencherTreeview(int parentid,TreeNode parentNode)
        {
            com=new Conexao();
            string sql = "select * from usuario inner join perfil on perfil.id_perfil=usuario.id_perfil where perfil.id_perfil= " + parentid;
            DataTable perfilusuario= com.obterdados(sql);
            TreeNode childNode;
            foreach(DataRow dr in perfilusuario.Rows)
            {
                if(parentNode == null)
                {
                    childNode = treeView1.Nodes.Add(dr["nome"].ToString());
                }
                else
                {
                    childNode = parentNode.Nodes.Add(dr["nome"].ToString());
                }
            }


        }
    }
}
