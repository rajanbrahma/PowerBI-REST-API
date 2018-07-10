using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Web.Script.Serialization;
using System.Net;

namespace PBIRESTapitest
{
    public class GetGroupsClass
    {
        string token;
        private GlobalVariables gv;
        public GetGroupsClass(string Token)
        {
            token = Token;
        }
        public Groups GetGroups(dataset [] datasets)
        {
            //GET web request to list all groups.
            HttpWebRequest request = System.Net.WebRequest.Create("https://api.powerbi.com/v1.0/myorg/groups") as System.Net.HttpWebRequest;
            request.KeepAlive = true;
            request.Method = "GET";
            request.ContentLength = 0;
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", String.Format("Bearer {0}", token));

            //Get HttpWebResponse from GET request
            using (HttpWebResponse httpResponse = request.GetResponse() as System.Net.HttpWebResponse)
            {
                //Get StreamReader that holds the response stream
                using (System.IO.StreamReader reader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();

                    JavaScriptSerializer json = new JavaScriptSerializer();
                    Groups groups = (Groups)json.Deserialize(responseContent, typeof(Groups));
                    return groups;
                }
            }
        }
    }
}