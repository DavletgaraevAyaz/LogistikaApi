using System.ComponentModel.DataAnnotations;

namespace LogistikaApi.Model
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Location { get; set; }
    }
}
