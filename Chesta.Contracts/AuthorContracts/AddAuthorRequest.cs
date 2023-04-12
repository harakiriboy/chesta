using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chesta.Contracts.AuthorContracts
{
    public record AddAuthorRequest(
        string AuthorUsername,
        string StripeAccountId,
        int UserId,
        int AddressId
    );
}