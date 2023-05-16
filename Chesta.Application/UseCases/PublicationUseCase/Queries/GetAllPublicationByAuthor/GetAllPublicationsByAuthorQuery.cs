using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;
using MediatR;

namespace Chesta.Application.UseCases.PublicationUseCase.Queries.GetAllPublicationsByAuthor
{
    public class GetAllPublicationsByAuthorQuery : IRequest<IEnumerable<Publication>?>
    {
        public string AuthorUsername { get; set; } = null!;

        public GetAllPublicationsByAuthorQuery(string authorUsername)
        {
            AuthorUsername = authorUsername;
        }
    }
}