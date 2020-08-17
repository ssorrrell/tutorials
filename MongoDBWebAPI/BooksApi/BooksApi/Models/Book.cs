using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksApi.Models
{
    public class Book
    {
        //In the preceding class, the Id property:
        //Is required for mapping the Common Language Runtime(CLR) object to the MongoDB collection.
        //Is annotated with[BsonId] to designate this property as the document's primary key.
        //Is annotated with[BsonRepresentation(BsonType.ObjectId)] to allow passing the parameter as type string instead of an ObjectId structure. Mongo handles the conversion from string to ObjectId.
  
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string BookName { get; set; }
        //The BookName property is annotated with the [BsonElement] attribute. The attribute's value of Name represents the property name in the MongoDB collection.

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}
