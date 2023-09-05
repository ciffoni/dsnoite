using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
namespace testando
{
    public partial class FrmRelatorios : Form
    {
        public FrmRelatorios()
        {
            InitializeComponent();
        }

        private void FrmRelatorios_Load(object sender, EventArgs e)
        {
            Conexao com = new Conexao();
            grafico.DataSource = com.obterdados("select count(*) as qtde, desc_prod from produto");
        }
    }
}
