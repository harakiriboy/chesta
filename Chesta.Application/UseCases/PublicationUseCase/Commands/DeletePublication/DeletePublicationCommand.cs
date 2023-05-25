using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Chesta.Application.UseCases.PublicationUseCase.Commands.DeletePublication
{
    public class DeletePublicationCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeletePublicationCommand(int id)
        {
            Id = id;
        }        
    }
}