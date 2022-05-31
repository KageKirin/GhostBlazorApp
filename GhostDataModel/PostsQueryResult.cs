using System;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable enable

namespace GhostDataModel;

[Serializable]
public partial class PostsQueryResult
{
    [JsonPropertyName("posts")]
    public List<Post> Posts { get; set; }
}
