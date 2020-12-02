
using BackgroundChecks.Data.Models;
using System.Collections.Generic;
using System;
using BackgroundChecks.Services.Models;

namespace BackgroundChecks.Services.CheckRepo
{
    public class CheckService : ICheckService
    {
        public CheckModel ProcceedBackgroundCheck(CheckRequest model)
        {
            var checkModel = new CheckModel(model);
           
            checkModel.SSN =  SSN.FromString(model.SSN);

            checkModel.CrimeRecords = model.LastName.EndsWith("Clear") 
                ? new List<string>(0)
                : new List<string>(new string[] { "crime reco 1", "crime reco 2", "crime reco 3", "crime reco 4" });
            return checkModel;
        }

       
    }
}
