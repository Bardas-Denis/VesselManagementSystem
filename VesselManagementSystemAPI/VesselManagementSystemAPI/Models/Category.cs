namespace VesselManagementSystemAPI.Models
{
    public class Category
    {
        public int Id { get; set; }

        public int ShipId { get; set; }

        public string ShipType { get; set; }
        public int ShipTonnage { get; set; }

        public Ship Ship { get; set; }
    }
}
