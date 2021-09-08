using System.Diagnostics;

namespace Hrishikesh_s_RPC
{
    internal class LogonState
    {
        public bool IsUnlocked()
        {
            Process[] processes = Process.GetProcessesByName("LogonUI");
            if (processes.Length > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}
