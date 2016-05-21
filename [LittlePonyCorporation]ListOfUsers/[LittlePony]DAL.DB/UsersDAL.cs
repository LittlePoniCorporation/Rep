using _LittlePony_Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _LittlePony_Entites;
using System.Data.SqlClient;
using System.IO;

namespace _LittlePony_DAL.DB
{
    public class UsersDAL : IListOfUsersDAL
    {
        public static List<User> ListOfUser = null;
        string connectionString;
        public UsersDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            ListOfUser = new List<User>();
        }

        public bool Change(Guid id, string Sur, string Name, string SecName, DateTime Bday)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var addUser = connection.CreateCommand();
                addUser.CommandText = "UPDATE dbo.Users SET Surname=@SURNAME, Name=@NAME, SecondName=@SECONDNAME, BDay=@Bday WHERE Id = @ID";
                addUser.Parameters.AddWithValue("@ID", id);
                addUser.Parameters.AddWithValue("@SURNAME", Sur);
                addUser.Parameters.AddWithValue("@NAME", Name);
                addUser.Parameters.AddWithValue("@SECONDNAME", SecName);
                addUser.Parameters.AddWithValue("@BDAY", Bday);
                connection.Open();
                var result = addUser.ExecuteNonQuery();
                connection.Close();
                if (result == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public bool Create(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var addUser = connection.CreateCommand();
                addUser.CommandText = $"INSERT INTO dbo.Users (Id, Surname, Name, SecondName, BDay) VALUES (@ID, @SURNAME, @NAME, @SECONDNAME, @BDAY)";
                addUser.Parameters.AddWithValue("@ID", user.Id);
                addUser.Parameters.AddWithValue("@SURNAME", user.Surname);
                addUser.Parameters.AddWithValue("@NAME", user.Name);
                addUser.Parameters.AddWithValue("@SECONDNAME", user.Second_Name);
                addUser.Parameters.AddWithValue("@BDAY", user.BDay);
                connection.Open();
                var result = addUser.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public bool Delete(Guid id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var deleteUser = connection.CreateCommand();
                deleteUser.CommandText = "DELETE FROM dbo.Relation WHERE userId = @ID";
                deleteUser.Parameters.AddWithValue("@ID", id);
                connection.Open();
                var result = deleteUser.ExecuteNonQuery();
            }
                using (var connection = new SqlConnection(connectionString))
            {
                var deleteUser = connection.CreateCommand();
                deleteUser.CommandText = "DELETE FROM dbo.Users WHERE Id = @ID";
                deleteUser.Parameters.AddWithValue("@ID", id);
                connection.Open();
                var result = deleteUser.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public User Get(Guid id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                User myUser = null;
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Surname, Name, SecondName, BDay FROM dbo.Users WHERE Id = @ID";
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //string? secondname = reader["Second-Name"] as string?;
                        string secondname;
                        if (reader["SecondName"] is DBNull)
                        {
                            secondname = null;
                        }
                        else
                        {
                            secondname = (string)reader["SecondName"];
                        }
                        myUser = new User((string)reader["Surname"], (string)reader["Name"], secondname, (DateTime)reader["BDay"], (Guid)reader["Id"]);
                    }
                    return myUser;
                }
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Surname, Name, SecondName, BDay FROM dbo.Users";

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //string? secondname = reader["Second-Name"] as string?;
                        string secondname;
                        if (reader["SecondName"] is DBNull)
                        {
                            secondname = null;
                        }
                        else
                        {
                            secondname = (string)reader["SecondName"];
                        }
                        ListOfUser.Add(new User((string)reader["Surname"], (string)reader["Name"], secondname, (DateTime)reader["BDay"], (Guid)reader["Id"]));
                    }
                }
            }
            foreach (var item in ListOfUser)
            {
                yield return item;
            }
        }
    }
}
