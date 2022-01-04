using System;

namespace Hrishikesh_s_RPC
{
    internal class Config
    {
        long clientId = 874718200997232710;
        string lockedDetails = "AFK";
        string unlockedDetails = "Working";
        string defaultImageKey = "rog";
        string defaultImageText = "ROG";

        public long ClientId { get => clientId; set => clientId = value; }
        public string LockedDetails { get => lockedDetails; set => lockedDetails = value; }
        public string UnlockedDetails { get => unlockedDetails; set => unlockedDetails = value; }
        public string DefaultImageKey { get => defaultImageKey; set => defaultImageKey = value; }
        public string DefaultImageText { get => defaultImageText; set => defaultImageText = value; }

    }
}