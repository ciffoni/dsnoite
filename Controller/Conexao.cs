using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Modelo;
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
        //declara um valor aleatorio
        Random aleatorio = new Random(); 
        //strCon caminho de conexao
        static private string StrCon = "server=" + servidor + ";database=" + db +
            ";user id=" + usuario + ";pasword=" + senha;
        //chamo o modelo usuario
        UsuarioModelo usuarioModelo = new UsuarioModelo();
        
        //metodo de obter a conexao com o mysql
        public MySqlConnection getConexao()
        {
            //defino a varial conexao instanciando uma nova conexão
            MySqlConnection conexao = new MySqlConnection(StrCon);
            return conexao;//retorno o valor da conexao

        }
        public int cadastrar(int codigo,string[] campos, object[] valores, string sql)
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
                if (codigo > 0)
                {
                    cmd.Parameters.AddWithValue("@id", codigo);
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
        public DataTable obterdados(string sql)
        {
            DataTable dt = new DataTable();
            MySqlConnection sqlCon = getConexao();
            sqlCon.Open();//abrindo o banco
            MySqlCommand cmd = new MySqlCommand(sql, sqlCon);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;

        }
        public string getMD5Hash(string senha)
        {
            System.Security.Cryptography.MD5 md5=System.Security.Cryptography.MD5.Create();
            byte[] inputBytes= System.Text.Encoding.ASCII.GetBytes(senha);
            byte[] hash=md5.ComputeHash(inputBytes);
            StringBuilder sb=new StringBuilder();
            for(int i=0; i<hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public string recuperaremail(string login)
        { //testar a recuperacao
            try
            {
                //criar a tabela de dados
                DataTable dt= new DataTable();
                 string msg = null;//validação da informação
                string psenha;

                if(login == null) {//valido o preenchimento
                    msg = "login está vazio";
                }
                else
                {
                    
                    conn=getConexao();//conexao o BD
                    conn.Open(); //abrir o BD
                    //chamo a função obter dados passando o SQL com o login
                    dt = obterdados("select * from usuario where nome='" + login+"'");
                   //verifico se achou algum registro
                    if(dt.Rows.Count > 0)
                    {
                        //varaivel email e senha
                        string email = "ciffoni@gmail.com";
                        string senha = "senha";
                        //chamar o acesso ao email
                        SmtpClient cliente=new SmtpClient();
                        //chamo o nome do servidor
                        cliente.Host = "smtp.google.com";
                        //defino a porta de comunicação
                        cliente.Port = 25;// 587;
                        //segurança ssl habilitada
                        cliente.EnableSsl = false;
                        
                        //chamo minhas credenciais de acesso ao email
                        cliente.Credentials = new System.Net.NetworkCredential(email, senha);
                        //preparo a mensagem de email
                        MailMessage mail = new MailMessage();//criar a mensagem
                       //configura o email de envio
                        mail.Sender = new MailAddress(email, "Sistema TDS");
                        mail.From = new MailAddress(email, "Recuperar senha");
                        //email do usuário 
                        mail.To.Add(new MailAddress(dt.Rows[0][4].ToString(), dt.Rows[0][1].ToString())) ;
                        mail.Subject = "lembrar senha";
                        mail.Body = "Ola" + dt.Rows[0][1].ToString() + "sua senha é:" + aleatorio.Next(2000);
                        mail.IsBodyHtml= true;//cria um arquivo html
                        mail.Priority = MailPriority.High;//prioridade de envio
                        try
                        {
                            //enviar email
                            cliente.Send(mail);
                            msg = "e-mail enviado com sucesso";
                        }catch(Exception ex)
                        {
                            throw new Exception("Erro ao enviar o email:" + ex.Message);
;                        }



                    }
                    else
                    {
                        msg = "Usuário não localizado";
                    }
                }
                return msg;
            }catch (Exception ex)
            {
                throw new Exception("Erro:" + ex.Message);
            }
           

        }
    }
}
