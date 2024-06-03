using System;
using System.Runtime.Serialization;

namespace ProfessioniJson
{
    [Serializable]
    internal class MyException : Exception
    {
        private int NumeroElementiAnomaliTrovati;

        public MyException()
        {
        }

        public MyException(int v)
        {
            this.NumeroElementiAnomaliTrovati = v;
        }

        public MyException(string message) : base(message)
        {
        }

        public MyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}