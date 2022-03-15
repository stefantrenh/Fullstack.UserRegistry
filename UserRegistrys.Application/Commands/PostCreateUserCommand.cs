using System.Text.Json.Serialization;

namespace UserRegistrys.Application.Commands
{
    public class PostCreateUserCommand
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }
    }
}
