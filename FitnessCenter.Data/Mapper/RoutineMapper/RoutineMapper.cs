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
        public SqlOperation GetCreateStatement(Routine routine, 
            List<RoutineExercise> exercises, List<RoutineEquipment> equipment)
        {
            SqlOperation operation = new SqlOperation
            {
                ProcedureName = "CreateRoutineWithDetails"
            };

            operation.AddIntegerParam("ClientID", routine.ClientID); // Integer parameter set to routine.ClientID
            operation.AddIntegerParam("TrainerID", routine.TrainerID); // Integer parameter set to routine.TrainerID
            operation.AddDateTimeParam("CreatedAt", routine.CreatedAt); // DateTime parameter set to routine.CreatedAt

            var exerciseTable = new DataTable(); // exerciseTable - to hold exercise data
            exerciseTable.Columns.Add("ExerciseID", typeof(int));
            exerciseTable.Columns.Add("Sets", typeof(int));
            exerciseTable.Columns.Add("Repetitions", typeof(int));
            exerciseTable.Columns.Add("Weight", typeof(decimal));
            exerciseTable.Columns.Add("DurationInSeconds", typeof(int));
            exerciseTable.Columns.Add("AmrapTimeLimitInSeconds", typeof(int));
            exerciseTable.Columns.Add("AmrapRepetitions", typeof(int));

            //Iterates over each RoutineExercise object in the exercises list and adds a row to the exerciseTable for each exercise.
            foreach (var exercise in exercises) 
            {
                exerciseTable.Rows.Add(exercise.ExerciseID, exercise.Sets, exercise.Repetitions, exercise.Weight, exercise.DurationInSeconds, exercise.AmrapTimeLimitInSeconds, exercise.AmrapRepetitions);
            }

            var equipmentTable = new DataTable(); //equipmentTable is created to hold equipment data
            equipmentTable.Columns.Add("EquipmentID", typeof(int));

            //iterates over each RoutineEquipment object in the equipment list and adds a row to the equipmentTable for each equipment.
            foreach (var equip in equipment)
            {
                equipmentTable.Rows.Add(equip.EquipmentID);
            }

            //Adds the exerciseTable and equipmentTable as parameters to the operation
            operation.Parameters.Add(new SqlParameter("@Exercises", exerciseTable)
            {
                SqlDbType = SqlDbType.Structured, // SqlDbType is set to SqlDbType.Structured
                TypeName = "dbo.RoutineExerciseType" // TypeName is set to "dbo.RoutineExerciseType"
            });

            //Adds the equipmentTable as a parameter to the operation
            operation.Parameters.Add(new SqlParameter("@Equipment", equipmentTable)
            {
                SqlDbType = SqlDbType.Structured, // SqlDbType is set to SqlDbType.Structured
                TypeName = "dbo.RoutineEquipmentType" // TypeName is set to "dbo.RoutineEquipmentType"
            });

            //Adds a parameter to the operation to hold the output value of the stored procedure
            var routineIdParam = new SqlParameter("@RoutineID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output // Direction is set to ParameterDirection.Output
            };
            operation.Parameters.Add(routineIdParam); // Adds the routineIdParam to the operation's parameters

            return operation;
        }

        public SqlOperation GetUpdateStatement(Routine routine)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "UpdateRoutine"
            };

            operation.AddIntegerParam("RoutineID", routine.RoutineID);
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
                ProcedureName = "RetrieveRoutinesByClient"
            };

            operation.AddIntegerParam("ClientID", clientID);

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
            // Implementation to build a single object from a dictionary row
            throw new NotImplementedException();
        }

        public List<T> BuildObjects<T>(List<Dictionary<string, object>> rows)
        {
            // Implementation to build a list of objects from a list of dictionary rows
            throw new NotImplementedException();
        }
    }
}
