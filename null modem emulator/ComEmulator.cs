using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO.Ports;

namespace com_emulator
{
    /// <summary>
    /// Program to create virtual COM ports. com0com must be installed.
    /// </summary>
    public static class ComEmulator
    {
        /// <summary>
        /// path to the com0com directory
        /// </summary>
        private static string com0comPath = @"C:/Program Files (x86)/com0com";

        /// <summary>
        /// path to the com0com setupc.exe file
        /// </summary>
        private static string fileNamePath = Path.Combine(com0comPath, "setupc.exe");

        /// <summary>
        /// Sets the path to the com0com directory
        /// </summary>
        /// <param name="path"></param>
        public static void SetCom0ComPath([StringSyntax(StringSyntaxAttribute.Uri)] string path)
        {
            com0comPath = path;
            fileNamePath = Path.Combine(com0comPath, "setupc.exe");
        }

        /// <summary>
        /// Lists all existing pairs of COM ports
        /// </summary>
        public static void GetExistingPortPairs()
        {
            RunCom0comCommand("list");
        }

        /// <summary>
        /// Creates a pair of COM ports
        /// </summary>
        /// <param name="firstPortName"></param>
        /// <param name="secondPortName"></param>
        public static void CreateCOMPair(string firstPortName, string secondPortName, EmulationSettings emulationSettings)
        {
            var existingPorts = new HashSet<string>(SerialPort.GetPortNames());

            if (existingPorts.Contains(firstPortName) || existingPorts.Contains(secondPortName))
            {
                Console.WriteLine($"Port name - {(existingPorts.Contains(firstPortName) ? firstPortName : secondPortName)} - already exists. Please use a different port name.");
                return;
            }

            RunCom0comCommand(
                "install",
                $"PortName={firstPortName}",
                $"PortName={secondPortName}" +
                emulationSettings.GetSettings());
        }

        /// <summary>
        /// Deletes an existing pair of COM ports
        /// </summary>
        public static void DeleteCOMPair(int portId = 0)
        {
            RunCom0comCommand(
                "remove", 
                $"{portId}");
        }

        /// <summary>
        /// Runs a com0com command
        /// </summary>
        /// <param name="arguments"></param>
        private static void RunCom0comCommand(params string[] arguments)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = fileNamePath,
                Arguments = string.Join(" ", arguments),
                UseShellExecute = true,
                CreateNoWindow = true,
                Verb = "runas",
                WorkingDirectory = com0comPath,
            };

            try
            {
                using var process = Process.Start(startInfo);
                process?.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
