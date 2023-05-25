using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using Chesta.Domain.Specifications;
using MediatR;

namespace Chesta.Application.UseCases.PublicationUseCase.Commands.UpdatePublication
{
    public class UpdatePublicationCommandHandler : IRequestHandler<UpdatePublicationCommand, Publication>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ISubscriptionPlanRepository _subscriptionPlanRepository;
        private readonly IPublicationRepository _publicationRepository;

        public UpdatePublicationCommandHandler(IPublicationRepository publicationRepository, ISubscriptionPlanRepository subscriptionPlanRepository, IAuthorRepository authorRepository)
        {
            _publicationRepository = publicationRepository;
            _subscriptionPlanRepository = subscriptionPlanRepository;
            _authorRepository = authorRepository;
        }

        public async Task<Publication> Handle(UpdatePublicationCommand request, CancellationToken cancellationToken)
        {
            int subscriptionPlanId = Convert.ToInt32(request.SubscriptionPlanId);
            var subscriptionPlan = await _subscriptionPlanRepository.GetByIdAsync(SubscriptionPlanSpecs.ById(subscriptionPlanId));
            var author = await _authorRepository.GetByIdAsync(AuthorSpecs.ById(subscriptionPlan.AuthorId));

            Publication publication = await _publicationRepository.GetByAuthorIdAndVideoLink(author.Id, request.VideoLink);

            publication.Title = request.Title;
            publication.Text = request.Text;
            publication.VideoLink = request.VideoLink;
            publication.SubscriptionPlanId = subscriptionPlanId;
            publication.AuthorId = author.Id;

            await _publicationRepository.UpdatePublication(publication);

            return publication;
        }
    }
}