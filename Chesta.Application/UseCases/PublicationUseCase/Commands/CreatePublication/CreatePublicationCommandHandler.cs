using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using Chesta.Domain.Specifications;
using MediatR;

namespace Chesta.Application.UseCases.PublicationUseCase.Commands.CreatePublication
{
    public class CreatePublicationCommandHandler : IRequestHandler<CreatePublicationCommand, Publication>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ISubscriptionPlanRepository _subscriptionPlanRepository;
        private readonly IPublicationRepository _publicationRepository;

        public CreatePublicationCommandHandler(IAuthorRepository authorRepository, ISubscriptionPlanRepository subscriptionPlanRepository, IPublicationRepository publicationRepository)
        {
            _authorRepository = authorRepository;
            _subscriptionPlanRepository = subscriptionPlanRepository;
            _publicationRepository = publicationRepository;
        }

        public async Task<Publication> Handle(CreatePublicationCommand request, CancellationToken cancellationToken)
        {
            int subscriptionPlanId = Convert.ToInt32(request.SubscriptionPlanId);
            var subscriptionPlan = await _subscriptionPlanRepository.GetByIdAsync(SubscriptionPlanSpecs.ById(subscriptionPlanId));
            var author = await _authorRepository.GetByIdAsync(AuthorSpecs.ById(subscriptionPlan.AuthorId));

            var publication = new Publication {
                Title = request.Title,
                Text = request.Text,
                VideoLink = request.VideoLink,
                SubscriptionPlanId = subscriptionPlanId,
                AuthorId = author.Id
            };

            await _publicationRepository.AddAsync(publication);

            return publication;
        }
    }
}