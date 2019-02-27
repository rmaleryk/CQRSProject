using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CQRSProject.Core.Entities
{
    public class UserActivity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("distance")]
        public long Distance { get; set; }

        [BsonElement("steps")]
        public long Steps { get; set; }
        
        [BsonElement("date")]
        public DateTime Date { get; set; }

        public UserActivity(string id, string userId, long distance, long steps, DateTime date)
        {
            Id = id;
            UserId = userId;
            Distance = distance;
            Steps = steps;
            Date = date;
        }
    }
}