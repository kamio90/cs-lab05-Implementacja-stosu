using System;
namespace cs_lab05_Implementacja_stosu
{
    public class StosEmptyException : Exception
    {
        public StosEmptyException() { }

        public StosEmptyException(string message) : base(message)
        { }

        public StosEmptyException(string message, Exception inner) : base(message, inner)
        { }
    }
}