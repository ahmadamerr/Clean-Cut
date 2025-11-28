using System;
using System.Data;
using System.Data.SqlClient;
using static CleanCut_DataAccess.clsDataConnection;

namespace CleanCut_DataAccess
{
    public class clsCustomerData
    {
        public static DataTable GetAllCustomers()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetAllCustomers", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows) dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving customers.", ex);
            }

            return dt;
        }

        public static bool GetCustomerById(int customerId, 
            ref string customerName, ref string customerNumber,
            ref decimal customerDebt)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetCustomerById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CustomerID", customerId);

                        cmd.Parameters.Add("@CustomerName", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@CustomerNumber", SqlDbType.NVarChar, 15).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@CustomerDebt", SqlDbType.Decimal).Direction = ParameterDirection.Output;

                        con.Open();

                        cmd.ExecuteNonQuery();

                        if (cmd.Parameters["@CustomerName"].Value != DBNull.Value)
                        {
                            customerName = Convert.ToString(cmd.Parameters["@CustomerName"].Value);
                            customerNumber = Convert.ToString(cmd.Parameters["@CustomerNumber"].Value);
                            customerDebt = Convert.ToDecimal(cmd.Parameters["@CustomerDebt"].Value);

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

        public static bool GetCustomerByNumber(string customerNumber, 
            ref int customerId, ref string customerName,
            ref decimal customerDebt)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetCustomerByNumber", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CustomerNumber", customerNumber);

                        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@CustomerName", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@CustomerDebt", SqlDbType.Decimal).Direction = ParameterDirection.Output;

                        con.Open();

                        cmd.ExecuteNonQuery();

                        if (cmd.Parameters["@CustomerDebt"].Value != DBNull.Value)
                        {
                            customerId = Convert.ToInt32(cmd.Parameters["@CustomerID"].Value);
                            customerName = Convert.ToString(cmd.Parameters["@CustomerName"].Value);
                            customerDebt = Convert.ToDecimal(cmd.Parameters["@CustomerDebt"].Value);

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

        public static bool GetCustomerByName(string customerName, 
            ref int customerId, ref string customerNumber,
            ref decimal customerDebt)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetCustomerByName", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CustomerName", customerName);

                        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@CustomerNumber", SqlDbType.NVarChar, 15).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@CustomerDebt", SqlDbType.Decimal).Direction = ParameterDirection.Output;

                        con.Open();

                        cmd.ExecuteNonQuery();

                        if (cmd.Parameters["@CustomerNumber"].Value != DBNull.Value)
                        {
                            customerId = Convert.ToInt32(cmd.Parameters["@CustomerID"].Value);
                            customerNumber = Convert.ToString(cmd.Parameters["@CustomerNumber"].Value);
                            customerDebt = Convert.ToDecimal(cmd.Parameters["@CustomerDebt"].Value);

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

        public static int AddNewCustomer(string customerName, string customerNumber, decimal customerDebt)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_AddNewCustomer", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CustomerName", customerName);
                        cmd.Parameters.AddWithValue("@CustomerNumber", customerNumber);
                        cmd.Parameters.AddWithValue("@CustomerDebt", customerDebt);

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

        public static bool UpdateCustomer(int customerId,
            string customerName, string customerNumber,
            decimal customerDebt)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateCustomer", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CustomerID", customerId);
                        cmd.Parameters.AddWithValue("@CustomerName", customerName);
                        cmd.Parameters.AddWithValue("@CustomerNumber", customerNumber);
                        cmd.Parameters.AddWithValue("@CustomerDebt", customerDebt);

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

        public static bool DeleteCustomer(int customerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DeleteCustomer", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CustomerID", customerId);

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

        public static string GetCustomerNameById(int customerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetCustomerNameById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CustomerId", customerId);

                        con.Open();

                        return cmd.ExecuteScalar().ToString();
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
