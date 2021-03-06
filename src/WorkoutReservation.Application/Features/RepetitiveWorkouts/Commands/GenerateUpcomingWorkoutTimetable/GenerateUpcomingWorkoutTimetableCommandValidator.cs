using FluentValidation;
using WorkoutReservation.Domain.Entities;

namespace WorkoutReservation.Application.Features.RepetitiveWorkouts.Commands.GenerateUpcomingWorkoutTimetable;

public class GenerateUpcomingWorkoutTimetableCommandValidator : AbstractValidator<GenerateUpcomingWorkoutTimetableCommand>
{
    public GenerateUpcomingWorkoutTimetableCommandValidator()
    {
        RuleFor(x => x.IsAutoGenerated)
            .NotNull();
    }
}
