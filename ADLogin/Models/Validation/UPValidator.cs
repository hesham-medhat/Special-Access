using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;

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

        private bool ValidateByEntity(string inputUsername, string inputPassword)
        {
            using (LoginDBEntities db = new LoginDBEntities())
            {
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

        private bool ValidateBySqlConnection(ref string inputUsername, ref string inputPassword)
        {
            string connectionString;
            using (LoginDBEntities db = new LoginDBEntities())
            {
                connectionString = db.Database.Connection.ConnectionString;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand()
                {
                    CommandText = "validateUserByUP",
                    Connection = connection,
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add(new SqlParameter("@username", inputUsername));
                    command.Parameters.Add(new SqlParameter("@password", inputPassword));

                    // Adding parameter for the returned value.
                    SqlParameter returnValueParameter = new SqlParameter("returner", System.Data.SqlDbType.Int);
                    returnValueParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    command.Parameters.Add(returnValueParameter);

                    command.ExecuteNonQuery();
                    int returner = (int) command.Parameters["returner"].Value;
                    return returner == 1;
                }

            }
        }

        public bool Validate() {

            
            string inputUsername = loginCredentials.username;
            string inputPassword = loginCredentials.password;

            return ValidateBySqlConnection(ref inputUsername, ref inputPassword);

            //Another method: return ValidateByEntity(inputUsername, inputPassword);
            
        }
    }
}