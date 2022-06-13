﻿using AutoMapper;
using FluentValidation;
using MediatR;
using WorkoutReservation.Application.Common.Exceptions;
using WorkoutReservation.Application.Contracts;
using WorkoutReservation.Domain.Entities;

namespace WorkoutReservation.Application.Features.RealWorkouts.Commands.CreateRealWorkout
{
    public class CreateRealWorkoutCommandHandler : IRequestHandler<CreateRealWorkoutCommand, int>
    {
        private readonly IRealWorkoutRepository _realWorkoutRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IWorkoutTypeRepository _workoutTypeRepository;
        private readonly IMapper _mapper;

        public CreateRealWorkoutCommandHandler(IRealWorkoutRepository realWorkoutRepository,
                                               IInstructorRepository instructorRepository,
                                               IWorkoutTypeRepository workoutTypeRepository,
                                               IMapper mapper)
        {
            _realWorkoutRepository = realWorkoutRepository;
            _instructorRepository = instructorRepository;
            _workoutTypeRepository = workoutTypeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateRealWorkoutCommand request,
                                      CancellationToken cancellationToken)
        {
            var instructor = await _instructorRepository.GetByIdAsync(request.InstructorId);
            if (instructor is null)
                throw new NotFoundException($"Instructor with Id: {request.InstructorId} not found.");

            var workoutType = await _workoutTypeRepository.GetByIdAsync(request.WorkoutTypeId);
            if (workoutType is null)
                throw new NotFoundException($"Workout type with Id: {request.WorkoutTypeId} not found.");

            var dailyWorkoutsList = await _realWorkoutRepository.GetAllAsync(request.Date, request.Date.AddDays(1));

            var validator = new CreateRealWorkoutCommandValidator(dailyWorkoutsList);
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var realWorkout = _mapper.Map<RealWorkout>(request);

            realWorkout.CreatedDate = DateTime.Now;
            realWorkout.IsAutoGenerated = false;
            realWorkout.CurrentParticipianNumber = 0;

            realWorkout = await _realWorkoutRepository.AddAsync(realWorkout);

            return realWorkout.Id;

        }
    }
}
