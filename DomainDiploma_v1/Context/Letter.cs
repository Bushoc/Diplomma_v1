using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDiploma_v1.Context
{
    public class Letter
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public int LetterIndex { get; set; }

        public int AlphabetId { get; set; }
    }
}
