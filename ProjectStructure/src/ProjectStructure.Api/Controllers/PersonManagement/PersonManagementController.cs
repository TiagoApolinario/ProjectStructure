using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.Commands.Commands.PersonManagement;
using ProjectStructure.Commands.Commands.PersonManagement.RequestsDto;
using ProjectStructure.Queries.Queries.PersonManagement.PersonList;
using System.Threading.Tasks;

namespace ProjectStructure.Api.Controllers.PersonManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonManagementController : CustomControllerBase
    {
        private readonly IMediator _mediator;

        public PersonManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/list")]
        public async Task<IActionResult> Get()
        {
            var query = new GetPersonListQuery();
            var result = await _mediator.Send(query);
            return FromResult(result);
        }

        [HttpGet("/add")]
        public async Task<IActionResult> AddNewPersonAsync(AddNewPersonRequestDto requestDto)
        {
            var command = new AddPersonCommand(requestDto.Name, requestDto.AddressLine, requestDto.Suburb, requestDto.State, requestDto.Postcode);
            var result = await _mediator.Send(command);
            return FromResult(result);
        }
    }
}
