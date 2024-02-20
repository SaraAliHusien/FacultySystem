
using FacultySystem.Core.Features.Students.Commands.Models;
using FacultySystem.Service.Abstruction;
using FluentValidation;

namespace Faculty.Core.Fratures.Students.Commands.Validations
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        #endregion

        #region ctors
        public EditStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
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
            RuleFor(x => x.StudentName).MustAsync(async (model, Key, CancellationToken) => await _studentService.IsUnique(Key, model.StId)).WithMessage("This name already exist");
        }
        #endregion
    }

}
