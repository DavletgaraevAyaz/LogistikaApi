using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogistikaApi.Model
{
    public class ProductMovement
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int WarehouseId { get; set; }
        [ForeignKey("WarehouseId")]
        public Warehouse Warehouse { get; set; }

        public int MovementTypeId { get; set; }
        [ForeignKey("MovementTypeId")]
        public MovementType MovementType { get; set; }

        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
    }

}
