using FitnessCenter.DTO.RoutineDTO;
using FitnessCenter.DTO.EquipmentDTO;
using FitnessCenter.Data.Mapper.RoutineMapper;
using System;
using System.Collections.Generic;

namespace FitnessCenter.Data.Dao
{
    public class RoutineCrudFactory
    {
        private readonly RoutineMapper mapper;
        private readonly SqlDao dao;

        public RoutineCrudFactory()
        {
            mapper = new RoutineMapper();
            dao = SqlDao.GetInstance();
        }

        public Dictionary<string, string> Create(Routine routine, List<RoutineExerciseDetail> exerciseDetails)
        {
            SqlOperation operation = mapper.GetCreateStatement(routine, exerciseDetails);
            var result = dao.ExecuteStoredProcedureWithResult(operation);

            var response = new Dictionary<string, string>();

            if (result.Count > 0)
            {
                var firstRow = result[0];
                foreach (var key in firstRow.Keys)
                {
                    response[key] = firstRow[key].ToString();
                }

                if (firstRow.ContainsKey("SuccessMessage"))
                {
                    response["SuccessMessage"] = firstRow["SuccessMessage"].ToString();
                }
            }

            return response;
        }

        public Dictionary<string, string> Update(Routine routine)
        {
            SqlOperation operation = mapper.GetUpdateStatement(routine);
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            if (result.Count == 0)
            {
                throw new Exception("No response from stored procedure.");
            }
            var firstRow = result[0];
            var response = new Dictionary<string, string>();

            foreach (var key in firstRow.Keys)
            {
                response[key] = firstRow[key].ToString();
            }

            return response;
        }

        public Dictionary<string, string> Delete(int routineID)
        {
            SqlOperation operation = mapper.GetDeleteStatement(routineID);
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            if (result.Count == 0)
            {
                throw new Exception("No response from stored procedure.");
            }
            var firstRow = result[0];
            var response = new Dictionary<string, string>();

            foreach (var key in firstRow.Keys)
            {
                response[key] = firstRow[key].ToString();
            }

            return response;
        }

        public T Retrieve<T>(int routineID)
        {
            SqlOperation operation = mapper.GetRetrieveByIdStatement(routineID);
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            if (result.Count == 0)
            {
                return default(T);
            }
            return mapper.BuildObject<T>(result[0]);
        }

        public List<T> RetrieveAll<T>()
        {
            SqlOperation operation = mapper.GetRetrieveAllStatement();
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            return mapper.BuildObjects<T>(result);
        }

        public List<RoutineWithID> RetrieveByClient(int clientID)
        {
            SqlOperation operation = mapper.GetRetrieveByClientStatement(clientID);
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            return mapper.BuildObjects<RoutineWithID>(result);
        }


        public void AddExercise(RoutineExercise exercise)
        {
            SqlOperation operation = mapper.GetAddExerciseStatement(exercise);
            dao.ExecuteStoredProcedure(operation);
        }

        public void ClearExercises(int routineID)
        {
            SqlOperation operation = mapper.GetClearExercisesStatement(routineID);
            dao.ExecuteStoredProcedure(operation);
        }

        public void AddEquipment(RoutineEquipment equipment)
        {
            SqlOperation operation = mapper.GetAddEquipmentStatement(equipment);
            dao.ExecuteStoredProcedure(operation);
        }

        public void ClearEquipment(int routineID)
        {
            SqlOperation operation = mapper.GetClearEquipmentStatement(routineID);
            dao.ExecuteStoredProcedure(operation);
        }

        public RoutineRequest RetrieveRoutineById(int routineID)
        {
            SqlOperation operation = mapper.GetRetrieveByIdStatement(routineID);
            var result = dao.ExecuteStoredProcedureWithResult(operation);

            if (result.Count == 0)
            {
                return new RoutineRequest();
            }

            var routine = mapper.BuildObject<Routine>(result[0]);

            var exerciseDetails = new List<RoutineExerciseDetail>();
            for (int i = 1; i < result.Count; i++)
            {
                var detail = mapper.BuildObject<RoutineExerciseDetail>(result[i]);
                exerciseDetails.Add(detail);
            }

            return new RoutineRequest
            {
                Routine = routine,
                ExerciseDetails = exerciseDetails
            };
        }


    }
}
