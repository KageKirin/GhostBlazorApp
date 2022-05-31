using GhostDataModel;

using System;
using System.Diagnostics;
using System.Text.Json;
using NUnit.Framework;

namespace GhostDataModel.Tests;

public class AuthorUnitTests
{
    string testJson =
        @"
{
    ""slug"": ""cameron"",
    ""id"": ""5ddc9b9510d8970038255d02"",
    ""name"": ""Cameron Almeida"",
    ""profile_image"": ""https://docs.ghost.io/content/images/2019/03/1c2f492a-a5d0-4d2d-b350-cdcdebc7e413.jpg"",
    ""cover_image"": null,
    ""bio"": ""Editor at large."",
    ""website"": ""https://example.com"",
    ""location"": ""Cape Town"",
    ""facebook"": ""example"",
    ""twitter"": ""@example"",
    ""meta_title"": null,
    ""meta_description"": null,
    ""url"": ""https://docs.ghost.io/author/cameron/""
}
";

    [SetUp]
    public void Setup() { }

    [Test]
    public void TestJson()
    {
        var author = JsonSerializer.Deserialize<Author>(testJson, new JsonSerializerOptions() { });
        Assert.NotNull(author);
        TestContext.Progress.WriteLine($"{author} {JsonSerializer.Serialize<Author>(author)}");

        Assert.That(author.Slug, Is.EqualTo("cameron"));
        Assert.That(author.Id, Is.EqualTo("5ddc9b9510d8970038255d02"));
        Assert.That(author.Name, Is.EqualTo("Cameron Almeida"));
        Assert.That(
            author.ProfileImage,
            Is.EqualTo(
                "https://docs.ghost.io/content/images/2019/03/1c2f492a-a5d0-4d2d-b350-cdcdebc7e413.jpg"
            )
        );
        Assert.That(author.Bio, Is.EqualTo("Editor at large."));
        Assert.That(author.Website, Is.EqualTo("https://example.com"));
        Assert.That(author.Location, Is.EqualTo("Cape Town"));
        Assert.That(author.Facebook, Is.EqualTo("example"));
        Assert.That(author.Twitter, Is.EqualTo("@example"));
        Assert.That(author.Url, Is.EqualTo("https://docs.ghost.io/author/cameron/"));
    }
}
