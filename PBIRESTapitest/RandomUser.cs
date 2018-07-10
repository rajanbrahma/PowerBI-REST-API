using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PBIRESTapitest
{
    /// <summary>
    /// Using https://randomuser.me
    /// </summary>

    public class RandomUser
    {
        public class randomuser
        {
            public List<results> results { get; set; }
        }

        public class results
        {
            public user user { get; set; }
            public string seed { get; set; }
        }

        public class user
        {
            //public name name { get; set; }
            public string name { get; set; }
            public string gender { get; set; }
            public string email { get; set; }
            public DateTime dob { get; set; }
        }

        public class name
        {
            public string title { get; set; }
            public string first { get; set; }
            public string last { get; set; }
        }

        public class location
        {
            public string street { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string zip { get; set; }
        }

        public class picture
        {
            public string large { get; set; }
            public string medium { get; set; }
            public string thumbnail { get; set; }
        }


        public string GetSingleDummyUser()
        {
            var user = new user();

            string url = "http://api.randomuser.me/";

            var data = FetchJson(url);

            return data;
        }

        public static string GetManyDummyUser(int take)
        {
            var users = new List<user>();
            string url = "http://api.randomuser.me/?results=" + take;

            var data = FetchJson(url);
            
            return data;

        }

        private static string FetchJson(string url)
        {
            var data = new randomuser();
            string json="";
            try
            {
                using (WebClient wc = new WebClient())
                {
                    json = wc.DownloadString(url);
                }

            }
            catch (Exception)
            {
                // throw;
            }
            return json;
        }
        //public static void Main(string[] args)
        //{
        //    for (int i = 0; i < 40; i++)
        //    {
        //        //var res = GetSingleDummyUser();
        //        dynamic res = JObject.Parse(GetSingleDummyUser());
        //        Console.WriteLine(res.results[0]);
        //        Thread.Sleep(10000);
        //    }
        //    //Console.ReadKey();
        //}
        public static async void callme()
        {
            await Task.Delay(70000);
        }
    }
}