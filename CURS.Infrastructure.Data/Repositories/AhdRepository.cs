using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CURS.Domain.Core.Models;
using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Data;
using CURS.Infrastructure.Data.Contexts;
using CURS.Infrastructure.Data.Documents;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CURS.Infrastructure.Data.Repositories
{
    public class AhdRepository : IAhdRepository
    {
        private readonly MongoContext _context;
        private readonly IMapper _mapper;
        public AhdRepository(MongoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CalculateStudentsWithTranscript()
        {
            //Retrieve cube data for transcript 001E
            var dateOfCreation = DateTime.Now;
            var dateEnd = new DateTime(dateOfCreation.Year, dateOfCreation.Month, DateTime.DaysInMonth(
                dateOfCreation.Year,
                dateOfCreation.Month));
            var cubeData = await _context.AhdCubesInfo.Aggregate()
                .Match(Builders<AhdCubesInfoDocument>.Filter.Eq(s => s.Filters.Code, "001E"))
                .Lookup<ReferenceDocument, AhdCubesInfoDocument>("References",
                    "Filters.Code", "Code", "Transcripts")
                .Lookup<StudentDocument, AhdCubesInfoDocument>("Students",
                    "Transcripts.User.ID", "User.ID", "Students")
                .Project(Builders<AhdCubesInfoDocument>.Projection.Expression(s => new AhdCubeDataDocument
                {
                    Accumulation = s.Accumulation,
                    Index = s.Index,
                    PeriodType = s.PeriodType,
                    DateOfCreation = dateOfCreation,
                    DateEnd = dateEnd,
                    DateModified = dateOfCreation,
                    Id = ObjectId.GenerateNewId(),
                    Items = s.Students.Select(st => new StudentFacultyViewDto<ObjectId>
                    {
                        Faculty = st.Faculty,
                        User = st.User
                    }).GroupBy(st => st.Faculty.ID,
                        (key, students) => new AhdItem
                        {
                            Value = students.Count(),
                            Pairs = new List<AhdItemPair>
                            {
                                new AhdItemPair
                                {
                                    Code = "Faculty",
                                    Value = key.ToString()
                                }
                            }
                        }),
                })).ToListAsync();
            var indexes = new HashSet<int>();
            var updateCubesTasks = new List<Task>();
                foreach (var ad in cubeData.Where(ad => !indexes.Contains(ad.Index)))
                {
                    updateCubesTasks.Add(_context.AhdCubeData.UpdateManyAsync(Builders<AhdCubeDataDocument>
                            .Filter.Eq("Index", ad.Index),
                        Builders<AhdCubeDataDocument>.Update.Set(cube => cube.DateEnd, dateEnd)
                            .Set(cube => cube.Items, ad.Items)));
                    indexes.Add(ad.Index);
                }
            updateCubesTasks.Add(_context.AhdCubeData.InsertManyAsync(cubeData));
            await Task.WhenAll(updateCubesTasks);
        }
    }
}