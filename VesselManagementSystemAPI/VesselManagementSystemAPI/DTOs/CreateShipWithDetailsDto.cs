namespace VesselManagementSystemAPI.DTOs
{
    public class CreateShipWithDetailsDto
    {
        public string ShipName { get; set; }
        public long ImoNumber { get; set; }
        // Category
        public string ShipType { get; set; }
        public long ShipTonnage { get; set; }

        // Owner IDs to link to
        public List<int> OwnerIds { get; set; }
    }
}
