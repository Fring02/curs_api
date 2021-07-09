using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CURS.Domain.Core.Models;
using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Data;
using CURS.Infrastructure.Data.Contexts;
using CURS.Infrastructure.Data.Documents;
using MongoDB.Driver;

namespace CURS.Infrastructure.Data.Repositories
{
    public class ProgrammesRepository : BaseRepository<Programme, ProgrammeViewDto>, IProgrammesRepository
    {

        public ProgrammesRepository(MongoContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<IReadOnlyCollection<ProgrammeViewDto>> GetAllAsync()
        {
            return await _context.Programmes.Find(_ => true).Project(Builders<ProgrammeDocument>.Projection
                .Expression(s => _mapper.Map<ProgrammeViewDto>(s))).ToListAsync();
        }
        public override Task CreateAsync(Programme model)
        {
            throw new NotImplementedException();
        }
    }
}