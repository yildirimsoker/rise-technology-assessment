using FluentAssertions;
using NUnit.Framework;
using RiseTechnology.Application.Persons.Commands.CreatePerson;
using RiseTechnology.Domain.Entities;
using System.Threading.Tasks;

namespace RiseTechnology.UnitTest.CreatePerson
{
    using static Testing;

    public class CreatePersonUnitTest
    {

        [Test]
        public async Task ShouldCreatePerson()
        {
            var createPersonCommand = new CreatePersonCommand
            {
                Company = "test company",
                Name = "test name",
                Surname = "test surname"
            };

            var personId = await SendAsync(createPersonCommand);
            var person = await FindAsync<Person>(personId);

            person.Should().NotBeNull();
            person.Company.Should().Be(createPersonCommand.Company);
            person.Name.Should().Be(createPersonCommand.Name);
            person.Surname.Should().Be(createPersonCommand.Surname);
        }
    }
}
