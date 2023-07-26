using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    }
   
}
