using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommandValidator : AbstractValidator<OrderDeleteCommand>
    {
        public OrderDeleteCommandValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("OrderId cannot be empty.");
        }
    }
}
