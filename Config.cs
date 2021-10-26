using System;

namespace Hrishikesh_s_RPC
{
    internal class Config
    {
        long clientId;
        string lockedDetails;
        string unlockedDetails;
        string defaultImageKey;
        string defaultImageText;

        public long ClientId { get => clientId; set => clientId = value; }
        public string LockedDetails { get => lockedDetails; set => lockedDetails = value; }
        public string UnlockedDetails { get => unlockedDetails; set => unlockedDetails = value; }
        public string DefaultImageKey { get => defaultImageKey; set => defaultImageKey = value; }
        public string DefaultImageText { get => defaultImageText; set => defaultImageText = value; }

    }
}