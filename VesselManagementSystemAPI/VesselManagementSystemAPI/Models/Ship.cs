namespace VesselManagementSystemAPI.Models
{
    public class Ship
    {
        public int Id { get; set; }
        public string ShipName { get; set; }
        public string ImoNumber { get; set; }

       
        public Category Category { get; set; }
        public ICollection<ShipOwner> ShipOwners { get; set; }
    }
}
