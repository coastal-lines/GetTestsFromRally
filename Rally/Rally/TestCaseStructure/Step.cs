using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally.TestCaseStructure
{
    public class Step
    {
        public int StepNumber { get; set; }
        public string InputText { get; set; }
        public string ExpectedText { get; set; }
    }
}
