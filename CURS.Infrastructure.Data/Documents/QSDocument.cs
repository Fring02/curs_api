using CURS.Domain.Core.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CURS.Infrastructure.Data.Documents
{
    public class QSDocument
    {

        [BsonId]
        public ObjectId Id { get; set; }
        public string ExtraCode { get; set; }
        public Name Name { get; set; }
    }
}