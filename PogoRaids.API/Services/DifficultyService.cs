using PogoRaids.API.DOMModels;
using PogoRaids.API.Models;
using PogoRaidsBackend.Domain;
using PogoRaidsBackend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Services
{
    public class DifficultyService : IDifficultyService
    {
        private IDifficultyRepository repository;
        public DifficultyService(IDifficultyRepository repository)
        {
            this.repository = repository;
        }
        public DifficultyModel Create(DifficultyLevelDOM model)
        {
            var difficulty = new DifficultyDataModel() { Level = model.Level };
            return new DifficultyModel(repository.Save(difficulty));
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public DifficultyModel Get(long id)
        {
            return new DifficultyModel(repository.Get(id));
        }

        public IList<DifficultyModel> GetAll()
        {
            return repository.GetAll().Select(x => new DifficultyModel(x)).ToList();
        }
    }
}
