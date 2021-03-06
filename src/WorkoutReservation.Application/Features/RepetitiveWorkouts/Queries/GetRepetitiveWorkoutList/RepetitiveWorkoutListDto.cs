using System.Text.Json.Serialization;
using WorkoutReservation.Domain.Enums;

namespace WorkoutReservation.Application.Features.RepetitiveWorkouts.Queries.GetRepetitiveWorkoutList;

public class RepetitiveWorkoutListDto
{
    public int Id { get; set; }
    public int MaxParticipianNumber { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DayOfWeek DayOfWeek { get; set; }

    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }

    public WorkoutTypeForRepetitiveWorkoutListDto WorkoutType { get; set; }
    public InstructorForRepetitiveWorkoutListDto Instructor { get; set; }
}

public class WorkoutTypeForRepetitiveWorkoutListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public WorkoutIntensity Intensity { get; set; }
}

public class InstructorForRepetitiveWorkoutListDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
