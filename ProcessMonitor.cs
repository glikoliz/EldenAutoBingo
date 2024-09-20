using System.Diagnostics;

namespace Elden_Ring_Auto_Bingo
{
    public class ERProcessMonitor
    {
        private const string ProcessName = "eldenring";
        private Process? currentProcess;
        public event EventHandler? ProcessChanged;

        public Process? CurrentProcess
        {
            get { return currentProcess; }
            private set
            {
                if (currentProcess != value)
                {
                    currentProcess = value;
                    ProcessChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public bool IsProcessRunning => CurrentProcess != null && !CurrentProcess.HasExited;

        public void Update()
        {
            if (IsProcessRunning) return;
            Console.WriteLine("No process here!");
            Process[] processes = Process.GetProcessesByName(ProcessName);
            CurrentProcess = processes.Length > 0 ? processes[0] : null;
        }
    }
}