using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Coderbyte_Math_App.Exceptions
{
    public class InvalidMeasurementException : Exception
    {
        public InvalidMeasurementException() { }

        public InvalidMeasurementException(string message) : base(message) { }
        
        public InvalidMeasurementException(string message, Exception innerException) : base(message, innerException) { }
        
        protected InvalidMeasurementException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
