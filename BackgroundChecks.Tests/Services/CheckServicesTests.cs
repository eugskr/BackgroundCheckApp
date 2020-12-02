using BackgroundChecks.Data.Models;
using BackgroundChecks.Services.CheckRepo;
using BackgroundChecks.Services.Models;
using NUnit.Framework;
using System;

namespace BackgroundChecks.Tests.Services
{
    public class CheckServicesTests
    {
        ICheckService _service;

        [SetUp]
        public void Setup()
        {
            _service = new CheckService();
        }

        [TestCase("123456789")]
        [TestCase("111111111")]
        public void ProcceedBackgroundCheck_SSNAssign_Success(string ssnNumber)
        {
            var ssnExpected = SSN.FromString(ssnNumber);
            var model = new CheckRequest
            {
                FirstName = "Yevhen",
                LastName = "Skrypnyk",
                DateOfBirth = new DateTime(2002, 10, 10),
                SSN = ssnNumber
            };

            var result = _service.ProcceedBackgroundCheck(model);

            Assert.NotNull(result);
            Assert.AreEqual(ssnExpected, result.SSN);
        }

        [TestCase("1234567890")]
        [TestCase("12345 6789")]
        [TestCase("12345F789")]

        public void ProcceedBackgroundCheck_SSNAssign_Fail(string ssnNumber)
        {
            var model = new CheckRequest
            {
                FirstName = "Yevhen",
                LastName = "Skrypnyk",
                DateOfBirth = new DateTime(2002, 10, 10),
                SSN = ssnNumber
            };

            var exception = Assert.Throws(
                typeof(ArgumentException),
                delegate { _service.ProcceedBackgroundCheck(model); });

            Assert.AreEqual("ssnNumber", exception.Message);
        }
        [TestCase("Skrypnyk")]
        [TestCase("Krays")]

        public void ProcceedBackgroundCheck_LastNameEndsWithClear_ListCrimeRecords(string lastName)
        {
            var ssnNumber = "123456789";
            var model = new CheckRequest
            {
                FirstName = "Yevhen",
                LastName = lastName,
                DateOfBirth = new DateTime(2002, 10, 10),
                SSN = ssnNumber
            };

            var result = _service.ProcceedBackgroundCheck(model);

            Assert.NotZero(result.CrimeRecords.Count);
        }

        [TestCase("SkrypnykClear")]
        [TestCase("SClear")]

        public void ProcceedBackgroundCheck_LastNameEndsWithClear_ListCrimeRecordsEmpty(string lastName)
        {
            var ssnNumber = "123456789";
            var model = new CheckRequest
            {
                FirstName = "Yevhen",
                LastName = lastName,
                DateOfBirth = new DateTime(2002, 10, 10),
                SSN = ssnNumber
            };

            var result = _service.ProcceedBackgroundCheck(model);

            Assert.Zero(result.CrimeRecords.Count);
        }
    }
}