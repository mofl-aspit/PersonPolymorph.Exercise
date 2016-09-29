using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLayer
{
    class AdministrativeEmployee : Employee
    {


        #region Constants

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
                payLevel = value;
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

        #endregion

    }
}
