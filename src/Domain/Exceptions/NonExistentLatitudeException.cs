namespace Accommodation.Domain.Exceptions
{
    using System;

    public class NonExistentLatitudeException : Exception
    {
        public NonExistentLatitudeException(decimal latitude)
            : base($"Latitude {latitude} does not exist.")
        {
        }
    }
}
