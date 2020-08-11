using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CardsGameServerQuery.Controllers
{
    public class BaseController : ApiController
    {
        public IDatabaseConnectionFactory databaseConnectionFactory { get; set; }

        public BaseController()
        {
            this.databaseConnectionFactory = new DatabaseConnectionFactory();
        }
    }
}
