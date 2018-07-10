using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Clients.ActiveDirectory.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Microsoft.Graph;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace PBIRESTapitest
{
    public class ExcelRowAdd
    {
        public ExcelRowAdd()
        {
            string authorityUri = "https://login.microsoftonline.com/97e50a3c-284b-429f-9a93-2526d921baef/oauth2/authorize?scope=offline_access%20user.read%20mail.read%20Files.ReadWrite.All";
            string clientID = "2b6cb3eb-1c08-418a-b30b-13269beb0fae"; //rajanbrahma@hotmail
            string redirectUri = "http://localhost:13528/redirect";
            string resourceUri = "https://graph.microsoft.com/";
            AuthenticationContext authContext = new AuthenticationContext(authorityUri);
            string token = authContext.AcquireToken(resourceUri, clientID, new Uri(redirectUri), PromptBehavior.RefreshSession).AccessToken;

            //string authorityUri="https://login.microsoftonline.com/{tenant}/oauth2/v2.0/authorize?client_id=&response_type=code&redirect_uri=&response_mode=query&scope=offline_access%20user.read%20mail.read&state=12345";

            string ApiUrl = "https://graph.microsoft.com/v1.0/me";
            //string ApiUrl = "https://graph.windows.net/97e50a3c-284b-429f-9a93-2526d921baef/me";
            //string ApiUrl = "https://login.live.com/oauth20_authorize.srf?client_id=2b6cb3eb-1c08-418a-b30b-13269beb0fae&scope=wl.signin%20wl.basic&response_type=code&redirect_uri=http://localhost:13526/redirect";
            HttpWebRequest request = System.Net.WebRequest.Create(ApiUrl) as System.Net.HttpWebRequest;
            request.KeepAlive = true;
            request.Method = "GET";
            request.ContentLength = 0;
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", String.Format("Bearer {0}", token));


            Console.WriteLine("The token is : " + token);
            Console.ReadKey();


            
            using (HttpWebResponse httpResponse = request.GetResponse() as System.Net.HttpWebResponse)
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    Console.WriteLine(responseContent);
                    Console.ReadKey();
                }
            }
        }
    }
}