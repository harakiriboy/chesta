using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;
using Chesta.Domain.Enums;
using MediatR;

namespace Chesta.Application.UseCases.SubscriptionUseCase.Commands
{
    public class CreateSubscriptionPlanCommand : IRequest<AuthorPlan>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string AccessLevel { get; set; } = null!;
        public SubscriptionType SubscriptionType { get; set; }
        public int UserId { get; set; }
    }
}