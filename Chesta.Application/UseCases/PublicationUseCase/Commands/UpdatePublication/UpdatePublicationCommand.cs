using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;
using MediatR;

namespace Chesta.Application.UseCases.PublicationUseCase.Commands.UpdatePublication
{
    public class UpdatePublicationCommand : IRequest<Publication>
    {
        public string SubscriptionPlanId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public string VideoLink { get; set; } = null!;
    }
}