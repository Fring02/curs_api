using CURS.Domain.Core.Models;
using CURS.Domain.Interfaces.Data.Documents;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CURS.Infrastructure.Data.Documents
{
    public class StudentDocument : Student<ObjectId>, IMongoDocument<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}