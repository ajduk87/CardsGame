using AutoMapper;
using CardsGameServer.ApplicationLayer.Mappings;
using System.Web.Http;

namespace CardsGameServer.ApplicationLayer.Controllers
{
    public class BaseController : ApiController
    {
        protected readonly IMapper mapper;

        public BaseController()
        {
            this.mapper = GenerateMapper();
        }

        private IMapper GenerateMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GameProfile>();
                //cfg.AddProfile<CustomerProfile>();
                //cfg.AddProfile<StorageProfile>();
                //cfg.AddProfile<OrderProfile>();
                //cfg.AddProfile<InvoiceProfile>();
                //cfg.AddProfile<ActionProfile>();
            });

            return mapperConfiguration.CreateMapper();

        }
    }
}