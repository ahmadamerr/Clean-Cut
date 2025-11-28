using System;
using System.Data;
using System.Data.SqlClient;
using static CleanCut_DataAccess.clsDataConnection;

namespace CleanCut_DataAccess
{
    public class clsCutData
    {
        public static DataTable GetAllCut()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetAllCut", con))
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

        public static bool GetCutById(int cutId, ref sbyte barber,
            ref int customerId, ref DateTime cutDate,
            ref sbyte madeByUser, ref decimal paidFees)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetCutById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CutId", cutId);

                        cmd.Parameters.Add("@Barber", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@CutDate", SqlDbType.DateTime).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@MadeByUser", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@PaidFees", SqlDbType.Decimal).Direction = ParameterDirection.Output;

                        con.Open();

                        cmd.ExecuteNonQuery();

                        if (cmd.Parameters["@Barber"].Value != DBNull.Value)
                        {
                            barber = Convert.ToSByte(cmd.Parameters["@Barber"].Value);
                            customerId = Convert.ToInt32(cmd.Parameters["@CustomerId"].Value);
                            cutDate = Convert.ToDateTime(cmd.Parameters["@CutDate"].Value);
                            madeByUser = Convert.ToSByte(cmd.Parameters["@MadeByUser"].Value);
                            paidFees = Convert.ToDecimal(cmd.Parameters["@PaidFees"].Value);

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

        public static int AddNewCut(sbyte barber, int customerId,
            DateTime cutDate, sbyte madeByUser,
            decimal paidFees)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_AddNewCut", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Barber", (byte)barber);
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);
                        cmd.Parameters.AddWithValue("@CutDate", cutDate);
                        cmd.Parameters.AddWithValue("@MadeByUser", (byte)madeByUser);
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

        public static bool UpdateCut(int cutId, sbyte barber,
            int customerId, DateTime cutDate, sbyte madeByUser, 
            decimal paidFees)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateCut", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CutId", cutId);
                        cmd.Parameters.AddWithValue("@Barber", (byte)barber);
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);
                        cmd.Parameters.AddWithValue("@CutDate", cutDate.Date); 
                        cmd.Parameters.AddWithValue("@MadeByUser", (byte)madeByUser);
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

        public static bool DeleteCut(int cutId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DeleteCut", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CutId", cutId);

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
