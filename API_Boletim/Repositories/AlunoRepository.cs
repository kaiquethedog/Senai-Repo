using DDD_Aluno.Domains;
using DDD_Aluno.Interfaces;
using DDD_Aluno.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DDD_Aluno.Repositories
{
    public class AlunoRepository : IAluno
    {

        BoletimContext conexao = new BoletimContext();

        SqlCommand cmd = new SqlCommand();
        public Aluno Alterar(Aluno a)
        {
            throw new NotImplementedException();
        }

        public Aluno BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM ALUNO WHERE Id_Aluno = @id ";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Aluno a = new Aluno();

            while(dados.Read())
            {
                a.Id_Aluno = Convert.ToInt32(dados.GetValue(0));
                a.Nome = dados.GetValue(1).ToString();
                a.RA = dados.GetValue(2).ToString();
                a.Idade = Convert.ToInt32(dados.GetValue(3));
            }
            conexao.Desconectar();

            return a; 
        }
        public Aluno Cadastrar(Aluno a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Aluno (Nome, RA, Idade) " +
                "VALUES" +
                "(@nome, @ra, @idade)";
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.RA);
            cmd.Parameters.AddWithValue("@idade", a.Idade);

            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            return a;
        }

        public Aluno Excluir(Aluno a)
        {
            throw new NotImplementedException();
        }

        public List<Aluno> LerTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Aluno";

            SqlDataReader dados = cmd.ExecuteReader();


            List<Aluno> alunos = new List<Aluno>();

            Aluno a = new Aluno();
            while(dados.Read())
            {
                alunos.Add(
                    new Aluno()
                    {
                        Id_Aluno = Convert.ToInt32(dados.GetValue(0)),
                        Nome = dados.GetValue(1).ToString(),
                        RA = dados.GetValue(2).ToString(),
                        Idade = Convert.ToInt32(dados.GetValue(3))
                    }
                    ) ;
            }
            conexao.Desconectar();

            return alunos;
        }
    }
}
