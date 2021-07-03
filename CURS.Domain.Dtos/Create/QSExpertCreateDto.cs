using System;
using System.ComponentModel.DataAnnotations;
using CURS.Domain.Core.Models;

namespace CURS.Domain.Dtos.Create
{
    public class QSExpertCreateDto : IDto
    {
        [Required(ErrorMessage = "DateOfCreation is required")]
        public DateTime DateOfCreation { get; set; }

        public DateTime DateModified => DateOfCreation;
        [Required(ErrorMessage = "ExtraId is required")]
        public int ExtraId { get; set; }
        [Required(ErrorMessage = "Employer is required")]
        public EmployerCreateDto Employer { get; set; }
        [Required(ErrorMessage = "EmpUniversity is required")]
        public string EmpUniversity { get; set; }
        [Required(ErrorMessage = "Unit is required")]
        public string Unit { get; set; }
        [Required(ErrorMessage = "Organization is required")]
        public string Organization { get; set; }
        [Required(ErrorMessage = "Sector is required")]
        public string Sector { get; set; }
        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; }
        [Required(ErrorMessage = "University id is required")]
        public string UniversityId { get; set; }
        [Required(ErrorMessage = "Country id is required")]
        public string CountryId { get; set; }
        [Required(ErrorMessage = "Title id is required")]
        public string TitleId { get; set; }
        [Required(ErrorMessage = "Boolean id is required")]
        public string BooleanId { get; set; }
        [Required(ErrorMessage = "QS id is required")]
        public string QsId { get; set; }
    }
}