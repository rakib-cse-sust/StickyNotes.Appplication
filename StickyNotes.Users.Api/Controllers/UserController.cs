using MediatR;
using Microsoft.AspNetCore.Mvc;
using StickyNotes.Users.Application.Features.User.Queries.GetUserDetail;

namespace StickyNotes.Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<UserDetailVm>> GetUserById(int id)
        {
            var getUserDetailQuery = new GetUserDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getUserDetailQuery));
        }
    }
}
