using System;
using CURS.Domain.Interfaces.Core;

namespace CURS.Domain.Core.Models
{
    public class Student<TId> : IEntity
    {
        public User<TId> User { get; set; }
        public DateTime DateOfCreate { get; set; }
        public DateTime DateModified { get; set; }
        public string SurNameRu { get; set; }
        public string FirstNameRu { get; set; }
        public string MiddleNameRu { get; set; }
        public string IIN { get; set; }
        public string MobileNumber { get; set; }
        public int Course { get; set; }
        public Faculty<TId> Faculty { get; set; }
        public Speciality<TId> Speciality { get; set; }
        public Degree<TId> Degree { get; set; }
    }
}