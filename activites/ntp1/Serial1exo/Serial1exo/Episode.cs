using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial1exo
{
    public class Episode
    {
        public string Title { get; set; }
        public int DurationMinutes { get; set; }
        public int SequenceNumber { get; set; }
        public string Director { get; set; }
        public string Synopsis { get; set; }
        public List<Character> Characters { get; set; } = new List<Character>();
    }
}
