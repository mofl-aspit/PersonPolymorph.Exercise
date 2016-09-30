

namespace UserLayer
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    #endregion

    class Student
    {
        #region Constants

        #endregion

        #region Fields
        private short earnedECTS;
        private DateTime startDate;
        
        #endregion

        #region Constructor

        #endregion

        #region Properties
        public short EarnedECTS
        {
            get
            {
                return earnedECTS;
            }

            set
            {
                earnedECTS = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
            }
        }
        #endregion

        #region Methods
        public TimeSpan StudyTimeSoFar()
        {
            
        }
        #endregion
    }
}
