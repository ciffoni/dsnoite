using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//biblioteca para o cliente mysql 

namespace Controller
{
    //classe de conexão com o banco de dados 
    public class Conexao
    {
        //atributos de conexão
        static private string servidor = "localhost";
        static private string db = "testando";
        static private string usuario = "root";
        static private string senha = "";
        public MySqlConnection conn = null;//minha conexao
        //strCon caminho de conexao
        static private string StrCon = "server=" + servidor + ";database=" + db +
            ";user id=" + usuario + ";pasword=" + senha;
        //metodo de obter a conexao com o mysql
        public MySqlConnection getConexao()
        {
            //defino a varial conexao instanciando uma nova conexão
            MySqlConnection conexao = new MySqlConnection(StrCon);
            return conexao;//retorno o valor da conexao

        }
        public int cadastrar(string[] campos, object[] valores, string sql)
        {
            int registro = 0;
            try//testa o cadastro
            {
                conn = getConexao();//chamo o metodo obter conexao
                conn.Open();//abro o banco direto
                //preparo o comando sql passando o SQL e a conexao
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //monto meu parametros do sql
                for (int i = 0; i < valores.Length; i++)
                {
                    cmd.Parameters.AddWithValue(campos[i], valores[i]);
                }
                registro = cmd.ExecuteNonQuery();
                conn.Close();
                return registro;
            }//se houver erro
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public int atualizar(string[] campos, object[] valores, string sql)
        {
            int registro = 0;

            return registro;

        }
    }
}
