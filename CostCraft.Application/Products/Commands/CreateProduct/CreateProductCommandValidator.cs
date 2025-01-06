using FluentValidation;

namespace CostCraft.Application.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.UnitsProduced).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.ProfitMarginPercentage).NotEmpty();
        RuleFor(x => x.Materials)
            .NotEmpty()
            .When(x => x.Labors == null || x.Labors.Count == 0);
        RuleFor(x => x.Labors)
            .NotEmpty()
            .When(x => x.Materials == null || x.Materials.Count == 0);
    }
}
