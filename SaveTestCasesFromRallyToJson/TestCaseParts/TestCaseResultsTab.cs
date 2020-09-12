using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTestCasesFromRallyToJson.TestCaseParts
{
    public class TestCaseResultsTab
    {
        public int CountResultsOfTestCase { get; private set; }

        public TestCaseResultsTab(dynamic rallyResult)
        {
            var defectsObj = rallyResult["Results"];
            CountResultsOfTestCase = defectsObj["Count"];
        }
    }
}
