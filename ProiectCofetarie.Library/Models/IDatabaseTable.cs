using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProiectCofetarie.Library.Models
{
    public class IDatabaseTable
    {
        [JsonPropertyName("id")] //am auzit ca dai o bere 5l de bere dau asa bun ce mai trb facut? am vrut sa se salveze emailu si data cand dai comanda
        public int Id { get; set; }
    }
}
