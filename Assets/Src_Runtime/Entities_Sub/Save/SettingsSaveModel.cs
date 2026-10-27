using System;
using System.Runtime.Serialization;
namespace Hamdoku {
    [Serializable, DataContract]
    public sealed class SettingsSaveModel {
        [DataMember] public bool effects;
        [DataMember] public bool music;
        [DataMember] public bool vibration;
        [DataMember] public bool border;
        [DataMember] public bool pattern;
        [DataMember] public ComboVoiceType voice;
    }
}
