using GhostDataModel;

using System;
using System.Diagnostics;
using System.Text.Json;
using NUnit.Framework;

namespace GhostDataModel.Tests;

public class PostsQueryResultUnitTests
{
    string testJson =
        @"
{
    ""posts"": [
        {
            ""slug"": ""welcome-short"",
            ""id"": ""5c7ece47da174000c0c5c6d7"",
            ""uuid"": ""3a033ce7-9e2d-4b3b-a9ef-76887efacc7f"",
            ""title"": ""Welcome"",
            ""html"": ""<p>👋 Welcome, it's great to have you here.</p>"",
            ""comment_id"": ""5c7ece47da174000c0c5c6d7"",
            ""feature_image"": ""https://casper.ghost.org/v2.0.0/images/welcome-to-ghost.jpg"",
            ""feature_image_alt"": null,
            ""feature_image_caption"": null,
            ""featured"": false,
            ""meta_title"": null,
            ""meta_description"": null,
            ""created_at"": ""2019-03-05T19:30:15.000+00:00"",
            ""updated_at"": ""2019-03-26T19:45:31.000+00:00"",
            ""published_at"": ""2012-11-27T15:30:00.000+00:00"",
            ""custom_excerpt"": ""Welcome, it's great to have you here."",
            ""codeinjection_head"": null,
            ""codeinjection_foot"": null,
            ""og_image"": null,
            ""og_title"": null,
            ""og_description"": null,
            ""twitter_image"": null,
            ""twitter_title"": null,
            ""twitter_description"": null,
            ""custom_template"": null,
            ""canonical_url"": null,
            ""authors"": [
                {
                    ""id"": ""5951f5fca366002ebd5dbef7"",
                    ""name"": ""Ghost"",
                    ""slug"": ""ghost"",
                    ""profile_image"": ""https://demo.ghost.io/content/images/2017/07/ghost-icon.png"",
                    ""cover_image"": null,
                    ""bio"": ""The professional publishing platform"",
                    ""website"": ""https://ghost.org"",
                    ""location"": null,
                    ""facebook"": ""ghost"",
                    ""twitter"": ""@tryghost"",
                    ""meta_title"": null,
                    ""meta_description"": null,
                    ""url"": ""https://demo.ghost.io/author/ghost/""
                }
            ],
            ""tags"": [
                {
                    ""id"": ""59799bbd6ebb2f00243a33db"",
                    ""name"": ""Getting Started"",
                    ""slug"": ""getting-started"",
                    ""description"": null,
                    ""feature_image"": null,
                    ""visibility"": ""public"",
                    ""meta_title"": null,
                    ""meta_description"": null,
                    ""url"": ""https://demo.ghost.io/tag/getting-started/""
                }
            ],
            ""primary_author"": {
                ""id"": ""5951f5fca366002ebd5dbef7"",
                ""name"": ""Ghost"",
                ""slug"": ""ghost"",
                ""profile_image"": ""https://demo.ghost.io/content/images/2017/07/ghost-icon.png"",
                ""cover_image"": null,
                ""bio"": ""The professional publishing platform"",
                ""website"": ""https://ghost.org"",
                ""location"": null,
                ""facebook"": ""ghost"",
                ""twitter"": ""@tryghost"",
                ""meta_title"": null,
                ""meta_description"": null,
                ""url"": ""https://demo.ghost.io/author/ghost/""
            },
            ""primary_tag"": {
                ""id"": ""59799bbd6ebb2f00243a33db"",
                ""name"": ""Getting Started"",
                ""slug"": ""getting-started"",
                ""description"": null,
                ""feature_image"": null,
                ""visibility"": ""public"",
                ""meta_title"": null,
                ""meta_description"": null,
                ""url"": ""https://demo.ghost.io/tag/getting-started/""
            },
            ""url"": ""https://demo.ghost.io/welcome-short/"",
            ""excerpt"": ""Welcome, it's great to have you here.""
        }
    ]
}
";

    [SetUp]
    public void Setup() { }

