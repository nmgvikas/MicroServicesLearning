using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Ng.WebApi.MongoDb.RabbitMQ.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _Id { get; set; }
        [Required]
        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("customerSince")]
        public DateTime CustomerSince { get; set; }
        [BsonElement("totalPurchases")]
        public double TotalPurchases { get; set; }
        [Required]
        [BsonElement("location")]
        public string Location { get; set; }

    }
}
