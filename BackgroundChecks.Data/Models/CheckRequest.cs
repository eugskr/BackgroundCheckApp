using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundChecks.Data.Models
{
    public class CheckRequest
    {
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SSN { get; set; }

    }
}
