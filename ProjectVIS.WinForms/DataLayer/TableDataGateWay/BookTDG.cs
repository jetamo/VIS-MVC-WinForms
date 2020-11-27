using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;

namespace DataLayer.TableDataGateWay
{
    public class BookTDG
    {
        public string GetBookByID(int id)
        {
            //return new BookDTO();
            return null; //temp
        }

        public DataTable Find()
        {
            DataTable dt = new DataTable();
            SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM kniha";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }

            catch { }
            return dt;
        }

        public bool Insert(int _idAuthor, string _title, string _genre)
        {
            try
            {
                SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Clear();
                    sb.Append("INSERT INTO kniha ");
                    sb.Append("VALUES (@p_id_author, @p_title, @p_genre);");


                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@p_id_author", _idAuthor);
                        command.Parameters.AddWithValue("@p_title", _title);
                        command.Parameters.AddWithValue("@p_genre", _genre);
                        command.ExecuteScalar();
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
