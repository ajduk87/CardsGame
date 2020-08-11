using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Mappings
{
    public class DtoToEntityMapper : IMapper
    {
        protected readonly EntityFactory entityFactory;

        public DtoToEntityMapper()
        {
            this.entityFactory = new EntityFactory();
        }

        public Destination Map<Source, Destination>(Source dto) where Source : Dto
                                                                where Destination : Entity
        {
            return (Destination)this.entityFactory.Create<Source, Destination>(dto);
        }

        public Destination MapList<Source, Destination>(Source dto) where Source : IEnumerable<Dto>
                                                        where Destination : IEnumerable<Entity>
        {
            return (Destination)this.entityFactory.CreateList<Source, Destination>(dto);
        }

        public Destination MapView<Source, Destination>(Source entity) where Source : Entity
                                                       where Destination : Dto
        {
            return (Destination)this.entityFactory.Get<Source, Destination>(entity);
        }

        public Destination MapViewList<Source, Destination>(Source entities) where Source : IEnumerable<Entity>
                                                        where Destination : IEnumerable<Dto>
        {
            return (Destination)this.entityFactory.GetList<Source, Destination>(entities);
        }
    }
}
