using AutoMapper;
using StickyNotes.Application.Features.Notes.Commands.CreateNote;
using StickyNotes.Application.Features.Notes.Commands.DeleteNote;
using StickyNotes.Application.Features.Notes.Commands.UpdateNote;
using StickyNotes.Application.Features.Notes.Queries.GetNoteDetail;
using StickyNotes.Application.Features.Notes.Queries.GetNotesListQuery;
using StickyNotes.Domain.Entities;

namespace StickyNotes.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Note, NoteListVm>().ReverseMap();
            CreateMap<Note, NoteDetailVm>().ReverseMap();
            CreateMap<User, UserDto>();

            CreateMap<Note, CreateNoteCommand>().ReverseMap();
            CreateMap<Note, UpdateNoteCommand>().ReverseMap();
            CreateMap<Note, DeleteNoteCommand>().ReverseMap();
        }
    }
}
