using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer.TableDataGateWay
{
    public class LibrarianTDG
    {
        public DataTable GetLibrarianByID(int _id)
        {
            DataTable dt = new DataTable();
            SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM knihovnik k WHERE k.id_knihovnik = @p_id_knihovnik";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@p_id_knihovnik", _id);
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

                    string sql = "SELECT * FROM knihovnik";
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

                    string sql = "SELECT TOP 1 k.id_knihovnik FROM knihovnik k ORDER BY k.id_knihovnik DESC";
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
        public int Insert(string _name, string _surname, string _email)
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
                    sb.Append("VALUES (@p_name, @p_surname, @p_email);");


                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@p_name", _name);
                        command.Parameters.AddWithValue("@p_surname", _surname);
                        command.Parameters.AddWithValue("@p_email", _email);
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
    }
}
