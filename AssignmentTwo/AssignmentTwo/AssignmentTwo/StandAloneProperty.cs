using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwo
{
    class StandAloneProperty : Property
    {
        private bool isEnteranceClear;

        public bool IsEnteranceClear { get => isEnteranceClear; set => isEnteranceClear = value; }
        public StandAloneProperty() { }
        public StandAloneProperty(string name, string sizeOfLot, string sizeOfWorkingArea, string creditCard, bool isEnteranceClear) : base( name ,sizeOfLot, sizeOfWorkingArea, creditCard)
        {
            this.isEnteranceClear = isEnteranceClear;
        }
        public override void Requirement()
        {
            Console.WriteLine("Appointment Fixed");
        }

        public override string ToString()
        {
            return string.Format("{0} for total area of land {1} acre, area available For Work is {2} acre, {0} " +
                "credit Card number is {3} and " +
                "enterance is {4}", Name,SizeOfLot, SizeOfWorkingArea, CreditCard,(isEnteranceClear) ? "cleared" : "Not cleared");
        }
    }
}
