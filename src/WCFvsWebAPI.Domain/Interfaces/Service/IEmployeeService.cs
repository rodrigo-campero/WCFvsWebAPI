using System.Collections.Generic;
using WCFvsWebAPI.Domain.Entities;

namespace WCFvsWebAPI.Domain.Interfaces.Service
{
    public interface IEmployeeService
    {
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        Employee GetById(int id);
        IEnumerable<Employee> GetAll();
    }
}
