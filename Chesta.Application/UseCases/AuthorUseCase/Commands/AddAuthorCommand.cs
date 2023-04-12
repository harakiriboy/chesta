using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.UseCases.AddressUseCase.Dto;
using Chesta.Domain.Entities;
using MediatR;

namespace Chesta.Application.UseCases.AuthorUseCase.Commands
{
    public class AddAuthorCommand : IRequest<Author>
    {
        public string AuthorUsername { get; set; } = null!;
        public string StripeAccountId { get; set; } = null!;
        public int UserId { get; set; }
        public AddressDto Address { get; set; } = null!;
    }
}