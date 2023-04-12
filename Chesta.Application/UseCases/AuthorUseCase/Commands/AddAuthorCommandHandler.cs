using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Application.Services;
using Chesta.Domain.Entities;
using MediatR;

namespace Chesta.Application.UseCases.AuthorUseCase.Commands
{
    // public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, Author>
    // {
    //     private readonly IAuthorRepository _authorRepository;
    //     private readonly IStripeAccountService _accountService;

    //     public AddAuthorCommandHandler(IAuthorRepository authorRepository, IStripeAccountService accountService)
    //     {
    //         _authorRepository = authorRepository;
    //         _accountService = accountService;
    //     }

    //     public async Task<Author> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    //     {
    //         var author = new Author {
    //             AuthorUsername = request.AuthorUsername, 
    //             UserId = request.UserId
    //         };
    //         var address = new Address(request.Address.Country, request.Address.Region);
    //         author.AddressId = address.Id;

    //         author.StripeAccountId = await _accountService.CreateConnectedAccount(author);

    //         return author;
    //     }
    // }
}