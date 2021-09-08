using System;
using System.Threading;

namespace Hrishikesh_s_RPC
{
    class Entry
    {
        static void Main(string[] args)
        {
            while (true)
            {
                LogonState logonState = new LogonState();
                if (logonState.IsUnlocked())
                {
                    Console.WriteLine("Unlocked");
                }
                else
                {
                    Console.WriteLine("Locked");
                }
                Thread.Sleep(500);
            }
        }
    }
}
