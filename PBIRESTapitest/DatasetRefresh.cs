using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PBIRESTapitest
{
    public class DatasetRefreshClass
    {
        private string token;
        private dataset[] set;
        private string datasetName;
        public DatasetRefreshClass(string Token, dataset [] set, string datasetName)
        {
            token = Token;
            this.set = set;
            this.datasetName = datasetName;
        }
        public string datasetrefresh()
        {
            string powerBIApiUrl = "https://api.powerbi.com/v1.0/myorg";
                
            HttpWebRequest request = System.Net.WebRequest.Create(string.Format(powerBIApiUrl + "/datasets/{0}" + "/refreshes",(from s in set where s.Name == datasetName select s).FirstOrDefault().Id)) as System.Net.HttpWebRequest;
            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentLength = 0;
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", String.Format("Bearer {0}", token));

            using (HttpWebResponse httpResponse = request.GetResponse() as System.Net.HttpWebResponse)
            {
                using (StreamReader reader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd().ToString();
                    return responseContent;
                }
            }
        }
    }
}