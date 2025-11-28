using System;
using System.Data;
using System.Data.SqlClient;
using static CleanCut_DataAccess.clsDataConnection;

namespace CleanCut_DataAccess
{
    public class clsDeductionData
    {
        public static int AddDeduction(sbyte userId, decimal amount,
            string reason, DateTime date)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_AddDeduction", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserId", (byte)userId);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@Reason", reason);
                        cmd.Parameters.AddWithValue("@Date", date);

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

        public static bool UpdateDeduction(int deductionId, int userId, 
            decimal amount, string reason, DateTime date)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateDeduction", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DeductionId", deductionId);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@Reason", reason);
                        cmd.Parameters.AddWithValue("@Date", date);

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

        public static bool GetDeductionById(int deductionId,
            ref sbyte userId ,ref decimal amount ,ref string reason ,
            ref DateTime date)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetDeductionById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DeductionId", deductionId);

                        cmd.Parameters.Add("@UserId", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Date", SqlDbType.Date).Direction = ParameterDirection.Output;

                        con.Open();

                        cmd.ExecuteNonQuery();

                        if (cmd.Parameters["@UserId"].Value != DBNull.Value)
                        {
                            userId = Convert.ToSByte(cmd.Parameters["@UserId"].Value);
                            amount = Convert.ToDecimal(cmd.Parameters["@Amount"].Value);
                            reason = Convert.ToString(cmd.Parameters["@Reason"].Value);
                            date = Convert.ToDateTime(cmd.Parameters["@Date"].Value);

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

        public static DataTable GetAllDeductions()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetAllDeductions", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

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

        public static bool DeleteDeduction(int deductionID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataConnection.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DeleteDeduction", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DeductionID", deductionID);

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
