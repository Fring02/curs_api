using System;
using System.ComponentModel.DataAnnotations.Schema;
using CURS.Domain.Core.Models;
using CURS.Domain.Interfaces.Data.Documents;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CURS.Infrastructure.Data.Documents
{
    public class QsExpertDocument : IMongoDocument<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public QsExpertUniversityDocument University { get; set; }
        public QsExpertCountryDocument Country { get; set; }
        public QsExpertTitleDocument Title { get; set; }
        public QsExpertBooleanDocument Boolean { get; set; }
        public QsExpertQSDocument QS { get; set; }
        
        public DateTime DateOfCreation { get; set; }
        public DateTime DateModified { get; set; }
        public int ExtraId { get; set; }
        public Employer Employer { get; set; }
        public string EmpUniversity { get; set; }
        public string Unit { get; set; }
        public string Organization { get; set; }
        public string Sector { get; set; }
        public string Position { get; set; }
    }
}