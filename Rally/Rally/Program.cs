using Rally.RestApi;
using Rally.RestApi.Response;
using Rally.TestCaseStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally
{
    class Program
    {
        static void Main(string[] args)
        {
            String host = "https://rally1.rallydev.com/";

            String wsapiVersion = "v2.0";
            String projectRef = "/project/2222";
            String workspaceRef = "/workspace/11111";
            String applicationName = "RestExample_AddTCR";

            RallyRestApi restApi = new RallyRestApi();
            restApi.Authenticate(username, password, host, proxy: null, allowSSO: false);

            Request request = new Request("TestCase");
            request.Fetch = new List<string>() { "ObjectID", "FormattedID", "Name", "Description", "Notes", "Results", "Discussion", "Steps", "RevisionHistory", "Connections" };
            request.Query = new Query("ObjectID", Query.Operator.Equals, "92342102772");
            QueryResult queryResult = restApi.Query(request);
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            TestCase tc = new TestCase(queryResult.Results.First());
        }
    }
}
