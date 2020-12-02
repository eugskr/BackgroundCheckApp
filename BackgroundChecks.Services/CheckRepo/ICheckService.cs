using BackgroundChecks.Data.Models;
using BackgroundChecks.Services.Models;


namespace BackgroundChecks.Services.CheckRepo
{
    public interface ICheckService
    {
        CheckModel ProcceedBackgroundCheck(CheckRequest model);
    }
}
