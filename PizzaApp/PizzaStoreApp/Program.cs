using System;
using System.Collections.Generic;
using PizzaStoreDetails;
using PizzaStoreData;

namespace PizzaStoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Customers customer = new Customers();
            List<Customers> listCustomer = customer.InitCustomer();
            string ConfirmMsg = customer.AddInitCustomer(listCustomer);
            Console.WriteLine(ConfirmMsg);

            Inventory inventoryObj = new Inventory();
            var Inventorydict = inventoryObj.InitInventory();
            inventoryObj.AddInitInventory(Inventorydict);

            OrderHistory historyObj = new OrderHistory();
            var HistoryData = historyObj.InitOrderHistory();
            historyObj.AddInitOrderHistory(HistoryData);

            Console.WriteLine("\n\t-----------Welcome to Pizza Store----------");
            /// <summary>
            /// This loop takes input from user and print those details in the formatted way
            /// </summary>
            while (true)
            {
                Console.WriteLine("\n--Press<1> New Customer\n--Press<2> Already Customer\n--Press<3> Check Order History\n--Press<4> Check Total Order History\n--Press<5> Exit");
                Console.WriteLine("\nEnter your choice:");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        customer.GetCustomerDetails();
                        customer.AddCustomerDetails(customer);

                        break;
                    case "2":
                        customer.SearchCustomerByID();
                        break;
                    case "3":
                        historyObj.GetHistoryByID();
                        break;
                    case "4":
                        historyObj.GetTotalHistory();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("\n-------------------------------------------------\nThanks for Visit us...Have a Nice Day\n-------------------------------------------------");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice!..Enter option again");
                        break;
                }
            }
        }
    }
}
