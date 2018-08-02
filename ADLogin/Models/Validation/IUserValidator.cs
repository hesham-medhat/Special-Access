using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLogin.Models.Validation
{
    interface IUserValidator
    {
        // Returns true if the candidate is validated successfully
        // Returns false otherwise.
        bool Validate();
    }
}
