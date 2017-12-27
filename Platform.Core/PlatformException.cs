using System;
using System.Runtime.Serialization;

namespace Platform.Core
{
    /// <summary>
    /// Platform“Ï≥£¿‡
    /// </summary>
    [Serializable]
    public class PlatformException : ApplicationException
    {
        public PlatformException() { }

        public PlatformException(string message) : base(message) { }

        public PlatformException(string message, Exception inner) : base(message, inner) { }

        protected PlatformException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
