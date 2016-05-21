using _LittelPony_Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _LittlePony_Entites;
using System.Configuration;
using System.Data.SqlClient;

namespace _LittlePony_DAL.DB
{
    public class RegistrateDAL : IRegistrateDAL
    {
        public static List<Registrate> ListOfReg = null;
        string connectionString;
        public RegistrateDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            ListOfReg = new List<Registrate>();
        }

        public bool Change(string login, int roleId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var changeRole = connection.CreateCommand();
                changeRole.CommandText = "UPDATE dbo.Authentication SET RoleId=@NewId WHERE Login = @LOGIN";
                changeRole.Parameters.AddWithValue("@NewId", roleId);
                changeRole.Parameters.AddWithValue("@LOGIN", login);
                connection.Open();
                var result = changeRole.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public bool Create(Registrate reg)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var addReg = connection.CreateCommand();
                addReg.CommandText = $"INSERT INTO dbo.Authentication (Login, Password, RoleId) VALUES (@LOG, @PASS, @ROLE)";
                addReg.Parameters.AddWithValue("@LOG", reg.Login);
                addReg.Parameters.AddWithValue("@PASS", reg.Password);
                addReg.Parameters.AddWithValue("@ROLE", reg.RoleId);
                connection.Open();
                var result = addReg.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public bool Delete(string login)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var deleteReg = connection.CreateCommand();
                deleteReg.CommandText = "DELETE FROM dbo.Authentication WHERE Login = @LOG";
                deleteReg.Parameters.AddWithValue("@LOG", login);
                connection.Open();
                var result = deleteReg.ExecuteNonQuery();
                if (result != 0)
                {
                    return false;
                }
                return true;
            }
        }

        public Registrate Get(string login)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                Registrate myReg = null;
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Password, RoleId FROM dbo.Authentication WHERE Login = @LOG";
                command.Parameters.AddWithValue("@LOG", login);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        myReg = new Registrate(login, (string)reader["Password"], (int)reader["RoleId"]);
                    }
                }
                return myReg;
            }
        }

        public IEnumerable<Registrate> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Login, Password, RoleId FROM dbo.Authentication";

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListOfReg.Add(new Registrate((string)reader["Login"],(string)reader["Password"], (int)reader["RoleId"]));
                    }
                }
            }
            foreach (var item in ListOfReg)
            {
                yield return item;
            }
        }

    }
}
