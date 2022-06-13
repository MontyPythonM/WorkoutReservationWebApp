﻿using Microsoft.EntityFrameworkCore;
using WorkoutReservation.Domain.Common;
using WorkoutReservation.Domain.Entities;
using WorkoutReservation.Infrastructure.Presistence.Configuration;

namespace WorkoutReservation.Infrastructure.Presistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<WorkoutType> WorkoutTypes { get; set; }
        public DbSet<WorkoutTypeInstructor> WorkoutTypeInstructors { get; set; }
        public DbSet<WorkoutTypeTag> WorkoutTypeTags { get; set; }

        public DbSet<BaseWorkout> BaseWorkouts { get; set; }
        public DbSet<RepetitiveWorkout> RepetitiveWorkouts { get; set; }
        public DbSet<RealWorkout> RealWorkouts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new InstructorConfiguration().Configure(modelBuilder.Entity<Instructor>()); 
            new WorkoutTypeConfiguration().Configure(modelBuilder.Entity<WorkoutType>());
            new WorkoutTypeTagConfiguration().Configure(modelBuilder.Entity<WorkoutTypeTag>());
            new BaseWorkoutConfiguration().Configure(modelBuilder.Entity<BaseWorkout>());
            new RepetitiveWorkoutConfiguration().Configure(modelBuilder.Entity<RepetitiveWorkout>());
            new RealWorkoutConfiguration().Configure(modelBuilder.Entity<RealWorkout>());

        }
    }
}
