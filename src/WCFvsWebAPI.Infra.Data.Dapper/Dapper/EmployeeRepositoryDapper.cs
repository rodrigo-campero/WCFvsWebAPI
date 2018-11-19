using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WCFvsWebAPI.Domain.Entities;
using WCFvsWebAPI.Domain.Interfaces.Repository.Dapper;
using WCFvsWebAPI.Infra.Data.Common;
using WCFvsWebAPI.Infra.Data.Common.SQL;

namespace WCFvsWebAPI.Infra.Data.Dapper.Dapper
{
    public class EmployeeRepositoryDapper : Connection, IEmployeeRepositoryDapper
    {
        public Employee Add(Employee employee)
        {
            using (IDbConnection connection = DefaultConnection)
            {
                employee.EmployeeId = connection.ExecuteScalar<int>(EmployeeSQL.CommandTextAdd,
                    new { employee.Name, employee.Email, employee.Phone, employee.Gender });
            }
            return employee;
        }

        public Employee Update(Employee employee)
        {
            using (IDbConnection connection = DefaultConnection)
            {
                connection.Execute(EmployeeSQL.CommandTextUpdate,
                    new { employee.EmployeeId, employee.Name, employee.Email, employee.Phone, employee.Gender });
            }
            return employee;
        }

        public Employee GetById(int id)
        {
            using (IDbConnection connection = DefaultConnection)
            {
                return connection.Query<Employee>(EmployeeSQL.CommandTextGetById, new { EmployeeId = id }).SingleOrDefault();
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            using (IDbConnection connection = DefaultConnection)
            {
                return connection.Query<Employee>(EmployeeSQL.CommandTextGelAll);
            }
        }
    }
}
