using GhostDataModel;

using System;
using System.Diagnostics;
using System.Text.Json;
using NUnit.Framework;

namespace GhostDataModel.Tests;

public class SettingsQueryResultUnitTests
{
    string testJson =
        @"
{
    ""settings"": {
        ""title"": ""Ghost"",
        ""description"": ""The professional publishing platform"",
        ""logo"": ""https://docs.ghost.io/content/images/2014/09/Ghost-Transparent-for-DARK-BG.png"",
        ""icon"": ""https://docs.ghost.io/content/images/2017/07/favicon.png"",
        ""accent_color"": null,
        ""cover_image"": ""https://docs.ghost.io/content/images/2019/10/publication-cover.png"",
        ""facebook"": ""ghost"",
        ""twitter"": ""@tryghost"",
        ""lang"": ""en"",
        ""timezone"": ""Etc/UTC"",
        ""codeinjection_head"": null,
        ""codeinjection_foot"": ""<script src=\""//rum-static.pingdom.net/pa-5d8850cd3a70310008000482.js\"" async></script>"",
        ""navigation"": [
            {
                ""label"": ""Home"",
                ""url"": ""/""
            },
            {
                ""label"": ""About"",
                ""url"": ""/about/""
            },
            {
                ""label"": ""Getting Started"",
                ""url"": ""/tag/getting-started/""
            },
            {
                ""label"": ""Try Ghost"",
                ""url"": ""https://ghost.org""
            }
        ],
        ""secondary_navigation"": [],
        ""meta_title"": null,
        ""meta_description"": null,
        ""og_image"": null,
        ""og_title"": null,
        ""og_description"": null,
        ""twitter_image"": null,
        ""twitter_title"": null,
        ""twitter_description"": null,
        ""members_support_address"": ""noreply@docs.ghost.io"",
        ""url"": ""https://docs.ghost.io/""
    }
}
";

    [SetUp]
    public void Setup() { }

    [Test]
    public void TestJson()
    {
        var settingsQueryResult = JsonSerializer.Deserialize<SettingsQueryResult>(
            testJson,
            new JsonSerializerOptions() { }
        );
        Assert.NotNull(settingsQueryResult);
        TestContext.Progress.WriteLine(
            $"{settingsQueryResult} {JsonSerializer.Serialize<SettingsQueryResult>(settingsQueryResult)}"
        );

        var settings = settingsQueryResult.Settings;
        Assert.That(settings.Title, Is.EqualTo("Ghost"));
        Assert.That(settings.Description, Is.EqualTo("The professional publishing platform"));
        Assert.That(
            settings.Logo,
            Is.EqualTo(
                "https://docs.ghost.io/content/images/2014/09/Ghost-Transparent-for-DARK-BG.png"
            )
        );
        Assert.That(
            settings.Icon,
            Is.EqualTo("https://docs.ghost.io/content/images/2017/07/favicon.png")
        );
        Assert.That(
            settings.CoverImage,
            Is.EqualTo("https://docs.ghost.io/content/images/2019/10/publication-cover.png")
        );
        Assert.That(settings.Facebook, Is.EqualTo("ghost"));
        Assert.That(settings.Twitter, Is.EqualTo("@tryghost"));
        Assert.That(settings.Lang, Is.EqualTo("en"));
        Assert.That(settings.Timezone, Is.EqualTo("Etc/UTC"));
        Assert.That(
            settings.CodeinjectionFoot,
            Is.EqualTo(
                "<script src=\"//rum-static.pingdom.net/pa-5d8850cd3a70310008000482.js\" async></script>"
            )
        );
        Assert.That(settings.MembersSupportAddress, Is.EqualTo("noreply@docs.ghost.io"));
        Assert.That(settings.Url, Is.EqualTo("https://docs.ghost.io/"));

        Assert.That(settings.Navigation.Count, Is.EqualTo(4));
        Assert.That(settings.Navigation[0].Label, Is.EqualTo("Home"));
        Assert.That(settings.Navigation[0].Url, Is.EqualTo("/"));
        Assert.That(settings.Navigation[1].Label, Is.EqualTo("About"));
        Assert.That(settings.Navigation[1].Url, Is.EqualTo("/about/"));
        Assert.That(settings.Navigation[2].Label, Is.EqualTo("Getting Started"));
        Assert.That(settings.Navigation[2].Url, Is.EqualTo("/tag/getting-started/"));
        Assert.That(settings.Navigation[3].Label, Is.EqualTo("Try Ghost"));
        Assert.That(settings.Navigation[3].Url, Is.EqualTo("https://ghost.org"));
    }
}
