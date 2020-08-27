using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally.TestCaseStructure
{
    public class TestCaseDetailsTab
    {
        #region Left side

        public string Description { get; set; }
        public string Notes { get; set; }
        public string Objective { get; set; }
        public string PreConditions { get; set; }
        public string PostCondition { get; set; }
        public string ValidationInput { get; set; }
        public string ValidationExpectedResult { get; set; }

        #endregion

        #region Right side

        public string Color { get; set; }
        public string Owner { get; set; }
        public string Project { get; set; }
        public string TestFolderId { get; set; }
        public bool Expedite { get; set; }
        public string WorkProductId { get; set; }
        public List<string> Tags { get; set; }
        public string Risk { get; set; }
        public string Type { get; set; }
        public string Method { get; set; }
        public List<string> Milestones { get; set; }
        public string Priority { get; set; }
        public string LastVerdict { get; set; }
        public string LastRun { get; set; }
        public string LastBuild { get; set; }
        public List<string> Attachments { get; set; }
        public string AutomationTestType { get; set; }
        public string Browser { get; set; }
        public string CanThisBeAutomated { get; set; }
        public bool ForPreview { get; set; }
        public string ProductArea { get; set; }
        public string Run1Duration { get; set; }
        public string Run2Duration { get; set; }

        #endregion
    }
}
