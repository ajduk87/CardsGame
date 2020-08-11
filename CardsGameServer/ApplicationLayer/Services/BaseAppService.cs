using CardsGameServer.DomainLayer.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Services
{
    public abstract class BaseAppService
    {
        protected readonly IMapper dtoToEntityMapper;
        protected readonly IDatabaseConnectionFactory databaseConnectionFactory;

        public BaseAppService()
        {
            this.dtoToEntityMapper = new DtoToEntityMapper();
            this.databaseConnectionFactory = new DatabaseConnectionFactory();
        }
    }
}
