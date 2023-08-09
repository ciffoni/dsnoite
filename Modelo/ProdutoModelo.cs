using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    //meu objeto produto
   public class ProdutoModelo
    {
        //variaveis do produto
        private int cod_prod;
        private string desc_prod;
        private int qtde_prod;
        private decimal preco_prod;
        private bool perecivel_prod;
        private DateTime data_validade;
        private string foto_prod;
        //contrutor da classe
        public  ProdutoModelo()
        {
            //inicializando os valores default
            this.cod_prod = 0;
            this.desc_prod = "";
            this.qtde_prod = 0;
            this.preco_prod = 0;
            //
            this.perecivel_prod = false;
            //datatime data agora
            this.data_validade = DateTime.Now;


        }
        //metodo de acesso as varivaies
        public int codigo
        {
            //obter dados da variavel
            get { return cod_prod; }
            //alterar dados da variavel
            set { cod_prod = value; }
        }
        public string descricao
        {
            get { return desc_prod; }
            set { desc_prod = value; }
        }
        public int quantidade
        {
            get { return qtde_prod; }
            set { qtde_prod = value;}
        }
        public decimal preco
        {
            get { return preco_prod; }
            set { preco_prod = value; }
        }
        public bool perecivel
        {
            get { return perecivel_prod; }
            set { perecivel_prod = value;}
        }
        public DateTime data_val
        {
            get { return data_validade; }
            set { data_validade = value;}
        }
        public string foto
        {
            get { return foto_prod; }
            set { foto_prod = value;}
        }
    }
}
