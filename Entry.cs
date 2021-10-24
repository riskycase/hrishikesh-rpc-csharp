using System;
using System.Threading;

namespace Hrishikesh_s_RPC
{
    class Entry
    {
        static void Main(string[] args)
        {
            Discord.ActivityManager.UpdateActivityHandler updateActivityHandler = (result) =>
            {
                if (result == Discord.Result.Ok)
                {
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            };
            bool unlocked = false;
            var start = DateTime.Now;
            var discord = new Discord.Discord(874718200997232710, (UInt64)Discord.CreateFlags.Default);
            var discordActivityManager = discord.GetActivityManager();
            var activity = new Discord.Activity {
                Details = "Idling",
                Timestamps =
                {
                    Start = ((DateTimeOffset)start).ToUnixTimeMilliseconds(),
                },
                Assets =
                {
                    LargeImage = "rog",
                    LargeText = "test",
                },
                Instance = false
            };
            LogonState logonState = new LogonState();
            while (true)
            {
                if (logonState.IsUnlocked())
                {
                    if (!unlocked)
                    {
                        start = DateTime.Now;
                        unlocked = true;
                        activity.Timestamps.Start = ((DateTimeOffset)start).ToUnixTimeMilliseconds();
                        activity.Details = "Working";
                        discordActivityManager.UpdateActivity(activity, updateActivityHandler);
                    }
                }
                else
                {
                    if (unlocked)
                    {
                        start = DateTime.Now;
                        unlocked = false;
                        activity.Timestamps.Start = ((DateTimeOffset)start).ToUnixTimeMilliseconds();
                        activity.Details = "Idling";
                        discordActivityManager.UpdateActivity(activity, updateActivityHandler);
                    }
                }
                discord.RunCallbacks();
                Thread.Sleep(250);
            }
        }
    }
}
