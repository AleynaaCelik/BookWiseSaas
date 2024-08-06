using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommand : IRequest<bool>
    {
        public Guid OrderId { get; set; }

        public OrderDeleteCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
