using PogoRaidsBackend.Domain;
using PogoRaidsBackend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PogoRaidsBackend.Repository
{
    public class RaidRepository : IRaidRepository
    {
        private INHibernateHelper helper;
        public RaidRepository(INHibernateHelper helper)
        {
            this.helper = helper;
        }
        public RaidDataModel AddUserToContenders(long raidId, UserDataModel userModel)
        {
            using (var session = helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var raidModel = this.Get(raidId);
                        raidModel.Contendors.Add(userModel);
                        userModel.ParticipatedRaids.Add(raidModel);

                        session.SaveOrUpdate(raidModel);
                        transaction.Commit();
                        return raidModel;
                    }
                    catch (Exception e)
                    {
                        throw e.InnerException ?? e;
                    }
                }
            }
        }

        public void Delete(long id)
        {
            using (var session = helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var raidModel = this.Get(id);
                    var pokemonModel = raidModel.Pokemon;
                    pokemonModel.Raids.Remove(raidModel);
                    var creator = raidModel.Creator;
                    creator.CreatedRaids.Remove(raidModel);
                    var contenders = raidModel.Contendors;

                    foreach(var contender in contenders)
                    {
                        contender.ParticipatedRaids.Remove(raidModel);
                    }

                    session.Delete(raidModel);
                    transaction.Commit();
                }
            }
        }

        public RaidDataModel Get(long id)
        {
            try
            {
                var session = helper.OpenSession();
                return session.Query<RaidDataModel>().ToList().Where(x => x.Id == id).First();
            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }

        public IList<RaidDataModel> GetAll()
        {
            var session = helper.OpenSession();
            return session.Query<RaidDataModel>().ToList();
        }

        public RaidDataModel RemoveUserFromContenders(long raidId, long userId)
        {
            using (var session = helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var raidModel = this.Get(raidId);
                        var user = raidModel.Contendors.Where(x => x.Id == userId).First();
                        raidModel.Contendors.Remove(user);
                        user.ParticipatedRaids.Remove(raidModel);

                        session.SaveOrUpdate(raidModel);
                        transaction.Commit();
                        return raidModel;
                    }
                    catch (Exception e)
                    {
                        throw e.InnerException ?? e;
                    }
                }
            }
        }

        public RaidDataModel Save(RaidDataModel raidModel)
        {
            using (var session = helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(raidModel);
                    transaction.Commit();
                    return raidModel;
                }
            }
        }
    }
}
