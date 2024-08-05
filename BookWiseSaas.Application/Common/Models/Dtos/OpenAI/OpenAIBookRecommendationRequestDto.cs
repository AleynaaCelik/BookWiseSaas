using BookWiseSaas.Application.Features.Orders.Commands.Add;
using System;

namespace BookWiseSaas.Application.Common.Models.Dtos.OpenAI
{
    public class OpenAIBookRecommendationRequestDto
    {
        public string UserPreferences { get; set; } // Kullanıcının kitap tercihleri veya ilgi alanları
        public string Mood { get; set; }            // Kullanıcının o anki ruh hali, örneğin "neşeli", "hüzünlü"
        public int MaxResults { get; set; }         // Önerilecek kitap sayısı
        public string Language { get; set; }        // Kitap dili, örneğin "Türkçe", "İngilizce"
        public string PreviousReads { get; set; }   // Kullanıcının daha önce okuduğu kitaplar, OpenAI'yi bilgilendirmek için
        public int MinimumRating { get; set; }      // Önerilecek kitapların minimum kullanıcı puanı

        public static OpenAIBookRecommendationRequestDto MapFromOrderAddCommand(OrderAddCommand orderAddCommand)
        {
            return new OpenAIBookRecommendationRequestDto
            {
                UserPreferences = orderAddCommand.UserPreferences,
                Mood = orderAddCommand.Mood,
                MaxResults = orderAddCommand.MaxResults,
                Language = orderAddCommand.Language,
                PreviousReads = string.Join(", ", orderAddCommand.PreviouslyReadBooks),
                MinimumRating = orderAddCommand.MinimumRating
            };
        }
    }
}
