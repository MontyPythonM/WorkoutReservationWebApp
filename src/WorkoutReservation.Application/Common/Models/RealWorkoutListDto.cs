﻿using WorkoutReservation.Domain.Entities;

namespace WorkoutReservation.Application.Common.Models
{
    public class RealWorkoutListDto
    {
        public int Id { get; set; }
        public int MaxParticipianNumber { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public WorkoutTypeDto WorkoutType { get; set; }
        public int? WorkoutTypeId { get; set; }

        public InstructorDto Instructor { get; set; }
        public int? InstructorId { get; set; }
        public DateOnly Date { get; set; }
        public int CurrentParticipianNumber { get; set; }
        public bool IsAutoGenerated { get; set; }
    }
}
