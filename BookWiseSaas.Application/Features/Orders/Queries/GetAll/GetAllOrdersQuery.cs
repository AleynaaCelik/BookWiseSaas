using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Features.Orders.Queries.GetAll
{
    public class GetAllOrdersQuery : IRequest<List<OrderGetAllDto>>
    {
    }
}
