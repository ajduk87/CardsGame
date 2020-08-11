using AutoMapper;
using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.DomainLayer.Mappings.Profiles;
using System.Collections.Generic;


namespace CardsGameServer.DomainLayer.Entities
{
    public class EntityFactory
    {
        protected readonly IMapper mapper;

        public EntityFactory()
        {
            this.mapper = GenerateMapper();
        }

        private IMapper GenerateMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GameProfile>();
            });

            return mapperConfiguration.CreateMapper();
        }

        public Entity Create<Source, Destination>(Source dto) where Source : Dto
                                                              where Destination : Entity
        {
            return this.mapper.Map<Source, Destination>(dto);
        }

        public IEnumerable<Entity> CreateList<Source, Destination>(Source dto) where Source : IEnumerable<Dto>
                                                             where Destination : IEnumerable<Entity>
        {
            return this.mapper.Map<Source, Destination>(dto);
        }

        public Dto Get<Source, Destination>(Source entity) where Source : Entity
                                                             where Destination : Dto
        {
            return this.mapper.Map<Source, Destination>(entity);
        }

        public IEnumerable<Dto> GetList<Source, Destination>(Source entities) where Source : IEnumerable<Entity>
                                                            where Destination : IEnumerable<Dto>
        {
            return this.mapper.Map<Source, Destination>(entities);
        }
    }
}