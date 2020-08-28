using Rally.RallyRest;
using Rally.RestApi;
using Rally.RestApi.Response;
using Rally.TestCaseStructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rally.CommonMethods
{
    public class CommonMethodsClass
    {
        private RallyRestApi api;

        public void SetupApi(string username, string password, string host)
        {
            ApiClass apiClass = new ApiClass(username, password, host);
            api = apiClass.GetApiService();
        }

        public void GetOneTestCase()
        {
            Request request = new Request("TestCase");
            request.Fetch = new List<string>() { "ObjectID", "FormattedID", "Name", "Description", "Notes", "Results", "Discussion", "Steps", "RevisionHistory", "Connections" };
            request.Query = new Query("ObjectID", Query.Operator.Equals, "92342102772");
            QueryResult queryResult = api.Query(request);
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            TestCase tc = new TestCase(queryResult.Results.First(), api);
        }
    }
}