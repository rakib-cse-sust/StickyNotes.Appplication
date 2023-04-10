using MediatR;
using Microsoft.AspNetCore.Mvc;
using StickyNotes.Application.Features.Notes.Queries.GetNotesListQuery;

namespace StickyNotes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StickyNoteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StickyNoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllNotes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<NoteListVm>>> GetAllNotes()
        {
            var dtos = await _mediator.Send(new GetNotesListQuery());
            return Ok(dtos);
        }
    }
}
