using FluentValidation;
using MediatR;

namespace YoutubeApi.Application.Beheviors
{
    public class FluentValidationBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
         where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validator;

        public FluentValidationBehevior(IEnumerable<IValidator<TRequest>> validator)
        {
            this.validator = validator;
        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = validator
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .GroupBy(x => x.ErrorMessage)
                .Select(x => x.First())
                .Where(x => x is not null)
                .ToList();

            if (failures.Any())
                throw new ValidationException(failures);


            return next();
        }
    }
}
