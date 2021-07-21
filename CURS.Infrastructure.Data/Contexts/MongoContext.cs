using CURS.Infrastructure.Data.Config;
using CURS.Infrastructure.Data.Documents;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using CURS.Domain.Dtos;

namespace CURS.Infrastructure.Data.Contexts
{
    public class MongoContext
    {
        private readonly IMongoDatabase _db;
        public MongoContext(IOptions<DatabaseSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database) ??
                throw new ArgumentException($"Failed to connect to database {options.Value.Database}");
        }

        internal IMongoCollection<UniversityDocument> Universities => _db.GetCollection<UniversityDocument>("Copy_of_DirUniversities");
        internal IMongoCollection<QsExpertDocument> QSExperts => _db.GetCollection<QsExpertDocument>("QSExperts");
        internal IMongoCollection<TitleDocument> Titles => _db.GetCollection<TitleDocument>("DirTitle");
        internal IMongoCollection<CountryDocument> Countries => _db.GetCollection<CountryDocument>("DirCountry");
        internal IMongoCollection<BooleanDocument> Booleans => _db.GetCollection<BooleanDocument>("DirBoolean");
        internal IMongoCollection<QSDocument> QS => _db.GetCollection<QSDocument>("DirQS");
        internal IMongoCollection<ProgrammeDocument> Programmes => _db.GetCollection<ProgrammeDocument>("Programmes");

        internal IMongoCollection<StudentDocument> Students => _db.GetCollection<StudentDocument>("Programmes");
        internal IMongoCollection<ReferenceDocument> References => _db.GetCollection<ReferenceDocument>("References");
        internal IMongoCollection<AhdRelationDocument> AhdRelations =>
            _db.GetCollection<AhdRelationDocument>("AhdRelations");
        internal IMongoCollection<AhdCubesInfoDocument> AhdCubesInfo =>
            _db.GetCollection<AhdCubesInfoDocument>("AhdCubesInfo");
        internal IMongoCollection<AhdCubeDataDocument> AhdCubeData =>
            _db.GetCollection<AhdCubeDataDocument>("AhdCubeData");
    }
}
