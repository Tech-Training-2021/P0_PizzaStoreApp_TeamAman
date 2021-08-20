using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace PizzaStoreData
{
    public class Inventory
    {
        /// <summary>
        /// Giving a path here where the default Inventory will get created and will have data stored in json format
        /// </summary>
        static string path = @"..\..\..\..\DataFiles\ItemsInventory.json";

       static Dictionary<string, int> PizzaInventory = null;

        /// <summary>
        /// We are creating a dictionary here and storing the quantity of each Pizza available at the store location
        /// </summary>
        /// <returns>Dictionary</returns>
        public Dictionary<string,int> InitInventory()
        {
            PizzaInventory = new Dictionary<string, int>()
            {
                [PizzaType.CHINESE_PIZZA.ToString()]=40,
                [PizzaType.THIN_CRUST.ToString()] = 80,
                [PizzaType.VEGGIE_PARADISE.ToString()] = 53,
                [PizzaType.MEXICAN_GREEWAVE.ToString()] = 59,
                [PizzaType.CHICKEN_DOMINATOR_PIZZA.ToString()] = 48,
                [PizzaType.CHICKEN_SAUSAGE_PIZZA.ToString()] = 73,
                [PizzaType.CHICKEN_GOLDEN.ToString()] = 60,
            };
            return PizzaInventory;
        }

        /// <summary>
        /// This function is Adding the Default data into Inventory.json file
        /// </summary>
        /// <param name="dict"></param>
        public void AddInitInventory(Dictionary<string, int> dict)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(path);
                writer.Write(JsonConvert.SerializeObject(dict));
                Console.WriteLine("Default Inventory Added to Inventory.json file");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File Not Found " + e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Directory Not Found : " + e.Message);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// This function helps us in updating out inventory file based on the pizza we sold, the quantity gets decreased as the number of pizza are getting sold
        /// </summary>
        /// <param name="NameOfPizza"></param>
        public static void UpdateInventory(string NameOfPizza)
        {
            int data;
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(path);
                var jsonData = JsonConvert.SerializeObject(PizzaInventory);
                var DictData = JsonConvert.DeserializeObject<IDictionary<string, int>>(jsonData);
                foreach (var entry in DictData)
                {
                    if (NameOfPizza == entry.Key)
                    {
                        data = entry.Value-1;
                        PizzaInventory[NameOfPizza] = data;
                    } 
                }
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("File Not Found "+e.Message);
            }
            finally
            {
                reader.Close();
            }
            //updating file
            TextWriter writer = null;
            try
            {
                writer = new StreamWriter(path);
                writer.Write(JsonConvert.SerializeObject(PizzaInventory));
            }
            catch (FileNotFoundException e) 
            {
                Console.WriteLine("File Not Found "+e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Directory Not Found " + e.Message);
            }
            finally
            {
                writer.Close();
            }
        }
    }  
}
