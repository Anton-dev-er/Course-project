using System;

namespace BLL
{
    public class RailwayOfficeExeption : Exception
    {
        private string message;
        public RailwayOfficeExeption() : base() { }

        public RailwayOfficeExeption(string message)
        {
            this.message = message;
        }

        public override string Message => message;
    }
}
