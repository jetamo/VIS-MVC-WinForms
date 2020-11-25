using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer.TableDataGateWay
{
    public class AuthorTDG
    {
        public AuthorDTO GetAuthorByID(int id)
        {
            return new AuthorDTO();
        }
        public bool Insert(AuthorDTO author)
        {
            SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Clear();
                sb.Append("INSERT INTO autor ");
                sb.Append("VALUES (@p_name, @p_surname);");


                string sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@p_name", author.Name);
                    command.Parameters.AddWithValue("@p_surname", author.Surname);
                    command.ExecuteScalar();
                }
            }
            return true;
        }
    }
}
