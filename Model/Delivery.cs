using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogistikaApi.Model
{
    public class Delivery
    {
        [Key]
        public int Id { get; set; }

        public int RouteId { get; set; }
        [ForeignKey("RouteId")]
        public Route Route { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public DateTime ScheduledDate { get; set; }
        public bool IsDelivered { get; set; }
    }
}
