using Rally.RestApi;
using Rally.RestApi.Exceptions;
using System;
using System.Windows.Forms;

namespace SaveTestCasesFromRallyToJson.Api
{
    public class ApiClass
    {
        private readonly RallyRestApi restApi;

        public ApiClass(string username, string password, string host)
        {
            restApi = new RallyRestApi();

            try
            {
                restApi.Authenticate(username, password, host, proxy: null, allowSSO: false);
            }
            
            catch (UriFormatException ex)
            {
                var confirmResult = MessageBox.Show("Wrong URL for server", "Error connection", MessageBoxButtons.OK);

                if (confirmResult == DialogResult.OK)
                {
                    System.Windows.Forms.Application.Exit();
                    System.Environment.Exit(0);
                }
            }
            catch (RallyUnavailableException ex)
            {
                var confirmResult = MessageBox.Show("Connection was not opened", "Error connection", MessageBoxButtons.OK);

                if (confirmResult == DialogResult.OK)
                {
                    System.Windows.Forms.Application.Exit();
                    System.Environment.Exit(0);
                }
            }
            
            catch (Exception ex)
            {
                System.Windows.Forms.Application.Exit();
                System.Environment.Exit(0);
            }
        }

        public RallyRestApi GetApiService()
        {
            return restApi;
        }
    }
}
