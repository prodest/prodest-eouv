using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Shared.Utils.Exceptions
{
    [Serializable]
    public class EDocsApiException : Exception
    {
        public EDocsApiException() : base() { }
        public EDocsApiException(string message) : base(message) { }
        protected EDocsApiException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public override void GetObjectData(SerializationInfo info, StreamingContext context) { base.GetObjectData(info, context); }
    }
}
