using ProiectCofetarie.Library.Models;
using System.Text.Json.Serialization;

namespace ProiectCofetarie
{
	public class IstoricComenzi : IDatabaseTable
	{
        [JsonPropertyName("email")]
        public string Emailclient { get; set; }
        [JsonPropertyName("data")]
        public string Data { get; set; }
        [JsonPropertyName("comanda")]
        public string Comanda { get; set; }
	}
}
