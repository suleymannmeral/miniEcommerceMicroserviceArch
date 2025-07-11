using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MiniEcommerce.Orders.WebAPI.Models
{
    public sealed class Order
    {
        public Order()
        {
            Id= Guid.NewGuid();
           
        }
        [BsonRepresentation(BsonType.String)]

        public Guid Id { get; set; }
        [BsonRepresentation(BsonType.String)]

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatAt { get; set; }


    }
}
