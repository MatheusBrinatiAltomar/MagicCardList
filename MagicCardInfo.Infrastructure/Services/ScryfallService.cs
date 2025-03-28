using System.Net.Http;
using System.Text.Json;
using MagicCardInfo.Domain.Models;
using MagicCardInfo.Domain.Services;

namespace MagicCardInfo.Infrastructure.Services
{
    public class ScryfallService : IScryfallService
    {
        private readonly HttpClient _httpClient;

        public ScryfallService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Card>> GetCardsAsync()
        {
            // The search is limited to Legendary Creature cards that exist in paper
            // which is another way to search for cards that can be your Commander in the Commander Format
            var response = await _httpClient.GetAsync($"https://api.scryfall.com/cards/search?q=t%3Alegendary+t%3Acreature+game%3Apaper");

            if (!response.IsSuccessStatusCode)
                return new List<Card>();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ScryfallResponse>(json);

            return result?.Data ?? new List<Card>();
        }
    }

    public class ScryfallResponse
    {
        public List<Card> Data { get; set; } = new();
    }
}
