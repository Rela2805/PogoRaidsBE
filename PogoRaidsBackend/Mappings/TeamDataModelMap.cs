using FluentNHibernate.Mapping;
using PogoRaidsBackend.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PogoRaidsBackend.Mappings
{
    class TeamDataModelMap: ClassMap<TeamDataModel>
    {
        public TeamDataModelMap()
        {
            Id(x => x.Id);
            Map(x => x.Color);
            HasMany(x => x.Members).Inverse().Cascade.All();
        }
    }
}
