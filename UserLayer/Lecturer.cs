

namespace UserLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    class Lecturer : Employee
    {


        #region Constants

        #endregion


        #region Fields
        protected decimal courseSalary;
        protected short numberOfYearlyCourses;



        #endregion


        #region Constructor
        public Lecturer(string username, string password ,decimal baseSalary, decimal christmasBonus,
            decimal courseSalary, short numberOfYearlyCourses) : base(username, password, baseSalary, christmasBonus)
        {
            CourseSalary = courseSalary;
            NumberOfYearlyCourses = numberOfYearlyCourses;
        }
        #endregion


        #region Properties
        public decimal CourseSalary
        {
            get
            {
                return courseSalary;
            }

            set
            {
                courseSalary = value;
            }
        }

        public short NumberOfYearlyCourses
        {
            get
            {
                return numberOfYearlyCourses;
            }

            set
            {
                numberOfYearlyCourses = value;
            }
        }
        #endregion


        #region Methods

        #endregion
    }
}
