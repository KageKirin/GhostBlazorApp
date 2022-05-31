using GhostDataModel;

using System;
using System.Diagnostics;
using System.Text.Json;
using NUnit.Framework;

namespace GhostDataModel.Tests;

public class TiersQueryResultUnitTests
{
    string testJson =
        @"
{
    ""tiers"": [
        {
            ""id"": ""62307cc71b4376a976734037"",
            ""name"": ""Free"",
            ""description"": null,
            ""slug"": ""free"",
            ""active"": true,
            ""type"": ""free"",
            ""welcome_page_url"": null,
            ""created_at"": ""2022-03-15T11:47:19.000Z"",
            ""updated_at"": ""2022-03-15T11:47:19.000Z"",
            ""stripe_prices"": null,
            ""benefits"": null,
            ""visibility"": ""public""
        },
        {
            ""id"": ""6230d7c8c62265c44f24a594"",
            ""name"": ""Gold"",
            ""description"": null,
            ""slug"": ""gold"",
            ""active"": true,
            ""type"": ""paid"",
            ""welcome_page_url"": ""/welcome-to-gold"",
            ""created_at"": ""2022-03-15T18:15:36.000Z"",
            ""updated_at"": ""2022-03-15T18:16:00.000Z"",
            ""stripe_prices"": null,
            ""benefits"": null,
            ""visibility"": ""public""
        }
    ]
}
";

    [SetUp]
    public void Setup() { }

    [Test]
    public void TestJson()
    {
        var tiersQueryResult = JsonSerializer.Deserialize<TiersQueryResult>(
            testJson,
            new JsonSerializerOptions() { }
        );
        Assert.NotNull(tiersQueryResult);
        TestContext.Progress.WriteLine(
            $"{tiersQueryResult} {JsonSerializer.Serialize<TiersQueryResult>(tiersQueryResult)}"
        );

        var tier = tiersQueryResult.Tiers[0];
        Assert.That(tier.Id, Is.EqualTo("62307cc71b4376a976734037"));
        Assert.That(tier.Name, Is.EqualTo("Free"));
        Assert.That(tier.Slug, Is.EqualTo("free"));
        Assert.That(tier.Active, Is.EqualTo(true));
        Assert.That(tier.Type, Is.EqualTo("free"));
        Assert.That(tier.CreatedAt, Is.EqualTo(DateTimeOffset.Parse("2022-03-15T11:47:19.000Z")));
        Assert.That(tier.UpdatedAt, Is.EqualTo(DateTimeOffset.Parse("2022-03-15T11:47:19.000Z")));
        Assert.That(tier.Visibility, Is.EqualTo("public"));
    }
}
