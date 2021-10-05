using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Prodest.EOuv.Shared.Utils.Exceptions
{
    [Serializable]
    public class ApiUnauthorizedException : Exception
    {
        public ApiUnauthorizedException() : base("401 UNAUTHORIZED: The request has not been applied because it lacks valid authentication credentials for the target resource.") { }
        public override void GetObjectData(SerializationInfo info, StreamingContext context) { base.GetObjectData(info, context); }
        protected ApiUnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
