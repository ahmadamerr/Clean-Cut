using CleanCut.GlobalClasses;
using CleanCutBussiness;
using System;
using System.Windows.Forms;

namespace CleanCut
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LocalDBHelper.EnsureLocalDBInstance();

            if (!clsUser.DoesUsersExist())
            {
                using (frmAddUpdateUser frm = new frmAddUpdateUser())
                {
                    frm.ShowDialog();

                    if (frm.UserID != -1) Application.Run(new frmLogin());
                    else
                    {
                        Application.Exit();

                        return;
                    }
                }
            }

            Application.Run(new frmLogin());
        }
    }
}
