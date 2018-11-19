using SimpleInjector;
using WCFvsWebAPI.Domain.Interfaces.Repository.DAO;
using WCFvsWebAPI.Domain.Interfaces.Repository.Dapper;
using WCFvsWebAPI.Domain.Interfaces.Service;
using WCFvsWebAPI.Domain.Service;
using WCFvsWebAPI.Infra.Data.ADO.DAO;
using WCFvsWebAPI.Infra.Data.Dapper.Dapper;

namespace WCFvsWebAPI.Infra.CrossCutting.IoC
{
    public class Bootstrap
    {
        public static void RegisterServices(Container container)
        {
            // Domain
            container.Register<IEmployeeService, EmployeeService>(Lifestyle.Scoped);

            // Infra Data
            container.Register<IEmployeeRepositoryDAO, EmployeeRepositoryDAO>(Lifestyle.Scoped);
            container.Register<IEmployeeRepositoryDapper, EmployeeRepositoryDapper>(Lifestyle.Scoped);
        }
    }
}
