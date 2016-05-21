using _LittlePony_Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using _LittlePony_Entites;
using System.Configuration;
using System.Data.SqlClient;

namespace _LittlePony_DAL.DB
{
    public class AwardDAL : IAwardDAL
    {
        public static List<Award> ListOfAward = null;
        public string connectionString;
        public AwardDAL()
        {
            ListOfAward = new List<Award>();
            connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }

        public bool Change(Guid id, string Title)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var addImage = connection.CreateCommand();
                addImage.CommandText = "UPDATE dbo.Awards SET Title=@NT WHERE Id = @eId";
                addImage.Parameters.AddWithValue("@NT", Title);
                addImage.Parameters.AddWithValue("@eId", id);
                connection.Open();
                var result = addImage.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public bool Create(Award award)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var addAward = connection.CreateCommand();
                addAward.CommandText = $"INSERT INTO dbo.Awards (Id, Title) VALUES (@ID, @TITLE)";
                addAward.Parameters.AddWithValue("@ID", award.Id);
                addAward.Parameters.AddWithValue("@TITLE", award.Title);
                connection.Open();
                var result = addAward.ExecuteNonQuery();
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
                var deleteAward = connection.CreateCommand();
                deleteAward.CommandText = "DELETE FROM dbo.Relation WHERE awardId = @ID";
                deleteAward.Parameters.AddWithValue("@ID", id);
                connection.Open();
                var result = deleteAward.ExecuteNonQuery();
            }
                using (var connection = new SqlConnection(connectionString))
            {
                var deleteAward = connection.CreateCommand();
                deleteAward.CommandText = "DELETE FROM dbo.Awards WHERE Id = @ID";
                deleteAward.Parameters.AddWithValue("@ID", id);
                connection.Open();
                var result = deleteAward.ExecuteNonQuery();
                if (result != 0)
                {
                    return false;
                }
                return true;
            }
        }

        public Award Get(Guid id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                Award myAward = null;
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Title FROM dbo.Awards WHERE Id = @ID";
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        myAward = new Award((string)reader["Title"], (Guid)reader["Id"]);
                    }
                }
                return myAward;
            }
        }

        public IEnumerable<Award> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Title FROM dbo.Awards";

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListOfAward.Add(new Award((string)reader["Title"], (Guid)reader["Id"]));
                    }
                }
            }
            foreach (var item in ListOfAward)
            {
                yield return item;
            }
        }
    }
}
