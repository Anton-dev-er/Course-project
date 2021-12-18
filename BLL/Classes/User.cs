using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes
{
    [Serializable]

    public class User
    {
        public User()
        {
        }
        public User(string name, string surname, int countTicket)
        {
            Name = name;
            Surname = surname;
            CountTicket = countTicket;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int CountTicket { get; set; } = 0;

        public override string ToString() => "\n\tName:" + Name + "\t\tSurname:" + Surname + "\t\tReserved tickets: " + CountTicket;

    }
}
