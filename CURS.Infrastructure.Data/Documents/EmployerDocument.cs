using CURS.Domain.Core.Models;
using CURS.Domain.Interfaces.Data.Documents;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CURS.Infrastructure.Data.Documents
{
    public class EmployerDocument : Employer, IMongoDocument<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
