using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WCFvsWebAPI.Domain.Entities;
using WCFvsWebAPI.Domain.Interfaces.Repository.DAO;
using WCFvsWebAPI.Infra.Data.Common.SQL;

namespace WCFvsWebAPI.Infra.Data.ADO.DAO
{
    public class EmployeeRepositoryDAO : RepositoryBase, IEmployeeRepositoryDAO
    {
        private static Employee Mapper(Employee employee, SqlDataReader dataReader)
        {
            employee.EmployeeId = Convert.ToInt32(dataReader["EmployeeId"]);
            employee.Name = dataReader["Name"].ToString();
            employee.Email = dataReader["Email"].ToString();
            employee.Phone = dataReader["Phone"].ToString();
            employee.Gender = dataReader["Gender"].ToString();
            return employee;
        }

        public Employee Add(Employee employee)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", employee.Name),
                new SqlParameter("@Email", employee.Email),
                new SqlParameter("@Phone", employee.Phone),
                new SqlParameter("@Gender", employee.Gender)
            };
            int newId = ExecuteScalar(EmployeeSQL.CommandTextAdd, parameters);
            if (newId == 0) return null;
            employee.EmployeeId = newId;
            return employee;
        }

        public Employee Update(Employee employee)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", employee.Name),
                new SqlParameter("@Email", employee.Email),
                new SqlParameter("@Phone", employee.Phone),
                new SqlParameter("@Gender", employee.Gender),
                new SqlParameter("@EmployeeId", employee.EmployeeId)
            };
            ExecuteNonQuery(EmployeeSQL.CommandTextUpdate, parameters);
            return employee;
        }

        public Employee GetById(int id)
        {
            Employee employee = null;
            using (SqlConnection connection = DefaultConnection)
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = EmployeeSQL.CommandTextGetById;
                    command.Parameters.AddWithValue("@EmployeeId", id);
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            employee = new Employee();
                            while (dataReader.Read())
                            {
                                Mapper(employee, dataReader);
                            }
                        }
                    }
                }
            }
            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            List<Employee> employees = null;
            using (SqlConnection connection = DefaultConnection)
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = EmployeeSQL.CommandTextGelAll;
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            employees = new List<Employee>();
                            while (dataReader.Read())
                            {
                                employees.Add(Mapper(new Employee(), dataReader));
                            }
                        }
                    }
                }
            }
            return employees;
        }
    }
}
