using AutoMapper;
using MediatR;
using WorkoutReservation.Application.Common.Exceptions;
using WorkoutReservation.Application.Contracts;

namespace WorkoutReservation.Application.Features.Instructors.Queries.GetInstructorDetail;

public class GetInstructorDetailQueryHandler : IRequestHandler<GetInstructorDetailQuery, 
                                                               InstructorDetailQueryDto>
{
    private readonly IInstructorRepository _instructorRepository;
    private readonly IMapper _mapper;

    public GetInstructorDetailQueryHandler(IInstructorRepository instructorRepository,
                                           IMapper mapper)
    {
        _instructorRepository = instructorRepository;
        _mapper = mapper;
    }

    public async Task<InstructorDetailQueryDto> Handle(GetInstructorDetailQuery request, 
                                                 CancellationToken cancellationToken)
    {
        var instructor = await _instructorRepository.GetByIdAsync(request.InstructorId);

        if (instructor is null)
            throw new NotFoundException($"Instructor with Id: {request.InstructorId} not found.");

        return _mapper.Map<InstructorDetailQueryDto>(instructor);
    }
}
