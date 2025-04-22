using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace YoutubeApi.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithName("Id");
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
