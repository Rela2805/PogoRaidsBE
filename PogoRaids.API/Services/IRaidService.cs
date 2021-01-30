using PogoRaids.API.DOMModels;
using PogoRaids.API.Models;
using PogoRaidsBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Services
{
    public interface IRaidService
    {
        RaidModel Save(RaidDOM raidModel);
        IList<RaidModel> GetAll();
        void Delete(long raidId, long userId);
        RaidModel Get(long id);
        void AddUserToContenders(long raidId, long userId);
        void RemoveUserFromContenders(long raidId, long userId);
    }
}
