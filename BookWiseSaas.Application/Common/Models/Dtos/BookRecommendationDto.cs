﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Common.Models.Dtos
{
    public class BookRecommendationDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
