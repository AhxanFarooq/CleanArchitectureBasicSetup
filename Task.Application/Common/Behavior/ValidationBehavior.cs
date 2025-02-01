using ErrorOr;
using FluentValidation;
using MediatR;

namespace Dinner.Application.Common.Behavior{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? _validators;

        public ValidationBehavior(IValidator<TRequest>? validators = null)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validators == null)
            {
                return await next();
            }
            var result = await _validators.ValidateAsync(request);
            if(!result.IsValid)
            {
                var errors = result.Errors.ConvertAll(e => Error.Validation(e.PropertyName, e.ErrorMessage));
                return (dynamic)errors;
            }

            return await next();
        }
    }
}