using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;
using MediatR;

namespace Chesta.Application.UseCases.SubscriptionUseCase.Commands.EditSubscriptionPlan
{
    public class EditSubscriptionPlanCommand : IRequest<SubscriptionPlan>
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Price { get; set; } = null!;
    }
}