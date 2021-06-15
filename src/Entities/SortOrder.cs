using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Entities
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortOrder
    {
        [EnumMember(Value = "Guessed")]
        Guessed,
        [EnumMember(Value = "Selected")]
        Selected
    }
}
