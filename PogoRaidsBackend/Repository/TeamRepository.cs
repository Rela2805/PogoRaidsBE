using NHibernate;
using NHibernate.Util;
using PogoRaidsBackend.Domain;
using PogoRaidsBackend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PogoRaidsBackend.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private INHibernateHelper helper;
        public TeamRepository(INHibernateHelper helper)
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
                        var team = session.Get<TeamDataModel>(id);
                        var members = team.Members;

                        foreach (var member in members)
                        {
                            member.Team = null;
                        }

                        session.Delete(team);
                        transaction.Commit();
                    } 
                    catch(Exception e) 
                    {
                        throw e.InnerException ?? e;
                    }
                }
            }
        }

        public TeamDataModel Get(long id)
        {
            try
            {
                var session = helper.OpenSession();
                return session.Query<TeamDataModel>().ToList().Where(x => x.Id == id).First();
            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }

        public IList<TeamDataModel> GetAll()
        {
            var session = helper.OpenSession();
            return session.Query<TeamDataModel>().ToList();
        }

        public TeamDataModel GetByColor(string color)
        {
            try
            {
                var session = helper.OpenSession();
                return session.Query<TeamDataModel>().ToList().Where(x => x.Color == color).First();
            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }

        public TeamDataModel Save(TeamDataModel teamModel)
        {
            using (var session = helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(teamModel);
                    transaction.Commit();
                    return teamModel;
                }
            }
        }
    }
}
