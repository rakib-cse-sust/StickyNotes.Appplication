using AutoMapper;
using MediatR;
using StickyNotes.Application.Features.Notes.Queries.GetNoteDetail;
using StickyNotes.Users.Application.Contracts.Persistance;
using StickyNotes.Users.Application.Exceptions;

namespace StickyNotes.Users.Application.Features.Notes.Queries.GetNoteDetail
{
    internal class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailVm>
    {
        private readonly IAsyncRepository<Domain.Entities.User> _userRepository;
        private readonly IMapper _mapper;

        public GetUserDetailQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDetailVm> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.User), request.Id);
            }

            var userDetailDto = _mapper.Map<UserDetailVm>(user);

            return userDetailDto;
        }
    }
}