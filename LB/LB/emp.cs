using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB
{
    class Emp
    {
        string payEmployee;
        bool isHired = true;
        string id;
        string fNAme;
        string lName;
        double payRate;
        double raise;
        DateTime termination;
        public string Employee { get; set; }

        public Emp(string eNum, string first, double money)
        {
            id = eNum;
            fNAme = first;
            payRate = money;
        }

        public double PayRate
        {
            get
            {
                return payRate;
            }
        }
        public DateTime Terminate
        {
            get
            {
                return termination;
            }
        }
        public string PayEmployee
        {
            set
            {
                if (isHired)
                {
                    isHired = true;
                }
                else if (!isHired)
                {
                    isHired = false;
                }

            }
        }

        public string FNAme
        {
            get
            {
                return fNAme;
            }
        }

        public string LName
        {
            get
            {
                return lName;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }
        }

       

        public double Raise()
        {
            {

                return PayRate * 1.04;
            }
        }
        public void Fired()
        {
            termination = DateTime.Now;
        }

    }
}
