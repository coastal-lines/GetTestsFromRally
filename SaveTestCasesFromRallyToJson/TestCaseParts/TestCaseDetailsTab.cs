using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaveTestCasesFromRallyToJson.TestCaseParts
{
    public class TestCaseDetailsTab
    {
        #region Left side

        public string Description { get; set; }
        public string Notes { get; set; }
        public string Objective { get; set; }
        public string PreConditions { get; set; }
        public string PostConditions { get; set; }
        public string ValidationInput { get; set; }
        public string ValidationExpectedResult { get; set; }

        #endregion

        #region Right side

        public string Color { get; set; }
        public string Owner { get; set; }
        public string Project { get; set; }
        public string TestFolderName { get; set; }
        public bool Expedite { get; set; }
        public System.String WorkProductName { get; set; }
        public List<string> Tags { get; set; }
        public string Risk { get; set; }
        public string Type { get; set; }
        public string Method { get; set; }
        public List<string> Milestones { get; set; }
        public string Priority { get; set; }
        public string LastVerdict { get; set; }
        public string LastRun { get; set; }
        public string LastBuild { get; set; }
        public bool Attachments { get; set; }
        public string AutomationTestType { get; set; }
        public string Browser { get; set; }
        public string CanThisBeAutomated { get; set; }
        public bool ForReview { get; set; }
        public string ProductArea { get; set; }
        public string Run1Duration { get; set; }
        public string Run2Duration { get; set; }

        #endregion

        private dynamic rallyResult;

        public TestCaseDetailsTab(dynamic rallyResult)
        {
            this.rallyResult = rallyResult;

            //Left side of page
            Description = this.rallyResult["Description"];
            Notes = this.rallyResult["Notes"];
            Objective = this.rallyResult["Objective"];
            PreConditions = this.rallyResult["PreConditions"];
            PostConditions = this.rallyResult["PostConditions"];
            ValidationInput = this.rallyResult["ValidationInput"];
            ValidationExpectedResult = this.rallyResult["ValidationExpectedResult"];

            //Right side of page
            Color = this.rallyResult["DisplayColor"];
            Owner = ExtractDataFromResultObject("Owner");
            Project = ExtractDataFromResultObject("Project");
            TestFolderName = ExtractDataFromResultObject("TestFolder");
            Expedite = rallyResult["Expedite"];
            WorkProductName = ExtractDataFromResultObject("WorkProduct");
            Tags = InitializeTags(rallyResult);
            Risk = rallyResult["Risk"];
            Type = rallyResult["Type"];
            Method = rallyResult["Method"];
            Priority = rallyResult["Priority"];
            LastVerdict = rallyResult["LastVerdict"];
            LastRun = rallyResult["LastRun"];
            LastBuild = rallyResult["LastBuild"];
            Attachments = AreAttachmentsInTestCase();
            Browser = rallyResult["c_Browser"];
            CanThisBeAutomated = rallyResult["c_Canthisbeautomated"];
            ForReview = rallyResult["c_ForReview"];
            ProductArea = rallyResult["c_ProductAreaHighLevel"];
            Run1Duration = rallyResult["c_Run1DurationHours"];
            Run2Duration = rallyResult["c_Run2DurationHours"];
        }

        public string ExtractDataFromResultObject(string where)
        {
            string data = string.Empty;

            try
            {
                var resutObj = this.rallyResult[where];
                data = resutObj["_refObjectName"];
            }
            catch (RuntimeBinderException err)
            {
                Console.WriteLine(err.Message);
            }

            return data;
        }

        public bool AreAttachmentsInTestCase()
        {
            var obj = this.rallyResult["Attachments"];

            if (obj["Count"] > 0)
            {
                return true;
            }

            return false;
        }

        public List<string> InitializeTags(dynamic rallyResult)
        {
            List<string> tagsList = new List<string>();

            Dictionary<string, object> dict = rallyResult["Tags"].ToDictionary();
            var tags = dict.Where(k => k.Key.Equals("_tagsNameArray")).FirstOrDefault();

            foreach (var value in (System.Collections.ArrayList)tags.Value)
            {
                var refNameObject = (Dictionary<string, object>)value;
                tagsList.Add(refNameObject["Name"].ToString());
            }

            return tagsList;
        }
    }
}
