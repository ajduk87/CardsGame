using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.DomainLayer.Entities;
using System.Collections.Generic;

namespace CardsGameServer.DomainLayer.Mappings
{
    public interface IMapper
    {
        Destination Map<Source, Destination>(Source dto) where Source : Dto
                                                        where Destination : Entity;

        Destination MapList<Source, Destination>(Source dto) where Source : IEnumerable<Dto>
                                                        where Destination : IEnumerable<Entity>;

        Destination MapView<Source, Destination>(Source entity) where Source : Entity
                                                        where Destination : Dto;

        Destination MapViewList<Source, Destination>(Source entities) where Source : IEnumerable<Entity>
                                                        where Destination : IEnumerable<Dto>;
    }
}