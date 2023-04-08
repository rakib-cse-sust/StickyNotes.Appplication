using StickyNotes.Application.Responses;

namespace StickyNotes.Application.Features.Notes.Commands.CreateNote
{
    public class CreateNoteCommandResponse : BaseResponse
    {
        public CreateNoteCommandResponse() : base()
        {

        }

        public CreateNoteDto Note { get; set; } = default!;
    }
}
