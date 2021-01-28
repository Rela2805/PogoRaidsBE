using PogoRaidsBackend.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PogoRaidsBackend.Repository
{
    public interface ITeamRepository
    {
        TeamDataModel Save(TeamDataModel teamModel);
        IList<TeamDataModel> GetAll();
        void Delete(long id);
        TeamDataModel Get(long id);
        TeamDataModel GetByColor(string color);
    }
}
