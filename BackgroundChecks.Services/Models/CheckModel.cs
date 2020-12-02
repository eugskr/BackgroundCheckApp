using BackgroundChecks.Data.Models;
using System;
using System.Collections.Generic;

namespace BackgroundChecks.Services.Models
{
    public class CheckModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public SSN SSN { get; set; }
        public List<string> CrimeRecords { get; set; }

        public CheckModel(CheckRequest model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            DateOfBirth = model.DateOfBirth;           
        }
    }
}
