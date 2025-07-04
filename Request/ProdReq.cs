namespace LogistikaApi.Request
{
    public class ProdReq
    {
        public string Name { get; set; }
        public string BatchNumber { get; set; }
        public int Quantity { get; set; }
        public string ExpirationDate { get; set; }
        public string StorageConditions { get; set; }
    }
}
