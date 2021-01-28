using PogoRaidsBackend.Domain;
using PogoRaidsBackend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PogoRaidsBackend.Repository
{
    public class DifficultyRepository : IDifficultyRepository
    {
        private INHibernateHelper helper;
        public DifficultyRepository(INHibernateHelper helper)
        {
            this.helper = helper;
        }

        public void Delete(long id)
        {
            using (var session = helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var difficulty = session.Get<DifficultyDataModel>(id);
                        var pokemons = difficulty.Pokemons;

                        foreach (var pokemon in pokemons)
                        {
                            pokemon.Difficulty = null;
                        }

                        session.Delete(difficulty);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        throw e.InnerException ?? e;
                    }
                }
            }
        }

        public DifficultyDataModel Get(long id)
        {
            try
            {
                var session = helper.OpenSession();
                return session.Query<DifficultyDataModel>().ToList().Where(x => x.Id == id).First();
            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }

        public IList<DifficultyDataModel> GetAll()
        {
            var session = helper.OpenSession();
            return session.Query<DifficultyDataModel>().ToList();
        }

        public DifficultyDataModel Save(DifficultyDataModel difficultyModel)
        {
            using (var session = helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(difficultyModel);
                    session.Transaction.Commit();
                    return difficultyModel;
                }
            }
        }

        public DifficultyDataModel GetByLevel(int level)
        {
            try
            {
                var session = helper.OpenSession();
                return session.Query<DifficultyDataModel>().ToList().Where(x => x.Level == level).First();
            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }
    }
}
