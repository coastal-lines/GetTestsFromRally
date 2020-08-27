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

        public TestCase(dynamic result)
        {
            ObjectID = result["ObjectID"];
            TestCaseNumber = result["FormattedID"];
            TestCaseName = result["Name"];
        }
    }
}
