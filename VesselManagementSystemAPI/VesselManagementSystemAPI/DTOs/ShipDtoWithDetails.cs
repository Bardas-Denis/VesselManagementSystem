namespace VesselManagementSystemAPI.DTOs
{
    public class ShipDtoWithDetails
    {
        public int Id { get; set; }
        public string ShipName { get; set; }
        public long ImoNumber { get; set; }
        public string ShipType { get; set; }
        public long ShipTonnage { get; set; }
        public IEnumerable<OwnerDto> Owners { get; set; }
    }
}
