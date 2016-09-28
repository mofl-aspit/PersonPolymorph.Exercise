using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLayer
{
    public class User
    {
        #region Fields
        protected string password;
        protected string username;

        #endregion


        #region Constructor
        /// <summary>
        /// Creates a new instance of this class. Use this class to enable a user to login
        /// then downcast the object to the appropriate derived type.
        /// </summary>
        /// <param name="username">the username (a string)</param>
        /// <param name="password">the password (a string)</param>
        public User(string username, string password)
        {
            try
            {
                Username = username;
                Password = password;
            }
            catch (ArgumentOutOfRangeException) { throw; }
            catch (ArgumentException) { throw; }
            
        }
        #endregion


        #region Properties
        /// <summary>
        /// property which encapsulates password
        /// makes minor validation
        /// </summary>
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                string error = String.Empty;
                bool validationSuccess = false;

                try
                {
                    validationSuccess = IsPasswordValid(value, out error);
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
                    password = value;
                }
                
            }
        }


        /// <summary>
        /// Property which encapsulates Username
        /// makes minor validation
        /// </summary>
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                if (String.IsNullOrWhiteSpace(username))
                {
                    throw new ArgumentException();
                }
                username = value;
            }
        }

        #endregion


        #region Method
        
        public static bool IsPasswordValid(string password ,out string error)
        {
            bool CorrectlyFormatted = false;

            if (string.IsNullOrWhiteSpace(password))
            {
                error = "something went wrong";
                throw new ArgumentException();
            }
            else if(password.Length < 8)
            {
                CorrectlyFormatted = false;
                error = "Password is too short, please try again";
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
