using Dapper;
using MediatR;
using ProjectStructure.Utils;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStructure.Queries.Queries.PersonManagement.PersonList
{
    public sealed class GetPersonListQuery : IRequest<Result<IEnumerable<PersonListResponseDto>>>
    {
        public GetPersonListQuery() { }

        public sealed class GetPersonListQueryHandler : IRequestHandler<GetPersonListQuery, Result<IEnumerable<PersonListResponseDto>>>
        {
            private readonly string _connectionString;

            public GetPersonListQueryHandler(string connectionString)
            {
                _connectionString = connectionString;
            }

            public async Task<Result<IEnumerable<PersonListResponseDto>>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var query = "SELECT * FROM People";
                    var people = await connection.QueryAsync<PersonListResponseDto>(query);
                    return Result.Success(people.OrderBy(x => x.Name).AsEnumerable());
                }
            }
        }
    }
}