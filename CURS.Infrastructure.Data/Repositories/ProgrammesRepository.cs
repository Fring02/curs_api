using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using CURS.Domain.Core.Models;
using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Data;
using CURS.Infrastructure.Data.Contexts;
using CURS.Infrastructure.Data.Documents;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CURS.Infrastructure.Data.Repositories
{
    public class ProgrammesRepository : BaseRepository<Programme, ProgrammeViewDto>, IProgrammesRepository
    {
        private readonly IDictionary<double, bool> _lectureFactCounted;
        private readonly IDictionary<double, bool> _practiceFactCounted;
        private readonly IDictionary<double, bool> _laboratoryFactCounted;
        private readonly IDictionary<double, bool> _srspFactCounted;

        public ProgrammesRepository(MongoContext context, IMapper mapper) : base(context, mapper)
        {
            _lectureFactCounted = new Dictionary<double, bool>();
            _practiceFactCounted = new Dictionary<double, bool>();
            _laboratoryFactCounted = new Dictionary<double, bool>();
            _srspFactCounted = new Dictionary<double, bool>();
        }

        public override async Task<IReadOnlyCollection<ProgrammeViewDto>> GetAllAsync()
        {
            return await _context.Programmes.Find(_ => true).Project(Builders<ProgrammeDocument>.Projection.Expression(s => new ProgrammeViewDto
            {
                ID = s.ID,
                ATT_DISCIPLINE = s.ATT_DISCIPLINE,
                ATT_SPECIALITIES = s.ATT_SPECIALITIES,
                ATT_COURSES = s.ATT_COURSES,
                ATT_LANGUAGE_DEPARTMENTS = s.ATT_LANGUAGE_DEPARTMENTS,
                ATT_TOTAL_CREDITS = s.ATT_TOTAL_CREDITS,
                ATT_COUNT_OF_STUDENTS = s.ATT_COUNT_OF_STUDENTS,
                ATT_GROUPS = s.ATT_GROUPS,
                ATT_SUBGROUPS = s.ATT_SUBGROUPS,
                ATT_TOTAL = FactsSum(s.ATT_PRACTICE_FACT, s.ATT_LABORATORY_FACT, s.ATT_LECTURE_FACT, s.ATT_SRSP_FACT,
                    s.ATT_STUDY_PRACTICE, s.ATT_PROD_PRACTICE, s.ATT_PED_PRACTICE, s.ATT_DIPLOMA_PRACTICE,
                    s.ATT_RESEARCH_PRACTICE, s.ATT_LANGUAGE_PRACTICE, s.ATT_DIPLOMA_WORK, s.ATT_DISSERTATION, s.ATT_GOS,
                    s.ATT_OTHER),
                ATT_LESSON_TYPE = s.ATT_LESSON_TYPE,
                ATT_GROUP_CODE = s.ATT_GROUP_CODE,
                ATT_CONNECTION_CODE = s.ATT_CONNECTION_CODE
            })).ToListAsync();
        }


        private double FactsSum(double practiceFact, double labFact, double lectureFact, double srspFact,
            double studyPractice, double prodPractice, double pedPractice, double preDiplomaPractice, 
            double researchPractice, double languagePractice, double diplomaWork, double dissertation, double gos,
            double other)
        {
            if (practiceFact == 0 && labFact == 0 && lectureFact == 0 && srspFact == 0)
            {
                return studyPractice + prodPractice + pedPractice + preDiplomaPractice + researchPractice +
                       languagePractice
                       + diplomaWork + dissertation + gos + other;
            }
            double res = 0;
            if (practiceFact > 0 && (!_practiceFactCounted.ContainsKey(practiceFact) || !_practiceFactCounted[practiceFact]))
            {
                res += practiceFact;
                _practiceFactCounted[practiceFact] = true;
            }
            if (labFact > 0 && (!_laboratoryFactCounted.ContainsKey(labFact) || !_laboratoryFactCounted[labFact]))
            {
                res += labFact;
                _laboratoryFactCounted[labFact] = true;
            }
            if (lectureFact > 0 && (!_lectureFactCounted.ContainsKey(lectureFact) || !_lectureFactCounted[lectureFact]))
            {
                res += lectureFact;
                _lectureFactCounted[lectureFact] = true;
            }
            if (srspFact > 0 && (!_srspFactCounted.ContainsKey(srspFact) || !_srspFactCounted[srspFact]))
            {
                res += srspFact;
                _srspFactCounted[srspFact] = true;
            }
            return res;
        }
        public override Task CreateAsync(Programme model)
        {
            throw new System.NotImplementedException();
        }
    }
}