namespace Accommodation.Domain.Exceptions
{
    using System;

    public class NonExistentLongitudeException : Exception
    {
        public NonExistentLongitudeException(decimal longitude)
            : base($"Longitude {longitude} does not exist.")
        {
        }
    }
}
