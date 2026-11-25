using FluentValidation;
using TXCSwagger5._0.Models;

namespace TXCSwagger5._0.Validators
{
    public class ExpirySchemeByProductIdQueryValidator : AbstractValidator<ExpirySchemeByProductIdQuery>
    {
        public ExpirySchemeByProductIdQueryValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Continue;
            RuleFor(p => p.ProductId)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(1)
                .WithMessage("Invalid Product Id");
        }


    }
}
