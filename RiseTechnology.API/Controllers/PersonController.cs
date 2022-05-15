using Microsoft.AspNetCore.Mvc;
using RiseTechnology.Application.Common.Model;
using RiseTechnology.Application.Persons.Commands.CreatePerson;
using RiseTechnology.Application.Persons.Commands.DeletePerson;
using RiseTechnology.Application.Persons.Commands.UpdatePerson;
using RiseTechnology.Application.Persons.Queries.GetPersonById;
using RiseTechnology.Application.Persons.Queries.GetPersonsWithPagination;

namespace RiseTechnology.API.Controllers
{
    [Route("api/person")]
    public class PersonController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePersonCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(UpdatePersonCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletePersonCommand { Id = id });

            return NoContent();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetPersonByIdDTO>> GetById(int id)
        {
            return await Mediator.Send(new GetPersonByIdQuery { Id = id });
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<GetPersonsWithPaginationDTO>>> GetAll([FromQuery] GetPersonsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
