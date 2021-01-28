using PogoRaidsBackend.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PogoRaidsBackend.Repository
{
    public interface IDifficultyRepository
    {
        DifficultyDataModel Save(DifficultyDataModel teamModel);
        IList<DifficultyDataModel> GetAll();
        void Delete(long id);
        DifficultyDataModel Get(long id);
        DifficultyDataModel GetByLevel(int level);
    }
}
