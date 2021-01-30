using PogoRaids.API.DOMModels;
using PogoRaids.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Services
{
    public interface IDifficultyService
    {
        DifficultyModel Get(long id);
        IList<DifficultyModel> GetAll();
        DifficultyModel Create(DifficultyLevelDOM model);
        void Delete(long id);
    }
}
