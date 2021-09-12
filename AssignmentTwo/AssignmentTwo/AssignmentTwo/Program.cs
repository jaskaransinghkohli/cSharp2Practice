using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwo
{
    class Program
    {
        enum AppointmentSlots
        {
            AM7h = 1,
            AM8h = 2,
            AM9h = 3,
            AM10h = 4,
            AM11h = 5,
        }

        enum Properties
        {
            RuralProperty, StandAloneProperty, TownHouseProperty
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Go();
            Console.ReadKey();

        }
        public void Go()
        {
            //Initialization of values
            var appointmentAvailable = Enum.GetNames(typeof(AppointmentSlots));
            var appointmentAvailableValues = Enum.GetValues(typeof(AppointmentSlots));

            //Hastable to hold timeslots
             Hashtable timeTable = new Hashtable();

            //Array to hold appointments
            Appointments[] appointments = new Appointments[appointmentAvailable.Length];

            //Customer 
            Customer cust = new Customer();

            //Converting time
            for(int i=0; i< appointmentAvailable.Length; i++)
            {
                string slotType = (string)appointmentAvailable[i];
                int slotProperty = (int)appointmentAvailableValues.GetValue(i);
                string convertedTime = slotType.Substring(2).Replace('h' , ':') + "00 am";

                timeTable.Add(slotProperty, convertedTime);

                //Array of appointments initialized
                appointments[i] = new Appointments();
                appointments[i].Time = convertedTime;
            }

            bool appointmentNeeded = false;
            do
            {
                string response = string.Empty;
                do
                {
                    Console.Write("Do you need an appointment? (y/n) [press n to terminate] : ");
                    response = Console.ReadLine();
                } while ((response.ToUpper() != "Y") && (response.ToUpper() != "N"));

                //If we do not need (anymore) appointments, the registration ends
                if ((response.ToUpper() == "N"))
                {
                    appointmentNeeded = false;
                    continue;
                }

                //Displaying time values
                foreach (int inVal in appointmentAvailableValues)
                {
                    if (timeTable.ContainsKey(inVal))
                    {
                        Console.WriteLine("{0}. {1}", inVal , timeTable[inVal]);
                    }
                }

                string slotChoice = string.Empty;
                int slot = 0;
                do
                {
                    Console.Write("Please choose available slot : ");
                    slotChoice = Console.ReadLine();   
                } while (!int.TryParse(slotChoice, out slot) || !timeTable.ContainsKey(slot));
                 
              
                    Console.WriteLine("Here are the properties we accept:");
                    var properties = Enum.GetValues(typeof(Properties));
                    int index = 0;
                    foreach (var inVal in properties)
                    {
                        Console.WriteLine("{0}. {1}", ++index, inVal);
                    }
                    string propertyChoice = string.Empty;
                    int choice = 0;
                    do
                    {
                        Console.Write("Which Type Of Properity Landscaping You Prefer? ");
                        propertyChoice = Console.ReadLine();
                    } while (!int.TryParse(propertyChoice, out choice) || (choice <= 0 || choice > properties.Length));

                    if(choice > 0)
                    {
                        //--------------------------------NAME OF CUSTOMER-------------------------
                        do
                        {
                            Console.Write("Please Enter Your Name: [eg. john or john doe]: ");
                            cust.CustName = Console.ReadLine();
                        } while (!cust.ValidateCustomerName());
                        string custNameString = cust.CustName; 
                        //--------------------------------SIZE OF LOT-----------------------------
                        do
                        {
                            Console.Write("How Much acres land You Own? [Should be less than 100 acre] ");
                            cust.SizeOfLot = Console.ReadLine();
                        } while (!cust.ValidateSizeOfLot());
                         string sizeOfLotString = cust.SizeOfLot; 
                        //--------------------------------SIZE OF WORK-----------------------------
                        do
                        {
                            Console.Write("How Much acre land is available for the Landscaping Work? " +
                                "[Should be less than or equal to land you own ({0})] ", sizeOfLotString);
                            cust.SizeOfWorkArea = Console.ReadLine();
                        } while (!cust.ValidateSizeOfWork());
                         
                        string sizeOfWorkAreaString = cust.SizeOfWorkArea;
                        //--------------------------------CREDIT CARD-----------------------------               
                        do
                         {
                             Console.Write("Enter Credit Card Details [Format : 0000 0000 0000 0000]: ");
                           cust.CreditCard = Console.ReadLine();
                         } while (!cust.ValidCreditCardNumber());
                    string ccNumMaskString = cust.MaskCreditCardNum;
                    Property property = null;

                        // Working with polymorphism
                    switch (choice - 1)
                    {
                        case (int)Properties.RuralProperty:
                            do                            
                            {
                            Console.Write("Is Working Area Clean? (y/n): ");
                             response = Console.ReadLine();   
                            } while ((response.ToUpper() != "Y") && (response.ToUpper() != "N"));
                                
                            property = new RuralProperty(custNameString, sizeOfLotString, sizeOfWorkAreaString, ccNumMaskString, (response.ToUpper() == "Y") ? true : false);
                            break;

                            case (int)Properties.StandAloneProperty:
                                do
                                {
                                    Console.Write("Is enterance to the lot cleared (y/n) ");
                                    response = Console.ReadLine();
                                } while ((response.ToUpper() != "Y") && (response.ToUpper() != "N"));
                                property = new StandAloneProperty(custNameString, sizeOfLotString, sizeOfWorkAreaString, ccNumMaskString, (response.ToUpper() == "Y") ? true : false);
                                break;
                            case (int)Properties.TownHouseProperty:
                                do
                                {
                                    Console.Write("Did Neighbors gave consent? (y/n) ");
                                    response = Console.ReadLine();
                                } while ((response.ToUpper() != "Y") && (response.ToUpper() != "N"));
                                property = new TownHouseProperty(custNameString, sizeOfLotString, sizeOfWorkAreaString, ccNumMaskString, (response.ToUpper() == "Y") ? true : false);
                                break;

                            default:
                            Console.WriteLine("Please select the service which is mentioned in the list.");
                            break;
                        }
                        //Setting up appointment
                        appointments[slot - 1].PropertyType = property;
                        appointmentNeeded = true;
                        //Removing Taken Slot
                        timeTable.Remove(slot);
                    }
            } while (appointmentNeeded && timeTable.Keys.Count > 0);
            
            //Check for no appointments booked
            
            int customerCount = 1;
            string generalCustOutput = "Customer should create the Design, estimate the Work & arrange the Workers";
            Console.WriteLine("\n\t***** APPOINTMENT SUMMARY FOR CUSTOMERS *****");
            for (int i = 0; i < appointments.Length; i++)
            {
                if (appointments[i].PropertyType != null)
                {
                    //We do not need to elaborate on the property properties because we overrode ToString()
                    Console.WriteLine("\n\t\t--- CUSTOMER #{0} ---" +
                        "\nTime Slot booked at {1} for customer {2}. {3}.", customerCount.ToString(),
                         appointments[i].Time, appointments[i].PropertyType, generalCustOutput);
                    customerCount += 1;
                }
            }
            if (customerCount == 1)
            {
                Console.WriteLine("\nSorry No appointments were booked");
            }
            Console.WriteLine("\nPlease press any key twice to exit");
            Console.ReadKey();
        }
    }
}
