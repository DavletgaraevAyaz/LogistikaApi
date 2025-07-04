using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogistikaApi.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string BatchNumber { get; set; }
        public int Quantity { get; set; }
        public string ExpirationDate { get; set; }
        public string StorageConditions { get; set; }
    }

}
