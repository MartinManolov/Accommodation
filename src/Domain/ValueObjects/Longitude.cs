namespace Accommodation.Domain.ValueObjects
{
    using System.Collections.Generic;
    using Accommodation.Domain.Common;
    using Accommodation.Domain.Exceptions;

    public class Longitude : ValueObject
    {
        private Longitude(decimal value)
        {
            this.Value = value;
        }

        public static Longitude Set(decimal value)
        {
            if (value < -90 || value > 90)
            {
                throw new NonExistentLongitudeException(value);
            }

            var longitude = new Longitude(value);

            return longitude;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public decimal Value { get; private set; }
    }
}
