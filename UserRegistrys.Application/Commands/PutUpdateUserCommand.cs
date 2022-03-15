using System.Text.Json.Serialization;

namespace UserRegistrys.Application.Commands
{
    public class PutUpdateUserCommand
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }
    }
}
