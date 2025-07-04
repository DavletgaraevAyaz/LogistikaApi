using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogistikaApi.Model
{
    public class MaintenanceRecord
    {
        [Key]
        public int Id { get; set; }

        public int VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
