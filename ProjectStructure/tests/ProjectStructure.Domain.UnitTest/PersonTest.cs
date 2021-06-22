using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectStructure.Domain.UnitTest
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void Create_CreatePersonSucessfully_ShouldCreatePersonSucessfully()
        {
            var personName = " personName ";
            var addressLine = " addressLine ";
            var suburb = " suburb ";
            var state = " state ";
            var postcode = " postcode ";

            var address = Address.Create(addressLine, suburb, state, postcode);
            var personResult = Person.Create(personName, address.Value);

            personResult.IsSuccess.Should().BeTrue();
            personResult.Value.Name.Should().Be(personName.Trim());
        }
    }
}
