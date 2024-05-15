using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace IdentityServerProject_Rasmus.Shared.Entities;

public class UserCart
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    [BsonElement("userId")]
    [Required]
    public Guid UserId { get; set; }

    [BsonElement("shopProducts")]
    public List<ShopProduct> ShopProducts { get; set; }
}