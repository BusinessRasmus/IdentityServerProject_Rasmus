using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace IdentityServerProject_Rasmus.Shared.Entities;

public class ShopProduct
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    [BsonElement("name")]
    [Required]
    public string Name { get; set; }

    [BsonElement("description")]
    [Required]
    public string Description { get; set; }

    [BsonElement("price")]
    [Required]
    public decimal Price { get; set; }

    [BsonElement("imageUrl")]
    [Required]
    public string ImageUrl { get; set; }

}