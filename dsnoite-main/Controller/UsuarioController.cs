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
        public DataTable ObterDados(string sql)
        {
            //crio uma nova tabela de dados
            DataTable dt = new DataTable();
            //conn é a conexão com o banco de dados
            MySqlConnection conn= con.getConexao();
            conn.Open();//abre o banco de dados
            //preparo o comando sql
            MySqlCommand sqlCon = new MySqlCommand(sql, conn);
            //tipo de instrução texto
            sqlCon.CommandType=System.Data.CommandType.Text;
            sqlCon.CommandText=sql;
            //irá montar as informações da consulta
            MySqlDataAdapter dados = new MySqlDataAdapter(sqlCon);
            dados.Fill(dt);//montar a tabela de dados
            conn.Close();//fecho a conexão
            return dt;//
        }

        public bool Excluir(int codigo)
        {
            bool resultado=false;
            MySqlConnection sqlcon = con.getConexao();
            string sql = "delete from usuario where idusuario=" + codigo;
            sqlcon.Open();
            MySqlCommand mySqlCommand = new MySqlCommand(sql, sqlcon);
            mySqlCommand.CommandType=System.Data.CommandType.Text;
            mySqlCommand.CommandText=sql;
            if(mySqlCommand.ExecuteNonQuery() >= 1)
            {
                resultado = true;
            }
            return resultado;
        }
        public bool editar(UsuarioModelo us)
        {
            bool resultado = false;
            string sql = "update usuario set nome=@nome, senha=@senha where idusuario=@id";
            MySqlConnection sqlcon=con.getConexao();
            sqlcon.Open();
            MySqlCommand command = new MySqlCommand(sql, sqlcon);
            command.CommandType=System.Data.CommandType.Text;
            command.CommandText=sql;
            //substituindo a variavel @... pelo conteudo do objeto
            command.Parameters.AddWithValue("@nome", us.nome);
            command.Parameters.AddWithValue("@senha", us.senha);
            command.Parameters.AddWithValue("@id", us.idusuario);
            if( command.ExecuteNonQuery() >= 1 )
                resultado = true;
            sqlcon.Close();
            return resultado;
        }
    }
}
