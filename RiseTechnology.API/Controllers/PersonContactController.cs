using Microsoft.AspNetCore.Mvc;
using RiseTechnology.Application.PersonContacts.Commands.CreatePersonContact;
using RiseTechnology.Application.PersonContacts.Commands.DeletePersonContact;

namespace RiseTechnology.API.Controllers
{
    [Route("api/personcontact")]
    public class PersonContactController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePersonContactCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletePersonContactCommand { Id = id });

            return NoContent();
        }
    }
}
