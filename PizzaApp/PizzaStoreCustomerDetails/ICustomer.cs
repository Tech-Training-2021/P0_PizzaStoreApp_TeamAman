using System;
using System.Collections.Generic;


namespace PizzaStoreDetails
{
    interface ICustomer
    {
        public double ID { set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        Gender Gender { get; set; }
       // void AddCustomer(Customers customer);
    }
    /// <summary>
    /// Gender enumeration
    /// </summary>
    public enum Gender
    {
        Male=0,
        Female
    }
}
