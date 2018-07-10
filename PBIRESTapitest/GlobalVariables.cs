using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Configuration;
using System.Collections.Specialized;

namespace PBIRESTapitest
{
    public class GlobalVariables
    {
        public string GetToken()
        {
            string authorityUri = ConfigurationSettings.AppSettings["authorityUri"];
            string resourceUri = ConfigurationSettings.AppSettings["resourceUri"];
            string clientID = ConfigurationSettings.AppSettings["clientID"];
            string redirectUri = ConfigurationSettings.AppSettings["redirectUri"];
            var credential = new UserCredential(ConfigurationSettings.AppSettings["UserId"], ConfigurationSettings.AppSettings["Password"]);
            AuthenticationContext authContext = new AuthenticationContext(authorityUri);
            //use following for UserOwnsData
            //string token = authContext.AcquireToken(resourceUri, clientID, new Uri(redirectUri), PromptBehavior.RefreshSession).AccessToken;
            var token = authContext.AcquireToken(resourceUri, clientID, credential).AccessToken;
            return token;
        }


        //public string GetPowerbiapiurl(dataset[] set)
        //{
        //    string powerBIApiUrlFormat= ConfigurationSettings.AppSettings["powerBIApiUrlFormat"];
        //    string datasetName = "Microsoft Data Visualization";
        //    string datasetId = (from d in set where d.Name == datasetName select d).FirstOrDefault().Id;
        //    string tableName = ConfigurationSettings.AppSettings["tableName"];
        //    string powerBIApiUrl = String.Format(powerBIApiUrlFormat, datasetId, tableName);
        //    return powerBIApiUrl;
        //}
        //public string GetPowerbiapiurlRefersh(dataset[] set)
        //{
        //    string powerBIApiUrlFormat = ConfigurationSettings.AppSettings["powerBIApiUrlFormatRefresh"];
        //    string datasetName = "Microsoft Data Visualization";
        //    string datasetId = (from d in set where d.Name == datasetName select d).FirstOrDefault().Id;
        //    string tableName = ConfigurationSettings.AppSettings["tableName"];
        //    string powerBIApiUrl = String.Format(powerBIApiUrlFormat, datasetId);
        //    return powerBIApiUrl;
        //}

        //public string GetDatasetId(dataset[] set)
        //{
        //    string datasetName = "Microsoft Data Visualization";
        //    string datasetId = (from d in set where d.Name == datasetName select d).FirstOrDefault().Id;
        //    return datasetId;
        //}
    }
}