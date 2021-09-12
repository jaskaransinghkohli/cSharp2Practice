using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwo
{
    class TownHouseProperty : Property
    {
        private bool isNeighborConsent;

        public bool IsNeighborConsent { get => isNeighborConsent; set => isNeighborConsent = value; }
        public TownHouseProperty() { }
        public TownHouseProperty(string name, string sizeOfLot, string sizeOfWorkingArea, string creditCard, bool isNeighborConsent) : base(name, sizeOfLot, sizeOfWorkingArea, creditCard)
        {
            this.isNeighborConsent = isNeighborConsent;
        }
        public override void Requirement()
        {
            Console.WriteLine("Appointment Fixed ");
        }
        public override string ToString()
        {
            return string.Format("{0} for total area of land {1} acre, area available For Work is {2} acre, {0} " +
                "credit Card number is {3} and " +
                "Neighbor's concent {4}", Name, SizeOfLot, SizeOfWorkingArea, CreditCard, (isNeighborConsent) ? "is taken" : "is not taken");
        }
    }
}
