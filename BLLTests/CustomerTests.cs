using System.Collections.Generic;
using BLL.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Services;
using BLL;

namespace BLLTests
{
    [TestClass]
    public class CustomerTests
    {
        Customer us = new Customer();

        [TestMethod()]
        public void AddTest()
        {
            Assert.ThrowsException<RailwayOfficeExeption>(() => us.Add("", "sa"), "Name can`t be null");
        }

        [TestMethod()]
        public void AddTest1()
        {
            Assert.ThrowsException<RailwayOfficeExeption>(() => us.Add("sa", ""), "Surname can`t be empty");
        }

        [TestMethod()]
        public void AddTest2()
        {
            us.Add("sa", "sa");
        }

        [TestMethod()]
        public void RemoveTest()
        {
            Assert.ThrowsException<RailwayOfficeExeption>(() => us.Remove(-1, new List<RailwayOffice> { }), "Wrond ID");
        }

        [TestMethod()]
        public void RemoveTest1()
        {
            var a = new User { Name = "d" };
            us.Users.Add(a);
            us.Users.Add(new User { });
            us.Remove(0, new List<RailwayOffice> { new RailwayOffice { CashBox = new List<CashBox> { new CashBox { User = a } } } });
        }

        [TestMethod()]
        public void EditTest()
        {
            Assert.ThrowsException<RailwayOfficeExeption>(() => us.Edit(-1, "sa", "sa", new List<RailwayOffice>()), "Wrond ID");
        }

        [TestMethod()]
        public void EditTest1()
        {
            us.Users.Add(new User { });
            Assert.ThrowsException<RailwayOfficeExeption>(() => us.Edit(0, "", "sa", new List<RailwayOffice>()), "Name can`t be empty");
        }

        [TestMethod()]
        public void EditTest2()
        {
            us.Users.Add(new User { });
            Assert.ThrowsException<RailwayOfficeExeption>(() => us.Edit(0, "фів", "", new List<RailwayOffice>()), "Surname can`t be empty");
        }

        [TestMethod()]
        public void EditTest3()
        {
            var a = new User { Name = "d" };
            us.Users.Add(a);
            us.Users.Add(new User { });
            us.Edit(0, "das", "sa", new List<RailwayOffice> { new RailwayOffice { CashBox = new List<CashBox> { new CashBox { User = a } } } });
        }

        [TestMethod()]
        public void Edit1Test()
        {
            Assert.ThrowsException<RailwayOfficeExeption>(() => us.AddReserve(-1, 0), "Wrond Id");
        }

        [TestMethod()]
        public void Edit1Test1()
        {
            us.Users.Add(new User { });
            Assert.ThrowsException<RailwayOfficeExeption>(() => us.AddReserve(0, -1), "Count of ticket should be more then 0");
        }

        [TestMethod()]
        public void Edit1Test2()
        {
            var a = new User { Name = "d" };
            us.Users.Add(a);
            us.Users.Add(new User { });
            us.AddReserve(0, 15);
        }

        [TestMethod()]
        public void GetUserTest()
        {
            Assert.ThrowsException<RailwayOfficeExeption>(() => us.GetUserById(-1), "Wrond Id");
        }
    }
}
