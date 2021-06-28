using CURS.Domain.Core.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CURS.Infrastructure.Data.Documents
{
    public class UniversityDocument : University
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
