using FacultySystem.Core.Features.Subjects.Commands.Models;
using FacultySystem.Service.Abstruction;
using FluentValidation;

namespace FacultySystem.Core.Features.Subjects.Commands.Validations
{
    public class CreateSubjectValidator : AbstractValidator<CreateSubjectCommand>
    {
        #region Fields
        private readonly ISubjectService _subjectService;
        #endregion

        #region ctors
        public CreateSubjectValidator(ISubjectService subjectService)
        //  IStringLocalizer<SharedResource> localizerString
        {
            _subjectService = subjectService;
            ApplayValidationRules();
            ApplayCustomValidationRules();

        }
        #endregion

        #region Methods
        public void ApplayValidationRules()
        {

            RuleFor(x => x.SubjectName).NotEmpty().WithMessage("Subject Name is required.").
                                        NotNull().WithMessage("Subject Name is required.").
                                        MaximumLength(20).WithMessage("Subject Name must not be grater than 20 char").
                                        MinimumLength(2).WithMessage("Subject Name must not be less than 2 char");
            RuleFor(x => x.Period).NotEmpty().WithMessage("Subject Period is required.").
                                        NotNull().WithMessage("Subject Period is required.");
        }
        public void ApplayCustomValidationRules()
        {
            RuleFor(x => x.SubjectName).MustAsync(async (Key, CancellationToken) => await _subjectService.IsUnique(Key)).WithMessage("This name is already exist");
        }
        #endregion
    }
}
