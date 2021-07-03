using System;
using System.ComponentModel.DataAnnotations;
using CURS.Domain.Core.Models;

namespace CURS.Domain.Dtos.Create
{
    public class EmployerCreateDto : IDto
    {
        [Required(ErrorMessage = "Employer FirstNameKk is required")]
        public string FirstNameKk { get; set; }
        [Required(ErrorMessage = "Employer FirstNameRu is required")]
        public string FirstNameRu { get; set; }
        [Required(ErrorMessage = "Employer FirstNameEn is required")]
        public string FirstNameEn { get; set; }
        [Required(ErrorMessage = "Employer MiddleNameKk is required")]
        public string MiddleNameKk { get; set; }
        [Required(ErrorMessage = "Employer MiddleNameRu is required")]
        public string MiddleNameRu { get; set; }
        [Required(ErrorMessage = "Employer MiddleNameEn is required")]
        public string MiddleNameEn { get; set; }
        [Required(ErrorMessage = "Employer SurNameKk is required")]
        public string SurNameKk { get; set; }
        [Required(ErrorMessage = "Employer SurNameRu is required")]
        public string SurNameRu { get; set; }
        [Required(ErrorMessage = "Employer SurNameEn is required")]
        public string SurNameEn { get; set; }
        [Required(ErrorMessage = "Employer MobileNumber is required")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Employer Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Employer BirthDate is required")]
        public DateTime BirthDate { get; set; }
    }
}