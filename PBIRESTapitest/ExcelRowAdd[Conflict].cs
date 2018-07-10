using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PBIRESTapitest
{
    public class ExcelRowAdd
    {
        public ExcelRowAdd()
        {
            //string authorityUri = "https://login.windows.net/swastitirtha.onmicrosoft.com"; // /tenant name - where the app has been registered, OR, You can use the following also, both works.
            string authorityUri = "https://login.windows.net/common/oauth2/authorize";
            string resourceUri = "https://graph.windows.net";//DONE
            string clientID = "dd7b5ad1-28c3-4f90-bb2c-082c9389312c";
            string redirectUri = "http://localhost:13527/redirect"; //DONE
            AuthenticationContext authContext = new AuthenticationContext(authorityUri, false);
            string token = authContext.AcquireToken(resourceUri, clientID, new Uri(redirectUri), PromptBehavior.RefreshSession).AccessToken;
            Console.WriteLine("Token : " + token);
            Console.ReadKey();


            //string MicrosoftGraphExcelURL = "https://graph.microsoft.com/v1.0/drives/root/children";
            string MicrosoftGraphExcelURL = "https://graph.microsoft.com/v1.0/drives";
            HttpWebRequest request = System.Net.WebRequest.Create(MicrosoftGraphExcelURL) as System.Net.HttpWebRequest;
            request.KeepAlive = true;
            request.Method = "GET";
            request.ContentLength = 0;
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", String.Format("Bearer {0}", token));
            Console.WriteLine(request.Address);
            Console.ReadKey();

            var resp = request.GetResponse();
            Console.WriteLine(resp);

            using (HttpWebResponse httpResponse = request.GetResponse() as System.Net.HttpWebResponse)
            {
                using (StreamReader reader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                    Datasets datasets = (Datasets)jsonSerializer.Deserialize(responseContent, typeof(Datasets));
                    dataset[] d = datasets.value;
                    foreach (dataset i in d)
                    {
                        Console.WriteLine("ID : " + i.Id + "NAME : " + i.Name);
                    }
                    Console.ReadKey();
                }
            }





            //string json = "{ \"persistChanges\": true }";

            //byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(json);
            //request.ContentLength = byteArray.Length;

            //using (Stream writer = request.GetRequestStream())
            //{
            //    writer.Write(byteArray, 0, byteArray.Length);
            //    var response = (HttpWebResponse)request.GetResponse();
            //    Console.WriteLine(response + " | " + response.StatusDescription);
            //}
            //request.Abort();




        }
    }
}
