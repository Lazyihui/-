using System;
using System.Runtime.Serialization;
namespace Hamdoku {
    [Serializable]
    [DataContract]
    public sealed class EndlessSaveModel {
        [DataMember] public int bestFound;
    }
}
