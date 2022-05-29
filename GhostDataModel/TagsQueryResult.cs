using System;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable enable

namespace GhostDataModel;

[Serializable]
public partial class TagsQueryResult
{
    [JsonPropertyName("tags")]
    public List<Tag> Tags { get; set; }
}
