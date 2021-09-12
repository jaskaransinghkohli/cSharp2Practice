using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwo
{
    class Property
    {
        private string name;
        private string sizeOfLot;
        private string sizeOfWorkingArea;
        private string creditCard;

        public string Name { get => name; set => name = value; }
        public string SizeOfLot { get => sizeOfLot; set => sizeOfLot = value; }
        public string SizeOfWorkingArea { get => sizeOfWorkingArea; set => sizeOfWorkingArea = value; }
        public string CreditCard { get => creditCard; set => creditCard = value; }

        public Property() { }
        public Property(string name, string sizeOfLot, string sizeOfWorkingArea, string creditCard)
        {
            this.name = name;
            this.sizeOfLot = sizeOfLot;
            this.sizeOfWorkingArea = sizeOfWorkingArea;
            this.creditCard = creditCard;
        }
        public virtual void Requirement()
        {
            Console.WriteLine("Let's get the requirements");
        }
    }
}
