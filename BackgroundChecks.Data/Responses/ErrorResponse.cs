﻿using BackgroundChecks.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundChecks.Data.Responses
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
