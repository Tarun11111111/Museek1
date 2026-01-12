using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Museek.Services
{
    public class LastFmClient
    {
        private readonly HttpClient _http;
        private readonly IMemoryCache _cache;
        private readonly string _apiKey;

        private const string BaseUrl = "https://ws.audioscrobbler.com/2.0/";

        public LastFmClient(HttpClient http, IMemoryCache cache, IConfiguration config)
        {
            _http = http;
            _cache = cache;
            _apiKey = config["LastFm:ApiKey"] ?? "";
        }

        public async Task<List<string>> SearchArtistsAsync(string query, int limit = 8)
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
                throw new InvalidOperationException("LastFm:ApiKey is missing.");

            query = (query ?? "").Trim();
            if (query.Length < 2) return new();

            var cacheKey = $"lastfm_search::{query.ToLowerInvariant()}::{limit}";
            if (_cache.TryGetValue(cacheKey, out List<string>? cached) && cached != null)
                return cached;

            var url =
                $"{BaseUrl}?method=artist.search" +
                $"&artist={WebUtility.UrlEncode(query)}" +
                $"&api_key={WebUtility.UrlEncode(_apiKey)}" +
                $"&format=json" +
                $"&limit={limit}";

            using var resp = await _http.GetAsync(url);
            resp.EnsureSuccessStatusCode();

            var json = await resp.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            var results = new List<string>();

            if (doc.RootElement.TryGetProperty("results", out var resultsEl) &&
                resultsEl.TryGetProperty("artistmatches", out var matchesEl) &&
                matchesEl.TryGetProperty("artist", out var artistEl))
            {
                if (artistEl.ValueKind == JsonValueKind.Array)
                {
                    foreach (var a in artistEl.EnumerateArray())
                    {
                        var name = a.TryGetProperty("name", out var nameEl) ? nameEl.GetString() : null;
                        if (!string.IsNullOrWhiteSpace(name))
                            results.Add(name!);
                    }
                }
                else if (artistEl.ValueKind == JsonValueKind.Object)
                {
                    var name = artistEl.TryGetProperty("name", out var nameEl) ? nameEl.GetString() : null;
                    if (!string.IsNullOrWhiteSpace(name))
                        results.Add(name!);
                }
            }

            _cache.Set(cacheKey, results, TimeSpan.FromMinutes(10));
            return results;
        }

        public async Task<LastFmArtistInfo?> GetArtistInfoAsync(string artistName)
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
                throw new InvalidOperationException("LastFm:ApiKey is missing.");

            artistName = (artistName ?? "").Trim();
            if (artistName.Length == 0) return null;

            var cacheKey = $"lastfm_info::{artistName.ToLowerInvariant()}";
            if (_cache.TryGetValue(cacheKey, out LastFmArtistInfo? cached) && cached != null)
                return cached;

            var url =
                $"{BaseUrl}?method=artist.getinfo" +
                $"&artist={WebUtility.UrlEncode(artistName)}" +
                $"&api_key={WebUtility.UrlEncode(_apiKey)}" +
                $"&format=json" +
                $"&autocorrect=1";

            using var resp = await _http.GetAsync(url);
            resp.EnsureSuccessStatusCode();

            var json = await resp.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            if (!doc.RootElement.TryGetProperty("artist", out var artistEl))
                return null;

            var name = artistEl.TryGetProperty("name", out var nameEl) ? nameEl.GetString() : null;

            string? bio = null;
            if (artistEl.TryGetProperty("bio", out var bioEl) &&
                bioEl.TryGetProperty("summary", out var summaryEl))
            {
                bio = summaryEl.GetString();
                if (!string.IsNullOrWhiteSpace(bio))
                {
                    var idx = bio.IndexOf("<a href=", StringComparison.OrdinalIgnoreCase);
                    if (idx >= 0) bio = bio.Substring(0, idx).Trim();
                }
            }

            var info = new LastFmArtistInfo
            {
                Name = name ?? artistName,
                Bio = bio
            };

            _cache.Set(cacheKey, info, TimeSpan.FromMinutes(30));
            return info;
        }
    }

    public class LastFmArtistInfo
    {
        public string Name { get; set; } = "";
        public string? Bio { get; set; }
    }
}
