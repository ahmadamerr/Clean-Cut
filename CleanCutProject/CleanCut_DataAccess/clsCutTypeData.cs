using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static CleanCut_DataAccess.clsDataConnection;

namespace CleanCut_DataAccess
{
    public class clsCutTypeData
    {
        public static DataTable GetAllCutTypes()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetAllCutTypes", con))
                    {
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();

                            if (reader.HasRows) dt.Load(reader);

                            return dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }
        }

        public static DataTable GetAllCutTypesNameAPrice()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetAllCutTypesNameAPrice", con))
                    {
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();

                            if (reader.HasRows) dt.Load(reader);

                            return dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }
        }

        public static List<string> GetAllCutTypesNameByCutId(int cutId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetAllCutTypesNameByCutId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CutId", cutId);

                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<string> cutTypes = new List<string>();

                            while (reader.Read())
                            {
                                cutTypes.Add(reader.GetString(0));
                            }

                            return cutTypes;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }
        }

        public static bool GetCutTypeById(sbyte typeId, 
            ref string cutName, ref decimal fees)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetCutTypeById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TypeId", (byte)typeId);

                        cmd.Parameters.Add("@CutName", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Fees", SqlDbType.Decimal).Direction = ParameterDirection.Output;

                        con.Open();

                        cmd.ExecuteNonQuery();

                        if (cmd.Parameters["@CutName"].Value != DBNull.Value)
                        {
                            cutName = Convert.ToString(cmd.Parameters["@CutName"].Value);
                            fees = Convert.ToDecimal(cmd.Parameters["@Fees"].Value);

                            return true;
                        }

                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }
        }

        public static sbyte AddNewCutType(string cutName, decimal price)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_AddNewCutType", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CutName", cutName);
                        cmd.Parameters.AddWithValue("@Fees", price);

                        con.Open();

                        return Convert.ToSByte(cmd.ExecuteScalar());
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }
        }

        public static bool UpdateCutType(sbyte typeId, string cutName,
            decimal fees)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateCutType", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TypeId", (byte)typeId);
                        cmd.Parameters.AddWithValue("@CutName", cutName);
                        cmd.Parameters.AddWithValue("@Fees", fees);

                        con.Open();

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }
        }

        public static bool DeleteCutType(sbyte typeId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DeleteCutType", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TypeId", (byte)typeId);

                        con.Open();

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }
        }

        public static sbyte GetCutIdByName(string cutName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetCutIdByName", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CutName", cutName);

                        con.Open();

                        return Convert.ToSByte(cmd.ExecuteScalar());
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }
        }
    }
}
