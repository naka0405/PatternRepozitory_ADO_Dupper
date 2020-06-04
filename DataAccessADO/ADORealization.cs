using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Interfaces;
using Utils.Models;

namespace DataAccessADO
{
    public class ADORealization : IOrderRepoz,ICustomerRepoz
    {
        private readonly string connection = string.Empty;
        public ADORealization()
        {
            connection = ConfigurationManager.ConnectionStrings["HRSQLProvider"].ConnectionString;
        }

        public int DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetAllCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            var selectionStr = "Select * from dbo.customers";
            var adapter = new SqlDataAdapter(selectionStr, connection);
            var customerSet = new DataSet();
            adapter.Fill(customerSet, "Customers");
            foreach(DataRow row in customerSet.Tables[0].Rows)
            {
                customerList.Add(new Customer(
                    (int)row[0],
                    (string) row[1],
                    (int)row[2],
                    (int)row[3],
                    (int)row[4]));
            }

            return customerList;
        }

        public IList<Order> GetAllOrders()
        {
            List<Order> orderList = new List<Order>();
            var selString= "Select * from dbo.orders";
            var adapter = new SqlDataAdapter(selString, connection);
            var orders = new DataSet();
            adapter.Fill(orders, "Orders");
            foreach(DataRow row in orders.Tables[0].Rows)
            {
                orderList.Add(new Order(
                    (int)row[0],
                    (DateTime)row[1],
                    (DateTime)row[2],
                    (int)row[3],
                    (int)row[4],
                    (int)row[5],
                    (int)row[6],
                    (decimal)row[7]));
            };
            return orderList;
        }

        public Customer GetCustomerById(int id)
        {
            var selCustomer = new Customer();
            var selectionString = "Select * from customers where customer_id=@id";
            var adapter = new SqlDataAdapter();
            var connect = new SqlConnection(connection);
            adapter.SelectCommand = new SqlCommand(selectionString, connect);
            adapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int);
            adapter.SelectCommand.Parameters[0].Value = id;

            var customerSet = new DataSet();
            adapter.Fill(customerSet, "Customers");
            foreach(DataRow row in customerSet.Tables[0].Rows)
            {
                selCustomer=new Customer(
                    (int)row[0],
                    (string)row[1],
                    (int)row[2],
                    (int)row[3],
                    (int)row[4]
                   );
            };
            return selCustomer;
        }

        public IList<Order> GetOrdersByCustomName(string name)
        {
            var ordersList = new List<Order>();
            var selectString = "Select o.*, c.customer_name from orders o , customers c " +
                "where customer_name  = '@name' and o.customer_id = c.customer_id";
            var connect = new SqlConnection(connection);
            var adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(selectString, connect);
            adapter.SelectCommand.Parameters.Add("@name", SqlDbType.VarChar);
            adapter.SelectCommand.Parameters[0].Value = name;
            var orderSet = new DataSet();
            adapter.Fill(orderSet,"Customers");
            foreach (DataRow row in orderSet.Tables[0].Rows)
            {
                ordersList.Add(new Order(                   
                    (int)row[0],
                    (DateTime)row[1],
                    (DateTime)row[2],
                    (int)row[3],
                    (int)row[4],
                    (int)row[5],
                    (int)row[6],
                    (decimal)row[7],
                    (string)row[8]));               
            };
            return ordersList;
        }

        public IList<Order> GetOrdersByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IList<Order> GetOrdersByView()
        {
            List<Order> orderList = new List<Order>();
            var selString = "Select * from OrdersInfo";
            var adapter = new SqlDataAdapter(selString, connection);
            var orders = new DataSet();
            adapter.Fill(orders, "OrdersInfo");
            foreach (DataRow row in orders.Tables[0].Rows)
            {
                orderList.Add(new Order(
                    (int)row[0],
                    (string)row[1],
                    (string)row[2],
                    (string)row[3]));                  
            };
            return orderList;
        }

        public int InsertOrder(Order order)
        {
            using (SqlConnection scn = new SqlConnection(connection))
            {
                scn.Open();
                var insertion = String.Format("Insert into orders values ('{0}', '{1}', '{2}',{3}, {4}, {5}, {6})",  order.Order_Date, order.Ship_Date, order.Product_Id, order.Customer_Id, order.Ship_Id, order.Quantity, order.OrderProfit);

                var command = new SqlCommand(insertion, scn);
                int number = command.ExecuteNonQuery();
                scn.Close();
                return number;
            }            
        }
    }
}
