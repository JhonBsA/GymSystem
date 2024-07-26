using FitnessCenter.DTO.RoutineDTO;
using FitnessCenter.DTO.RoutineDTO;

public class RoutineRequest
{
    public Routine Routine { get; set; }
    public List<RoutineExerciseDetail> ExerciseDetails { get; set; }
}

public class Routine
{
    public int ClientID { get; set; }
    public int TrainerID { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class RoutineExerciseDetail
{
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
