using AutoMapper;
using WorkoutReservation.Application.Features.Users.Commands.Login;
using WorkoutReservation.Application.Features.Users.Commands.Register;
using WorkoutReservation.Application.Features.Users.Queries.GetUsersList;
using WorkoutReservation.Domain.Entities;

namespace WorkoutReservation.Application.Common.MappingProfile;

public class UserProfile : Profile
{
    public UserProfile()
    {
        // register
        CreateMap<RegisterCommand, User>();

        // login
        CreateMap<LoginCommand, User>();

        // GetUsersList
        CreateMap<User, UsersListDto>();
    }
}
