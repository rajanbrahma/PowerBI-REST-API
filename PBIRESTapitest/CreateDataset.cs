using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace PBIRESTapitest
{
    class CreateDatasetClass
    {
        private GlobalVariables gv;
        private string token;
        private HttpWebRequest request;

        public CreateDatasetClass(string Token)
        {
            token = Token;

            string powerBIApiUrl = "https://api.powerbi.com/v1.0/myorg";
            request = System.Net.WebRequest.Create(string.Format("{0}/datasets", powerBIApiUrl)) as System.Net.HttpWebRequest;
            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentLength = 0;
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", String.Format("Bearer {0}", token));
        }

        public string CreateDataset(string type)
        {
            object obj=new object();
            string DatasetName="";

            if (type == "product")
            {
                obj = new Product();
                DatasetName = "Products";

            }
            if(type=="user")
            {
                obj = new Person();
                DatasetName = "Users";
            }
            if (type == "sales")
            {
                obj = new Sales();
                DatasetName = "Sales";
            }

            string json = CreateJSON(obj, DatasetName);
            Console.WriteLine(json);
            Console.ReadKey();
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(json);
            request.ContentLength = byteArray.Length;

            using (Stream writer = request.GetRequestStream())
            {
                    writer.Write(byteArray, 0, byteArray.Length);
                    var response = (HttpWebResponse)request.GetResponse();
                    return response.StatusCode.ToString();
            }
        }

        public static string CreateJSON(System.Object ob1, string datasetName)
        {
            string json = "";
            string ClassName = ob1.GetType().Name.ToString(); //Gets the Name of the class - OK
            json = json + "{ \"name\":\"" + datasetName + "\",\"tables\":[{\"name\":\"" + ClassName + "\",\"columns\":[";
            var PropertyDetails = ob1.GetType().GetProperties(); //Gets the class Properties and it's type - OK
            foreach (var i in PropertyDetails)
            {
                json = json + "{ \"name\":\"" + i.Name.ToString() + "\", \"dataType\": \"" + i.PropertyType.Name.ToString() + "\"},";
            }
            json = json.Remove(json.Length - 1);
            json = json + "]}]}";
            return json;
        }
    }
}
