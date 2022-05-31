using FluentValidation;
using SimpleCQRSApp.Application.Commands.Product;

namespace SimpleCQRSApp.Application.Validators
{
    public sealed class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Alias).NotEmpty();
        }
    }
}
