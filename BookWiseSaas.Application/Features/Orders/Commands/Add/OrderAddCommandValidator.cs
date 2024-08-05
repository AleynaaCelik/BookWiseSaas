using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommandValidator : AbstractValidator<OrderAddCommand>
    {
        public OrderAddCommandValidator()
        {
            RuleFor(x => x.UserPreferences).NotEmpty().WithMessage("User preferences cannot be empty.");
            RuleFor(x => x.Mood).NotEmpty().WithMessage("Mood cannot be empty.");
            RuleFor(x => x.MaxResults).GreaterThan(0).WithMessage("Max results must be greater than 0.");
            RuleFor(x => x.Language).NotEmpty().WithMessage("Language cannot be empty.");
            RuleFor(x => x.MinimumRating).InclusiveBetween(1, 5).WithMessage("Minimum rating must be between 1 and 5.");
        }
    }
}
