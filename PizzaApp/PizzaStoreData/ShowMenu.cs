using System;
using System.IO;
using System.Linq;
namespace PizzaStoreData
{
    public class ShowMenu
    {
        public static double Uid;
        protected string pizzaName, pizzaSize, pizzaTopping;
        string path = @"..\..\..\..\DataFiles\Menu.txt";

        /// <summary>
        /// This method Displays Menu of the Pizza
        /// </summary>
        public void ShowPizzaMenu()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("\t\t------Menu for Pizza's------");
            Console.WriteLine("----------------------------------------------------------------------\n");

            using StreamReader reader = new StreamReader(path);
            var menu = reader.ReadToEnd();
            Console.WriteLine(menu);
            Console.WriteLine("-----------------------------------------------------------------------");

            PizzaOrders pizzaorder = new PizzaOrders();
            pizzaorder.TakePizzaOrder(Uid);
            pizzaorder.DisplayTotalBill();
        }
    }
}
