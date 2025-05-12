using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VesselManagementSystemAPI.Models
{
    public class Ship
    {
        [Column("Ship_Id")]
        public int Id { get; set; }

        [Column("Ship_name")]
        public string ShipName { get; set; }

        [Column("Imo_number")]
        public long ImoNumber { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }
        public ICollection<ShipOwner> ShipOwners { get; set; }
    }
}
