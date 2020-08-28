using Rally.RestApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally.TestCaseStructure
{
    public class TestCase
    {
        public string ObjectID { get; set; }
        public string TestCaseNumber { get; set; }
        public string TestCaseName { get; set; }
        public List<Step> Steps { get; private set; }

        private dynamic rallyResult;
        private RallyRestApi api;

        public TestCase(dynamic result, RallyRestApi api)
        {
            this.rallyResult = result;
            this.api = api;

            ObjectID = rallyResult["ObjectID"].ToString();
            TestCaseNumber = rallyResult["FormattedID"].ToString();
            TestCaseName = rallyResult["Name"].ToString();

            InitiliazeStepsFromTestCase();
        }

        public void InitiliazeStepsFromTestCase()
        {
            var resultSteps = rallyResult["Steps"];
            var stepsRef = resultSteps["_ref"];
            var stepsFromRally = api.GetByReference(stepsRef);

            if (stepsFromRally.TotalResultCount > 0)
            {
                Steps = new List<Step>();

                foreach (var step in stepsFromRally.Results)
                {
                    Steps.Add(new Step()
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
