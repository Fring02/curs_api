﻿using CURS.Domain.Interfaces.Data.Documents;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CURS.Infrastructure.Data.Documents
{
    public class QsExpertCountryDocument
    {
        [BsonElement("ID")]
        public ObjectId ID { get; set; }
    }
}