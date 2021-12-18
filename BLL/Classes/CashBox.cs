using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BLL.Classes
{
    [Serializable]

    public class CashBox
    {
        public string CashBoxName { get; set; }
        public RailwayOffice RailwayOffice { get; set; }
        public User User { get; set; }
        public List<User> Customers { get; set; } = new List<User>();
        public double TicketPrice { get; set; }
    }
}