    [Test]
    public void TestJson()
    {
        var postsQueryResult = JsonSerializer.Deserialize<PostsQueryResult>(
            testJson,
            new JsonSerializerOptions() { }
        );
        Assert.NotNull(postsQueryResult);
        TestContext.Progress.WriteLine(
            $"{postsQueryResult} {JsonSerializer.Serialize<PostsQueryResult>(postsQueryResult)}"
        );
        Assert.NotNull(postsQueryResult.Posts);
        Assert.That(postsQueryResult.Posts.Count, Is.EqualTo(1));

        var post = postsQueryResult.Posts[0];
        Assert.That(post.Slug, Is.EqualTo("welcome-short"));
        Assert.That(post.Id, Is.EqualTo("5c7ece47da174000c0c5c6d7"));
        Assert.That(post.Uuid, Is.EqualTo("3a033ce7-9e2d-4b3b-a9ef-76887efacc7f"));
        Assert.That(post.Title, Is.EqualTo("Welcome"));
        Assert.That(post.Html, Is.EqualTo("<p>👋 Welcome, it's great to have you here.</p>"));
        Assert.That(post.CommentId, Is.EqualTo("5c7ece47da174000c0c5c6d7"));
        Assert.That(
            post.FeatureImage,
            Is.EqualTo("https://casper.ghost.org/v2.0.0/images/welcome-to-ghost.jpg")
        );
        Assert.That(post.Featured, Is.EqualTo(false));
        Assert.That(
            post.CreatedAt,
            Is.EqualTo(DateTimeOffset.Parse("2019-03-05T19:30:15.000+00:00"))
        );
        Assert.That(
            post.UpdatedAt,
            Is.EqualTo(DateTimeOffset.Parse("2019-03-26T19:45:31.000+00:00"))
        );
        Assert.That(
            post.PublishedAt,
            Is.EqualTo(DateTimeOffset.Parse("2012-11-27T15:30:00.000+00:00"))
        );
        Assert.That(post.CustomExcerpt, Is.EqualTo("Welcome, it's great to have you here."));
        Assert.That(post.Url, Is.EqualTo("https://demo.ghost.io/welcome-short/"));
        Assert.That(post.Excerpt, Is.EqualTo("Welcome, it's great to have you here."));

        Assert.NotNull(post.Authors);
        Assert.That(post.Authors.Count, Is.EqualTo(1));
        Assert.NotNull(post.Tags);
        Assert.That(post.Tags.Count, Is.EqualTo(1));

        Assert.NotNull(post.PrimaryAuthor);
        Assert.NotNull(post.PrimaryTag);

        Assert.That(post.Authors[0].Id, Is.EqualTo("5951f5fca366002ebd5dbef7"));
        Assert.That(post.Authors[0].Name, Is.EqualTo("Ghost"));
        Assert.That(post.Authors[0].Slug, Is.EqualTo("ghost"));
        Assert.That(
            post.Authors[0].ProfileImage,
            Is.EqualTo("https://demo.ghost.io/content/images/2017/07/ghost-icon.png")
        );
        Assert.That(post.Authors[0].Bio, Is.EqualTo("The professional publishing platform"));
        Assert.That(post.Authors[0].Website, Is.EqualTo("https://ghost.org"));
        Assert.That(post.Authors[0].Facebook, Is.EqualTo("ghost"));
        Assert.That(post.Authors[0].Twitter, Is.EqualTo("@tryghost"));
        Assert.That(post.Authors[0].Url, Is.EqualTo("https://demo.ghost.io/author/ghost/"));

        Assert.That(post.PrimaryAuthor.Id, Is.EqualTo("5951f5fca366002ebd5dbef7"));
        Assert.That(post.PrimaryAuthor.Name, Is.EqualTo("Ghost"));
        Assert.That(post.PrimaryAuthor.Slug, Is.EqualTo("ghost"));
        Assert.That(
            post.PrimaryAuthor.ProfileImage,
            Is.EqualTo("https://demo.ghost.io/content/images/2017/07/ghost-icon.png")
        );
        Assert.That(post.PrimaryAuthor.Bio, Is.EqualTo("The professional publishing platform"));
        Assert.That(post.PrimaryAuthor.Website, Is.EqualTo("https://ghost.org"));
        Assert.That(post.PrimaryAuthor.Facebook, Is.EqualTo("ghost"));
        Assert.That(post.PrimaryAuthor.Twitter, Is.EqualTo("@tryghost"));
        Assert.That(post.PrimaryAuthor.Url, Is.EqualTo("https://demo.ghost.io/author/ghost/"));

        Assert.That(post.Tags[0].Id, Is.EqualTo("59799bbd6ebb2f00243a33db"));
        Assert.That(post.Tags[0].Name, Is.EqualTo("Getting Started"));
        Assert.That(post.Tags[0].Slug, Is.EqualTo("getting-started"));
        Assert.That(post.Tags[0].Visibility, Is.EqualTo("public"));
        Assert.That(post.Tags[0].Url, Is.EqualTo("https://demo.ghost.io/tag/getting-started/"));

        Assert.That(post.PrimaryTag.Id, Is.EqualTo("59799bbd6ebb2f00243a33db"));
        Assert.That(post.PrimaryTag.Name, Is.EqualTo("Getting Started"));
        Assert.That(post.PrimaryTag.Slug, Is.EqualTo("getting-started"));
        Assert.That(post.PrimaryTag.Visibility, Is.EqualTo("public"));
        Assert.That(post.PrimaryTag.Url, Is.EqualTo("https://demo.ghost.io/tag/getting-started/"));
    }
}
