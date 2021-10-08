using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Prodest.EOuv.Shared.Utils
{
    [Serializable]
    public class OrganogramaApiException : Exception
    {
        public OrganogramaApiException() : base() { }
        public OrganogramaApiException(string message) : base(message) { }
        protected OrganogramaApiException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public override void GetObjectData(SerializationInfo info, StreamingContext context) { base.GetObjectData(info, context); }
    }
}
