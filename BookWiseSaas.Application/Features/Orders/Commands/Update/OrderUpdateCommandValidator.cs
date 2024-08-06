using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Features.Orders.Commands.Update
{
    public class OrderUpdateCommandValidator : AbstractValidator<OrderUpdateCommand>
    {
        public OrderUpdateCommandValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("OrderId cannot be empty.");

            RuleFor(x => x.UserPreferences)
                .NotEmpty().WithMessage("User preferences cannot be empty.");

            RuleFor(x => x.Mood)
                .NotEmpty().WithMessage("Mood cannot be empty.");

            RuleFor(x => x.MaxResults)
                .GreaterThan(0).WithMessage("MaxResults should be greater than 0.");

            RuleFor(x => x.Language)
                .NotEmpty().WithMessage("Language cannot be empty.");

            RuleFor(x => x.MinimumRating)
                .InclusiveBetween(0, 5).WithMessage("MinimumRating should be between 0 and 5.");
        }
    }
}
