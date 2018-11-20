using FluentValidation;
using System;
using System.Collections.Generic;
using WCFvsWebAPI.Domain.Entities;
using WCFvsWebAPI.Domain.Interfaces.Service;
using WCFvsWebAPI.Domain.Validations;

namespace WCFvsWebAPI.Service.WCF.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeServiceContract" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeServiceContract.svc or EmployeeServiceContract.svc.cs at the Solution Explorer and start debugging.

    public class EmployeeServiceContract : IEmployeeServiceContract
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeServiceContract(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public EmployeeDataContract Add(EmployeeDataContract employeeDataContract)
        {
            Employee employee = new Employee
            {
                Name = employeeDataContract.Name,
                Email = employeeDataContract.Email,
                Phone = employeeDataContract.Phone,
                Gender = employeeDataContract.Gender
            };
            FluentValidation.Results.ValidationResult validator = new EmployeeValidator().Validate(employee);
            if (validator.IsValid)
            {
                employeeDataContract.EmployeeId = _employeeService.Add(employee).EmployeeId;
                return employeeDataContract;
            }
            return null;
        }

        public EmployeeDataContract Update(EmployeeDataContract employeeDataContract)
        {
            Employee employee = new Employee
            {
                EmployeeId = employeeDataContract.EmployeeId,
                Name = employeeDataContract.Name,
                Email = employeeDataContract.Email,
                Phone = employeeDataContract.Phone,
                Gender = employeeDataContract.Gender
            };
            EmployeeValidator validator = new EmployeeValidator();
            validator.RuleFor(x => x.EmployeeId).NotNull().WithMessage("The EmployeeId cannot be null.").GreaterThan(0).WithMessage("The EmployeeId cannot be greater than 0.");
            FluentValidation.Results.ValidationResult validationResult = validator.Validate(employee);
            if (validationResult.IsValid)
            {
                employeeDataContract.EmployeeId = _employeeService.Update(employee).EmployeeId;
                return employeeDataContract;
            }
            return null;
        }

        public EmployeeDataContract GetById(string id)
        {
            Employee employee = _employeeService.GetById(Convert.ToInt32(id));
            return new EmployeeDataContract
            {
                EmployeeId = employee.EmployeeId,
                Email = employee.Email,
                Phone = employee.Phone,
                Gender = employee.Gender,
                Name = employee.Name
            };
        }

        public IEnumerable<EmployeeDataContract> GetAll()
        {
            IEnumerable<Employee> employess = _employeeService.GetAll();
            List<EmployeeDataContract> employeeDataContracts = new List<EmployeeDataContract>();
            foreach (Employee employee in employess)
            {
                employeeDataContracts.Add(new EmployeeDataContract
                {
                    EmployeeId = employee.EmployeeId,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Gender = employee.Gender,
                    Name = employee.Name
                });
            }

            return employeeDataContracts;
        }
    }
}
