using BookWiseSaas.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommand : IRequest<RecommendationResponse>
    {
        public string UserPreferences { get; set; }
        public string Mood { get; set; }
        public int MaxResults { get; set; }
        public string Language { get; set; }
        public List<string> PreviouslyReadBooks { get; set; }
        public int MinimumRating { get; set; }
    }
}
