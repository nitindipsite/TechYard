using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JunkYard.E;

namespace IEnumerable
{
    public class LinqExample
    {

        public LinqExample()
        {
            _customer = new List<Customer>()
            {
                new Customer() {Name = "Manik Roy", Designation = "Test Manager", City = ""},
                new Customer {Name = "Nitin Bhartiya", Designation = "SDET 2", City = ""},
                new Customer {Name = "Sushovan Sarkar", Designation = "SDE 2", City = ""},
                new Customer {Name = "Saurabh Mehta", Designation = "PM Lead", City = ""}
            };
        }

        private List<Customer> _customer;
        public List<Customer> Customers
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public void AddCustomer(Customer cust)
        {
            _customer.Add(cust);
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public string City { get; set; }
    }

}
