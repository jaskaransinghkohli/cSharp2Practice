using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwo
{
    class RuralProperty : Property
    {
        private bool isWorkingAreaClean;

        public bool IsWorkingAreaClean { get => isWorkingAreaClean; set => isWorkingAreaClean = value; }
        public RuralProperty() { }     
        public RuralProperty(string name, string sizeOfLot, string sizeOfWorkingArea, string creditCard, bool isWorkingAreaClean) : base(name, sizeOfLot, sizeOfWorkingArea, creditCard)
        {
            this.isWorkingAreaClean = isWorkingAreaClean;
        }
        public override void Requirement()
        {
            Console.WriteLine("Appointment Fixed");
        }
        public override string ToString()
        {
            return string.Format("{0} for total area of land {1} acre, area available For Work is {2} acre, {0} " +
                "credit Card number is {3} and " +
                "working area is {4}", Name, SizeOfLot, SizeOfWorkingArea, CreditCard, (isWorkingAreaClean) ? "clean" : "not clean");
        }
    }
}
