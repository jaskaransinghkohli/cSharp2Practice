using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwo
{
    class Appointments
    {
        private string time;
        private Property property;

        public string Time { get => time; set => time = value; }
        internal Property PropertyType { get => property; set => property = value; }

    }
}
