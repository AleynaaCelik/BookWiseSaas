using BookWiseSaas.Application.Common.Models.Dtos;
using BookWiseSaas.Application.Common.Models.Dtos.OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Common.Interfaces
{
    public interface IOpenAIService
    {
        Task<List<BookRecommendationDto>> GetBookRecommendationsAsync(OpenAIBookRecommendationRequestDto requestDto);
    }
}
