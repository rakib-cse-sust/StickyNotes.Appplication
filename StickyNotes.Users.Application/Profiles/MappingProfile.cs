using AutoMapper;
using StickyNotes.Users.Application.Features.Notes.Queries.GetNoteDetail;
using StickyNotes.Users.Application.Features.User.Commands.RegisterUser;

namespace StickyNotes.Users.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.User, UserDetailVm>();
            CreateMap<Domain.Entities.User, RegisterUserCommand>().ReverseMap();
        }
    }
}
