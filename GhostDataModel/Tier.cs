using System;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable enable

namespace GhostDataModel;

[Serializable]
public partial class Tier
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } //TODO: enum

    [JsonPropertyName("welcome_page_url")]
    public string? WelcomePageUrl { get; set; } //TODO: url

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTimeOffset UpdatedAt { get; set; }

    [JsonPropertyName("stripe_prices")]
    public List<string>? StripePrices { get; set; }

    [JsonPropertyName("monthly_price")]
    public int? MonthlyPrice { get; set; }

    [JsonPropertyName("yearly_price")]
    public int? YearlyPrice { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; } //TODO: enum

    [JsonPropertyName("benefits")]
    public List<string>? Benefits { get; set; }

    [JsonPropertyName("visibility")]
    public string Visibility { get; set; } // TODO: enum
}
