using FluentValidation;
using ZeroStack.DeviceCenter.Application.Commands.Projects;

namespace ZeroStack.DeviceCenter.Application.Validations.Projects
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(m => m.Name).NotNull().NotEmpty().Length(5, 20);
        }
    }
}
