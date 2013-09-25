using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Problem(int id, string desc)
        {
            Description = desc;
            Id = id;
        }
    }
}
