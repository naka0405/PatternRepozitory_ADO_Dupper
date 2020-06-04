using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Interfaces;
using Utils.Models;

namespace DataAccessDupper
{
    public class DupperRealization : IOrderRepoz, ICustomerRepoz
    {
        private readonly string connection = string.Empty;
        public DupperRealization()
        {
            connection = ConfigurationManager.ConnectionStrings["HRSQLProvider"].ConnectionString;
        }
        public int DeleteCustomer(int id)
        {
            using (SqlConnection sqlConnect = new SqlConnection(connection))
            {
                var deletionQuery = "Delete from customers where customer_id=@id";
                var numOfAffectedRows = sqlConnect.Execute(deletionQuery, new { id = id });

                return numOfAffectedRows;
            }
        }

        public IList<Customer> GetAllCustomers()
        {
            var sqlConnection = new SqlConnection(connection);
            var selection = "Select * from dbo.customers";
            var customers = sqlConnection.Query<Customer>(selection).AsList();

            return customers;
        }

        public IList<Order> GetAllOrders()
        {
            var sqlConnection = new SqlConnection(connection);
            var selection = "Select * from dbo.orders";
            var orders = sqlConnection.Query<Order>(selection).AsList();

            return orders;
        }

        public Customer GetCustomerById(int id)
        {
            var sqlConnection = new SqlConnection(connection);
            var selectionString = "Select * from customers where customer_id=@id";
            var customerById = sqlConnection.QuerySingle<Customer>(selectionString, new { @id = id });
            return customerById;
        }

        public IList<Order> GetOrdersByCustomName(string name)
        {
            var sqlConnection = new SqlConnection(connection);
            var selectionString = "Select o.*, c.customer_name from orders o , customers c " +
                " where o.customer_id=c.customer_id and customer_name=@name";

            var ordersByName = sqlConnection.Query<Order>(selectionString, new { @name = name }).AsList();
            return ordersByName;
        }

        public IList<Order> GetOrdersByDate(DateTime date)
        {
            var sqlConnection = new SqlConnection(connection);
            var selectionString = "Select o.*, c.customer_name from orders o , customers c " +
                " where o.customer_id=c.customer_id and order_date=@date";

            var ordersByDate = sqlConnection.Query<Order>(selectionString, new { @date = date }).AsList();
            return ordersByDate;
        }

        public IList<Order> GetOrdersByView()
        {
            throw new NotImplementedException();
        }

        public int InsertOrder(Order order)
        {
            var sqlConnection = new SqlConnection(connection);
            var newOrderRow = "Insert into orders(order_date, ship_date, customer_id, product_id, ship_id, quantity, orderProfit) values (@Order_Date, @Ship_Date, @Customer_Id, @Product_Id, @Ship_Id, @Quantity, @OrderProfit)";//sqlConnection.CreateCommand(;
            var insertStr = sqlConnection.Execute(newOrderRow, new
            {
                //@Order_id = order.Order_Id,
                @order_date = order.Order_Date,
                @Ship_date = order.Ship_Date,
                @customer_id = order.Customer_Id,
                @product_id = order.Product_Id,
                @ship_id = order.Ship_Id,
                @quantity = order.Quantity,
                @orderProfit = order.OrderProfit
            });

            return insertStr;
        }
    }
}
