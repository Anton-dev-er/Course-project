using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace BLL.Classes
{
    [Serializable]
    public class RailwayOffice
    {

        public string Name { get; set; }
        public List<CashBox> CashBox { get; set; } = new List<CashBox>();

        public override string ToString()
        {
            return "Railway Office: " + Name;
        }
    }
}
