using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBIRESTapitest
{
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
