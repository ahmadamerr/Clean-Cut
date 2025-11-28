using System.Diagnostics;

namespace CleanCut.GlobalClasses
{
    public class LocalDBHelper
    {
        private const string InstanceName = "MSSQLLocalDB";

        public static void EnsureLocalDBInstance()
        {
            if (!IsInstanceExists())
            {
                CreateInstance();
            }

            if (!IsInstanceRunning())
            {
                StartInstance();
            }
        }

        private static bool IsInstanceExists()
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "sqllocaldb",
                    Arguments = "info",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    return output.Contains(InstanceName);
                }
            }
            catch
            {
                return false;
            }
        }

        private static void CreateInstance()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "sqllocaldb",
                Arguments = $"create \"{InstanceName}\"",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(psi))
            {
                process.WaitForExit();
            }
        }

        private static bool IsInstanceRunning()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "sqllocaldb",
                Arguments = $"info {InstanceName}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                return output.Contains("Running");
            }
        }

        private static void StartInstance()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "sqllocaldb",
                Arguments = $"start \"{InstanceName}\"",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(psi))
            {
                process.WaitForExit();
            }
        }
    }
}
