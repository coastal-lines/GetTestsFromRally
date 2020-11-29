using Rally.RestApi;
using System.Collections.Generic;

namespace SaveTestCasesFromRallyToJson.TestCaseClasses
{
    public class TestCase
    {
        public string ObjectID { get; set; }
        public string TestCaseNumber { get; set; }
        public string TestCaseName { get; set; }
        public List<TestCaseStep> Steps { get; private set; }
        public TestCaseDetailsTab Details { get; private set; }
        public TestCaseDefectsTab Defects { get; private set; }
        public TestCaseResultsTab Results { get; private set; }

        private dynamic rallyResult;
        private RallyRestApi api;

        public TestCase(dynamic result, RallyRestApi api)
        {
            this.rallyResult = result;
            this.api = api;

            ObjectID = rallyResult["ObjectID"].ToString();
            TestCaseNumber = rallyResult["FormattedID"].ToString();
            TestCaseName = rallyResult["Name"].ToString();

            Details = new TestCaseDetailsTab(rallyResult);
            Defects = new TestCaseDefectsTab(rallyResult);
            Results = new TestCaseResultsTab(rallyResult);
            InitializeSteps();
        }

        public void InitializeSteps()
        {
            var resultSteps = rallyResult["Steps"];
            var stepsRef = resultSteps["_ref"];
            var stepsFromRally = api.GetByReference(stepsRef);

            if (stepsFromRally.TotalResultCount > 0)
            {
                Steps = new List<TestCaseStep>();

                foreach (var step in stepsFromRally.Results)
                {
                    Steps.Add(new TestCaseStep()
                    {
                        StepNumber = step["StepIndex"],
                        ExpectedText = step["ExpectedResult"],
                        InputText = step["Input"]
                    });
                }
            }
        }
    }
}
