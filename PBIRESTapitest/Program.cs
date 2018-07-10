using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;
using System.Collections.Specialized;

namespace PBIRESTapitest
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalVariables gv = new GlobalVariables();
            string Token = gv.GetToken();

            //Console.WriteLine("MENU");
            //do
            //{
            //    Console.WriteLine("Press 1 to get the list of datasets.\nPress 2 to get the list of groups\nPress 3 to create a new dataset\nPress 4 to add a new row\nPress 5 to delete all rows\nPress 6 to refresh a dataset\nPress 0 to exit\nEnter your choice : ");
            //    Int64 i = Convert.ToInt64(Console.ReadKey());

            //    Console.ReadKey();
            //    break;
            //} while (true);

            //CreateDatasetClass dataset = new CreateDatasetClass(Token);
            //string str = dataset.CreateDataset();
            //Console.WriteLine("dataset " + str);
            //Console.ReadKey();

            GetDatasetsClass getdatasets = new GetDatasetsClass(Token);
            dataset[] set = getdatasets.GetDatasets();
            foreach (dataset i in set)
            {
                Console.WriteLine(i.Id + " | " + i.Name);
                Console.ReadKey();
            }

            //AddRowsClass addrow = new AddRowsClass(Token,set, "Sales", "Product");
            //string[] ProdName = { "Shampoo", "Razor", "Shaving Cream", "Brush", "Toilet Paper", "Cream", "Hair Gel", "Mirror", "Hand Sanitizer" };
            //Int64[] ProdPrice = { 200, 150, 250, 60, 80, 430, 70, 500, 200 };
            //for (int i = 0; i < ProdName.Length; i++)
            //{
            //    addrow.AddRows(i + 1, ProdName[i], ProdPrice[i]);
            //}

            //DeleteRowsClass deleterow = new DeleteRowsClass(Token,set,"Sales","Product");
            //string r = deleterow.DeleteRows();

            //GetGroupsClass getgroup = new GetGroupsClass(Token);
            //Groups grs = getgroup.GetGroups(set);
            //group[] g = grs.value;
            //foreach (group gr in g)
            //{
            //    Console.WriteLine(gr.GrId + " | " + gr.GrName);
            //    Console.ReadKey();
            //}

            //DatasetRefreshClass ds = new DatasetRefreshClass(Token, set, "Microsoft Data Visualization");
            //string s = ds.datasetrefresh();
            //Console.WriteLine("Response : "+ s);
            //Console.ReadKey();

            // ExcelRowAdd xl = new ExcelRowAdd();
        }
    }
    public class Datasets
    {
        public dataset[] value { get; set; }
    }

    public class dataset
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Tables
    {
        public table[] value { get; set; }
    }

    public class table
    {
        public string Name { get; set; }
    }

    public class Groups
    {
        public group[] value { get; set; }
    }

    public class group
    {
        public string GrId { get; set; }
        public string GrName { get; set; }
        public bool IsReadOnly { get; set; }
    }
}
