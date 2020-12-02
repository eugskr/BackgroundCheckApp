using BackgroundChecks.Data.Responses;
using BackgroundChecks.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundChecks.Services.Extensions
{
    public static class CheckResponseMapper
    {
        public static CheckResponse ToCheckResponse(this CheckModel checkModel)
        {
            return new CheckResponse
            {
                FirstName = checkModel.FirstName,
                LastName = checkModel.LastName,
                DateOfBirth = checkModel.DateOfBirth.ToString("dd-MM-yyyy"),
                SSN = checkModel.SSN.ToString(),
                CrimeRecords = checkModel.CrimeRecords
            };


        }
    }
}
