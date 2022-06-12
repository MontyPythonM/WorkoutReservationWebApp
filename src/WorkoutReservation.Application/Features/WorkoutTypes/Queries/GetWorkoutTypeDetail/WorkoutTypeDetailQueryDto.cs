﻿using System.Text.Json.Serialization;
using WorkoutReservation.Application.Common.Models;
using WorkoutReservation.Domain.Enums;

namespace WorkoutReservation.Application.Features.WorkoutTypes.Queries.GetWorkoutTypeDetail
{
    public class WorkoutTypeDetailQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))] 
        public WorkoutIntensity Intensity { get; set; }

        public List<InstructorDto> Instructors { get; set; }
        public List<WorkoutTypeTagDto> WorkoutTypeTags { get; set; }
    }
}
