using System;

namespace SIS.HTTP.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        private const string InternalServerErrorDefaultMessage = "The Server has encountered an error.";

        public InternalServerErrorException()
            :this(InternalServerErrorDefaultMessage)
        {
        }

        public InternalServerErrorException(string name )
            : base(name)
        {
        }
    }
}
