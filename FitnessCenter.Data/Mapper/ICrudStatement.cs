﻿using FitnessCenter.Data.Dao;
using FitnessCenter.DTO;

namespace DataAccess.Mapper
{
    public interface ICrudStatements
    {
        SqlOperation GetCreateStatement(BaseClass entityDTO);
        SqlOperation GetUpdateStatement(BaseClass entityDTO);
        SqlOperation GetDeleteStatement(BaseClass entityDTO);
        SqlOperation GetRetrieveAllStatement();
        SqlOperation GetRetrieveByIdStatement(int Id);
        SqlOperation GetRetrieveByPhraseStatement(string searchType, string searchPhrase);
    }
}