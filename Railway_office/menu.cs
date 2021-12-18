using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BLL.Services;
using BLL.Classes;


namespace Railway_office
{
    class Menu
    {
        Customer customer = new Customer();
        RailwayOfficeService RailwayOfficeServices = new RailwayOfficeService();
        ReserveTicket reserveTicket = new ReserveTicket();
        private int GetCorectId(string number) => !Regex.IsMatch(number, "[0-9]") ? -1 : int.Parse(number) - 1;
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\n\n============Menu============");
                Console.WriteLine("\n\n\t1 - Customer\n\t2 - Railway Office\n\t3 - Reserve Ticket\n\texit - To Exit and Save");
                Console.WriteLine("Action: ");
                switch (Console.ReadLine())
                {

                    case "1":
                        Customer();
                        break;
                    case "2":
                        RailwayOffice();
                        break;
                    case "3":
                        ReserveTicket();
                        break;
                    case "exit":
                        RailwayOfficeServices.Save();
                        customer.Save();
                        break;
                    default:
                        Console.WriteLine("Wrong id\nPress smth to continue...");
                        Console.ReadKey();
                        continue;
                }
                break;
            }
        }
        private void Customer()
        {
            while (true)
            {
                Console.WriteLine("\n\n============Customer============");
                Console.WriteLine("\n\nCustomer\n\t1 - Add\n\t2 - Remove\n\t3 - Edit\n\t4 - Show all\n\tback - To Back");
                Console.Write("Action: ");
                switch (Console.ReadLine())
                {

                    case "back":
                        break;
                    case "1":
                        try
                        {
                            Console.Write("Name: ");
                            var name = Console.ReadLine();
                            Console.Write("Surname: ");
                            var surname = Console.ReadLine();
                            customer.Add(name, surname);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message); Console.ReadKey();
                        }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Choose customer:");
                            customer.Remove(GetUserID(), RailwayOfficeServices.RailwayOffices);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message); Console.ReadKey();
                        }
                        break;
                    case "3":
                        try
                        {
                            Console.WriteLine("Choose customer:");
                            int id = GetUserID();
                            Console.Write("New name: ");
                            var name = Console.ReadLine();
                            Console.Write("New surname: ");
                            var surname = Console.ReadLine();
                            customer.Edit(id, name, surname, RailwayOfficeServices.RailwayOffices);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message); Console.ReadKey();
                        }
                        break;
                    case "4":
                        foreach (var user in customer.Users)
                            Console.WriteLine(user);
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Wrong id\nPress smth to continue...");
                        Console.ReadKey();
                        break;
                }
                break;
            }
            Start();
        }
        private void RailwayOffice()
        {
            while (true)
            {
                Console.WriteLine("\n\n============RailwayOffice============");
                Console.WriteLine("Railway Office\n\t1 - Add\n\t2 - Remove\n\t3 - Show all\n\t4 - Add Cash Box\n\t5 - Remove Cash Box\n\t6 - Show Cask Box\n\tback - To Back");
                Console.Write("Action: ");
                switch (Console.ReadLine())
                {

                    case "back":
                        break;
                    case "1":
                        try
                        {
                            Console.Write("Name: ");
                            var name = Console.ReadLine();
                            RailwayOfficeServices.Add(name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message); Console.ReadKey();
                        }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Choose Railway Office:");
                            RailwayOfficeServices.Remove(GetRailwayOfficeID());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message); Console.ReadKey();
                        }
                        break;
                    case "3":
                        foreach (var r in RailwayOfficeServices.RailwayOffices)
                            Console.WriteLine("Railway Office: " + r.Name);
                        Console.ReadKey();
                        break;
                    case "4":
                        try
                        {
                            Console.WriteLine("Choose Railway Office:");
                            int id = GetRailwayOfficeID();
                            Console.Write("Cash box name: ");
                            var cashBoxName = Console.ReadLine();
                            Console.Write("Ticket price: ");
                            var ticketPrice = Console.ReadLine();
                            RailwayOfficeServices.AddCashBox(id, cashBoxName, GetCorectId(ticketPrice));

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message); Console.ReadKey();
                        }
                        break;
                    case "5":
                        try
                        {
                            Console.WriteLine("Choose Railway Office:");
                            int id = GetRailwayOfficeID();
                            Console.WriteLine("Choose Cash Box:");
                            RailwayOfficeServices.RemoveCashBox(id, GetCheshBoxID(RailwayOfficeServices.GetRailwayOffice(id)));

                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
                        break;
                    case "6":
                        try
                        {
                            Console.WriteLine("Choose Railway Office:");
                            Console.WriteLine(RailwayOfficeServices.ShowCashBoxByRailwayOffice(GetRailwayOfficeID()));
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Wrong id\nPress smth to continue...");
                        Console.ReadKey();
                        break;
                }
                break;
            }
            Start();
        }
        private void ReserveTicket()
        {
            Console.WriteLine("\n\n============Reserve Ticket============");
            Console.WriteLine("\t1 - Add\n\t2 - Remove\n\t3 - Show reserved By Cash Box\n\t4 - Show reserved By Railway Office");
            Console.Write("Action: ");
            switch (Console.ReadLine())
            {

                case "exit":
                    return;
                case "1":
                    try
                    {
                        Console.WriteLine("Choose Railway office:");
                        int rId = GetRailwayOfficeID();
                        Console.WriteLine("Choose Cash Box:");
                        int cId = GetCheshBoxID(RailwayOfficeServices.GetRailwayOffice(rId));
                        Console.WriteLine("Choose customer:");
                        int cusId = GetUserID();
                        Console.Write("Count Ticket: ");
                        int countTicket = int.Parse(Console.ReadLine());
                        reserveTicket.Add(RailwayOfficeServices.GetCashBox(rId, cId), cusId, countTicket);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message); Console.ReadKey();
                    }
                    break;
                case "2":
                    try
                    {
                        Console.WriteLine("Choose Railway office:");
                        int rId = GetRailwayOfficeID();
                        Console.WriteLine("Choose Cash Box:");
                        int cId = GetCheshBoxID(RailwayOfficeServices.GetRailwayOffice(rId));
                        Console.WriteLine("Choose customer:");
                        int cusId = GetUserID();
                        reserveTicket.Remove(RailwayOfficeServices.GetCashBox(rId, cId), cusId);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message); Console.ReadKey();
                    }
                    break;
                case "3":
                    try
                    {
                        Console.WriteLine("Choose Railway office:");
                        int rId = GetRailwayOfficeID();
                        Console.WriteLine("Choose Cash Box:");
                        int cId = GetCheshBoxID(RailwayOfficeServices.GetRailwayOffice(rId));
                        var customers = RailwayOfficeServices.GetCashBox(rId, cId).Customers;
                        foreach (var customer in customers)
                        {
                            Console.WriteLine(customer);
                        }
                        Console.ReadKey();
                    }


                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message); Console.ReadKey();
                    }
                    break;
                case "4":
                    try
                    {
                        Console.WriteLine("Choose Railway");
                        int rId = GetRailwayOfficeID();
                        Console.WriteLine("All");
                        foreach (var a in RailwayOfficeServices.GetRailwayOffice(rId).CashBox)
                        {
                            Console.WriteLine(a.User);
                        }
                        Console.ReadKey();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                    break;
                default:
                    Console.WriteLine("Wrong id\nPress smth to continue...");
                    Console.ReadKey();
                    break;
            }
            Start();
        }
        private int GetUserID()
        {
            int i = 1;
            foreach (var c in customer.Users)
                Console.WriteLine((i++) + ". Customer: " + c.Name + " " + c.Surname);
            Console.Write("Choose Customer by id: ");
            return GetCorectId(Console.ReadLine());
        }
        private int GetRailwayOfficeID()
        {
            int i = 1;
            foreach (var r in RailwayOfficeServices.RailwayOffices)
                Console.WriteLine((i++) + " - Railway Office: " + r.Name);
            Console.Write("Id: ");
            return GetCorectId(Console.ReadLine());
        }
        private int GetCheshBoxID(RailwayOffice railwayOffice)
        {
            int i = 1;
            foreach (var c in railwayOffice.CashBox)
                Console.WriteLine((i++) + " - CashBox: " + c.CashBoxName + "Ticket price: " + c.TicketPrice);
            Console.Write("ID: ");
            return GetCorectId(Console.ReadLine());
        }
    }
}
