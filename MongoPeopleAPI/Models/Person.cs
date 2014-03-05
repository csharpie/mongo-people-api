namespace MongoPeopleAPI.Models
{
    using System.Collections.Generic;
    using MongoDB.Bson.Serialization.Attributes;
    using Newtonsoft.Json;

    public class Person : MongoEntity
    {
        [BsonIgnoreIfNull]
        [BsonElement("first_name", Order = 2)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "firstName")] //Should be snake-case eg. first_name
        public string FirstName { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("last_name", Order = 3)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "lastName")]
        public string LastName { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("activities", Order = 4)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "activities")]
        public List<string> Activities { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("favorite_hobby", Order = 5)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "favoriteHobby")]
        public string FavoriteHobby { get; set; }

        public Person()
        {
            Activities = null;
        }
    }
}