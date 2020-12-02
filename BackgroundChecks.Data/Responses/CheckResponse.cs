using System.Collections.Generic;

namespace BackgroundChecks.Data.Responses
{
    public class CheckResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string SSN { get; set; }
        public List<string> CrimeRecords { get; set; }
       
    }
}
