using System.Text.Json.Serialization;

namespace StoreApp.Models
{

    [Serializable]
    public class MessageInfo
    {

        public required string Name { get; set; }


        public MessageType Type { get; set; }

    }

    public enum MessageType
    {
        Success, 
        Fail,
        Warning
    }
}
