using System.Text.Json.Serialization;

namespace UserRegistrys.Application.Commands
{
    public class DeleteUserCommand
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
