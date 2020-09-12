using Rally.RestApi;

namespace SaveTestCasesFromRallyToJson.Api
{
    public class ApiClass
    {
        private readonly RallyRestApi restApi;

        public ApiClass(string username, string password, string host)
        {
            restApi = new RallyRestApi();
            restApi.Authenticate(username, password, host, proxy: null, allowSSO: false);
        }

        public RallyRestApi GetApiService()
        {
            return restApi;
        }
    }
}
