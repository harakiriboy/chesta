using Chesta.Application.Authentication.Commands.RegisterAuthor;
using Chesta.Application.Services;
using Chesta.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace Chesta.Infrastructure.Services
{
    public class StripeAccountService : IStripeAccountService
    {
        private readonly IConfiguration _config;

        public StripeAccountService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> CreateConnectedAccount(RegisterAuthorCommand command)
        {
            StripeConfiguration.ApiKey = "sk_test_51MXfIUHsaxdXWEFBtf4h279DV4TSjtXUOSlvPG5WzeR68VGZ11mdPuPbARFZmbuwMo3OcAiHZxd317bqVoqXhiNL00LTFwNscZ";

            // Creating customer
            var options = new AccountCreateOptions
            {
                Type = "custom",
                Country = "US",
                Email = command.Email,
                Capabilities = new AccountCapabilitiesOptions
                    {
                        CardPayments = new AccountCapabilitiesCardPaymentsOptions
                        {
                            Requested = true,
                        },
                        Transfers = new AccountCapabilitiesTransfersOptions
                        {
                            Requested = true,
                        },
                    },
                TosAcceptance = new AccountTosAcceptanceOptions
                    {
                        Date = DateTimeOffset.FromUnixTimeSeconds(1609798905).UtcDateTime,
                        Ip = "8.8.8.8",
                    },
                ExternalAccount = "tok_visa_debit_us_transferSuccess",
                BusinessType = "individual",
                // BusinessProfile = new AccountBusinessProfileOptions
                //     {
                //         Mcc = "5045",
                //         Url = "https://bestcookieco.com",
                //     },
                //     Company = new AccountCompanyOptions
                //     {
                //         Address = new AddressOptions
                //         {
                //             City = "Schenectady",
                //             Line1 = "123 State St",
                //             PostalCode = "12345",
                //             State = "NY",
                //         },
                //         TaxId = "000000000",
                //         Name = "The Best Cookie Co",
                //         Phone = "8888675309",
                //     },
            };
            var service = new AccountService();
            var account = await service.CreateAsync(options);

            var accountId = account.Id;
            return accountId;
        }
    }
}