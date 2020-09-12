using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTestCasesFromRallyToJson.TestCaseParts
{
    public class TestCaseStep
    {
        public int StepNumber { get; set; }
        public string InputText { get; set; }
        public string ExpectedText { get; set; }
    }
}
