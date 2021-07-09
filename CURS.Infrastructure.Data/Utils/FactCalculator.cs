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


        public double FactsSum(double practiceFact, double labFact, double lectureFact, double srspFact,
            double studyPractice, double prodPractice, double pedPractice, double preDiplomaPractice, 
            double researchPractice, double languagePractice, double diplomaWork, double dissertation, double gos,
            double other)
        {
            double res = 0;
            if (practiceFact == 0 && labFact == 0 && lectureFact == 0 && srspFact == 0)
            {
                return studyPractice + prodPractice + pedPractice + preDiplomaPractice + researchPractice +
                       languagePractice
                       + diplomaWork + dissertation + gos + other;
            }
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
    }
    
    
}