﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExperianApi.Models
{
    public class Album
    {
        public Album() { }

        public int UserId { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }
    }
}
