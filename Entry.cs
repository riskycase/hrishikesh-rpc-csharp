using System;
using System.IO;
using System.Threading;

namespace Hrishikesh_s_RPC
{
    class Entry
    {
        static void Main(string[] args)
        {
            Config config = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(File.ReadAllText(@"config.json"));
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
            var discord = new Discord.Discord(config.ClientId, (UInt64)Discord.CreateFlags.Default);
            var discordActivityManager = discord.GetActivityManager();
            var activity = new Discord.Activity {
                Details = config.LockedDetails,
                Timestamps =
                {
                    Start = ((DateTimeOffset)start).ToUnixTimeMilliseconds(),
                },
                Assets =
                {
                    LargeImage = config.DefaultImageKey,
                    LargeText = config.DefaultImageText,
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
                        activity.Details = config.UnlockedDetails;
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
                        activity.Details = config.LockedDetails;
                        discordActivityManager.UpdateActivity(activity, updateActivityHandler);
                    }
                }
                discord.RunCallbacks();
                Thread.Sleep(500);
            }
        }
    }
}
