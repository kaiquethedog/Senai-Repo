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
    public class PetRacaRepository : IPetRaca
    {

        PetContext conexao = new PetContext();

        SqlCommand cmd = new SqlCommand();
        public PetRaca Alterar(PetRaca pr)
        {
            throw new NotImplementedException();
        }

        public PetRaca BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM raca WHERE id_raca = @id ";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            PetRaca pr = new PetRaca();

            while(dados.Read())
            {
                pr.id_raca = Convert.ToInt32(dados.GetValue(0));
                pr.id_tipo = Convert.ToInt32(dados.GetValue(1));
                pr.raca = dados.GetValue(2).ToString();
            }

            conexao.Desconectar();

            return pr;
        }

        public PetRaca Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "DELETE FROM raca WHERE id_raca = @id " +
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            return pr;
        }

        public List<PetRaca> LerTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM raca";

            SqlDataReader dados = cmd.ExecuteReader();

            List<PetRaca> racas = new List<PetRaca>();


            PetRaca pr = new PetRaca();

            while(dados.Read())
            {
                racas.Add(
                    new PetRaca()
                    {
                        id_raca = Convert.ToInt32(dados.GetValue(0)),
                        id_tipo = Convert.ToInt32(dados.GetValue(1)),
                        raca    = dados.GetValue(2).ToString()
                    }
                 );
            }

            conexao.Desconectar();

            return racas;
        }

        public PetRaca Registrar(PetRaca pr)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO raca (id_tipo, raca) " +
                "VALUES" +
                "(@id_tipo, @raca)";
            cmd.Parameters.AddWithValue("@id_tipo", pr.id_tipo);
            cmd.Parameters.AddWithValue("@raca", pr.raca);

            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            return pr;
        }
    }
}
