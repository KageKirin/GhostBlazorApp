using GhostDataModel;

using System;
using System.Diagnostics;
using System.Text.Json;
using NUnit.Framework;

namespace GhostDataModel.Tests;

public class TagsQueryResultUnitTests
{
    string testJson =
        @"
{
    ""tags"": [
        {
            ""slug"": ""getting-started"",
            ""id"": ""5ddc9063c35e7700383b27e0"",
            ""name"": ""Getting Started"",
            ""description"": null,
            ""feature_image"": null,
            ""visibility"": ""public"",
            ""meta_title"": null,
            ""meta_description"": null,
            ""og_image"": null,
            ""og_title"": null,
            ""og_description"": null,
            ""twitter_image"": null,
            ""twitter_title"": null,
            ""twitter_description"": null,
            ""codeinjection_head"": null,
            ""codeinjection_foot"": null,
            ""canonical_url"": null,
            ""accent_color"": null,
            ""url"": ""https://docs.ghost.io/tag/getting-started/""
        }
    ]
}
";

    [SetUp]
    public void Setup() { }

    [Test]
    public void TestJson()
    {
        var tagsQueryResult = JsonSerializer.Deserialize<TagsQueryResult>(
            testJson,
            new JsonSerializerOptions() { }
        );
        Assert.NotNull(tagsQueryResult);
        TestContext.Progress.WriteLine(
            $"{tagsQueryResult} {JsonSerializer.Serialize<TagsQueryResult>(tagsQueryResult)}"
        );

        var tag = tagsQueryResult.Tags[0];
        Assert.That(tag.Slug, Is.EqualTo("getting-started"));
        Assert.That(tag.Id, Is.EqualTo("5ddc9063c35e7700383b27e0"));
        Assert.That(tag.Name, Is.EqualTo("Getting Started"));
        Assert.That(tag.Visibility, Is.EqualTo("public"));
        Assert.That(tag.Url, Is.EqualTo("https://docs.ghost.io/tag/getting-started/"));
    }
}
