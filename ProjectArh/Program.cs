using LogicManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Models;

namespace ProjectArh
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderManager = new OrderManager();
            //var orderList=orderManager.GetAllOrders();
            //foreach(var ord in orderList)
            //{
            //    Console.WriteLine(ord);
            //}

            var customerManager = new CustomerManager();
            //var customersList=customerManager.GetAllCustomers();
            //foreach(var customer in customersList)
            //{
            //    Console.WriteLine(customer);
            //}

            //Console.WriteLine(customerManager.GetCustomerById(18));

            //var ordersByName = orderManager.GetOrdersByCustomerName("Bulkin A.V.");
            //foreach (var o in ordersByName)
            //{
            //    Console.WriteLine(o);
            //}

            //var ordersByView=orderManager.GetOrdersByView();
            //foreach (var order in ordersByView)
            //{
            //    Console.WriteLine(order);
            //}

            //var order = new Order(0, new DateTime(2020, 05, 29), new DateTime(2020, 05, 30), 18, 3, 1, 5, 120);
            //var insertOrder = orderManager.InsertOrder(order);
            //Console.WriteLine(insertOrder);

            //Console.WriteLine(customerManager.DeleteCustomer(19));

            //var ordersByDate = orderManager.GetOrdersByDate(new DateTime(2020, 05, 29));
            //foreach (var order in ordersByDate)
            //{
            //    Console.WriteLine(order);
            //}
        }

    }
}
