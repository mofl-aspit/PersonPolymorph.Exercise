using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLayer
{
    public abstract class Person
    {
        #region Fields
        private string firstname;
        private string lastnames;
        private string ssn;


        #endregion

        #region Constructor

        #endregion

        #region Properties
        public string Firstname
        {
            get
            {
                return firstname;
            }

            set
            {
                if (String.IsNullOrWhiteSpace(firstname))
                {
                    throw new ArgumentException();
                }
                firstname = value;
            }
        }

        public string Lastnames
        {
            get
            {
                return lastnames;
            }

            set
            {
                if (String.IsNullOrWhiteSpace(lastnames))
                {
                    throw new ArgumentException();
                }
                lastnames = value;
            }
        }

        protected string Ssn
        {
            get
            {
                return ssn;
            }

            set
            {
                string error = String.Empty;
                bool validationSuccess = false;

                try
                {
                    validationSuccess = IsSsnValid(value, out error);
                }
                catch(Exception)
                {
                    throw;
                }
                if (!validationSuccess)
                {
                    throw new ArgumentException();
                }
                else
                {
                    ssn = value;
                }
                
            }
        }


        #endregion

        #region Methods
        public bool IsSsnValid(string ssn, out string error)
        {
            
            bool CorrectlyFormatted = false;
            int stringCatcher;

            if (String.IsNullOrWhiteSpace(ssn))
            {
                error = "something went wrong";
                throw new ArgumentException();
            }
            else if(ssn.Length < 10)
            {
                CorrectlyFormatted = false;
                error = "ssn is too short, please try again";
            }
            //currently added, not sure if works
            else if(!int.TryParse(ssn, out stringCatcher))
            {
                CorrectlyFormatted = false;
                error = "ssn contains letters, please try again";
            }
            else
            {
                error = string.Empty;
                CorrectlyFormatted = true;
            }


            return CorrectlyFormatted;
        }

        
        #endregion

    }
}
