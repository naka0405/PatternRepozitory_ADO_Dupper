using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Models
{
    public class Order
    {
        public Order()
        {

        }
        public Order(int id, DateTime orderDate, DateTime shipDate, int customerId,  int prodId, int shipId, int quant, decimal profit, string customerName = default)
        {
            Order_Id = id;
            Order_Date = orderDate;
            Ship_Date = shipDate;
            Customer_Id = customerId;            
            Product_Id = prodId;
            Ship_Id = shipId;
            Quantity = quant;
            OrderProfit = profit;
            Customer_Name = customerName;
        }
        public Order(DateTime orderDate, DateTime shipDate, int customerId, int prodId, int shipId, int quant, decimal profit)
        {           
            Order_Date = orderDate;
            Ship_Date = shipDate;
            Customer_Id = customerId;
            Product_Id = prodId;
            Ship_Id = shipId;
            Quantity = quant;
            OrderProfit = profit;           
        }
        public Order(int id, string city, string name, string prodName )
        {
            Order_Id = id;
            CityName = city;
            Customer_Name = name;
            Product_Name = prodName;

        }
        public int Order_Id { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime Ship_Date { get; set; }
        public int Customer_Id { get; set; }
        public int Product_Id { get; set; }
        public int Ship_Id { get; set; }
        public int Quantity { get; set; }
        public decimal OrderProfit { get; set; }
        public string Customer_Name { get; set; }
        public string Product_Name { get; set; }
        public string CityName { get; set; }

        public override string ToString()
        {
            return $"#{Order_Id,3}|{Order_Date.ToShortDateString(),10}|{Ship_Date.ToShortDateString(),10}|city: {CityName}| customer:{Customer_Id,3}-{Customer_Name}|product:{Product_Id,3}-{Product_Name}|{Ship_Id,3}|quantity:{Quantity,3}|profit:{OrderProfit}";
        }
    }
}
