using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaStoreData
{
    /// <summary>
    /// This method is shadowing its parent's method by hiding its implementation. With new keyword we hide the implementation of the base class, this is why we call it as method hiding
    /// </summary>
    /// <returns>string format</returns>
    public class PizzaOrders:ShowMenu,IOrders
    {
        List<string> ListPizzanames = new List<string>();
        List<string> ListPizzaSizes = new List<string>();
        List<List<string>> ListPizzaToppings = new List<List<string>>();
        List<string> ListOfBills = new List<string>();
        List<List<string>> HistoryData = new List<List<string>>();
        public double UserId=2;
        /// <summary>
        /// Getter setter properties to get and set the values for taking order
        /// </summary>
        // Inventory inventoryObj = new Inventory();
        public string PizzaNames
        {
            get
            {
                return pizzaName;
            }
            set
            {
                pizzaName = value;
            }
        }
        public string PizzaSizes
        {
            get
            {
                return pizzaSize;
            }
            set
            {
                pizzaSize = value;
            }
        }
        public string PizzaToppings
        {
            get
            {
                return pizzaTopping;
            }
            set
            {
                pizzaTopping = value;
            }
        }

        /// <summary>
        /// This method is just taking user inputs and returning nothing
        /// </summary>
        /// <param name="Id"></param>
        /// <return>void</return>
        public void TakePizzaOrder(double Id)
        {
            //UserId = Id;
            Console.WriteLine("Enter Pizza Choices");
            pizzaName = Console.ReadLine();
            foreach (var input in pizzaName.Split(" "))
            {
                if (input == "1")
                    ListPizzanames.Add($"{PizzaType.CHINESE_PIZZA}");
                else if (input == "2")
                    ListPizzanames.Add($"{PizzaType.THIN_CRUST}");
                else if (input == "3")
                    ListPizzanames.Add($"{PizzaType.VEGGIE_PARADISE}");
                else if (input == "4")
                    ListPizzanames.Add($"{PizzaType.MEXICAN_GREEWAVE}");
                else if (input == "5")
                    ListPizzanames.Add($"{PizzaType.CHICKEN_DOMINATOR_PIZZA}");
                else if (input == "6")
                    ListPizzanames.Add($"{PizzaType.CHICKEN_SAUSAGE_PIZZA}");
                else
                    ListPizzanames.Add($"{PizzaType.CHICKEN_GOLDEN}");
            }

            Console.WriteLine("Choose Size for each Pizza");
            Console.WriteLine("1 for Small\n2 for Medium\n3 for Large");
            for (int i = 0; i < ListPizzanames.Count; i++)
            {
                Console.WriteLine($"Enter Size for {ListPizzanames[i]}");
                pizzaSize = Console.ReadLine();

                if (pizzaSize == "1")
                    ListPizzaSizes.Add($"{PizzaSize.Small}");
                else if (pizzaSize == "2")
                    ListPizzaSizes.Add($"{PizzaSize.Medium}");
                else
                    ListPizzaSizes.Add($"{PizzaSize.Large}");
            }

            Console.WriteLine("Choose Toppings for each Pizza");
            Console.WriteLine("1 for Pepperoni\n2 for Sausage\n3 for Capsicum\n4 for Mushrooms");

            for (int i = 0; i < ListPizzanames.Count; i++)
            {
                Console.WriteLine($"Toppings for {ListPizzanames[i]}?");
                pizzaTopping = Console.ReadLine();
                List<string> tempToppings = new List<string>();
                foreach (var input in pizzaTopping.Split(" "))
                {
                    if (input == "1")
                        tempToppings.Add("Pepperoni");
                    else if (input == "2")
                        tempToppings.Add("Sausage");
                    else if (input == "3")
                        tempToppings.Add("Capsicum");
                    else
                        tempToppings.Add("Mushrooms");
                }
                ListPizzaToppings.Add(tempToppings);
            }
        }

        /// <summary>
        /// This method is responsible for mathematical calculations and calling the UpdateInventory function to make changes
        /// </summary>
        public void CalculateTotalBill()
        {
            int TotalBill = 0;
            for (int i = 0; i < ListPizzanames.Count; i++)
            {
                if (ListPizzanames[i] == PizzaType.CHINESE_PIZZA.ToString())
                {
                    Inventory.UpdateInventory("CHINESE_PIZZA");
                    if (ListPizzaSizes[i] == PizzaSize.Small.ToString())
                    {
                        TotalBill += 110;
                    }
                    else if (ListPizzaSizes[i] == PizzaSize.Medium.ToString())
                    {
                        TotalBill += 180;
                    }
                    else
                    {
                        TotalBill += 240;
                    }
                }
                else if (ListPizzanames[i] == PizzaType.THIN_CRUST.ToString())
                {
                    Inventory.UpdateInventory("THIN_CRUST");
                    if (ListPizzaSizes[i] == PizzaSize.Small.ToString())
                    {
                        TotalBill += 30;
                    }
                    else if (ListPizzaSizes[i] == PizzaSize.Medium.ToString())
                    {
                        TotalBill += 45;
                    }
                    else
                    {
                        TotalBill += 60;
                    }
                }
                else if (ListPizzanames[i] == PizzaType.VEGGIE_PARADISE.ToString())
                {
                    Inventory.UpdateInventory("VEGGIE_PARADISE");
                    if (ListPizzaSizes[i] == PizzaSize.Small.ToString())
                    {
                        TotalBill += 50;
                    }
                    else if (ListPizzaSizes[i] == PizzaSize.Medium.ToString())
                    {
                        TotalBill += 70;
                    }
                    else
                    {
                        TotalBill += 90;
                    }
                }
                else if (ListPizzanames[i] == PizzaType.MEXICAN_GREEWAVE.ToString())
                {
                    Inventory.UpdateInventory("MEXICAN_GREEWAVE");
                    if (ListPizzaSizes[i] == PizzaSize.Small.ToString())
                    {
                        TotalBill += 80;
                    }
                    else if (ListPizzaSizes[i] == PizzaSize.Medium.ToString())
                    {
                        TotalBill += 150;
                    }
                    else
                    {
                        TotalBill += 250;
                    }
                }
                else if (ListPizzanames[i] == PizzaType.CHICKEN_DOMINATOR_PIZZA.ToString())
                {
                    Inventory.UpdateInventory("CHICKEN_DOMINATOR_PIZZA");
                    if (ListPizzaSizes[i] == PizzaSize.Small.ToString())
                    {
                        TotalBill += 50;
                    }
                    else if (ListPizzaSizes[i] == PizzaSize.Medium.ToString())
                    {
                        TotalBill += 70;
                    }
                    else
                    {
                        TotalBill += 115;
                    }
                }
                else if (ListPizzanames[i] == PizzaType.CHICKEN_SAUSAGE_PIZZA.ToString())
                {
                    Inventory.UpdateInventory("CHICKEN_SAUSAGE_PIZZA");
                    if (ListPizzaSizes[i] == PizzaSize.Small.ToString())
                    {
                        TotalBill += 110;
                    }
                    else if (ListPizzaSizes[i] == PizzaSize.Medium.ToString())
                    {
                        TotalBill += 210;
                    }
                    else
                    {
                        TotalBill += 380;
                    }
                }
                else
                {
                    Inventory.UpdateInventory("CHICKEN_GOLDEN");
                    if (ListPizzaSizes[i] == PizzaSize.Small.ToString())
                    {
                        TotalBill += 130;
                    }
                    else if (ListPizzaSizes[i] == PizzaSize.Medium.ToString())
                    {
                        TotalBill += 280;
                    }
                    else
                    {
                        TotalBill += 450;
                    }
                }

                for (int j = 0; j < ListPizzaToppings[i].Count; j++)
                {
                    if (ListPizzaToppings[i][j] == "Pepperoni")
                    {
                        TotalBill += 40;
                    }
                    else if (ListPizzaToppings[i][j] == "Sausage")
                    {
                        TotalBill += 50;
                    }
                    else if (ListPizzaToppings[i][j] == "Capsicum")
                    {
                        TotalBill += 30;
                    }
                    else
                    {
                        TotalBill += 60;
                    }
                } //end for of toppings 
                ListOfBills.Add(TotalBill.ToString());
                TotalBill = 0;
            }
        }

        /// <summary>
        /// This method displays the Bill of the customer and does not return anything
        /// </summary>
        public void DisplayTotalBill()
        {
            CalculateTotalBill();
            HistoryData.Add(ListPizzanames);
            HistoryData.Add(ListOfBills);
            OrderHistory obj = new OrderHistory();

            Console.WriteLine("Enter Unique Id Again To Confirm the order");
            UserId = double.Parse(Console.ReadLine());

            obj.AddNewOrderHistory(HistoryData,UserId);
            Console.Write("\n........................................................\n");
            for (int i = 0; i < ListOfBills.Count; i++)
            {
                Console.WriteLine($"Total Price for {ListPizzanames[i]} is {ListOfBills[i]}rs");
            }
            Console.WriteLine("\t\tTotal Bill = " + ListOfBills.Sum(x => Convert.ToInt32(x)));
            Console.Write("........................................................\n");
        }
    }
}
