using System.ComponentModel.DataAnnotations.Schema;

namespace VesselManagementSystemAPI.Models
{
    public class Owner
    {
        [Column("Owner_Id")]
        public int Id { get; set; }

        [Column("Owner_name")]
        public string OwnerName { get; set; }

        public ICollection<ShipOwner> ShipOwners { get; set; }
    }
}
