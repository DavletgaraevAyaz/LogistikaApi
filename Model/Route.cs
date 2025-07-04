using System;
using System.ComponentModel.DataAnnotations;

namespace LogistikaApi.Model
{
    public class Route
    {
        [Key]
        public int Id { get; set; }

        public string RouteName { get; set; }
        public DateTime PlannedDate { get; set; }
        public string Priority { get; set; }
    }
}
