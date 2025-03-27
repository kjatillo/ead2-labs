using System.Runtime.Serialization;
using System.Runtime.Serialization.DataContracts;

namespace SmsService.Client;

[DataContract]
class ShortMessage
{
    [DataMember(Name = "sender")]
    public string Sender { get; set; }
    [DataMember(Name = "receiver")]
    public string Receiver { get; set; }
    [DataMember(Name = "message")]
    public string Message { get; set; }
}
