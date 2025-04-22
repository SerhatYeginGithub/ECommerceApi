using FluentValidation;

namespace YoutubeApi.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithName("Title");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithName("Description");
            RuleFor(x => x.BrandId)
                .GreaterThan(0)
            .WithName("Brand");
            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithName("Price");
            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .WithName("Categories")
                .Must(x => x.Any());



        }
    }
}
