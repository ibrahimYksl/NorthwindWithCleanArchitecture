﻿using Core.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authorizations.Dtos
{
    public class LoggedInDto
    {
        public AccessToken AccessToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }
}
