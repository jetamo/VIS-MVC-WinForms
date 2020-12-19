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

        public void Update(int? _id, int? _idLibrarian, int? _idCustomer, DateTime? _rentalDate, DateTime? _returnDate, bool _vraceno, bool _prodlouzeno)
        {
            try
            {
                SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Clear();
                    sb.Append("UPDATE Vypujcka ");
                    sb.Append("SET id_knihovnik = @p_id_knihovnik, id_zakaznik = @p_id_zakaznik, datum_zapujceni = @p_datum_zapujceni, datum_vraceni = @p_datum_vraceni, vraceno = @p_vraceno, prodlouzeno = @p_prodlouzeno WHERE id_vypujcka = @p_id;");


                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@p_id_knihovnik", _idLibrarian);
                        command.Parameters.AddWithValue("@p_id_zakaznik", _idCustomer);
                        command.Parameters.AddWithValue("@p_datum_zapujceni", _rentalDate);
                        if(_returnDate != null)
                            command.Parameters.AddWithValue("@p_datum_vraceni", _returnDate);
                        else
                            command.Parameters.AddWithValue("@p_datum_vraceni", DBNull.Value);
                        command.Parameters.AddWithValue("@p_vraceno", _vraceno);
                        command.Parameters.AddWithValue("@p_id", _id);
                        command.Parameters.AddWithValue("@p_prodlouzeno", _prodlouzeno);
                        command.ExecuteScalar();
                    }
                }
            }
            catch(Exception ex) { }
        }

        public int Insert(int _id_knihovnik, int _id_zakaznik, DateTime? _datum_zapujceni, DateTime? _datum_vraceni, bool _vraceno, bool _extended)
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
                    sb.Append("VALUES (@p_id_knihovnik, @p_id_zakaznik, @p_datum_zapujceni, @p_datum_vraceni, @p_vraceno, @p_prodlouzeno);");


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
                        command.Parameters.AddWithValue("@p_prodlouzeno", _extended);
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
