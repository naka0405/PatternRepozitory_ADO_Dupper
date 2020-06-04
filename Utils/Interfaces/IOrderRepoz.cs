using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Models;

namespace Utils.Interfaces
{
    public interface IOrderRepoz
    {
        IList<Order> GetAllOrders();
        IList<Order> GetOrdersByView();//через view
        IList<Order> GetOrdersByCustomName(string name);
        IList<Order> GetOrdersByDate(DateTime date);//через хранимую процедуру
        int InsertOrder(Order order);

    }
}
