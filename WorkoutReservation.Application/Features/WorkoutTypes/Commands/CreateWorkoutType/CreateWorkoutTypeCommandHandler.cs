﻿using AutoMapper;
using MediatR;
using WorkoutReservation.Application.Contracts;
using WorkoutReservation.Application.Exceptions;
using WorkoutReservation.Domain.Entities;

namespace WorkoutReservation.Application.Features.WorkoutTypes.Commands.CreateWorkoutType
{
    public class CreateWorkoutTypeCommandHandler : IRequestHandler<CreateWorkoutTypeCommand, int>
    {
        private readonly IWorkoutTypeRepository _workoutRepository;
        private readonly IMapper _mapper;

        public CreateWorkoutTypeCommandHandler(IWorkoutTypeRepository workoutTypeRepository, IMapper mapper)
        {
            _workoutRepository = workoutTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateWorkoutTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateWorkoutTypeCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                throw new ValidationException($"Validation error:\n{validatorResult}");

            var workoutType = _mapper.Map<WorkoutType>(request);

            workoutType = await _workoutRepository.AddAsync(workoutType);

            return workoutType.Id;
        }
    }
}