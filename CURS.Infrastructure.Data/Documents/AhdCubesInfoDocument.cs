using System.Collections.Generic;
using CURS.Domain.Core.Models;
using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Data.Documents;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CURS.Infrastructure.Data.Documents
{
    public class AhdCubesInfoDocument : AhdCubesInfo<ObjectId>, IMongoDocument<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
        public IEnumerable<ReferenceDocument> Transcripts { get; set; }
        public IEnumerable<StudentDocument> Students { get; set; }
    }
}