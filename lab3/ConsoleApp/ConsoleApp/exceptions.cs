using System;

namespace ConsoleApp
{
    class Exceptions
    {
        public class BadIndexException : Exception
        {
            public BadIndexException(string message) : base(message)
            {

            }
        }
        public class BadFileException : Exception
        {
            public BadFileException(string message) : base(message)
            {

            }
        }
    }
}