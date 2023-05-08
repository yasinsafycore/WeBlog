﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeBloge.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string to, string subject, string body);
    }
}
