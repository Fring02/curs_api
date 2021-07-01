﻿using System;

namespace CURS.Domain.Core.Models
{
    public class Employer
    {
        public string FirstNameKk { get; set; }
        public string FirstNameRu { get; set; }
        public string FirstNameEn { get; set; }

        public string MiddleNameKk { get; set; }
        public string MiddleNameRu { get; set; }
        public string MiddleNameEn { get; set; }
        
        public string SurNameKk { get; set; }
        public string SurNameRu { get; set; }
        public string SurNameEn { get; set; }
        
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}