using System;
using System.Collections.Generic;

namespace FitnessCenter.DTO.RoutineDTO
{
    public class RoutineWithID
    {
        public int RoutineID { get; set; }
        public int ClientID { get; set; }
        public int TrainerID { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<RoutineExerciseDetail> ExerciseDetails { get; set; }

        public RoutineWithID()
        {
            ExerciseDetails = new List<RoutineExerciseDetail>();
        }
    }

    public class RoutineExerciseDetail
    {
        public string? ExerciseName { get; set; }
        public string? EquipmentName {  get; set; }
        public string? ExerciseTypeName { get; set; }

        public int ExerciseID { get; set; }
        public int EquipmentID { get; set; }
        public int? Sets { get; set; }
        public int? Repetitions { get; set; }
        public decimal? Weight { get; set; }
        public int? DurationInSeconds { get; set; }
        public int? AmrapTimeLimitInSeconds { get; set; }
        public int? AmrapRepetitions { get; set; }
        public int? Dia { get; set; }
    }
}
