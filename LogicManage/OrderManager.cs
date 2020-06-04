using DataAccessADO;
using DataAccessDupper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Interfaces;
using Utils.Models;

namespace LogicManage
{
    public class OrderManager
    {
        private readonly IOrderRepoz orderRepozitory;
        
        public OrderManager()
        {
            
            orderRepozitory = new DupperRealization(); //new ADORealization();//
        }
         public IList<Order>GetAllOrders()
        {
            return orderRepozitory.GetAllOrders();
        }
       
        public IList<Order>GetOrdersByCustomerName(string name)
        {
            return orderRepozitory.GetOrdersByCustomName(name);
        }

        public IList<Order>GetOrdersByView()
        {
            return orderRepozitory.GetOrdersByView();
        }
        public int InsertOrder(Order order)
        {
            return orderRepozitory.InsertOrder(order);
        }

        public IList<Order> GetOrdersByDate(DateTime date)
        {
            return orderRepozitory.GetOrdersByDate(date);
        }
    }

}
