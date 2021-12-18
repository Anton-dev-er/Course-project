using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.Classes;
using DAL;

namespace BLL.Services
{
    public class Customer
    {
        public List<User> Users { get; private set; } = new List<User>();
        public static Customer thisCustomer;
        Serialize<User> serialize;

        public Customer()
        {
            thisCustomer = this;
            serialize = new Serialize<User>("Users");
            try 
            { 
                Users = serialize.Load().ToList(); 
            }
            catch 
            { 
                serialize.Save(Users.ToArray()); 
            }
        }
        public User GetUserById(int id)
        {
            if (id < 0 || id >= Users.Count)
                throw new RailwayOfficeExeption("Wrond Id");
            return Users[id];
        }

        public void Save() => serialize.Save(Users.ToArray());
        public void Add(string name, string surname)
        {
            if (name == null || String.IsNullOrEmpty(name.Trim()))
                throw new RailwayOfficeExeption("Name can`t be empty");
            if (surname == null || String.IsNullOrEmpty(surname.Trim()))
                throw new RailwayOfficeExeption("Surname can`t be empty");
            Users.Add(new User { Name = name, Surname = surname });
        }
        public void Remove(int id, List<RailwayOffice> railwayOffices)
        {
            if (id < 0 || id >= Users.Count)
                throw new RailwayOfficeExeption("Wrong id");
            foreach (var r in railwayOffices)
                foreach (var checkBox in r.CashBox)
                    if (checkBox.User == Users[id])
                        checkBox.User = null;
            Users.RemoveAt(id);
        }
        public void Edit(int id, string name, string surname, List<RailwayOffice> RailwayOffices)
        {
            if (id < 0 || id >= Users.Count)
                throw new RailwayOfficeExeption("Wrong id");
            if (name == null || String.IsNullOrEmpty(name.Trim()))
                throw new RailwayOfficeExeption("Name can`t be empty");
            if (surname == null || String.IsNullOrEmpty(surname.Trim()))
                throw new RailwayOfficeExeption("Surname can`t be empty");
            foreach (var r in RailwayOffices)
                foreach (var room in r.CashBox)
                    if (room.User == Users[id])
                    {
                        room.User.Name = name;
                        room.User.Surname = surname;
                    }
            Users[id].Name = name;
            Users[id].Surname = surname;
        }
        public void AddReserve(int id, int countTicket)
        {
            if (id < 0 || id >= Users.Count)
                throw new RailwayOfficeExeption("Wrong Id");
            if (countTicket < 0)
                throw new RailwayOfficeExeption("Wrong count of ticket");   
            
            if( Users[id].CountTicket == 0)
                Users[id].CountTicket += countTicket;
            else
            {
                Console.WriteLine(
                        "You've already had reverved Ticket\n" +
                        "Would you like to reserve more? (yes/no)\n");
                if (Console.ReadLine() == "yes")
                    Users[id].CountTicket += countTicket;
            }
        }

    }
}
