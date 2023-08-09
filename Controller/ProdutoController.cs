using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;//importar o objeto
namespace Controller
{
    public class ProdutoController
    {
        bool resultado = false;//verificar o reusltado
        //chamo o metodo conexao
        string sql;//estrutura sql
        Conexao com = new Conexao();
        public bool cadastrarProduto(ProdutoModelo prod)
        {
            try
            {
                sql = "insert into produto(desc_prod,preco_prod,qtde_prod,perecivel,dat_validade,foto) " +
                    "values(@nome,@preco,@qtde,@perecivel,@data,@foto)";
                string[] campos = { "@nome","@preco","@qtde","@perecivel","@data","@foto" };
               object[] valores = {prod.descricao,prod.preco,prod.quantidade,prod.perecivel,prod.data_val,prod.foto };
                if (com.cadastrar(campos, valores, sql) >= 1)
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            
            return resultado;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
