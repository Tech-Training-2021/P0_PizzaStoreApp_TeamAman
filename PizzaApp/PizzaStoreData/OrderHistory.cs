using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PizzaStoreData
{
    /// <summary>
    /// This class will generate Order History for the customer 
    /// </summary>
    public class OrderHistory
    {
        static string path = @"..\..\..\..\DataFiles\RecordOrderHistory.json";
        public static Dictionary<int,List<string>> TotalOrderHistory=null;
        public static string AdminPass = "@123";
        /// <summary>
        /// This method is creating and initializing values to a dictionary
        /// </summary>
        /// <returns>Dictionary</returns>
        public Dictionary<int,List<string>> InitOrderHistory()
        {
            TotalOrderHistory = new Dictionary<int,List<string>>()
            {
                {1,new List<string>() {"Customer Name : Bob Jassy \nPizza Name:CHINESE_PIZZA, THIN_CRUST \nTotal Bill = 150rs", "Customer Name : Bob Jassy \nPizza Name:CHINESE_PIZZA, THIN_CRUST \nTotal Bill = 400rs" } },
                {2,new List<string>() {"Customer Name : Alice Den \nPizza Name:THIN_CRUST \nTotal Bill = 200rs"} },
                {3,new List<string>() {"Customer Name : Nancy Maris \nPizza Name:CHICKEN_GOLD \nTotal Bill = 800rs"} },
            };
            return TotalOrderHistory;
        }

        /// <summary>
        /// Adding the initial / default values in the path specified
        /// </summary>
        /// <param name="OrderDict"></param>
        public void AddInitOrderHistory(Dictionary<int,List<string>> OrderDict)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(OrderDict);
                File.WriteAllText(path, jsonData);
                Console.WriteLine("History File Created");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File Not Found " + e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Directory Not Found : " + e.Message);
            }
        }

        /// <summary>
        /// This method is responsible for updating the order history file by taking orders from the user and appending the data accordingly
        /// </summary>
        /// <param name="userId will store the key"></param>
        /// <param name="historyData will store value"></param>
        public void AddNewOrderHistory(List<List<string>> historyData,double userId)
        {
            List<string> pizzaNameAndBill = new List<string>();
            string pizzaNames="";
            int Bill = 0;

            for (int j = 0; j < historyData[0].Count; j++)
                    pizzaNames += " " + historyData[0][j];
            for(int j=0;j<historyData[1].Count;j++)
                    Bill += int.Parse(historyData[1][j]);
           
            string FileData = File.ReadAllText(path);
            var jsonData = JsonConvert.DeserializeObject<IDictionary<int,List<string>>>(FileData);
           
            List<string> HistData = new List<string>();
            foreach(var entry in jsonData)
            {
                if(entry.Key == Convert.ToInt32(userId)){
                    for(int i = 0; i < entry.Value.Count; i++)
                    {
                        HistData.Add(entry.Value[i]);
                    }
                }
            }
            HistData.Add($"Customer Name: AAA \nPizza Name : {pizzaNames} \nTotal Bill = {Bill}rs");
            TotalOrderHistory[Convert.ToInt32(userId)] = HistData;
            try
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(TotalOrderHistory));
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File Not Found " + e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Directory Not Found : " + e.Message);
            }
        }

        /// <summary>
        /// This method will generate Order History by accessing customer's unique ID
        /// </summary>
        public void GetHistoryByID()
        {
            int flag = 0;
            Console.WriteLine("Enter your ID to check History");
            int id = int.Parse(Console.ReadLine());
            string FileData = File.ReadAllText(path);
            var jsonData = JsonConvert.DeserializeObject<IDictionary<int, List<string>>>(FileData);
           
            foreach (var entry in jsonData)
            {
                if (entry.Key == id)
                {
                    flag += 1; 
                    for (int i = 0; i < entry.Value.Count; i++)
                    {
                            Console.WriteLine($"\n---------------------------------------------\n\t\tRecord-{i + 1}\n---------------------------------------------\n{entry.Value[i]}\n---------------------------------------------\n");
                    }  
                }
            }
            if(flag==0)
                Console.WriteLine($"No Order Found with ID {id}...Please Order Now!!");
        }

        public void GetTotalHistory()
        {
            Console.WriteLine("Enter Admin Password");
            string Pass = Console.ReadLine();
            Console.Clear();
            if (Pass == AdminPass)
            {
                string FileData = File.ReadAllText(path);
                var jsonData = JsonConvert.DeserializeObject<IDictionary<int, List<string>>>(FileData);
                int TotalCustomer = 0;
                foreach (var entry in jsonData)
                {
                    TotalCustomer += 1;
                    Console.WriteLine($"\t>>>>>  Customer {TotalCustomer} Records  <<<<<");
                    for (int i = 0; i < entry.Value.Count; i++)
                    {
                            Console.WriteLine($"\n---------------------------------------------\n\t\tRecord-{i + 1}\n---------------------------------------------\n{entry.Value[i]}\n---------------------------------------------\n");  
                    }
                }
            }
            else
                Console.WriteLine("Invalid Credentials");
        }
    }
}
