using System;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable enable

namespace GhostDataModel;

[Serializable]
public partial class Settings
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("logo")]
    public string Logo { get; set; } // TODO: url

    [JsonPropertyName("icon")]
    public string Icon { get; set; } // TODO: url

    [JsonPropertyName("accent_color")]
    public string? AccentColor { get; set; }

    [JsonPropertyName("cover_image")]
    public string CoverImage { get; set; } // TODO: url

    [JsonPropertyName("facebook")]
    public string Facebook { get; set; }

    [JsonPropertyName("twitter")]
    public string Twitter { get; set; }

    [JsonPropertyName("lang")]
    public string Lang { get; set; } //: "en" //TODO: enum

    [JsonPropertyName("timezone")]
    public string Timezone { get; set; } //: "Etc/UTC" //TODO: enum

    [JsonPropertyName("codeinjection_head")]
    public string? CodeinjectionHead { get; set; }

    [JsonPropertyName("codeinjection_foot")]
    public string? CodeinjectionFoot { get; set; }

    [JsonPropertyName("navigation")]
    public List<NavigationItem> Navigation { get; set; }

    [JsonPropertyName("secondary_navigation")]
    public List<NavigationItem> SecondaryNavigation { get; set; }

    [Serializable]
    public class NavigationItem
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; } //TODO: URL
    }

    [JsonPropertyName("meta_title")]
    public string? MetaTitle { get; set; }

    [JsonPropertyName("meta_description")]
    public string? MetaDescription { get; set; }

    [JsonPropertyName("og_image")]
    public string? OgImage { get; set; }

    [JsonPropertyName("og_title")]
    public string? OgTitle { get; set; }

    [JsonPropertyName("og_description")]
    public string? OgDescription { get; set; }

    [JsonPropertyName("twitter_image")]
    public string? TwitterImage { get; set; }

    [JsonPropertyName("twitter_title")]
    public string? TwitterTitle { get; set; }

    [JsonPropertyName("twitter_description")]
    public string? TwitterDescription { get; set; }

    [JsonPropertyName("members_support_address")] // TODO: email address
    public string MembersSupportAddress { get; set; }

    [JsonPropertyName("url")] // TODO: url
    public string Url { get; set; }
}
