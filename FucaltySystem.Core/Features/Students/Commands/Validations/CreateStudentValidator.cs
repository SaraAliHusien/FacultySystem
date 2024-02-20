
//using Faculty.Core.SharedResources;
//using Faculty.Service.Abstruction;
using FacultySystem.Core.Features.Students.Commands.Modals;
using FacultySystem.Service.Abstruction;
using FluentValidation;
//using Microsoft.Extensions.Localization;

namespace FacultySystem.Core.Features.Students.Commands.Validations
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        //private readonly IStringLocalizer<SharedResource> _localizerString;

        #endregion

        #region ctors
        public CreateStudentValidator(IStudentService studentService)
        //  IStringLocalizer<SharedResource> localizerString
        {
            _studentService = studentService;
            //_localizerString = localizerString;
            ApplayValidationRules();
            ApplayCustomValidationRules();

        }
        #endregion

        #region Methods
        public void ApplayValidationRules()
        {

            RuleFor(x => x.StudentName).NotEmpty().WithMessage("Student Name is required.").
                                        NotNull().WithMessage("Student Name is required.").
                                        MaximumLength(250).WithMessage("Student Name must not be grater than 250 char").
                                        MinimumLength(7).WithMessage("Student Name must not be less than 7 char");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Student Name is required.").
                                    NotNull().
                                    MaximumLength(250).WithMessage("Student Address must not be grater than 250 char").
                                    MinimumLength(4).WithMessage("Student Name must not be less than 4 char");
        }
        public void ApplayCustomValidationRules()
        {
            RuleFor(x => x.StudentName).MustAsync(async (Key, CancellationToken) => await _studentService.IsUnique(Key)).WithMessage("This name is already exist");
        }
        #endregion
    }
}
