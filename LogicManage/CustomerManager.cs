using DataAccessADO;
using DataAccessDupper;
using System;
using System.Collections.Generic;
using Utils.Interfaces;
using Utils.Models;

namespace LogicManage
{
    public class CustomerManager
    {
        private readonly ICustomerRepoz customerRepozitory;
        public CustomerManager()
        {
            customerRepozitory = new DupperRealization();// new ADORealization();
            
        }
        
        public IList<Customer> GetAllCustomers()
        {
            return customerRepozitory.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            return customerRepozitory.GetCustomerById(id);
        }

        public int DeleteCustomer(int id)
        {
            return customerRepozitory.DeleteCustomer(id);
        }
    }
}
