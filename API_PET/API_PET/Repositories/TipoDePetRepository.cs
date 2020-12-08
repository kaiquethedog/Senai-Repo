using API_PET.Context;
using API_PET.Domains;
using API_PET.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_PET.Repositories
{
    public class TipoDePetRepository : ITipoDePet
    {

        PetContext conexao = new PetContext();

        SqlCommand cmd = new SqlCommand();
        public TipoDePet Alterar(TipoDePet tp)
        {
            throw new NotImplementedException();
        }

        public TipoDePet BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM tipo WHERE id_tipo = @id ";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            TipoDePet tp = new TipoDePet();

            while (dados.Read())
            {
                tp.id_tipo = Convert.ToInt32(dados.GetValue(0));
                tp.tipo = dados.GetValue(1).ToString();
            }

            conexao.Desconectar();

            return tp;
        }

        public TipoDePet Excluir(TipoDePet tp)
        {
            throw new NotImplementedException();
        }

        public List<TipoDePet> LerTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM tipo";

            SqlDataReader dados = cmd.ExecuteReader();

            List<TipoDePet> tipos = new List<TipoDePet>();


            TipoDePet tp = new TipoDePet();

            while (dados.Read())
            {
                tipos.Add(
                    new TipoDePet()
                    {
                        id_tipo = Convert.ToInt32(dados.GetValue(0)),
                        tipo = dados.GetValue(1).ToString()
                    }
                 );
            }

            conexao.Desconectar();

            return tipos;
        }

        public TipoDePet Registrar(TipoDePet tp)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO tipo (tipo) " +
                "VALUES" +
                "(@tipo)";
            cmd.Parameters.AddWithValue("@tipo", tp.tipo);

            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            return tp;
        }
    }
}
