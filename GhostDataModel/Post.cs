using System;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable enable

namespace GhostDataModel;

[Serializable]
public partial class Post
{
    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("html")]
    public string Html { get; set; }

    [JsonPropertyName("comment_id")]
    public string CommentId { get; set; }

    [JsonPropertyName("feature_image")]
    public string FeatureImage { get; set; }

    [JsonPropertyName("feature_image_alt")]
    public string? FeatureImageAlt { get; set; }

    [JsonPropertyName("feature_image_caption")]
    public string? FeatureImageCaption { get; set; }

    [JsonPropertyName("featured")]
    public bool Featured { get; set; }

    [JsonPropertyName("visibility")]
    public string Visibility { get; set; }

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTimeOffset UpdatedAt { get; set; }

    [JsonPropertyName("published_at")]
    public DateTimeOffset PublishedAt { get; set; }

    [JsonPropertyName("custom_excerpt")]
    public string? CustomExcerpt { get; set; }

    [JsonPropertyName("codeinjection_head")]
    public string? CodeinjectionHead { get; set; }

    [JsonPropertyName("codeinjection_foot")]
    public string? CodeinjectionFoot { get; set; }

    [JsonPropertyName("custom_template")]
    public string? CustomTemplate { get; set; }

    [JsonPropertyName("canonical_url")]
    public string? CanonicalUrl { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("excerpt")]
    public string Excerpt { get; set; }

    [JsonPropertyName("reading_time")]
    public int ReadingTime { get; set; }

    [JsonPropertyName("access")]
    public bool Access { get; set; }

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

    [JsonPropertyName("meta_title")]
    public string? MetaTitle { get; set; }

    [JsonPropertyName("meta_description")]
    public string? MetaDescription { get; set; }

    [JsonPropertyName("email_subject")]
    public string? EmailSubject { get; set; }

#region optional elements
    [JsonPropertyName("authors")]
    public List<Author>? Authors { get; set; }

    [JsonPropertyName("tags")]
    public List<Tag>? Tags { get; set; }

    [JsonPropertyName("primary_author")]
    public Author? PrimaryAuthor { get; set; }

    [JsonPropertyName("primary_tag")]
    public Tag? PrimaryTag { get; set; }
#endregion

}
