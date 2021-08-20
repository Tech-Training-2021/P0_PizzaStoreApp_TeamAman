using System;
using Xunit;
using PizzaStoreData;
using PizzaStoreDetails;
using PizzaStoreApp;
using System.Collections.Generic;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void AddCustomerTest()
        {
            // Assert 
            Customers c = new Customers();
            List<Customers> customer = new List<Customers>(){
                    new Customers(){id=1, fname="", lname="Jassy",location="Hyderabad",Gender=Gender.Male},
                    new Customers(){id=2, fname="Alice", lname="Den",location="Mumbai",Gender=Gender.Male},
                    new Customers(){id=3, fname="Nancy", lname="Maris",location="Surat",Gender=Gender.Female}
                };

            var data = (List<Customers>)customer;
            string actual;
            actual = c.AddInitCustomer(customer);
            string expected = "Customer Data Not Added Due to Invalid Data";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AddCustomerTest2()
        {
            // Assert 
            Customers c = new Customers();
            List<Customers> customer = new List<Customers>(){
                    new Customers(){id=1, fname="Bob", lname="Jassy",location="Hyderabad",Gender=Gender.Male},
                    new Customers(){id=2, fname="Alice", lname="Den",location="Mumbai",Gender=Gender.Male},
                    new Customers(){id=3, fname="Nancy", lname="Maris",location="Surat",Gender=Gender.Female}
                };

            var data = (List<Customers>)customer;
            string actual;
            actual = c.AddInitCustomer(customer);
            string expected = "Default Data Added to customer.xml file";
            // string expected = "Customer Data Not Added Due to Invalid Data";
            Assert.Equal(expected, actual);
        }
    }
}
