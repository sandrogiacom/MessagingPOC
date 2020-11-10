using System.Text.Json.Serialization;

namespace MessagingPOC.Dto
{
    public class GroupCreateDTO
    {
        [JsonPropertyName("objectGuid")]
        public string ObjectGuid { get; set; }
        [JsonPropertyName("samAccountName")]
        public string SamAccountName { get; set; }
        [JsonPropertyName("distinguishedName")]
        public string DistinguishedName { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("lastAdChangeMillis")]
        public long LastAdChangeMillis { get; set; }
        [JsonPropertyName("adGroupScope")]
        public string GroupScope { get; set; }
        [JsonPropertyName("adGroupType")]
        public string GroupType { get; set; }
    }
}
