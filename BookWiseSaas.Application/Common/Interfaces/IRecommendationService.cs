using BookWiseSaas.Application.Common.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Common.Interfaces
{
    public  interface IRecommendationService
    {
        Task<RecommendationDto> GetRecommendationByIdAsync(int id);
        Task<IEnumerable<RecommendationDto>> GetAllRecommendationsAsync();
        Task AddRecommendationAsync(RecommendationDto recommendationDto);
        Task UpdateRecommendationAsync(RecommendationDto recommendationDto);
        Task DeleteRecommendationAsync(int id);
    }
}
