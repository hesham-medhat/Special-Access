using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLogin.Models.Validation
{
    public class UPValidator : IUserValidator
    {

        // User login credentials to validate.
        private user loginCredentials;

        public UPValidator(ref ADLogin.Models.user candidate)
        {
            loginCredentials = candidate;
        }

        public bool Validate() {
            using (LoginDBEntities db = new LoginDBEntities())
            {
                string inputUsername = loginCredentials.username;
                string inputPassword = loginCredentials.password;

                user foundUser = db.users.SingleOrDefault(user => user.username.Equals(inputUsername, StringComparison.Ordinal));
                if (foundUser == null || foundUser.password != inputPassword)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}