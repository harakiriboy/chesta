using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using Chesta.Domain.Specifications;
using MediatR;

namespace Chesta.Application.UseCases.PublicationUseCase.Commands.CreatePublication
{
    public class CreatePublicationCommandHandler : IRequestHandler<CreatePublicationCommand, Publication>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorPlanRepository _authorPlanRepository;
        private readonly IPublicationRepository _publicationRepository;

        public CreatePublicationCommandHandler(IAuthorRepository authorRepository, IAuthorPlanRepository authorPlanRepository, IPublicationRepository publicationRepository)
        {
            _authorRepository = authorRepository;
            _authorPlanRepository = authorPlanRepository;
            _publicationRepository = publicationRepository;
        }

        public async Task<Publication> Handle(CreatePublicationCommand request, CancellationToken cancellationToken)
        {
            var subscriptionPlan = await _authorPlanRepository.GetByIdAsync(AuthorPlanSpecs.ById(request.SubscriptionPlanId));
            var author = await _authorRepository.GetByIdAsync(AuthorSpecs.ById(subscriptionPlan.AuhorId));

            var publication = new Publication {
                Title = request.Title,
                Text = request.Text,
                VideoLink = request.VideoLink,
                PlanId = request.SubscriptionPlanId,
                AuthorId = author.Id
            };

            await _publicationRepository.AddAsync(publication);

            return publication;
        }
    }
}