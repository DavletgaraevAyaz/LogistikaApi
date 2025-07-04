using System.ComponentModel.DataAnnotations;

namespace LogistikaApi.Model
{
    public class MovementType
    {
        [Key]
        public int Id { get; set; }
        public string type { get; set; }
    }
}
