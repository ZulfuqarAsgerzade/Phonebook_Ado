using PhoneBook_Homework.ADO;
using PhoneBook_Homework.Interfaces;
using PhoneBook_Homework.Models;

public class Program
{
    public static void Main()
    {
        Interface_DB dbWorker = new DbWorker(@"server=CANR2-5;database=PhoneBook;Trusted_Connection=true");

        
        while (true)
        {
        repeat_app:
            Console.Clear();

            Console.WriteLine(
                "1. Add Contact \n" +
                "2. Delete Contact \n" +
                "3. Update Contact \n" +
                "4. Show All Contacts \n" +
                "5. Search \n" +
                "6. Exit"
            );

            string userMenuChoise = Console.ReadLine();

            if (userMenuChoise.Equals("1"))
            {
                Console.Clear();

                Console.Write("Enter Firstname: ");
                string contactName = Console.ReadLine();

                Console.Write("Enter Lastname: ");
                string contactLastname = Console.ReadLine();

                Console.Write("Enter phone: ");
                string contactPhone = Console.ReadLine();

                Console.Write("Enter email: ");
                string contacteEmail = Console.ReadLine();

                dbWorker.Insert(
                        new Person(contactName, contactLastname, contactPhone, contacteEmail)
                    );

                Console.ReadLine();

                goto repeat_app;
            }
            else if (userMenuChoise.Equals("2"))
            {
                Console.Clear();

                if (dbWorker.GetAllConnected().Any())
                {
                    var contacts = dbWorker.GetAllConnected();

                    foreach (Person person in contacts)
                    {
                        Console.WriteLine(
                                "ID: " + person.ID + "\n" +
                                "Firstname: " + person.FirstName + "\n" +
                                "Lastname: " + person.LastName + "\n" +
                                "Phone: " + person.Phone + "\n" +
                                "Email: " + person.Email + "\n" +
                                new String('_', 50)
                            );
                    }

                    Console.Write("Please choose ID for deleting contact: ");
                    int contactID = Convert.ToInt32(Console.ReadLine());

                    dbWorker.Delete(contactID);
                }
                else
                {
                    Console.WriteLine("There is no contact!");
                }   

                Console.ReadLine();

                goto repeat_app;
            }
            else if (userMenuChoise.Equals("3"))
            {
                Console.Clear();

                if (dbWorker.GetAllConnected().Any())
                {
                    var contacts = dbWorker.GetAllConnected();

                    foreach (Person person in contacts)
                    {
                        Console.WriteLine(
                                "ID: " + person.ID + "\n" +
                                "Firstname: " + person.FirstName + "\n" +
                                "Lastname: " + person.LastName + "\n" +
                                "Phone: " + person.Phone + "\n" +
                                "Email: " + person.Email + "\n" +
                                new String('_', 50)
                            );
                    }

                    Console.Write("Please choose ID for updating contact: ");
                    int contactID = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Firstname: ");
                    string contactName = Console.ReadLine();

                    Console.Write("Enter Lastname: ");
                    string contactLastname = Console.ReadLine();

                    Console.Write("Enter phone: ");
                    string contactPhone = Console.ReadLine();

                    Console.Write("Enter email: ");
                    string contacteEmail = Console.ReadLine();

                    dbWorker.Update
                        (
                            contactID,
                            new Person(contactName, contactLastname, contactPhone, contacteEmail)
                        );
                }
                else
                {
                    Console.WriteLine("There is no contact!");
                }

                Console.ReadLine();

                goto repeat_app;
            }
            else if (userMenuChoise.Equals("4"))
            {
                Console.Clear();

                if (dbWorker.GetAllConnected().Any())
                {
                    var contacts = dbWorker.GetAllConnected();

                    foreach (Person person in contacts)
                    {
                        Console.WriteLine(
                                "Firstname: " + person.FirstName + "\n" +
                                "Lastname: " + person.LastName + "\n" +
                                "Phone: " + person.Phone + "\n" +
                                "Email: " + person.Email + "\n" +
                                new String('_', 50)
                            );
                    }
                }
                else
                {
                    Console.WriteLine("There is no contact!");
                }

                Console.ReadLine();

                goto repeat_app;
            }
            else if (userMenuChoise.Equals("5"))
            {
                Console.Clear();

                if (dbWorker.GetAllConnected().Any())
                {
                    Console.Write("Enter keyword for searching: ");
                    string searchKeyword = Console.ReadLine();

                    var contacts = dbWorker.Search(searchKeyword);

                    foreach (Person person in contacts)
                    {
                        Console.WriteLine(
                                "Firstname: " + person.FirstName + "\n" +
                                "Lastname: " + person.LastName + "\n" +
                                "Phone: " + person.Phone + "\n" +
                                "Email: " + person.Email + "\n" +
                                new String('_', 50)
                            );
                    }
                }
                else
                {
                    Console.WriteLine("There is no contact!");
                }

                

                Console.ReadLine();

                goto repeat_app;
            }
            else if (userMenuChoise.Equals("6"))
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please choose correct menu section!");
                Console.ReadLine();

                goto repeat_app;
            }
        }


        

    }
}