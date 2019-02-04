using System;
using System.Collections.Generic;

namespace AdapterPattern
{
    class MainClass
    {
        // Problem to solve
        // Convert from one object to the other similar convert. 
        // just like the adapter we use when travelling to different country 
        // 220w to 200w.  The adapter is the convert between the power
        // outlet and the electrical appliances.

        // Assume we have receive a customer object from the web service.
        // We are using CustomerDTO (Data transfer object) to create an 
        // DTO object with the data coming from webservice then
        // we use the CustomerAdapter to add / get the customerDTO object
        // to the customer object in the database.

        private static int _customerID = 1;
        private static ICustomerList _customerList = new CustomerAdapter();

        public static void Main(string[] args)
        {
            int i = 1;
            while (i < 5)
            {
                AddCustomerToList();
                i++;
            }

            List<Customer> customers = new List<Customer>();
            customers = _customerList.GetCustomer();
            foreach (var customer in customers)
            {   
                Console.WriteLine(customer.Name);
           
            }
            Console.Read();

        }


        private static void AddCustomerToList()
        {
            CustomerDTO customer = new CustomerDTO()
            {
                ID = _customerID,
                FirstName = "Customer",
                LastName = _customerID.ToString(),
                Address = "",
                City = "",
                PostCode = "",
                State = ""
            };

            _customerList.AddCustomer(customer);
            _customerID++;
        }

    }
}
