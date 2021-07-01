using CURS.Infrastructure.Data.Config;
using CURS.Infrastructure.Data.Documents;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

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
        internal IMongoCollection<QSExpertDocument> QSExperts => _db.GetCollection<QSExpertDocument>("QSExperts");
        internal IMongoCollection<TitleDocument> Titles => _db.GetCollection<TitleDocument>("DirTitle");
        internal IMongoCollection<CountryDocument> Countries => _db.GetCollection<CountryDocument>("DirCountry");
        internal IMongoCollection<BooleanDocument> Booleans => _db.GetCollection<BooleanDocument>("DirBoolean");
        internal IMongoCollection<QSDocument> QS => _db.GetCollection<QSDocument>("DirQS");
    }
}
