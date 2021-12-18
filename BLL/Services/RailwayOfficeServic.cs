using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using BLL.Classes;

namespace BLL.Services
{
    public class RailwayOfficeService
    {
        public List<RailwayOffice> RailwayOffices { get; set; } = new List<RailwayOffice>();
        private Serialize<RailwayOffice> serialize;
        public RailwayOffice GetRailwayOffice(int id) => id < 0 || id >= RailwayOffices.Count ? throw new RailwayOfficeExeption("WrondId") : RailwayOffices[id];


        public void Save() => serialize.Save(RailwayOffices.ToArray());

        public RailwayOfficeService()
        {
            serialize = new Serialize<RailwayOffice>("Railway Office");
            try 
            {
                RailwayOffices = serialize.Load().ToList(); 
            }
            catch 
            { 
                serialize.Save(RailwayOffices.ToArray()); 
            }
        }
        public void Add(string name)
        {
            if (name == null || String.IsNullOrEmpty(name.Trim()))
                throw new RailwayOfficeExeption("Name can`t be empty");
            RailwayOffices.Add(new RailwayOffice { Name = name });
        }
        public void Remove(int id)
        {
            if (id < 0 || id >= RailwayOffices.Count)
                throw new RailwayOfficeExeption("Wrond ID");
            foreach (var cashBox in RailwayOffices[id].CashBox)
                foreach (var user in Customer.thisCustomer.Users)
                    if (user == cashBox.User)
                        user.CountTicket = 0;
            RailwayOffices.RemoveAt(id);
        }
        public void AddCashBox(int id, string name, int price)
        {
            if (id < 0 || id >= RailwayOffices.Count)
                throw new RailwayOfficeExeption("Wrond ID");
            if (price < 0)
                throw new RailwayOfficeExeption("Wrond price");
            RailwayOffices[id].CashBox.Add(new CashBox { CashBoxName = name, TicketPrice = price, RailwayOffice = RailwayOffices[id] });
        }
        public void RemoveCashBox(int railwayOfficesId, int cashBoxID)
        {
            if (railwayOfficesId < 0 || railwayOfficesId >= RailwayOffices.Count)
                throw new RailwayOfficeExeption("Wrond ID");
            if (cashBoxID < 0 || cashBoxID >= RailwayOffices[railwayOfficesId].CashBox.Count)
                throw new RailwayOfficeExeption("Wrond ID");
            foreach (var user in Customer.thisCustomer.Users)
                if (user == RailwayOffices[railwayOfficesId].CashBox[cashBoxID].User)
                    user.CountTicket = 0;
            RailwayOffices[railwayOfficesId].CashBox.RemoveAt(cashBoxID);
        }
        public string ShowCashBoxByRailwayOffice(int id)
        {
            if (id < 0 || id >= RailwayOffices.Count)
                throw new RailwayOfficeExeption("Wrond ID");
            string str = "";
            str += "Railway Office: " + RailwayOffices[id].Name + "\n";
            foreach (var c in RailwayOffices[id].CashBox)
            {
                str += "Cash Box: " + c.CashBoxName  + "\n";
            }
            return str;
        }
        public CashBox GetCashBox(int rId, int cusId)
        {
            if (rId < 0 || rId >= RailwayOffices.Count)
                throw new RailwayOfficeExeption("Wrond Railway Office Id");
            if (cusId < 0 || cusId >= RailwayOffices[rId].CashBox.Count)
                throw new RailwayOfficeExeption("Wrond Cash Box Id");
            return RailwayOffices[rId].CashBox[cusId];
        }
    }
}
