using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDiploma_v1.Context
{
    public class Alphabet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Type { get; set; }

        public string Notes { get; set; }

        public ICollection<Letter> Letters { get; set; }
    }
}
