using CURS.Domain.Core.Models;
using CURS.Domain.Interfaces.Data.Documents;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CURS.Infrastructure.Data.Documents
{
    public class TitleDocument : IMongoDocument<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string ExtraCode { get; set; }
        public Name Name { get; set; }
    }
}