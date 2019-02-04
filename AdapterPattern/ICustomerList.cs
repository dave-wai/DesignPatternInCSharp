using System;
using System.Collections.Generic;

namespace AdapterPattern
{
    public interface ICustomerList
    {
        List<Customer> GetCustomer();
        void AddCustomer(CustomerDTO customer);
    }
}
