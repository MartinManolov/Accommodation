namespace Accommodation.Domain.ValueObjects
{
    using System.Collections.Generic;
    using Accommodation.Domain.Common;
    using Accommodation.Domain.Exceptions;

    public class Latitude : ValueObject
    {
        private Latitude(decimal value)
        {
            this.Value = value;
        }

        public static Latitude Set(decimal value)
        {
            if (value < -90 || value > 90)
            {
                throw new NonExistentLatitudeException(value);
            }

            var latitude = new Latitude(value);

            return latitude;
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
