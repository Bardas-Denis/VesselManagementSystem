namespace VesselManagementSystemAPI.Models
{
    public class ShipOwner
    {

        public int ShipId { get; set; }
        public Ship Ship { get; set; }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
