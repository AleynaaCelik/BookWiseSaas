using BookWiseSaas.Application.Common.Interfaces;
using BookWiseSaas.Application.Common.Models;
using BookWiseSaas.Application.Common.Models.Dtos.OpenAI;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommandHandler : IRequestHandler<OrderAddCommand, RecommendationResponse>
    {
        private readonly IOpenAIService _openAIService;

        public OrderAddCommandHandler(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        public async Task<RecommendationResponse> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
            // OpenAI DTO oluşturuluyor
            var openAIRequestDto = new OpenAIBookRecommendationRequestDto
            {
                UserPreferences = request.UserPreferences,
                Mood = request.Mood,
                MaxResults = request.MaxResults,
                Language = request.Language,
                PreviousReads = string.Join(", ", request.PreviouslyReadBooks),
                MinimumRating = request.MinimumRating
            };

            // OpenAI hizmeti ile kitap önerileri alınıyor
            var recommendations = await _openAIService.GetBookRecommendationsAsync(openAIRequestDto);

            // Yanıt oluşturuluyor
            return new RecommendationResponse
            {
                Recommendations = recommendations
            };
        }
    }
}
