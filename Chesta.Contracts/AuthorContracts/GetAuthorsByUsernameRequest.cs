using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chesta.Contracts.AuthorContracts
{
    public class GetAuthorsByUsernameRequest
    {
        public string Username { get; set; } = null!;
        public string Tag { get; set; } = null!;

        public GetAuthorsByUsernameRequest(string username, string tag)
        {
            Username = username;
            Tag = tag;
        }
    }
}