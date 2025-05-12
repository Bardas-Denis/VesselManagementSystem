namespace VesselManagementSystemAPI.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string OwnerName { get; set; }

        public ICollection<ShipOwner> ShipOwners { get; set; }
    }
}
