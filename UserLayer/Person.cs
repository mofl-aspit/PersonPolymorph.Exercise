namespace UserLayer
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion


    public abstract class Person : User
    {
        #region Fields
        protected string firstname;
        protected string lastnames;
        protected string ssn;
        #endregion

        #region Constructor
        public Person(string username, string password) : base(username, password)
        {

        }
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
            else if(!IsValidNumericalString(ssn))
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

        private static bool IsValidNumericalString(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }
            else if (!s.Any(char.IsDigit))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

    }
}
