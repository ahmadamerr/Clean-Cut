using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static CleanCut_DataAccess.clsDataConnection;

namespace CleanCut_DataAccess
{
    public class clsCutDetailsData
    {
        public static DataTable GetCutDetailsById(int cutId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetCutDetailsById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CutId", cutId);

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

        public static int AddCutDetails(int cutId, sbyte cutType,
            decimal paidFees)
        {
            if (!CheckCutDetailsExists(cutId, cutType))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_AddCutDetails", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@CutId", cutId);
                            cmd.Parameters.AddWithValue("@CutType", (byte)cutType);
                            cmd.Parameters.AddWithValue("@PaidFees", paidFees);

                            con.Open();

                            return Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Database error: " + ex.Message);
                }
            }
            return -1;
        }

        public static bool UpdateCutDetails(int cutDetailsId,
            sbyte cutType, decimal paidFees)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateCutDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CutDetailsID", cutDetailsId);
                        cmd.Parameters.AddWithValue("@CutType", (byte)cutType);
                        cmd.Parameters.AddWithValue("@PaidFees", paidFees);

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

        public static bool DeleteCutDetails(int cutId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DeleteCutDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CutID", cutId);

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

        public static decimal GetTotalPaidByCutId(int cutId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetTotalPaidByCutId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CutId", cutId);

                        var totalPaidParam = new SqlParameter("@TotalPaid", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output,
                            Precision = 6,
                            Scale = 2
                        };
                        cmd.Parameters.Add(totalPaidParam);

                        con.Open();

                        return Convert.ToDecimal(cmd.ExecuteScalar());
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }
        }

        public static bool CheckCutDetailsExists(int cutId, sbyte type)  
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_CheckCutDetailsExists", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CutId", cutId);
                    cmd.Parameters.AddWithValue("@Type", (byte)type);

                    con.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
                }
            }
        }

        public static bool DeleteCutDetailsByType(sbyte cutType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DeleteCutDetailsByType", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CutType", (byte)cutType);

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
    }
}
