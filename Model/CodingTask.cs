using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp.Model
{
    public class CodingTask
    {
        public string Description { get; set; }
        public string UserCode { get; set; }
        public bool IsCorrect { get; set; }
        public string Output { get; set; }
        public string ExpectedOutput { get; set; }
    }
}
