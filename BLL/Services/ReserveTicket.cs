using BLL.Classes;
using BLL.Services;
using System;
using System.Linq;

namespace BLL.Services
{
    public class ReserveTicket
    {
        public void Add(CashBox cashBox, int cusId, int countTicket)
        {
            if (cashBox == null)
                throw new RailwayOfficeExeption("Cash Box cant be empty");
            Customer.thisCustomer.AddReserve(cusId, countTicket);
            cashBox.Customers.Add(ClearObject(Customer.thisCustomer.GetUserById(cusId), countTicket));
        }

        public void Remove(CashBox cashBox, int cusId)
        {
            if (cashBox == null)
                throw new RailwayOfficeExeption("Cash Box cant be empty ");
            var user = Customer.thisCustomer.GetUserById(cusId);
            var customers = cashBox.Customers;

            string name = user.Name;
            string surname = user.Surname;

            foreach(var i in customers.ToList())
            {
                if (i.Name == name && i.Surname == surname)
                {
                    Console.WriteLine("//" + "//");
                    Console.WriteLine(user.CountTicket + "   "  + i.CountTicket);
                    user.CountTicket -= i.CountTicket;
                    customers.Remove(i);
                }
            }
        }
        public User ClearObject(User user, int countTicket)
        {
            return new User(user.Name, user.Surname, countTicket);

        }
    }
}