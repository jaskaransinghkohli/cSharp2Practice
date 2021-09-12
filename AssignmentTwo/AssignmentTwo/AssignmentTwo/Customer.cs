using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwo
{
    class Customer
    {
        private string custName;
        private string sizeOfLot;
        private string sizeOfWorkArea;
        private string creditCard;

        public Customer() { }
        public Customer(string custName, string sizeOfLot, string sizeOfWorkArea, string creditCard) {
            this.CustName = custName;
            this.SizeOfLot = sizeOfLot;
            this.SizeOfWorkArea = sizeOfWorkArea;
            this.CreditCard = creditCard;
        }
        public string CustName { get => custName; set => custName = value; }
        public string SizeOfLot { get => sizeOfLot; set => sizeOfLot = value; }
        public string SizeOfWorkArea { get => sizeOfWorkArea; set => sizeOfWorkArea = value; }
        public string CreditCard { get => creditCard; set => creditCard = value; }
        public string MaskCreditCardNum { get => MaskCreditCardNumber(); }

        //---------------------------------------------------VALIDATE CUSTOMER NAME------------------------------
        public bool ValidateCustomerName()
        {
            string[] splitCustName = CustName.Split(' ');
            int falseCount = 0;
            if(CustName.Length == 0)
            {
                falseCount++;
            }
            else
            {
                for (int i = 0; i < splitCustName.Length; i++)
                {
                    char[] custNameArrChar = splitCustName[i].ToCharArray();
                    for (int j = 0; j < custNameArrChar.Length; j++)
                    {
                        if (!char.IsLetter(custNameArrChar[j]))
                        {
                            falseCount++;
                        }
                    }
                }
            }
            
            return (falseCount > 0 ? false : true);
        }
        //----------------------------------------------VALIDATE SIZE OF LOT--------------------------------------------
        public bool ValidateSizeOfLot()
        {
            bool isSizeOfLotValid = false;
            decimal sizeOfLot = 0;
            if(!decimal.TryParse(SizeOfLot, out sizeOfLot) || (sizeOfLot >= 100) || (sizeOfLot <= 0))
            {
                isSizeOfLotValid = false;
            }
            else
            {
                isSizeOfLotValid = true;
            }
            return isSizeOfLotValid;
        }
        //----------------------------------------------VALIDATE SIZE OF WORK--------------------------------------------
        public bool ValidateSizeOfWork()
        {
            bool isSizeOfWorkValid = false;
            decimal sizeOfWork = 0;
            decimal sizeOfLotDecimal = 0;
            decimal.TryParse(SizeOfLot, out sizeOfLotDecimal);
            if (!decimal.TryParse(sizeOfWorkArea, out sizeOfWork) || (sizeOfWork <= 0) || !(sizeOfWork <= sizeOfLotDecimal))
            {
                isSizeOfWorkValid = false;
            }
            else
            {
                isSizeOfWorkValid = true;
            }
            return isSizeOfWorkValid;
        }

        //----------------------------------------------VALIDATE CREDIT CARD NUMBER--------------------------------------
        public bool ValidCreditCardNumber()
        {
            bool isCreditCardNumberValid = false;
            string[] ccNumArr = CreditCard.Split(' ');
            char[] ccNumChar = CreditCard.ToCharArray();
            if (CreditCard != null && CreditCard.Length == 19 && ccNumArr.Length == 4)
            {
                for (int i = 0; i < ccNumChar.Length; i++)
                {
                    if (char.IsDigit(ccNumChar[i]) || ccNumChar[i] == ' ')
                    {
                        isCreditCardNumberValid = true;
                    }
                    else
                    {
                        isCreditCardNumberValid = false;
                        break;
                    }
                }
            }
               
            return isCreditCardNumberValid;
        }

        //-----------------------------------------------MASK CREDIT CARD NUMBER-------------------------------
        private string MaskCreditCardNumber()
        {
            char[] ccNumArr = CreditCard.ToCharArray();
            for (int i = 5; i < 14; i++)
            {
                if (ccNumArr[i] != ' ')
                {
                    ccNumArr[i] = 'X';
                }
            }
            return new string(ccNumArr);
        }


        

    }
}
