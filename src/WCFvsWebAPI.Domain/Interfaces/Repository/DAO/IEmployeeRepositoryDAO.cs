using System.Collections.Generic;
using WCFvsWebAPI.Domain.Entities;

namespace WCFvsWebAPI.Domain.Interfaces.Repository.DAO
{
    public interface IEmployeeRepositoryDAO
    {
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        Employee GetById(int id);
        IEnumerable<Employee> GetAll();
    }
}
