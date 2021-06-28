using CURS.Domain.Core.Config;
using CURS.Domain.Core.Models;
using CURS.Infrastructure.Data.Documents;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

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



        public IMongoCollection<UniversityDocument> Universities => _db.GetCollection<UniversityDocument>("Copy_of_DirUniversities");
    }
}
