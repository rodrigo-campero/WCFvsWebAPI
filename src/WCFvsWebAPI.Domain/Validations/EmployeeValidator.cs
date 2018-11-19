using FluentValidation;
using WCFvsWebAPI.Domain.Entities;

namespace WCFvsWebAPI.Domain.Validations
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The Name cannot be blank.")
                .Length(0, 60).WithMessage("The Name cannot be more than 60 characters.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("The E-mail cannot be blank.")
                .Length(0, 60).WithMessage("The E-mail cannot be more than 60 characters.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("The Phone cannot be blank.")
                .Length(0, 16).WithMessage("The Phone cannot be more than 16 characters.");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("The Gender cannot be blank.")
                .Length(0, 30).WithMessage("The Gender cannot be more than 30 characters.");
        }
    }
}
