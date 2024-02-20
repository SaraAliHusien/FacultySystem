using FacultySystem.Core.Features.Instructors.Commands.Models;
using FacultySystem.Service.Abstruction;
using FluentValidation;

namespace FacultySystem.Core.Features.Instructors.Commands.Validations
{
    public class CreateInstructorValidator : AbstractValidator<CreateInstructorCommand>
    {
        #region Fields
        private readonly IInstructorService _instructorService;
        #endregion

        #region ctors
        public CreateInstructorValidator(IInstructorService instructorService)

        {
            _instructorService = instructorService;

            ApplayValidationRules();
            ApplayCustomValidationRules();

        }
        #endregion

        #region Methods
        public void ApplayValidationRules()
        {

            RuleFor(x => x.InstructorName).NotEmpty().WithMessage("Instructor Name is required.").
                                        NotNull().WithMessage("Instructor Name is required.").
                                        MaximumLength(250).WithMessage("Instructor Name must not be grater than 250 char").
                                        MinimumLength(7).WithMessage("Instructor Name must not be less than 7 char");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Instructor Name is required.").
                                    NotNull().
                                    MaximumLength(250).WithMessage("Instructor Address must not be grater than 250 char").
                                    MinimumLength(4).WithMessage("Instructor Adress must not be less than 4 char");
            RuleFor(x => x.Position).NotEmpty().WithMessage("Instructor Position is required.").
                                    NotNull().
                                    MaximumLength(250).WithMessage("Instructor Position must not be grater than 10 char").
                                    MinimumLength(4).WithMessage("Instructor Position must not be less than 2 char");
            RuleFor(x => x.Salary).NotEmpty().WithMessage("Instructor Salary is required.").
                                    NotNull().WithMessage("Instructor Salary is required.").GreaterThan(0);

            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Department Id is required.").
                               NotNull().WithMessage("Department Id is required.");

        }
        public void ApplayCustomValidationRules()
        {
            RuleFor(x => x.InstructorName).MustAsync(async (Key, CancellationToken) => await _instructorService.IsUnique(Key)).WithMessage("This name is already exist");
        }
        #endregion
    }
}

