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
        public bool cadastrarProduto(ProdutoModelo prod, int operacao)
        {
            try
            {
                switch (operacao)
                {
                    case 1://inserir dados
                        sql = "insert into produto(desc_prod,preco_prod,qtde_prod,perecivel,dat_validade,foto) " +
                    "values(@nome,@preco,@qtde,@perecivel,@data,@foto)";
                        break;
                    case 2://atualizar
                        sql = "update  produto set desc_prod= @nome," +
                            "preco_prod= @preco,qtde_prod=@qtde,perecivel=@perecivel," +
                            "dat_validade=@data,foto=@foto " +
                            "where cod_prod=@id";
                        break;
                    case 3:
                        sql = "DELETE from produto where cod_prod=@id";
                        break;

                }
                string[] campos = { "@nome","@preco","@qtde","@perecivel","@data","@foto" };
               object[] valores = {prod.descricao,prod.preco,prod.quantidade,prod.perecivel,prod.data_val,prod.foto };
                if (com.cadastrar(prod.codigo,campos, valores, sql) >= 1)
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
