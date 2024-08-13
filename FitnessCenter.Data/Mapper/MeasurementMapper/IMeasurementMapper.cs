using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.MeasurementDTO;


namespace FitnessCenter.Data.Mapper.MeasurementMapper
{
    public interface IMeasurementMapper
    {
        Measurement MapToDTO(Dictionary<string, string> row);
        Dictionary<string, string> MapToRow(Measurement entityDTO);
        Measurement MapToMeasurement(Measurement entity);

        SqlOperation GetCreateMeasurementStatement(Measurement entityDTO);
        SqlOperation GetUpdateMeasurementStatement(Measurement entityDTO);
        SqlOperation GetDeleteMeasurementStatement(int measurementID);
        SqlOperation GetRetrieveAllMeasurementStatement();
        SqlOperation GetRetrieveMeasurementByUserIdStatement(int userId);

    }
}
