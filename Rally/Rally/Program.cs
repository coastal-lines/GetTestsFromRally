using Rally.RestApi;
using Rally.RestApi.Response;
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
            request.Fetch = new List<string>() { "Name", "Description", "Notes", "FormattedID" };
            request.Query = new Query("ObjectID", Query.Operator.Equals, "77391251364");
            QueryResult queryResult = restApi.Query(request);
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            foreach (var result in queryResult.Results)
            {
                Console.WriteLine(result["Name"]);
            }
        }
    }
}
