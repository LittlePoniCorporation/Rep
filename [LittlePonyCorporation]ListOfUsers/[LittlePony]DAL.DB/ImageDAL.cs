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
    public class ImageDAL : IimageDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public bool AddImage(Guid entites, Guid img, string AorU)
        {
            if (AorU == "A")
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var addImage = connection.CreateCommand();
                    addImage.CommandText = "UPDATE dbo.Awards SET ImageId=@iID WHERE Id = @eId";
                    addImage.Parameters.AddWithValue("@iID", img);
                    addImage.Parameters.AddWithValue("@eId", entites);
                    connection.Open();
                    var result = addImage.ExecuteNonQuery();
                    connection.Close();
                    if (result == 0)
                    {
                        return false;
                    }
                    return true;
                }
            }
            else
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var addImage = connection.CreateCommand();
                    addImage.CommandText = "UPDATE dbo.Users SET ImageId=@iID WHERE Id = @eId";
                    addImage.Parameters.AddWithValue("@iID", img);
                    addImage.Parameters.AddWithValue("@eId", entites);
                    connection.Open();
                    var result = addImage.ExecuteNonQuery();
                    connection.Close();
                    if (result == 0)
                    {
                        return false;
                    }
                    return true;
                }
            }
        }

        public bool Create(Image img)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var addImage = connection.CreateCommand();
                addImage.CommandText = $"INSERT INTO dbo.Image (Id, content, typeContent) VALUES (@ID, @CONTENT, @TYPECONTENT)";
                addImage.Parameters.AddWithValue("@ID", img.Id);
                addImage.Parameters.AddWithValue("@CONTENT", img.Content);
                addImage.Parameters.AddWithValue("@TYPECONTENT", img.ContentType);
                connection.Open();
                var result = addImage.ExecuteNonQuery();
                connection.Close();
                if (result == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public bool Delete(Guid Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var deleteImage = connection.CreateCommand();
                deleteImage.CommandText = "DELETE FROM dbo.Image WHERE Id = @ID";
                deleteImage.Parameters.AddWithValue("@ID", Id);
                connection.Open();
                var result = deleteImage.ExecuteNonQuery();
                connection.Close();
                if (result != 0)
                {
                    return false;
                }
                return true;
            }
        }

        public Image Get(Guid Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                Image myImage = null;
                var command = connection.CreateCommand();
                command.CommandText = "SELECT content, typeContent FROM dbo.Image WHERE Id = @ID";
                command.Parameters.AddWithValue("@ID", Id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        myImage = new Image((byte[])reader["content"], (string)reader["typeContent"]);
                    }
                }
                connection.Close();
                return myImage;
            }
        }

        public Guid GetImageForEntites(Guid entitesId, string AorU)
        {
            if (AorU == "U")
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    Guid myImageId=default(Guid);
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT ImageId FROM dbo.Users WHERE Id = @ID";
                    command.Parameters.AddWithValue("@ID", entitesId);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            myImageId = (Guid)reader["ImageId"];
                        }
                    }
                    return myImageId;
                }
            }
            using (var connection = new SqlConnection(connectionString))
            {
                Guid myImageId=default(Guid);
                var command = connection.CreateCommand();
                command.CommandText = "SELECT ImageId FROM dbo.Awards WHERE Id = @ID";
                command.Parameters.AddWithValue("@ID", entitesId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        myImageId = (Guid)reader["ImageId"];
                    }
                }
                return myImageId;
            }

        }
    }
}
