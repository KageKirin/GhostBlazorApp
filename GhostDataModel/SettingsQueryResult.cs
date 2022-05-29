using System;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable enable

namespace GhostDataModel;

[Serializable]
public partial class SettingsQueryResult
{
    [JsonPropertyName("settings")]
    public Settings Settings { get; set; }
}
