using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PBIRESTapitest
{
    class Sales
    {
        public Int64 ID { get; set; }
        public Int64 UserID { get; set; }
        public Double Total { get; set; }
        public Int64 ProductID { get; set; }
        public Int64 Qty { get; set; }
        public DateTime SellTime { get; set; }
    }
    class RandomSale {
        public void RandomSales(string Token, dataset[] setAddRow)
        {
            RandomUser ru = new RandomUser();
            var json = ru.GetSingleDummyUser();
            dynamic res = JObject.Parse(json);

            Person p = new Person();
            p.DateOfBirth = res.results[0].dob;
            p.Gender = res.results[0].gender;
            p.location = res.results[0].location.state;
            p.Name = res.results[0].name.first + " " + res.results[0].name.last;
            p.Age = DateTime.Now.Year - p.DateOfBirth.Year;
            p.ID = new Random().Next(1,500);
            AddRowsClass addrowPerson = new AddRowsClass(Token, setAddRow, "Users", "Person");
            addrowPerson.AddRows(p);

            Product prod = new Product();
            string[] ProdName = { "Shampoo", "Razor", "Shaving Cream", "Brush", "Toilet Paper", "Cream", "Hair Gel", "Mirror", "Hand Sanitizer" };
            Int64[] ProdPrice = { 200, 150, 250, 60, 80, 430, 70, 500, 200 };
            Random r = new Random();
            int i = r.Next(9);
            prod.name =ProdName[i];
            prod.price =ProdPrice[i];
            prod.ID = i;
            //AddRowsClass addrowProd = new AddRowsClass(Token, setAddRow, "Products", "Product");
            //addrowProd.AddRows(prod);

            Sales sale = new Sales();
            sale.ProductID = prod.ID;
            sale.Qty = new Random().Next(1,5);
            sale.SellTime = Convert.ToDateTime(DateTime.Now);
            sale.UserID = p.ID;
            sale.Total = sale.Qty * prod.price;
            AddRowsClass addrowSales = new AddRowsClass(Token, setAddRow, "Sales", "Sales");
            addrowSales.AddRows(sale);
            //Thread.Sleep(new Random().Next(1,60000));
        }
    }
}
