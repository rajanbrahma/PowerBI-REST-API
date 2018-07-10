using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBIRESTapitest
{
    public class SalesLog
    {
        public Int64 ID { get; set; }
        public Product Products { get; set; }
        public Int64 qty { get; set; }
    }
}
