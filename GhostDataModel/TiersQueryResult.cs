using System;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable enable

namespace GhostDataModel;

[Serializable]
public partial class TiersQueryResult
{
    [JsonPropertyName("tiers")]
    public List<Tier> Tiers { get; set; }
}
