namespace VesselManagementSystemAPI.DTOs
{
    public class UpdateShipDto
    {
        public string ShipName { get; set; }
        public string ImoNumber { get; set; }
        // Category
        public string ShipType { get; set; }
        public long ShipTonnage { get; set; }
        public List<int> OwnerIds { get; set; }
    }
}
