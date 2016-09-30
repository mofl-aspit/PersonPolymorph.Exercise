

namespace UserLayer
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion


    public class AdministrativeEmployee : Employee
    {


        #region Constants
        private const decimal TopTaxLimit = 467300m;
        private const decimal TopTaxRate = 0.15m;
        private const decimal NormalTaxRate = 0.37m;
        #endregion


        #region Fields
        protected byte payLevel;
        protected double yearlyRisePercent;


        #endregion


        #region Constructor
        public AdministrativeEmployee(string username, string password, decimal baseSalary, decimal christmasBonus,
            byte payLevel, double yearlyRisePercent) : base(username, password, baseSalary, christmasBonus)
        {
            ChristmasBonus = christmasBonus;
            PayLevel = payLevel;
        }
        #endregion


        #region Properties
        public byte PayLevel
        {
            get
            {
                return payLevel;
            }

            set
            {
                if(payLevel != value)
                {
                    payLevel = value;
                }
                
            }
        }

        public double YearlyRisePercent
        {
            get
            {
                return yearlyRisePercent;
            }

            set
            {
                yearlyRisePercent = value;
            }
        }
        #endregion


        #region Methods
        public new decimal GetMonthlyPayout()
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


        public new decimal GetYearlyPayout()
        {
            decimal christmasBonusCalculator = 0m;

            if (ChristmasBonus != 0)
            {
                christmasBonusCalculator = ChristmasBonus * NormalTaxRate;

            }


            decimal YearlyPayout = GetMonthlyPayout() * 12;
            YearlyPayout = YearlyPayout + christmasBonusCalculator;

            return YearlyPayout;

        }
        #endregion

    }
}
