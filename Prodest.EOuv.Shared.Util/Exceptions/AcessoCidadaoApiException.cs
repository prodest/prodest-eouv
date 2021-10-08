using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Prodest.EOuv.Shared.Utils
{
    [Serializable]
    public class AcessoCidadaoApiException : Exception
    {
        public AcessoCidadaoApiException() : base() { }
        public AcessoCidadaoApiException(string message) : base(message) { }
        protected AcessoCidadaoApiException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public override void GetObjectData(SerializationInfo info, StreamingContext context) { base.GetObjectData(info, context); }
    }
}
