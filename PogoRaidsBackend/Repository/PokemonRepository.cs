using PogoRaidsBackend.Domain;
using PogoRaidsBackend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PogoRaidsBackend.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private INHibernateHelper helper;
        public PokemonRepository(INHibernateHelper helper)
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
                        var pokemon = session.Get<PokemonDataModel>(id);
                        var difficulty = pokemon.Difficulty;
                        difficulty.Pokemons.Remove(pokemon);
                        pokemon.Difficulty = null;

                        session.Delete(pokemon);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        throw e.InnerException ?? e;
                    }
                }
            }
        }

        public PokemonDataModel Get(long id)
        {
            try
            {
                var session = helper.OpenSession();
                return session.Query<PokemonDataModel>().ToList().Where(x => x.Id == id).First();
            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }

        public IList<PokemonDataModel> GetAll()
        {
            var session = helper.OpenSession();
            return session.Query<PokemonDataModel>().ToList();
        }

        public PokemonDataModel GetByName(string name)
        {
            try
            {
                var session = helper.OpenSession();
                return session.Query<PokemonDataModel>().ToList().Where(x => x.Name == name).First();
            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }

        public PokemonDataModel Save(PokemonDataModel pokemonModel)
        {
            using (var session = helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(pokemonModel);
                    session.Transaction.Commit();
                    return pokemonModel;
                }
            }
        }
    }
}
