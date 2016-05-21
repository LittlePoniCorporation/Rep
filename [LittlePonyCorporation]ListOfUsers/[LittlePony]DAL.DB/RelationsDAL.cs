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
    public class RelationsDAL : IRelationsDAL
    {
        public static List<Relations> ListOfRelations = null;
        string connectionString;
        public RelationsDAL()
        {
            ListOfRelations = new List<Relations>();
            connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }

        public bool Add(Relations relation)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var addRelation = connection.CreateCommand();
                addRelation.CommandText = $"INSERT INTO dbo.Relation (userId, awardId) VALUES (@UID, @AID)";
                addRelation.Parameters.AddWithValue("@UID", relation.IdUser);
                addRelation.Parameters.AddWithValue("@AID", relation.IdAward);
                connection.Open();
                var result = addRelation.ExecuteNonQuery();
                connection.Close();
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
                var deleteRelation = connection.CreateCommand();
                deleteRelation.CommandText = "DELETE FROM dbo.Relation WHERE userId = @ID OR awardId=@ID";
                deleteRelation.Parameters.AddWithValue("@ID", id);
                connection.Open();
                var result = deleteRelation.ExecuteNonQuery();
                connection.Close();
                if (result != 0)
                {
                    return false;
                }
                return true;
            }
        }

        public IEnumerable<Relations> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT userId, awardId FROM dbo.Relation";

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListOfRelations.Add(new Relations((Guid)reader["userId"], (Guid)reader["awardId"]));
                    }
                }
                connection.Close();
            }
            foreach (var item in ListOfRelations)
            {
                yield return item;
            }
        }
    }
}
