using CURS.Domain.Core.Models;
using CURS.Domain.Interfaces.Data.Documents;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CURS.Infrastructure.Data.Documents
{
    public class QSExpertViewDocument : QSExpert, IMongoDocument<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public UniversityDocument University { get; set; }
        public CountryDocument Country { get; set; }
        public TitleDocument Title { get; set; }
        public BooleanDocument Boolean { get; set; }
        public QSDocument QS { get; set; }
    }
}
