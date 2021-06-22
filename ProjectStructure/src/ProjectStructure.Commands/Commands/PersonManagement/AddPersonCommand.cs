using MediatR;
using ProjectStructure.Domain;
using ProjectStructure.Infrastructure.MyDomainDAL;
using ProjectStructure.Utils;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStructure.Commands.Commands.PersonManagement
{
    public sealed class AddPersonCommand : IRequest<Result>
    {
        public string Name { get; }
        public string AddressLine { get; }
        public string Suburb { get; }
        public string State { get; }
        public string Postcode { get; }

        public AddPersonCommand(string name, string addressLine, string suburb, string state, string postcode)
        {
            Name = name;
            AddressLine = addressLine;
            Suburb = suburb;
            State = state;
            Postcode = postcode;
        }

        public sealed class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, Result>
        {
            private readonly MyDomainDbContext _dbContext;

            public AddPersonCommandHandler(MyDomainDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Result> Handle(AddPersonCommand request, CancellationToken cancellationToken)
            {
                var addressResult = Address.Create(request.AddressLine, request.Suburb, request.State, request.Postcode);
                if (addressResult.IsFailure)
                    return Result.Failure(addressResult.ErrorMessage);

                var personResult = Person.Create(request.Name, addressResult.Value);
                if (personResult.IsFailure)
                    return Result.Failure(personResult.ErrorMessage);

                await _dbContext.People.AddAsync(personResult.Value);
                await _dbContext.SaveChangesAsync();

                return Result.Success();
            }
        }
    }
}
