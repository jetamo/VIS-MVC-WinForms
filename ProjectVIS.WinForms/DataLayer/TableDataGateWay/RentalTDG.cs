using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer.TableDataGateWay
{
    public class RentalTDG
    {
        public DataTable GetRentalByID(int _id)
        {
            DataTable dt = new DataTable();
            SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM vypujcka a WHERE a.id_vypujcka = @p_id_vypujcka";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@p_id_vypujcka", _id);
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

                    string sql = "SELECT * FROM vypujcka";
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

                    string sql = "SELECT TOP 1 v.id_vypujcka FROM vypujcka v ORDER BY v.id_vypujcka DESC";
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

        public int Insert(int _id_knihovnik, int _id_zakaznik, DateTime? _datum_zapujceni, DateTime? _datum_vraceni, bool _vraceno)
        {
            try
            {
                SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Clear();
                    sb.Append("INSERT INTO vypujcka ");
                    sb.Append("VALUES (@p_id_knihovnik, @p_id_zakaznik, @p_datum_zapujceni, @p_datum_vraceni, @p_vraceno);");


                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@p_id_knihovnik", _id_knihovnik);
                        command.Parameters.AddWithValue("@p_id_zakaznik", _id_zakaznik);
                        command.Parameters.AddWithValue("@p_datum_zapujceni", _datum_zapujceni);
                        if(_datum_vraceni == null)
                            command.Parameters.AddWithValue("@p_datum_vraceni", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@p_datum_vraceni", _datum_vraceni);
                        command.Parameters.AddWithValue("@p_vraceno", _vraceno);
                        command.ExecuteScalar();
                    }
                }
                return GetLastID();
            }
            catch(Exception e)
            {
                return -1;
            }
        }
    }
}
