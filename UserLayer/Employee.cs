namespace UserLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Employee : Person
    {
        #region Constants
        private const decimal TopTaxLimit = 467300m;
        private const decimal TopTaxRate = 0.15m;
        private const decimal NormalTaxRate = 0.37m;
        #endregion

        #region Fields
        protected decimal baseSalary;
        protected decimal christmasBonus;


        #endregion

        #region Constructor
        public Employee(string username, string password, decimal baseSalary, decimal christmasBonus) : base(username, password)
        {
            BaseSalary = baseSalary;
            ChristmasBonus = christmasBonus;
        }
        #endregion

        #region Properties
        public decimal BaseSalary
        {
            get
            {
                return baseSalary;
            }

            set
            {
                if (!IsValidMonitarianValue(value))
                {
                    throw new ArgumentOutOfRangeException();
                }
                if(baseSalary != value)
                {
                    baseSalary = value;
                }
                
            }
        }

        public decimal ChristmasBonus
        {
            get
            {
                return christmasBonus;
            }

            set
            {
                christmasBonus = value;
            }
        }
        #endregion

        #region Methods
        public decimal GetMonthlyPayout()
        {
            decimal decMonthlyPayout = BaseSalary;

            decimal decTopTaxCalculated;
            decimal decNormalTaxCalculated;

            decimal decHighTaxRate = Convert.ToDecimal(TopTaxRate);
            decimal decNormalTaxRate = Convert.ToDecimal(NormalTaxRate);

            try
            {
                if (decMonthlyPayout < TopTaxLimit)
                {
                    decMonthlyPayout = decMonthlyPayout * decNormalTaxRate;
                }
                else if (decMonthlyPayout > TopTaxLimit)
                {


                    decTopTaxCalculated = decMonthlyPayout - TopTaxLimit;
                    decTopTaxCalculated = decTopTaxCalculated * decHighTaxRate;

                    //decNormalTaxCalculated = 0 - TopTaxLimit + decMonthlyPayout;
                    decNormalTaxCalculated = TopTaxLimit * decNormalTaxRate;

                    decMonthlyPayout = decTopTaxCalculated + decNormalTaxCalculated;
                }
            }
            catch
            {
                throw new ArgumentException();
            }

            return decMonthlyPayout;
        }

        public decimal GetYearlyPayout()
        {
            decimal christmasBonusCalculator = 0m;

            if(ChristmasBonus != 0)
            {
                christmasBonusCalculator = ChristmasBonus * NormalTaxRate;

            }


            decimal YearlyPayout = GetMonthlyPayout() * 12;
            YearlyPayout = YearlyPayout + christmasBonusCalculator;

            return YearlyPayout;

        }


        private bool IsValidMonitarianValue(decimal d) => d < 0.0m ? false : true;
        #endregion
    }
}
