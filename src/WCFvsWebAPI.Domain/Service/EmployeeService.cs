using System.Collections.Generic;
using WCFvsWebAPI.Domain.Entities;
using WCFvsWebAPI.Domain.Interfaces.Repository.DAO;
using WCFvsWebAPI.Domain.Interfaces.Repository.Dapper;
using WCFvsWebAPI.Domain.Interfaces.Service;

namespace WCFvsWebAPI.Domain.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepositoryDAO _employeeRepositoryDao;
        private readonly IEmployeeRepositoryDapper _employeeRepositoryDapper;

        public EmployeeService(IEmployeeRepositoryDAO employeeRepositoryDao, IEmployeeRepositoryDapper employeeRepositoryDapper)
        {
            _employeeRepositoryDao = employeeRepositoryDao;
            _employeeRepositoryDapper = employeeRepositoryDapper;
        }

        public Employee Add(Employee employee)
        {
            return _employeeRepositoryDapper.Add(employee);
        }

        public Employee Update(Employee employee)
        {
            return _employeeRepositoryDapper.Update(employee);
        }

        public Employee GetById(int id)
        {
            return _employeeRepositoryDapper.GetById(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepositoryDapper.GetAll();
        }
    }
}
