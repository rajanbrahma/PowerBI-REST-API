using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.IO;
using System.Web.Script.Serialization;

namespace PBIRESTapitest
{
    class DeleteRowsClass
    {
        private dataset[] datasets;
        private string token;
        private string datasetName;
        private string tableName;

        public DeleteRowsClass(string token, dataset[] datasets, string datasetName, string tableName)
        {
            this.datasets = datasets;
            this.token = token;
            this.datasetName = datasetName;
            this.tableName = tableName;
        }

        public string DeleteRows()
        {
            string powerBIApiUrl = "https://api.powerbi.com/v1.0/myorg";
            HttpWebRequest request = System.Net.WebRequest.Create(string.Format(powerBIApiUrl + "/datasets/{0}" + "/tables/{1}" + "/rows",(from d in datasets where d.Name == datasetName select d).FirstOrDefault().Id, tableName)) as System.Net.HttpWebRequest;
            request.KeepAlive = true;
            request.Method = "DELETE";
            request.ContentLength = 0;
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", String.Format("Bearer {0}", token));
            
            using (HttpWebResponse httpResponse = request.GetResponse() as System.Net.HttpWebResponse)
            { 
                using (StreamReader reader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();

                    return responseContent;
                }
            }
        }
    }
}
