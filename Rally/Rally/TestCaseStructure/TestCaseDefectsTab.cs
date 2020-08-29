namespace Rally.TestCaseStructure
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