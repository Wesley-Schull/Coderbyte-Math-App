using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Coderbyte_Math_App.Exceptions
{
    public class ImpossibleTriangleException : Exception
    {
        public ImpossibleTriangleException() { }

        public ImpossibleTriangleException(string message) : base(message) { }

        public ImpossibleTriangleException(string message, Exception innerException) : base(message, innerException) { }

        protected ImpossibleTriangleException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
