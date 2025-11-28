using System;
using System.Data;
using System.Data.SqlClient;
using static CleanCut_DataAccess.clsDataConnection;

namespace CleanCut_DataAccess
{
    public class clsExpensesData
    {
        public static DataTable GetAllExpenses()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetAllExpenses", con))
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

        public static bool GetExpenseById(int expenseId, 
            ref decimal expenseAmount, ref string expenseReason,
            ref sbyte madeByUser, ref DateTime expenseDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetExpenseById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ExpenseID", expenseId);

                        cmd.Parameters.Add("@ExpenseAmount", SqlDbType.Decimal).Precision = 6;
                        cmd.Parameters["@ExpenseAmount"].Scale = 2;
                        cmd.Parameters["@ExpenseAmount"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@ExpenseReason", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@MadeByUser", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@ExpenseDate", SqlDbType.Date).Direction = ParameterDirection.Output;

                        con.Open();

                        cmd.ExecuteNonQuery();

                        if (cmd.Parameters["@ExpenseAmount"].Value != DBNull.Value)
                        {
                            expenseAmount = Convert.ToDecimal(cmd.Parameters["@ExpenseAmount"].Value);
                            expenseReason = Convert.ToString(cmd.Parameters["@ExpenseReason"].Value);
                            madeByUser = Convert.ToSByte(cmd.Parameters["@MadeByUser"].Value);
                            expenseDate = Convert.ToDateTime(cmd.Parameters["@ExpenseDate"].Value);

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

        public static int AddNewExpense(decimal expenseAmount,
            string expenseReason, sbyte madeByUser,
            DateTime expenseDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_AddNewExpense", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ExpenseAmount", expenseAmount);
                        cmd.Parameters.AddWithValue("@ExpenseReason", expenseReason);
                        cmd.Parameters.AddWithValue("@MadeByUser", (byte)madeByUser);
                        cmd.Parameters.AddWithValue("@ExpenseDate", expenseDate);

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

        public static bool UpdateExpense(int expenseId,
            decimal expenseAmount, string expenseReason, 
            sbyte madeByUser, DateTime expenseDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateExpense", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ExpenseID", expenseId);
                        cmd.Parameters.AddWithValue("@ExpenseAmount", expenseAmount);
                        cmd.Parameters.AddWithValue("@ExpenseReason", expenseReason);
                        cmd.Parameters.AddWithValue("@MadeByUser", (byte)madeByUser);
                        cmd.Parameters.AddWithValue("@ExpenseDate", expenseDate);

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

        public static bool DeleteExpense(int expenseId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DeleteExpense", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ExpenseID", expenseId);

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
