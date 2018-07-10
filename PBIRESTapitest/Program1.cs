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
            int i;
            Console.WriteLine("MENU");
            do
            {
                Console.WriteLine("Press 1 to get the list of datasets.\nPress 2 to get the list of groups\nPress 3 to create a new dataset\nPress 4 to add a new row\nPress 5 to delete all rows\nPress 6 to Initiate RandomSales\nPress 0 to exit\nEnter your choice : ");
                i = Convert.ToInt32(Console.ReadLine());

                switch (i)
                {
                    case 1:
                            GetDatasetsClass getdatasets = new GetDatasetsClass(Token);
                            dataset[] set = getdatasets.GetDatasets();
                            foreach (dataset d in set)
                            {
                                Console.WriteLine(d.Id + " | " + d.Name);
                            }
                        break;
                    case 2:
                        GetDatasetsClass getdatasetsGr = new GetDatasetsClass(Token);
                        dataset[] setGr = getdatasetsGr.GetDatasets();
                        GetGroupsClass getgroup = new GetGroupsClass(Token);
                        Groups grs = getgroup.GetGroups(setGr);
                        group[] g = grs.value;
                        foreach (group gr in g)
                        {
                            Console.WriteLine(gr.GrId + " | " + gr.GrName);
                        }
                        break;
                    case 3:
                        //CreateDatasetClass dataset1 = new CreateDatasetClass(Token);
                        //string str = dataset1.CreateDataset("product");
                        //Console.WriteLine("dataset " + str);
                        
                        //CreateDatasetClass dataset2 = new CreateDatasetClass(Token);
                        //str = dataset2.CreateDataset("user");
                        //Console.WriteLine("dataset " + str);
                        
                        CreateDatasetClass dataset3 = new CreateDatasetClass(Token);
                        string str = dataset3.CreateDataset("sales");
                        Console.WriteLine("dataset " + str);
                        
                        break;
                    case 4:
                        GetDatasetsClass getdatasets_addRow = new GetDatasetsClass(Token);
                        dataset[] setAddRow = getdatasets_addRow.GetDatasets();
                        //AddRowsClass addrow = new AddRowsClass(Token, setAddRow, "Sales", "Product");
                        //string[] ProdName = { "Shampoo", "Razor", "Shaving Cream", "Brush", "Toilet Paper", "Cream", "Hair Gel", "Mirror", "Hand Sanitizer" };
                        //Int64[] ProdPrice = { 200, 150, 250, 60, 80, 430, 70, 500, 200 };
                        //for (int p = 0; p < ProdName.Length; p++)
                        //{
                        //    addrow.AddRows(p + 1, ProdName[p], ProdPrice[p]);
                        //}
                        //AddRowsClass addrow = new AddRowsClass(Token, setAddRow, "Sales", "Sales");
                        break;
                    case 5:
                        GetDatasetsClass getdatasets_delRow = new GetDatasetsClass(Token);
                        dataset[] setDelRow = getdatasets_delRow.GetDatasets();
                        DeleteRowsClass deleterow = new DeleteRowsClass(Token, setDelRow, "Users", "Person");
                        string r = deleterow.DeleteRows();
                        break;
                    case 6:
                        //Generate random sales
                        GetDatasetsClass GetDataSet = new GetDatasetsClass(Token);
                        dataset[] DataSets = GetDataSet.GetDatasets();
                        RandomSale rs = new RandomSale();
                        for (int count = 1; count < 100; count++)
                        {
                            rs.RandomSales(Token, DataSets);
                        }

                        break;
                    default:
                        i = 0;
                        break;
                }

            } while (i != 0);


            //CreateDatasetClass dataset = new CreateDatasetClass(Token);
            //string str = dataset.CreateDataset();
            //Console.WriteLine("dataset " + str);
            //Console.ReadKey();



            //GetDatasetsClass getdatasets = new GetDatasetsClass(Token);
            //dataset[] set = getdatasets.GetDatasets();
            //foreach (dataset d in set)
            //{
            //    Console.WriteLine(d.Id + " | " + d.Name);
            //    Console.ReadKey();
            //}

            //AddRowsClass addrow = new AddRowsClass(Token,set, "Sales", "Product");
            //string[] ProdName = { "Shampoo", "Razor", "Shaving Cream", "Brush", "Toilet Paper", "Cream", "Hair Gel", "Mirror", "Hand Sanitizer" };
            //Int64[] ProdPrice = { 200, 150, 250, 60, 80, 430, 70, 500, 200 };
            //for (int i = 0; i < ProdName.Length; i++)
            //{
            //    addrow.AddRows(i + 1, ProdName[i], ProdPrice[i]);
            //}

            //DeleteRowsClass deleterow = new DeleteRowsClass(Token, set, "Sales", "Product");
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