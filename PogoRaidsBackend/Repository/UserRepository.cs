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
    }
}
