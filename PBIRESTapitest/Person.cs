using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBIRESTapitest
{
    //class Json
    //{
        //public static void Main(string [] args)
        //{
            //Person myself = new Person();
            //Person myself = new Person
            //{
            //    ID = 123,
            //    Name = "Rajan Brahma",
            //    Gender = true,
            //    DateOfBirth = new DateTime(1992, 11, 22)
            //};
            //string serializedJson = JsonConvert.SerializeObject(myself);
            //string json = serializedJson;
            //Console.WriteLine(json);
            //Console.ReadKey();

            //var jsonSchemaGenerator = new JsonSchemaGenerator();
            //var myType = typeof(Product);

            //var schema = jsonSchemaGenerator.Generate(myType);
            //schema.Title = myType.Name;
            //Console.WriteLine(schema.ToString());
            //Console.ReadKey();
            //string json = CreateJSON(myself, "personDS");
        //}
        //public string CreateJSON(System.Object ob1, string datasetName)
        //{
        //    string json = null;

        //    string ClassName = ob1.GetType().Name; //Gets the Name of the class - OK
        //    json = json + "{ \"name\":\"" + datasetName + "\",\"tables\":[{\"name\":\"" + ClassName + "\",\"columns\":[";
        //    var PropertyDetails = ob1.GetType().GetProperties(); //Gets the class Properties and it's type - OK
        //    foreach (var i in PropertyDetails)
        //    {
        //        json = json+"{ \"name\":\"" + i.Name.ToString() + "\", \"dataType\": \""+i.PropertyType.Name+"\"},";
        //    }
        //    json = json + "\b";
        //    json = json + "]}]}";
        //    return json;
        //}
    //}
    class Person
    {
        public Int64 ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Gender
        {
            get;
            set;
        }
        public DateTime DateOfBirth
        {
            get;
            set;
        }
        public string location { get; set; }
        public Int64 Age { get; set; }
    }
}
