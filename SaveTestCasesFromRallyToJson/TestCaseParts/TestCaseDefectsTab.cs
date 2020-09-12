using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTestCasesFromRallyToJson.TestCaseParts
{
    public class TestCaseDefectsTab
    {
        public int CountDefectsOfTestCase { get; private set; }

        public TestCaseDefectsTab(dynamic rallyResult)
        {
            var defectsObj = rallyResult["Defects"];
            CountDefectsOfTestCase = defectsObj["Count"];
        }
    }
}
