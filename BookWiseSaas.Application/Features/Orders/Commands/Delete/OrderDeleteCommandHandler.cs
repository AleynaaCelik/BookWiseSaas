using BookWiseSaas.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommandHandler : IRequestHandler<OrderDeleteCommand, bool>
    {
        private readonly IApplicationDbContext _dbContext;

        public OrderDeleteCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async  Task<bool> Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FindAsync(new object[] { request.OrderId }, cancellationToken);

            if (order == null)
                return false;

            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
