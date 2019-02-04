using System;
using System.Collections.Generic;

namespace AdapterPattern
{
    public class CustomerAdapter : ICustomerList
    {
        private List<Customer> _customers = new List<Customer>();

        public void AddCustomer(CustomerDTO customer)
        {
            _customers.Add(new Customer() {
                CustomerID = customer.ID,
                Name = customer.FirstName + " " + customer.LastName,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                Zip = customer.PostCode
            });
        }

        public List<Customer> GetCustomer()
        {
            return _customers;
        }
    }
}
