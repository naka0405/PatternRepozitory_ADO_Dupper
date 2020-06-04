using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Models;

namespace Utils.Interfaces
{
    public interface ICustomerRepoz
    {
        Customer GetCustomerById(int id);
        IList<Customer>GetAllCustomers();
        int DeleteCustomer(int id);
    }
}
