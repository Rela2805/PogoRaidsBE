using FluentNHibernate.Mapping;
using PogoRaidsBackend.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PogoRaidsBackend.Mappings
{
    class RaidDataModelMap: ClassMap<RaidDataModel>
    {
        public RaidDataModelMap()
        {
            Id(x => x.Id);
            Map(x => x.MinimalLevel);
            Map(x => x.StartsIn);
            References(x => x.Pokemon);
            References(x => x.Creator);
            HasManyToMany(x => x.Contendors).Cascade.All().Table("UserRaid");
        }
    }
}
