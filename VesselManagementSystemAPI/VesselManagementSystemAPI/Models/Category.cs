using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VesselManagementSystemAPI.Models
{
    public class Category
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Ship_id")]
        public int ShipId { get; set; }

        [Column("Ship_type")]
        public string ShipType { get; set; }

        [Column("Ship_tonnage")]
        public long ShipTonnage { get; set; }

        [JsonIgnore]
        public Ship Ship { get; set; }
    }
}
