using ProjectStructure.Domain.Core;
using ProjectStructure.Utils;
using System;

namespace ProjectStructure.Domain
{
    public class Person : Entity
    {
        public string Name { get; private set; }
        public virtual Address Address { get; private set; }

        protected Person() { }

        private Person(string name, Address address)
            : this()
        {
            Name = name.Trim();
            Address = address;
        }

        public static Result<Person> Create(string name, Address address)
        {
            if (name.IsNullOrEmpty())
                return Result.Failure<Person>("'name' is required");

            if (address == null)
                return Result.Failure<Person>("'address' is required");

            return Result.Success(new Person(name, address));
        }

        public Result CanUpdateAddress(Address address)
        {
            if (address == null)
                return Result.Failure("'address' is required");

            return Result.Success();
        }

        public void UpdateAddress(Address address)
        {
            if (CanUpdateAddress(address).IsFailure)
                throw new InvalidOperationException();

            Address = address;
        }
    }
}
