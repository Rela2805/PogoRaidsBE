using FluentNHibernate.Mapping;
using PogoRaidsBackend.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PogoRaidsBackend.Mappings
{
    class PokemonDataModelMap: ClassMap<PokemonDataModel>
    {
        public PokemonDataModelMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.ImageId);
            References(x => x.Difficulty);
            HasMany(x => x.Raids).Inverse().Cascade.All();
        }
    }
}
