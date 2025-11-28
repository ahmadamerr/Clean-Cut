using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static CleanCut_DataAccess.clsDataConnection;

namespace CleanCut_DataAccess
{
    public class clsUserData
    {
        public static DataTable GetAllUsers()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataConnection.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetAllUsers", con))
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

        public static List<string> GetAllUsersNames()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetAllUsersNames", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<string> users = new List<string>();

                            while (reader.Read())
                            {
                                users.Add(reader.GetString(0));
                            }

                            return users;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }
        }

        public static bool FindByUserNameAndPassword(string userName,
            string Password, ref sbyte UserId, ref short permessions,
            ref decimal salary)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_LoginUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserName", userName);
                        cmd.Parameters.AddWithValue("@Password", Password);

                        cmd.Parameters.Add("@UserId", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Permessions", SqlDbType.SmallInt).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Salary", SqlDbType.Decimal).Direction = ParameterDirection.Output;

                        con.Open();

                        cmd.ExecuteNonQuery();

                        if (cmd.Parameters["@Permessions"].Value != DBNull.Value)
                        {
                            UserId = Convert.ToSByte(cmd.Parameters["@UserId"].Value);
                            permessions = Convert.ToInt16(cmd.Parameters["@Permessions"].Value);
                            if (cmd.Parameters["@Salary"].Value != DBNull.Value)
                                salary = Convert.ToDecimal(cmd.Parameters["@Salary"].Value);
                            else salary = 0;

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

        public static bool GetUserById(sbyte userId, ref string userName,
            ref short permessions, ref decimal salary, ref string password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetUserById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserId", (byte)userId);

                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Permessions", SqlDbType.SmallInt).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Salary", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;

                        con.Open();

                        cmd.ExecuteNonQuery();

                        if (cmd.Parameters["@UserName"].Value != DBNull.Value)
                        {
                            userName = Convert.ToString(cmd.Parameters["@UserName"].Value);
                            permessions = Convert.ToInt16(cmd.Parameters["@Permessions"].Value);
                            if (cmd.Parameters["@Salary"].Value != DBNull.Value)
                                salary = Convert.ToDecimal(cmd.Parameters["@Salary"].Value);
                            else salary = 0;
                            password = Convert.ToString(cmd.Parameters["@Password"].Value);

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

        public static sbyte AddUser(string name, string password,
            short permessions, decimal salary)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_AddNewUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserName", name);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Permessions", permessions);
                        cmd.Parameters.AddWithValue("@Salary", salary);

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

        public static bool UpdateUser(sbyte userId, string name,
            string password, short permessions, decimal salary)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserId", (byte)userId);
                        cmd.Parameters.AddWithValue("@UserName", name);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Permessions", permessions);
                        cmd.Parameters.AddWithValue("@Salary", salary);

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

        public static bool DeleteUser(sbyte userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DeleteUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserId", (byte)userId);

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

        public static bool DoesUserNameExist(string userName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DoesUserExistWithName", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Name", userName);

                        con.Open();

                        var result = cmd.ExecuteScalar();

                        if (result != null) return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }

            return false;
        }

        public static string GetUserNameById(sbyte Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetUserNameById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserId", (byte)Id);

                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;

                        con.Open();

                        cmd.ExecuteNonQuery();

                        return Convert.ToString(cmd.Parameters["@UserName"].Value);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }
        }

        public static sbyte GetUserIdByName(string userName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetUserIdByName", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserName", userName);

                        cmd.Parameters.Add("@UserId", SqlDbType.TinyInt).Direction = ParameterDirection.Output;

                        con.Open();

                        cmd.ExecuteNonQuery();

                        return Convert.ToSByte(cmd.Parameters["@UserId"].Value);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }
        }

        public static bool DoesUsersExist()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_DoesUsersExist", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
                }
            }
        }
    }
}
