using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Features.Orders.Commands.Update
{
    public class OrderUpdateCommand : IRequest<bool>
    {
        public Guid OrderId { get; set; }
        public string UserPreferences { get; set; }
        public string Mood { get; set; }
        public int MaxResults { get; set; }
        public string Language { get; set; }
        public string PreviousReads { get; set; }
        public int MinimumRating { get; set; }

        public OrderUpdateCommand(Guid orderId, string userPreferences, string mood, int maxResults, string language, string previousReads, int minimumRating)
        {
            OrderId = orderId;
            UserPreferences = userPreferences;
            Mood = mood;
            MaxResults = maxResults;
            Language = language;
            PreviousReads = previousReads;
            MinimumRating = minimumRating;
        }
    }
}
