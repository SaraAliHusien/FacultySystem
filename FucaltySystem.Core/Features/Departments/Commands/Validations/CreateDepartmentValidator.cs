using FacultySystem.Core.Features.Departments.Commands.Models;
using FacultySystem.Service.Abstruction;
using FluentValidation;

namespace FacultySystem.Core.Features.Departments.Commands.Validations
{
    public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentCommand>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        #endregion

        #region ctors
        public CreateDepartmentValidator(IDepartmentService departmentService)
        //  IStringLocalizer<SharedResource> localizerString
        {
            _departmentService = departmentService;
            //_localizerString = localizerString;
            ApplayValidationRules();
            ApplayCustomValidationRules();

        }
        #endregion

        #region Methods
        public void ApplayValidationRules()
        {

            RuleFor(x => x.DepartmentName).NotEmpty().WithMessage("Department Name is required.").
                                        NotNull().WithMessage("Department Name is required.").
                                        MaximumLength(20).WithMessage("Student Name must not be grater than 20 char").
                                        MinimumLength(2).WithMessage("Student Name must not be less than 2 char");
            RuleFor(x => x.ManagerId).NotEmpty().WithMessage("Manager ID is required.").
                                        NotNull().WithMessage("Manager ID is required.");
        }
        public void ApplayCustomValidationRules()
        {
            RuleFor(x => x.DepartmentName).MustAsync(async (Key, CancellationToken) => await _departmentService.IsUnique(Key)).WithMessage("This name is already exist");
        }
        #endregion
    }
}
