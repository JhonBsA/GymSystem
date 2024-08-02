using FitnessCenter.DTO.RoutineDTO;
using FitnessCenter.DTO.EquipmentDTO;
using FitnessCenter.Data.Dao;
using System.Collections.Generic;
using System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FitnessCenter.Data.Mapper.RoutineMapper
{
    public class RoutineMapper : IRoutineMapper
    {
        public SqlOperation GetCreateStatement(Routine routine, List<RoutineExerciseDetail> exerciseDetails)
        {
            SqlOperation operation = new SqlOperation
            {
                ProcedureName = "CreateRoutineWithDetails"
            };

            operation.AddIntegerParam("ClientID", routine.ClientID);
            operation.AddIntegerParam("TrainerID", routine.TrainerID);
            operation.AddDateTimeParam("CreatedAt", routine.CreatedAt);

            var exerciseDetailsTable = new DataTable();
            exerciseDetailsTable.Columns.Add("ExerciseID", typeof(int));
            exerciseDetailsTable.Columns.Add("EquipmentID", typeof(int));
            exerciseDetailsTable.Columns.Add("Sets", typeof(int));
            exerciseDetailsTable.Columns.Add("Repetitions", typeof(int));
            exerciseDetailsTable.Columns.Add("Weight", typeof(decimal));
            exerciseDetailsTable.Columns.Add("DurationInSeconds", typeof(int));
            exerciseDetailsTable.Columns.Add("AmrapTimeLimitInSeconds", typeof(int));
            exerciseDetailsTable.Columns.Add("AmrapRepetitions", typeof(int));
            exerciseDetailsTable.Columns.Add("Dia", typeof(int));

            foreach (var detail in exerciseDetails)
            {
                exerciseDetailsTable.Rows.Add(
                    detail.ExerciseID,
                    detail.EquipmentID,
                    detail.Sets.HasValue ? (object)detail.Sets.Value : DBNull.Value,
                    detail.Repetitions.HasValue ? (object)detail.Repetitions.Value : DBNull.Value,
                    detail.Weight.HasValue ? (object)detail.Weight.Value : DBNull.Value,
                    detail.DurationInSeconds.HasValue ? (object)detail.DurationInSeconds.Value : DBNull.Value,
                    detail.AmrapTimeLimitInSeconds.HasValue ? (object)detail.AmrapTimeLimitInSeconds.Value : DBNull.Value,
                    detail.AmrapRepetitions.HasValue ? (object)detail.AmrapRepetitions.Value : DBNull.Value,
                    detail.Dia.HasValue ? (object)detail.Dia.Value : DBNull.Value
                );
            }

            var exerciseDetailsParameter = new SqlParameter("@ExerciseDetails", exerciseDetailsTable)
            {
                SqlDbType = SqlDbType.Structured,
                TypeName = "dbo.RoutineExerciseDetailType"
            };

            operation.Parameters.Add(exerciseDetailsParameter);

            return operation;
        }

        public SqlOperation GetUpdateStatement(Routine routine)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "UpdateRoutine"
            };

            operation.AddIntegerParam("ClientID", routine.ClientID);
            operation.AddIntegerParam("TrainerID", routine.TrainerID);
            operation.AddDateTimeParam("CreatedAt", routine.CreatedAt);

            return operation;
        }

        public SqlOperation GetDeleteStatement(int routineID)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "DeleteRoutine"
            };

            operation.AddIntegerParam("RoutineID", routineID);

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int routineID)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "RetrieveRoutineById"
            };

            operation.AddIntegerParam("RoutineID", routineID);

            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation
            {
                ProcedureName = "RetrieveAllRoutines"
            };

            return operation;
        }

        public SqlOperation GetRetrieveByClientStatement(int clientID)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "GetUserRoutinesWithDetails"
            };

            operation.AddIntegerParam("UserID", clientID);

            return operation;
        }

        public SqlOperation GetAddExerciseStatement(RoutineExercise exercise)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "AddRoutineExercise"
            };

            operation.AddIntegerParam("RoutineID", exercise.RoutineID);
            operation.AddIntegerParam("ExerciseID", exercise.ExerciseID);
            operation.AddIntegerParam("Sets", exercise.Sets);
            operation.AddIntegerParam("Repetitions", exercise.Repetitions);
            operation.AddDecimalParam("Weight", exercise.Weight);
            operation.AddIntegerParam("DurationInSeconds", exercise.DurationInSeconds);
            operation.AddIntegerParam("AmrapTimeLimitInSeconds", exercise.AmrapTimeLimitInSeconds);
            operation.AddIntegerParam("AmrapRepetitions", exercise.AmrapRepetitions);

            return operation;
        }

        public SqlOperation GetClearExercisesStatement(int routineID)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "ClearRoutineExercises"
            };

            operation.AddIntegerParam("RoutineID", routineID);

            return operation;
        }

        public SqlOperation GetAddEquipmentStatement(RoutineEquipment equipment)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "AddRoutineEquipment"
            };

            operation.AddIntegerParam("RoutineExerciseID", equipment.RoutineExerciseID);
            operation.AddIntegerParam("EquipmentID", equipment.EquipmentID);

            return operation;
        }

        public SqlOperation GetClearEquipmentStatement(int routineID)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "ClearRoutineEquipment"
            };

            operation.AddIntegerParam("RoutineID", routineID);

            return operation;
        }

        public T BuildObject<T>(Dictionary<string, object> row)
        {
            if (typeof(T) == typeof(RoutineWithID))
            {
                var routineWithID = new RoutineWithID
                {
                    RoutineID = row.ContainsKey("RoutineID") ? Convert.ToInt32(row["RoutineID"]) : 0,
                    ClientID = row.ContainsKey("ClientID") ? Convert.ToInt32(row["ClientID"]) : 0,
                    TrainerID = row.ContainsKey("TrainerID") ? Convert.ToInt32(row["TrainerID"]) : 0,
                    CreatedAt = row.ContainsKey("CreatedAt") ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.MinValue,
                    ExerciseDetails = new List<FitnessCenter.DTO.RoutineDTO.RoutineExerciseDetail>()
                };

                return (T)(object)routineWithID;
            }
            else if (typeof(T) == typeof(FitnessCenter.DTO.RoutineDTO.RoutineExerciseDetail))
            {
                var exerciseDetail = new FitnessCenter.DTO.RoutineDTO.RoutineExerciseDetail
                {
                    ExerciseID = row.ContainsKey("ExerciseID") ? Convert.ToInt32(row["ExerciseID"]) : 0,
                    EquipmentID = row.ContainsKey("EquipmentID") ? Convert.ToInt32(row["EquipmentID"]) : 0,
                    Sets = row.ContainsKey("Sets") ? Convert.ToInt32(row["Sets"]) : (int?)null,
                    Repetitions = row.ContainsKey("Repetitions") ? Convert.ToInt32(row["Repetitions"]) : (int?)null,
                    Weight = row.ContainsKey("Weight") ? Convert.ToDecimal(row["Weight"]) : (decimal?)null,
                    DurationInSeconds = row.ContainsKey("DurationInSeconds") ? Convert.ToInt32(row["DurationInSeconds"]) : (int?)null,
                    AmrapTimeLimitInSeconds = row.ContainsKey("AmrapTimeLimitInSeconds") ? Convert.ToInt32(row["AmrapTimeLimitInSeconds"]) : (int?)null,
                    AmrapRepetitions = row.ContainsKey("AmrapRepetitions") ? Convert.ToInt32(row["AmrapRepetitions"]) : (int?)null,
                    Dia = row.ContainsKey("Dia") ? Convert.ToInt32(row["Dia"]) : (int?)null
                };

                return (T)(object)exerciseDetail;
            }

            
            return default(T);
        }

        public List<T> BuildObjects<T>(List<Dictionary<string, object>> rows)
        {
            var lstResults = new List<T>();

            if (typeof(T) == typeof(RoutineWithID))
            {
                var routineDictionary = new Dictionary<int, RoutineWithID>();

                foreach (var row in rows)
                {
                    var routineID = Convert.ToInt32(row["RoutineID"]);
                    if (!routineDictionary.ContainsKey(routineID))
                    {
                        var routine = BuildObject<RoutineWithID>(row);
                        routineDictionary[routineID] = routine;
                    }

                    var exerciseDetail = BuildObject<FitnessCenter.DTO.RoutineDTO.RoutineExerciseDetail>(row);
                    routineDictionary[routineID].ExerciseDetails.Add(exerciseDetail);
                }

                lstResults = routineDictionary.Values.Cast<T>().ToList();
            }
            else
            {
                foreach (var row in rows)
                {
                    var obj = BuildObject<T>(row);
                    if (obj != null)
                    {
                        lstResults.Add(obj);
                    }
                }
            }

            return lstResults;
        }
    }

}

