﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Common.Models.Dtos
{
    public class JwtDto
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }

        public JwtDto(string token, DateTime expires)
        {
            Token = token;
            Expires = expires;
        }

        public JwtDto()
        {

        }
    }
}
