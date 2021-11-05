namespace Prodest.EOuv.UI.Apresentacao
{
    public class MessageResult
    {
        public string Message { get; set; }
        public MessageType Type { get; set; }

        public MessageResult(string message, MessageType type)
        {
            Message = message;
            Type = type;
        }
    }

    public enum MessageType
    {
        Success = 1,
        Info = 2,
        Warning = 3,
        Fail = 4,
    }
}