using PogoRaidsBackend.Domain;
using PogoRaidsBackend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PogoRaidsBackend.Repository
{
    public class UserRepository : IUserRepository
    {
        private INHibernateHelper helper;
        public UserRepository(INHibernateHelper helper)
        {
            this.helper = helper;
        }
        public UserDataModel Get(long id)
        {
            try
            {
                var session = helper.OpenSession();
                return session.Query<UserDataModel>().ToList().Where(x => x.Id == id).First();
            }
            catch(Exception e)
            {
                throw e.InnerException ?? e;
            }
        }
        public IList<UserDataModel> GetAll()
        {
            var session = helper.OpenSession();
            return session.Query<UserDataModel>().ToList();
        }
        public UserDataModel Save(UserDataModel userModel)
        {
            using (var session = helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(userModel);
                    transaction.Commit();
                    return userModel;
                }
            }
        }
        public UserDataModel Login(string password, string email)
        {
            try
            {
                var session = helper.OpenSession();
                return session.Query<UserDataModel>().ToList().Where(x => x.Password == password && x.Email == email).First();
            }
            catch(Exception e)
            {
                throw e.InnerException ?? e;
            }
        }
        public void Delete(long id)
        {
            using (var session = helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var user = session.Query<UserDataModel>().ToList().Where(x => x.Id == id).First();
                        var participatedRaids = user.ParticipatedRaids;

                        foreach (var raid in participatedRaids)
                        {
                            raid.Contendors.Remove(user);
                        }

                        user.ParticipatedRaids = new List<RaidDataModel>();
                        var createdRaids = user.CreatedRaids;

                        foreach (var raidModel in createdRaids)
                        {
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
                        }

                        var team = user.Team;
                        team.Members.Remove(user);

                        session.Delete(user);
                        transaction.Commit();
                    }
                    catch(Exception e)
                    {
                        throw e.InnerException ?? e;
                    }
                    
                }
            }
        }
        public void Update(long id, string name, string surname, string username, string gameNickname, string email, string password, int level)
        {
            using (var session = helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var user = session.Query<UserDataModel>().ToList().Where(x => x.Id == id).First();
                        if (!string.IsNullOrEmpty(name))
                        {
                            user.Name = name;
                        }
                        if (!string.IsNullOrEmpty(surname))
                        {
                            user.Surname = surname;
                        }
                        if (!string.IsNullOrEmpty(username))
                        {
                            user.Username = username;
                        }
                        if (!string.IsNullOrEmpty(gameNickname))
                        {
                            user.GameNickname = gameNickname;
                        }
                        if (!string.IsNullOrEmpty(email))
                        {
                            user.Email = email;
                        }
                        if (!string.IsNullOrEmpty(password))
                        {
                            user.Password = password;
                        }

                        user.Level = level;

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

        public IList<UserDataModel> GetMostActive()
        {
            var session = helper.OpenSession();
            return session.Query<UserDataModel>().ToList().OrderByDescending(x => x.RaidsCompleted).ToList();
        }
    }
}
