using FluentValidation;
using MediatR;

namespace Restaurants.Application.Behaviors
{
    public class ValidationBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;
        public ValidationBehaviors(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator.Any())
            {
                var validationContext = new ValidationContext<TRequest>(request);
                var result = await Task.WhenAll(_validator.Select(v => v.ValidateAsync(validationContext, cancellationToken)));
                var failers = result.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failers.Count > 0)
                {
                    throw new ValidationException(failers);
                }
            }

            var response = await next();

            return response;
        }
    }
}
