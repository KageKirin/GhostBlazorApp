using System;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable enable

namespace GhostDataModel;

[Serializable]
public partial class AuthorsQueryResult
{
    [JsonPropertyName("authors")]
    public List<Author> Authors { get; set; }
}
