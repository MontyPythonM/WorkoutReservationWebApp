using FluentValidation;
using WorkoutReservation.Domain.Entities;

namespace WorkoutReservation.Application.Features.Reservations.Commands.CancelReservation;

public class CancelReservationCommandValidator : AbstractValidator<CancelReservationCommand>
{
    public CancelReservationCommandValidator(Reservation reservation, Guid userGuid)
    {
        RuleFor(x => x.ReservationId)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x).Custom((value, context) =>
        {
            if (reservation.User.Id != userGuid)
            {
                context.AddFailure($"Incorrect reservation Id. Access forbidden.");
            }
        });

        RuleFor(x => x).Custom((value, context) =>
        {
            if (reservation.RealWorkout.Date < DateOnly.FromDateTime(DateTime.Now.Date))
            {
                context.AddFailure($"Workout with Id: {reservation.RealWorkout.Id} has already taken place. You cannot cancel that reservation.");
            }
        });

    }
}
