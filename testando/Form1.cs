using System;
using System.Windows.Forms;

namespace testando
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nome " + txtnome.Text);
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Seja bem vindo(a)");
        }
    }
}
