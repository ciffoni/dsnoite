using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Modelo;
using System.Data;

namespace Controller
{
    public class UsuarioController
    {//instanciei o objeto conexao
        Conexao con = new Conexao();
        //criando o metodo de cadastrar usuário
        public bool cadastrar( UsuarioModelo usuario)//passo o objeto usuario
        {//declaro a variavel da resposta da query
            bool resultado = false;
            string sql = "insert into usuario(nome,senha,id_perfil) " +
                "values('" + usuario.nome + "','" + usuario.senha + "',"+usuario.idperfil+")";
            //chamando minha conexao
            MySqlConnection sqlCon = con.getConexao();
            sqlCon.Open();//abrindo o banco
            MySqlCommand cmd =new MySqlCommand(sql, sqlCon);
            if (cmd.ExecuteNonQuery() >= 1)//executar o seu sql
                resultado = true;
            sqlCon.Close();//fecho a conexao
            return resultado;//retorno o valor
        }
        public DataTable obterdados(string sql)
        {
            DataTable dt = new DataTable();
            MySqlConnection sqlCon = con.getConexao();
            sqlCon.Open();//abrindo o banco
            MySqlCommand cmd = new MySqlCommand(sql, sqlCon);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;

        }
        public bool excluir(int codigo)
        {
            bool resultado = false;
            string sql = "DELETE FROM usuario where idusuario=" +codigo;
            //chamando minha conexao
            MySqlConnection sqlCon = con.getConexao();
            sqlCon.Open();//abrindo o banco
            MySqlCommand cmd = new MySqlCommand(sql, sqlCon);
            cmd.CommandType =System.Data.CommandType.Text;
            cmd.CommandText = sql;
            if (cmd.ExecuteNonQuery() >= 1)//executar o seu sql
                resultado = true;
            sqlCon.Close();//fecho a conexao
            return resultado;//retorno o valor
        }
        public bool editar(UsuarioModelo us)
        {
            bool resultado = false;
            string sql = "update usuario set nome=@nome, senha=@senha where id_usuario=@id";
            MySqlConnection sqlcon=con.getConexao();
            sqlcon.Open();
            MySqlCommand command = new MySqlCommand(sql, sqlcon);   
            command.CommandType =System.Data.CommandType.Text;
            command.CommandText = sql;
            // substituindo a variavel @___ pelo conteudo do objeto
            command.Parameters.AddWithValue("@nome", us.nome);
            command.Parameters.AddWithValue("@senha", us.senha);
            command.Parameters.AddWithValue("@id", us.idusuario);
           if( command.ExecuteNonQuery()>=1)
                resultado=true;
           sqlcon.Close();
            return resultado;
        }
    }
}
