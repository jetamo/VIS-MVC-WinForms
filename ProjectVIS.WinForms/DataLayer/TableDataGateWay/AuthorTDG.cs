using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer.TableDataGateWay
{
    public class AuthorTDG
    {
        public DataTable GetAuthorByID(int _id)
        {
            DataTable dt = new DataTable();
            SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM autor a WHERE a.id_autor = @p_id_autor";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@p_id_autor", _id);
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

                    string sql = "SELECT * FROM autor";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }

            catch{ }
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

                    string sql = "SELECT TOP 1 a.id_autor FROM autor a ORDER BY a.id_autor DESC";
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

        public int Insert(string _name, string _surname)
        {
            try
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
                        command.Parameters.AddWithValue("@p_name", _name);
                        command.Parameters.AddWithValue("@p_surname", _surname);
                        command.ExecuteScalar();
                    }
                }
            }
            catch
            {
                return -1;
            }
            return GetLastID();
        }
    }
}
