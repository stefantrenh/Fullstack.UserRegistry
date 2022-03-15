using Microsoft.AspNetCore.Mvc;
using UserRegistrys.Application.Commands;
using UserRegistrys.Application.Queries;

namespace UserRegistrys.Web.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<GetAllUsersDataQueryResponse>>> GetAllUsers([FromServices] GetAllUsersDataQueryHandler handler)
        { 
            var response = await handler.HandleAsync();
            return Ok(response);          
        }

        [HttpGet]
        public async Task<ActionResult<GetUserDataQueryResponse>> GetUser([FromServices] GetUserDataQueryHandler handler, [FromQuery] GetUserDataQuery getUserDataQuery)
        {
            var response = await handler.HandleAsync(getUserDataQuery);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<PostCreateUserBack>> CreateUser([FromServices] PostCreateUserHandler handler, PostCreateUserCommand postCreateUserCommand)
        {
            var response = await handler.HandleAsync(postCreateUserCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<PutUpdateUserBack>> UpdateCurrentUser([FromServices] PutUpdateUserHandler handler, PutUpdateUserCommand putUpdateUserCommand)
        {
            var response = await handler.HandleAsync(putUpdateUserCommand);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<DeleteUserBack>> DeleteUser([FromServices] DeleteUserHandler handler, DeleteUserCommand deleteUserCommand)
        {
            var response = await handler.HandleAsync(deleteUserCommand);
            return Ok(response);
        }

    }
}
