using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace NoteService.Models
{
    public class Note
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        //[BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set;}
    }
}
