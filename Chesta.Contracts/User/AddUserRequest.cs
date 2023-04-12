using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chesta.Contracts.User
{
    public record AddUserRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password
    );
}