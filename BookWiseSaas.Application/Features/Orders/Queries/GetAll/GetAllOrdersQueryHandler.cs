using MediatR;
using BookWiseSaas.Application.Common.Interfaces;
using BookWiseSaas.Application.Common.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Features.Orders.Queries.GetAll
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderGetAllDto>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetAllOrdersQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OrderGetAllDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _dbContext.Orders
                .Include(o => o.Books)
                .Include(o => o.Recommendations)
                .Select(order => new OrderGetAllDto
                {
                    Id = order.Id,
                    UserId = order.UserId,
                    CreatedOn = order.CreatedOn,
                    Status = order.Status,
                    Description = order.Description,
                    Urls = order.Urls.ToList(),
                    Books = order.Books.Select(book => new BookDto
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Author = book.Author
                    }).ToList(),
                    Recommendations = order.Recommendations.Select(rec => new RecommendationDto
                    {
                        Id = rec.Id, // Id özelliği eklendi
                        UserId = rec.UserId,
                        RecommendedBooks = rec.RecommendedBooks.Select(b => new BookDto
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Author = b.Author
                        }).ToList(),
                        Reason = rec.Reason // Reason yerine RecommendationText kullanıyorsanız bunu güncelleyin
                    }).ToList()
                }).ToListAsync(cancellationToken);

            return orders;
        }
    }
}
