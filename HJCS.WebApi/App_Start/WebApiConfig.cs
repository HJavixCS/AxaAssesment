using Microsoft.Practices.Unity;
using System.Web.Http;
using HJCS.Domain.AdapterExternalServices;
using HJCS.Domain.Entities;
using HJCS.Domain.Repositories;
using HJCS.Infrastructure.AdapterExternalServices;
using HJCS.Infrastructure.DataEntities;
using HJCS.Infrastructure.Repositories;
using HJCS.WebApi.Resolver;

namespace HJCS.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Dependency Injection
            var container = new UnityContainer();
           
            container.RegisterType<IReadOnlyRepository<Client>, ClientRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IReadOnlyRepository<Policy>, PolicyRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IDataMapper<Client, ClientDto>, ClientMappper>();
            container.RegisterType<IDataMapper<Policy, PolicyDto>, PolicyMapper>();

            container.RegisterType<IDataRetriever<RootClientDto>, ClientsDataRetriever>();
            container.RegisterType<IDataRetriever<RootPolicyDto>, PoliciesDataRetriever>();

            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
