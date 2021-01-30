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
        public void AddUserToContenders(long raidId, long userId)
        {
            using (var session = helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var raidModel = session.Query<RaidDataModel>().ToList().Where(x => x.Id == raidId && x.Creator.Id != userId).First();
                        var userModel = session.Query<UserDataModel>().ToList().Where(x => x.Id == userId).First();

                        if (raidModel.Contendors.Count == 5 || raidModel.Contendors.Contains(userModel))
                        {
                            return;
                        }

                        raidModel.Contendors.Add(userModel);
                        userModel.ParticipatedRaids.Add(raidModel);
                        userModel.RaidsCompleted += 1;

                        session.Update(raidModel);
                        session.Update(userModel);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        throw e.InnerException ?? e;
                    }
                }
            }
        }

        public void Delete(long raidId, long userId)
        {
            using (var session = helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var raidModel = session.Query<RaidDataModel>().ToList().Where(x => x.Id == raidId && x.Creator.Id == userId).First();
                        var pokemonModel = raidModel.Pokemon;
                        pokemonModel.Raids.Remove(raidModel);
                        var creator = raidModel.Creator;
                        creator.CreatedRaids.Remove(raidModel);
                        var contenders = raidModel.Contendors;

                        foreach (var contender in contenders)
                        {
                            contender.ParticipatedRaids.Remove(raidModel);
                        }

                        raidModel.Contendors = new List<UserDataModel>();
                        raidModel.Creator = null;
                        raidModel.Pokemon = null;

                        session.Delete(raidModel);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        throw e.InnerException ?? e;
                    }
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

        public void RemoveUserFromContenders(long raidId, long userId)
        {
            using (var session = helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var raidModel = session.Query<RaidDataModel>().ToList().Where(x => x.Id == raidId).First();
                        var user = raidModel.Contendors.Where(x => x.Id == userId).First();
                        raidModel.Contendors.Remove(user);
                        user.ParticipatedRaids.Remove(raidModel);
                        user.RaidsCompleted = Math.Max(0, user.RaidsCompleted - 1);

                        session.Update(raidModel);
                        session.Update(user);
                        transaction.Commit();
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
