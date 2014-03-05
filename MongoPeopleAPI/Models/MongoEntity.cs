namespace MongoPeopleAPI.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;
    using Newtonsoft.Json;

    public class MongoEntity : IMongoEntity
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator), Order = 1)]
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }
    }
}