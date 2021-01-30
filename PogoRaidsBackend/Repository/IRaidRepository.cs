using PogoRaidsBackend.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PogoRaidsBackend.Repository
{
    public interface IRaidRepository
    {
        RaidDataModel Save(RaidDataModel raidModel);
        IList<RaidDataModel> GetAll();
        void Delete(long raidId, long userId);
        RaidDataModel Get(long id);
        void AddUserToContenders(long raidId, long userId);
        void RemoveUserFromContenders(long raidId, long userId);
    }
}
