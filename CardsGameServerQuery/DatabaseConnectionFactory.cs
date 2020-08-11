using Autofac;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServerQuery
{
    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        private DatabaseConnectionFactory instance = null;
        private readonly object padlock = new object();
        private readonly IConfigurationService configurationService;

        public DatabaseConnectionFactory()
        {
            this.configurationService = ContainerInitializer.Container.Resolve<IConfigurationService>();
        }

        private string LoadConnectionString()
        {
            List<Parameter> parameters = configurationService.GetParameters();

            return parameters.Where(parameter => parameter.Name.Equals("databaseConnectionString")).Single().Value;
        }

        public NpgsqlConnection Create(string connectionStringParam = null)
        {
            string connectionString = String.IsNullOrEmpty(connectionStringParam) ? this.LoadConnectionString() : connectionStringParam;
            return new NpgsqlConnection(connectionString);
        }

        public IDatabaseConnectionFactory Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DatabaseConnectionFactory();
                    }
                    return instance;
                }
            }
        }
    }
}
