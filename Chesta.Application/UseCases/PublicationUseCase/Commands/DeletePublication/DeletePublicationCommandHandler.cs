using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using MediatR;

namespace Chesta.Application.UseCases.PublicationUseCase.Commands.DeletePublication
{
    public class DeletePublicationCommandHandler : IRequestHandler<DeletePublicationCommand, bool>
    {
        private readonly IPublicationRepository _publicationRepository;

        public DeletePublicationCommandHandler(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<bool> Handle(DeletePublicationCommand request, CancellationToken cancellationToken)
        {
            var res = await _publicationRepository.DeleteById(request.Id);
            return res;   
        }
    }
}