﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientShowcase.Models
{
    public class JokeResponse
    {
        public string Type { get; set; }
        public string Setup { get; set; }
        public string Punchline { get; set; }
        public int Id { get; set; }
    }
}
