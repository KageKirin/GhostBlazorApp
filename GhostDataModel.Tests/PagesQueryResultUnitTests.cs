using GhostDataModel;

using System;
using System.Diagnostics;
using System.Text.Json;
using NUnit.Framework;

namespace GhostDataModel.Tests;

public class PagesQueryResultUnitTests
{
    string testJson =
        @"
{
    ""pages"": [
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
        var pagesQueryResult = JsonSerializer.Deserialize<PagesQueryResult>(
            testJson,
            new JsonSerializerOptions() { }
        );
        Assert.NotNull(pagesQueryResult);
        TestContext.Progress.WriteLine(
            $"{pagesQueryResult} {JsonSerializer.Serialize<PagesQueryResult>(pagesQueryResult)}"
        );

        Assert.NotNull(pagesQueryResult.Pages);
        Assert.That(pagesQueryResult.Pages.Count, Is.EqualTo(1));

        var page = pagesQueryResult.Pages[0];
        Assert.That(page.Slug, Is.EqualTo("welcome-short"));
        Assert.That(page.Id, Is.EqualTo("5c7ece47da174000c0c5c6d7"));
        Assert.That(page.Uuid, Is.EqualTo("3a033ce7-9e2d-4b3b-a9ef-76887efacc7f"));
        Assert.That(page.Title, Is.EqualTo("Welcome"));
        Assert.That(page.Html, Is.EqualTo("<p>👋 Welcome, it's great to have you here.</p>"));
        Assert.That(page.CommentId, Is.EqualTo("5c7ece47da174000c0c5c6d7"));
        Assert.That(
            page.FeatureImage,
            Is.EqualTo("https://casper.ghost.org/v2.0.0/images/welcome-to-ghost.jpg")
        );
        Assert.That(page.Featured, Is.EqualTo(false));
        Assert.That(
            page.CreatedAt,
            Is.EqualTo(DateTimeOffset.Parse("2019-03-05T19:30:15.000+00:00"))
        );
        Assert.That(
            page.UpdatedAt,
            Is.EqualTo(DateTimeOffset.Parse("2019-03-26T19:45:31.000+00:00"))
        );
        Assert.That(
            page.PublishedAt,
            Is.EqualTo(DateTimeOffset.Parse("2012-11-27T15:30:00.000+00:00"))
        );
        Assert.That(page.CustomExcerpt, Is.EqualTo("Welcome, it's great to have you here."));
        Assert.That(page.Url, Is.EqualTo("https://demo.ghost.io/welcome-short/"));
        Assert.That(page.Excerpt, Is.EqualTo("Welcome, it's great to have you here."));

        Assert.NotNull(page.Authors);
        Assert.That(page.Authors.Count, Is.EqualTo(1));
        Assert.NotNull(page.Tags);
        Assert.That(page.Tags.Count, Is.EqualTo(1));

        Assert.NotNull(page.PrimaryAuthor);
        Assert.NotNull(page.PrimaryTag);

        Assert.That(page.Authors[0].Id, Is.EqualTo("5951f5fca366002ebd5dbef7"));
        Assert.That(page.Authors[0].Name, Is.EqualTo("Ghost"));
        Assert.That(page.Authors[0].Slug, Is.EqualTo("ghost"));
        Assert.That(
            page.Authors[0].ProfileImage,
            Is.EqualTo("https://demo.ghost.io/content/images/2017/07/ghost-icon.png")
        );
        Assert.That(page.Authors[0].Bio, Is.EqualTo("The professional publishing platform"));
        Assert.That(page.Authors[0].Website, Is.EqualTo("https://ghost.org"));
        Assert.That(page.Authors[0].Facebook, Is.EqualTo("ghost"));
        Assert.That(page.Authors[0].Twitter, Is.EqualTo("@tryghost"));
        Assert.That(page.Authors[0].Url, Is.EqualTo("https://demo.ghost.io/author/ghost/"));

        Assert.That(page.PrimaryAuthor.Id, Is.EqualTo("5951f5fca366002ebd5dbef7"));
        Assert.That(page.PrimaryAuthor.Name, Is.EqualTo("Ghost"));
        Assert.That(page.PrimaryAuthor.Slug, Is.EqualTo("ghost"));
        Assert.That(
            page.PrimaryAuthor.ProfileImage,
            Is.EqualTo("https://demo.ghost.io/content/images/2017/07/ghost-icon.png")
        );
        Assert.That(page.PrimaryAuthor.Bio, Is.EqualTo("The professional publishing platform"));
        Assert.That(page.PrimaryAuthor.Website, Is.EqualTo("https://ghost.org"));
        Assert.That(page.PrimaryAuthor.Facebook, Is.EqualTo("ghost"));
        Assert.That(page.PrimaryAuthor.Twitter, Is.EqualTo("@tryghost"));
        Assert.That(page.PrimaryAuthor.Url, Is.EqualTo("https://demo.ghost.io/author/ghost/"));

        Assert.That(page.Tags[0].Id, Is.EqualTo("59799bbd6ebb2f00243a33db"));
        Assert.That(page.Tags[0].Name, Is.EqualTo("Getting Started"));
        Assert.That(page.Tags[0].Slug, Is.EqualTo("getting-started"));
        Assert.That(page.Tags[0].Visibility, Is.EqualTo("public"));
        Assert.That(page.Tags[0].Url, Is.EqualTo("https://demo.ghost.io/tag/getting-started/"));

        Assert.That(page.PrimaryTag.Id, Is.EqualTo("59799bbd6ebb2f00243a33db"));
        Assert.That(page.PrimaryTag.Name, Is.EqualTo("Getting Started"));
        Assert.That(page.PrimaryTag.Slug, Is.EqualTo("getting-started"));
        Assert.That(page.PrimaryTag.Visibility, Is.EqualTo("public"));
        Assert.That(page.PrimaryTag.Url, Is.EqualTo("https://demo.ghost.io/tag/getting-started/"));
    }
}
