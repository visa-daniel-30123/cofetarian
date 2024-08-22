using ProiectCofetarie.Library.Models;
using System.Text.Json.Serialization;

namespace ProiectCofetarie
{
	public class Produs : IDatabaseTable
    {
	
		[JsonPropertyName ("denumireProd")]
        public string DenumireProd { get; set; }
        [JsonPropertyName("pret")]
        public int Pret { get; set; }
		[JsonPropertyName("cantitate")]
		public int Cantitate {get; set; }


		public void scadecant(int x)
		{
			this.Cantitate -= x;
		}
	}
}
