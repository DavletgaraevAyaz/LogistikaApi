namespace LogistikaApi.Request
{
    public class VehReq
    {
        public string LicensePlate { get; set; }
        public string Model { get; set; }

        public DateTime LastMaintenanceDate { get; set; }
        public DateTime NextMaintenanceDate { get; set; }
    }
}
