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
        void Delete(long id);
        RaidDataModel Get(long id);
        RaidDataModel AddUserToContenders(long raidId, UserDataModel userModel);
        RaidDataModel RemoveUserFromContenders(long raidId, long userId);
    }
}
