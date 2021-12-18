using BLL.Services;
using BLL.Classes;
using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BLLTests
{
    [TestClass]
    public class ReserveTicketTests
    {
        private ReserveTicket reserveTicket = new ReserveTicket();
        [TestMethod()]
        public void AddReserveTest()
        {
            Assert.ThrowsException<RailwayOfficeExeption>(() => reserveTicket.Add(null, 0, 1), "CashBox cant be null");
        }

        [TestMethod()]
        public void AddReserveTest2()
        {
            Customer userService = new Customer();
            userService.Users.Add(new User { });
            reserveTicket.Add(new CashBox { }, 0, 1);
        }

        [TestMethod()]
        public void RemoveReserveTest()
        {
            Assert.ThrowsException<RailwayOfficeExeption>(() => reserveTicket.Remove(null, 5), "CashBox cant be null");
        }
        [TestMethod()]
        public void RemoveReserveTest1()
        {
            Assert.ThrowsException<RailwayOfficeExeption>(() => reserveTicket.Remove(new CashBox { }, 2), "CashBox cant be null");
        }
        [TestMethod()]
        public void RemoveReserveTest2()
        {
            Customer userService = new Customer();
            User user = new User { CountTicket = 15 };
            userService.Users.Add(new User { });
            reserveTicket.Remove(new CashBox { }, 0);
        }
    }
}
