using System.Data;

namespace CleanCutBussiness
{
    public class clsUserData
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enPermessions
        {
            pAll = -1,
            pCut = 1,
            pCustomer = 2,
            pExpenses = 4,
            pUsers = 8,
            pCutTypes = 16
        }

        public byte UserID;
        public string UserName;
        public string UserPassword;
        public short permessions;

        public clsUserData()
        {
            UserID = 0;
            UserName = "";
            UserPassword = "";
            permessions = 0;

            Mode = enMode.AddNew;
        }

        private clsUserData(byte userID, string userName, string userPassword, short permessions)
        {
            UserID = userID;
            UserName = userName;
            UserPassword = userPassword;
            this.permessions = permessions;

            Mode = enMode.Update;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }
    }
}
