using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using PizzaStoreData;

namespace PizzaStoreDetails
{

    public class Customers : ICustomer
    {
        public double id;
        string fname, lname, location;
        Gender gender;
        string path = @"..\..\..\..\DataFiles\Customers.xml";
        // string path = @"..\DataFiles\Customers.xml";

        public double ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string FirstName
        {
            get
            {
                return fname;
            }
            set
            {
                fname = value;
            }
        }
        public string LastName
        {
            get
            {
                return lname;
            }
            set
            {
                lname = value;
            }
        }
        public Gender Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }

        static List<Customers> customer = null;
        //List<Customers> newCustomer = null;

        /// <summary>
        /// This method is creating and initializing values to a List
        /// </summary>
        /// <returns>list</returns>
        public List<Customers> InitCustomer()
        {
            customer = new List<Customers>(){
                    new Customers(){id=1, fname="Bob", lname="Jassy",location="Hyderabad",Gender=Gender.Male},
                    new Customers(){id=2, fname="Alice", lname="Den",location="Mumbai",Gender=Gender.Male},
                    new Customers(){id=3, fname="Nancy", lname="Maris",location="Surat",Gender=Gender.Female}
                };
            return customer;
        }

        /// <summary>
        /// Adding the initial / default values in the path specified
        /// </summary>
        /// <param name="customer"></param>
        //adding default customers
        public void AddInitCustomer(List<Customers> customer)
        {
                using // FileStream file = new FileStream(path, FileMode.OpenOrCreate);
                StreamWriter writer = new StreamWriter(path);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Customers>));
                serializer.Serialize(writer, customer);
                writer.Close();
            
            Console.WriteLine("Default Data Added to customer.xml file");
        }

        /// <summary>
        /// This function generates random Id based on the last Id in the file
        /// </summary>
        /// <returns>id</returns>
        public double RandomIdGenerator()
        {
           using StreamReader reader = new StreamReader(path);
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Customers>));
            var customer = (List<Customers>)deserializer.Deserialize(reader);
            id = customer.Count + 1;
            reader.Close();
            return id;
        }

        /// <summary>
        /// This function takes input from customer and print those details in the formatted way
        /// </summary>
        public void GetCustomerDetails()
        {
            id = RandomIdGenerator();
            Console.WriteLine("Enter First Name:");
            fname = Console.ReadLine();

            Console.WriteLine("Enter Last Name:");
            lname = Console.ReadLine();

            Console.WriteLine("Enter Gender: <0> for Male  <1> for Female");
            int GenderChoice = int.Parse(Console.ReadLine());
            if (GenderChoice == 0)
            {
                Gender = Gender.Male;
            }
            if (GenderChoice == 1)
            {
                Gender = Gender.Female;
            }

            Console.WriteLine("Enter Location Name:");
            location = Console.ReadLine();
        }

        /// <summary>
        /// This function is responsible for updating the customer details file by taking input from the user and appending the data accordingly
        /// </summary>
        /// <param name="cus"></param>
        public void AddCustomerDetails(Customers cus)
        {
            customer = new List<Customers>(){ 
              new Customers() { id = cus.id, fname = cus.fname, lname = cus.lname, Gender = cus.Gender, location = cus.location }
            };
            XmlDocument xmlCustDoc = new XmlDocument();
            xmlCustDoc.Load(path);
            XmlElement ParentElement = xmlCustDoc.CreateElement("Customers");
            XmlElement ID = xmlCustDoc.CreateElement("ID");
            ID.InnerText = $"{cus.id}";
            XmlElement FName = xmlCustDoc.CreateElement("FirstName");
            FName.InnerText = cus.fname;
            XmlElement LName = xmlCustDoc.CreateElement("LastName");
            LName.InnerText = cus.lname;
            XmlElement Gender = xmlCustDoc.CreateElement("Gender");
            Gender.InnerText = $"{cus.Gender}";
            XmlElement Location = xmlCustDoc.CreateElement("Location");
            Location.InnerText = $"{cus.location}";

            ParentElement.AppendChild(ID);
            ParentElement.AppendChild(FName);
            ParentElement.AppendChild(LName);
            ParentElement.AppendChild(Gender);
            ParentElement.AppendChild(Location);

            xmlCustDoc.DocumentElement.AppendChild(ParentElement);
            xmlCustDoc.Save(path);
            Console.Clear();
            Console.WriteLine($"\t\t{cus.fname} {cus.lname} your Unique ID = {cus.id}");
            Console.WriteLine("\t\tPlease remember your Unique ID for future reference");

        }
        public void SearchCustomerByID()
        {
            Console.WriteLine("Enter Your Unique ID");
            id = int.Parse(Console.ReadLine());
            StreamReader reader = null;

            int flag = 0;
            reader = new StreamReader(path);
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Customers>));
            var customer = (List<Customers>)deserializer.Deserialize(reader);
           // Console.WriteLine("Total no of Customers : "+customer.Count);

            if (customer.Count > 0)
            {
                foreach (var data in customer)
                {
                    if (data.id == id)
                    {
                        List<string> NameOfCustomer = new List<string>();
                        Console.Clear();
                        Console.WriteLine($"\n |||   Welcome, {data.fname} {data.lname}   |||\n");
                        NameOfCustomer.Add(data.fname);
                        NameOfCustomer.Add(data.lname);
                        flag += 1;
                        //Console.Clear();
                        ShowMenu showmenu = new ShowMenu();
                        showmenu.ShowPizzaMenu();
                        break;
                    }
                }
                if (flag == 0)
                    Console.WriteLine("User Not Exist");
            }
            
            reader.Close();
        }
    }
}
/* if (customer.Count > 0)
{
    foreach (var data in customer)
    {
        Console.WriteLine($"Id={data.id}\tName={data.fname} {data.lname}\tGender={data.location}");
    }
}
else { Console.WriteLine("No record Found"); } */