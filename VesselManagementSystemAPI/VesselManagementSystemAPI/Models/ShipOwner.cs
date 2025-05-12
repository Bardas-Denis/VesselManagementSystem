using System.ComponentModel.DataAnnotations.Schema;

namespace VesselManagementSystemAPI.Models
{
    public class ShipOwner
    {
        [Column("Ship_Id")]
        public int ShipId { get; set; }
        public Ship Ship { get; set; }

        [Column("Owner_Id")]
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
