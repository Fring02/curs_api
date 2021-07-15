using System.Collections.Generic;

namespace CURS.Infrastructure.Data.Utils
{
    public class FactCalculator
    {
        private readonly ISet<double> _lectureFactCounted;
        private readonly ISet<double> _practiceFactCounted;
        private readonly ISet<double> _laboratoryFactCounted;
        private readonly ISet<double> _srspFactCounted;

        public FactCalculator()
        {
            _lectureFactCounted = new HashSet<double>();
            _practiceFactCounted = new HashSet<double>();
            _laboratoryFactCounted = new HashSet<double>();
            _srspFactCounted = new HashSet<double>();
        }

        public void Reset()
        {
            _lectureFactCounted.Clear();
            _practiceFactCounted.Clear();
            _laboratoryFactCounted.Clear();
            _srspFactCounted.Clear();
        }

        public double? FactsSum(double? practiceFact, double? labFact, double? lectureFact, double? srspFact,
            double? studyPractice, double? prodPractice, double? pedPractice, double? preDiplomaPractice, 
            double? researchPractice, double? languagePractice, double? diplomaWork, double? dissertation,
            double? gos, double? other)
        {
            double res = 0;
            if (!practiceFact.HasValue && !labFact.HasValue && !lectureFact.HasValue && !srspFact.HasValue)
            {
                return studyPractice + prodPractice + pedPractice + preDiplomaPractice + researchPractice +
                       languagePractice
                       + diplomaWork + dissertation + gos + other;
            }
            if (practiceFact > 0 && !_practiceFactCounted.Contains(practiceFact.Value))
            {
                res += practiceFact.Value;
                _practiceFactCounted.Add(practiceFact.Value);
            }
            if (labFact > 0 && !_laboratoryFactCounted.Contains(labFact.Value))
            {
                res += labFact.Value;
                _laboratoryFactCounted.Add(labFact.Value);
            }
            if (lectureFact > 0 && !_lectureFactCounted.Contains(lectureFact.Value))
            {
                res += lectureFact.Value;
                _lectureFactCounted.Add(lectureFact.Value);
            }
            if (srspFact > 0 && !_srspFactCounted.Contains(srspFact.Value))
            {
                res += srspFact.Value;
                _srspFactCounted.Add(srspFact.Value);
            }
            return res;
        }
    }
    
    
}