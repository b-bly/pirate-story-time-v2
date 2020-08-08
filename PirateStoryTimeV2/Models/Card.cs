using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PirateStoryTimeV2.Models
{
    public class Card
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //[BsonElement("Name")]
        public string Type { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public bool SaveToPirateverse { get; set; }

        public string Username { get; set; }
    }
}