using BookWiseSaas.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Features.Orders.Commands.Update
{
    public class OrderUpdateCommandHandler : IRequestHandler<OrderUpdateCommand, bool>
    {
        private readonly IApplicationDbContext _dbContext;

        public OrderUpdateCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(OrderUpdateCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FindAsync(new object[] { request.OrderId }, cancellationToken);

            if (order == null)
                return false;

            // Sipariş detaylarını güncelleme
            order.UserPreferences = request.UserPreferences;
            order.Mood = request.Mood;
            order.MaxResults = request.MaxResults;
            order.Language = request.Language;
            order.PreviousReads = request.PreviousReads;
            order.MinimumRating = request.MinimumRating;

            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
