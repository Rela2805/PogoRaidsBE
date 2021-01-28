using FluentNHibernate.Mapping;
using PogoRaidsBackend.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PogoRaidsBackend.Mappings
{
    class DifficultyDataModelMap: ClassMap<DifficultyDataModel>
    {
        public DifficultyDataModelMap()
        {
            Id(x => x.Id);
            Map(x => x.Level);
            HasMany(x => x.Pokemons).Inverse().Cascade.All();
        }
    }
}
