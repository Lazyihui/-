using System.Runtime.Serialization;
using System;
using System.Collections.Generic;

namespace Hamdoku {
    [Serializable]
    [DataContract]
    public sealed class StreakSaveModel {
        // One-based Gregorian day numbers; zero means no recorded win.
        [DataMember]
        public int lastWinDay;
        [DataMember]
        public int runDays;
        [DataMember]
        public int bestDays;
        [DataMember]
        public List<int> winDays = new List<int>();
        [DataMember]
        public int pendingHints;
        [DataMember]
        public int pendingGuides;
        [DataMember]
        public int pendingSlot;
        [DataMember]
        public bool pagePending;
        [DataMember]
        public int bonusHints;
        [DataMember]
        public int bonusGuides;
        [DataMember]
        public int recoveryDismissedDay;
    }
}
