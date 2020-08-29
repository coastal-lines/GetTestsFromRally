namespace Rally.TestCaseStructure
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
