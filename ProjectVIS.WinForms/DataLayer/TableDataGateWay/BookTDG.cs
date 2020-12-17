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
        public DataTable GetBookByID(int _id)
        {
            DataTable dt = new DataTable();
            SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Kniha k WHERE k.id_kniha = @p_id_kniha";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@p_id_kniha", _id);
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
        public int GetLastID()
        {
            DataTable dt = new DataTable();
            SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();

                    string sql = "SELECT TOP 1 k.id_kniha FROM kniha k ORDER BY k.id_kniha DESC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }

                return Convert.ToInt32(dt.Rows[0][0].ToString());
            }

            catch
            {
                return -1;
            }
        }

        public int Insert(int _idAuthor, string _title, string _genre, int _available)
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
                    sb.Append("VALUES (@p_id_author, @p_title, @p_genre, @p_available);");


                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@p_id_author", _idAuthor);
                        command.Parameters.AddWithValue("@p_title", _title);
                        command.Parameters.AddWithValue("@p_genre", _genre);
                        command.Parameters.AddWithValue("@p_available", _available);
                        command.ExecuteScalar();
                    }
                }
                return GetLastID();
            }
            catch
            {
                return -1;
            }
        }

        public void Update(int _id, int _idAuthor, string _title, string _genre, int _available)
        {
            try
            {
                SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Clear();
                    sb.Append("UPDATE kniha ");
                    sb.Append("SET id_autor = @p_id_author, nazev = @p_title, zanr = @p_genre, skladem = @p_available WHERE id_kniha = @p_id;");


                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@p_id_author", _idAuthor);
                        command.Parameters.AddWithValue("@p_title", _title);
                        command.Parameters.AddWithValue("@p_genre", _genre);
                        command.Parameters.AddWithValue("@p_available", _available);
                        command.Parameters.AddWithValue("@p_id", _id);
                        command.ExecuteScalar();
                    }
                }
            }
            catch { }
        }
    }
}
