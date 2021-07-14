using System.Collections.Concurrent;
using System.Collections.Generic;

namespace CURS.Infrastructure.Data.Utils
{
    public class FactCalculator
    {
        private readonly IDictionary<double, bool> _lectureFactCounted;
        private readonly IDictionary<double, bool> _practiceFactCounted;
        private readonly IDictionary<double, bool> _laboratoryFactCounted;
        private readonly IDictionary<double, bool> _srspFactCounted;

        public FactCalculator()
        {
            _lectureFactCounted = new Dictionary<double, bool>();
            _practiceFactCounted = new Dictionary<double, bool>();
            _laboratoryFactCounted = new Dictionary<double, bool>();
            _srspFactCounted = new Dictionary<double, bool>();
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
            if (practiceFact > 0 && (!_practiceFactCounted.ContainsKey(practiceFact.Value) || !_practiceFactCounted[practiceFact.Value]))
            {
                res += practiceFact.Value;
                _practiceFactCounted[practiceFact.Value] = true;
            }
            if (labFact > 0 && (!_laboratoryFactCounted.ContainsKey(labFact.Value) || !_laboratoryFactCounted[labFact.Value]))
            {
                res += labFact.Value;
                _laboratoryFactCounted[labFact.Value] = true;
            }
            if (lectureFact > 0 && (!_lectureFactCounted.ContainsKey(lectureFact.Value) || !_lectureFactCounted[lectureFact.Value]))
            {
                res += lectureFact.Value;
                _lectureFactCounted[lectureFact.Value] = true;
            }
            if (srspFact > 0 && (!_srspFactCounted.ContainsKey(srspFact.Value) || !_srspFactCounted[srspFact.Value]))
            {
                res += srspFact.Value;
                _srspFactCounted[srspFact.Value] = true;
            }
            return res;
        }
    }
    
    
}