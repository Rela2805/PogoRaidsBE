using PogoRaids.API.DOMModels;
using PogoRaidsBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Services
{
    public interface IRaidService
    {
        RaidDataModel Save(RaidDOM raidModel);
        IList<RaidDataModel> GetAll();
        void Delete(long id);
        RaidDataModel Get(long id);
        RaidDataModel AddUserToContenders(long raidId, long userId);
        RaidDataModel RemoveUserFromContenders(long raidId, long userId);
    }
}
