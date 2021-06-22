using ProjectStructure.Domain.Core;
using ProjectStructure.Utils;

namespace ProjectStructure.Domain
{
    public class Address : ValueObject<Address>
    {
        public string AddressLine { get; private set; }
        public string Suburb { get; private set; }
        public string State { get; private set; }
        public string Postcode { get; private set; }

        protected Address() { }

        private Address(string addressLine, string suburb, string state, string postcode)
            : this()
        {
            AddressLine = addressLine.Trim();
            Suburb = suburb.Trim();
            State = state.Trim();
            Postcode = postcode.Trim();
        }

        public static Result<Address> Create(string addressLine, string suburb, string state, string postcode)
        {
            if (addressLine.IsNullOrEmpty())
                return Result.Failure<Address>("'Address line 1' is required");

            if (suburb.IsNullOrEmpty())
                return Result.Failure<Address>("'Suburb' is required");

            if (state.IsNullOrEmpty())
                return Result.Failure<Address>("'State' is required");

            if (postcode.IsNullOrEmpty())
                return Result.Failure<Address>("'Postcode' is required");

            return Result.Success(new Address(addressLine, suburb, state, postcode));
        }

        protected override bool EqualsCore(Address other)
        {
            return AddressLine == other.AddressLine &&
                Suburb == other.Suburb &&
                State == other.State &&
                Postcode == other.Postcode;
        }

        protected override int GetHashCodeCore()
        {
            return AddressLine.GetHashCode() ^
                Suburb.GetHashCode() ^
                State.GetHashCode() ^
                Postcode.GetHashCode();
        }
    }
}