using System;
using System.ComponentModel.DataAnnotations;

namespace LogistikaApi.Model
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        public string LicensePlate { get; set; }
        public string Model { get; set; }

        public DateTime LastMaintenanceDate { get; set; }
        public DateTime NextMaintenanceDate { get; set; }
    }
}
