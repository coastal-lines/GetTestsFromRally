using Newtonsoft.Json;
using Rally.RallyRest;
using Rally.RestApi;
using Rally.RestApi.Response;
using Rally.TestCaseStructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Rally.CommonMethods
{
    public class CommonMethodsClass
    {
        private RallyRestApi api;
        private List<string> testcasesIds = new List<string>();
        private List<TestCase> tcList = new List<TestCase>();

        public void SetupApi(string username, string password, string host)
        {
            ApiClass apiClass = new ApiClass(username, password, host);
            api = apiClass.GetApiService();
        }

        public void SaveTestCasesIntoJson()
        {
            StringBuilder sb = new StringBuilder();
            string delimeter = ",";

            foreach (var tc in tcList)
            {
                if (tc.Steps != null && tc.Steps.Count > 0)
                {
                    sb.AppendLine(JsonConvert.SerializeObject(tc, Formatting.Indented) + delimeter);
                }
            }

            using (StreamWriter file = new System.IO.StreamWriter(@"C:\Repos\MyGit\GetTestsFromRally\Rally\Files\data.txt"))
            {
                file.WriteLine(sb.ToString());
            }
        }

        public void GetAllTestCasesFromFolder(string testfolderId)
        {
            Request request = new Request("TestFolder");
            request.Fetch = new List<string>() { };
            request.Query = new Query("ObjectID", Query.Operator.Equals, testfolderId);
            QueryResult queryResult = api.Query(request);

            var testscasesObj = queryResult.Results.First()["TestCases"];
            if (testscasesObj["Count"] > 0)
            {
                var testcases = GetListOfTestCasesFromFolder(testscasesObj["_ref"]);

                foreach (var id in testcases)
                {
                    if (!testcasesIds.Contains(id))
                    {
                        GetOneTestCase(id);
                    }
                }
            }

            var foldersObj = queryResult.Results.First()["Children"];
            if (foldersObj["Count"] > 0)
            {
                var testfolders = GetListOfTestFoldersFromFolder(foldersObj["_ref"]);
                foreach (var id in testfolders)
                {
                    GetAllTestCasesFromFolder(id);
                }
            }
        }

        public List<string> GetListOfTestCasesFromFolder(string testcasesRef)
        {
            List<string> listTestCases = null;
            var testcasesObj = api.GetByReference(testcasesRef);
            var testcasesResult = (ArrayList)testcasesObj["Results"];

            if (testcasesResult.Count > 0)
            {
                listTestCases = new List<string>();

                foreach (dynamic value in testcasesResult)
                {
                    listTestCases.Add(value["ObjectID"].ToString());
                }
            }

            return listTestCases;
        }

        public List<string> GetListOfTestFoldersFromFolder(string testcasesRef)
        {
            List<string> listTestFolders = null;
            var testfolderObj = api.GetByReference(testcasesRef);
            var testfoldersResult = (ArrayList)testfolderObj["Results"];

            if (testfoldersResult.Count > 0)
            {
                listTestFolders = new List<string>();

                foreach (dynamic value in testfoldersResult)
                {
                    listTestFolders.Add(value["ObjectID"].ToString());
                    Console.WriteLine("folder: " + value["ObjectID"].ToString());
                }
            }

            return listTestFolders;
        }

        public void GetOneTestCase(string testcaseId)
        {
            Request request = new Request("TestCase");
            request.Fetch = new List<string>() { };
            request.Query = new Query("ObjectID", Query.Operator.Equals, testcaseId);
            QueryResult queryResult = api.Query(request);

            TestCase tc = new TestCase(queryResult.Results.First(), api);
            tcList.Add(tc);
        }
    }
}