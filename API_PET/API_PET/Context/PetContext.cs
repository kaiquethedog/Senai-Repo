using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_PET.Context
{
    public class PetContext
    {
        SqlConnection con = new SqlConnection();

        public PetContext()
        {
            con.ConnectionString = @"Data Source=THEDOG-PC\SQLEXPRESS;Initial Catalog=petshop;Persist Security Info=True;User ID=sa;Password=sa132";
        }

        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
