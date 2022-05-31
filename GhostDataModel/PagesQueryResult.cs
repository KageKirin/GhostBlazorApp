using System;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable enable

namespace GhostDataModel;

[Serializable]
public partial class PagesQueryResult
{
    [JsonPropertyName("pages")]
    public List<Post> Pages { get; set; }
}
