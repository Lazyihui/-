using System;
namespace Hamdoku {
    [Serializable]
    public sealed class RankingEntryModel {
        public long playerId;
        public string displayName;
        public int avatarId;
        public int costumeId;
        public int rank;
        public int seeds;
    }
}
