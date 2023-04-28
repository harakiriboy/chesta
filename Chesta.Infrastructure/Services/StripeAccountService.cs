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
            
            
            // uploading document
            var filename = "C:/Users/HP/OneDrive/Документы/3course/diploma/Chesta/client/src/assets/images/grib.png";
            var fileId = "";
            using (FileStream stream = System.IO.File.Open(filename, FileMode.Open))
            {
                var fileOptions = new FileCreateOptions
                {
                    File = stream,
                    Purpose = FilePurpose.IdentityDocument,
                };
                var fileService = new FileService();
                var upload = fileService.Create(fileOptions);
                fileId = upload.Id;
            }


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
                Individual = new AccountIndividualOptions {
                    Dob = new DobOptions {
                        Day = 1,
                        Month = 1,
                        Year = 1902
                    },
                    Address = new AddressOptions {
                        City = "Osaka",
                        State = "Alabama",
                        PostalCode = "15110",
                        Line1 = "address_full_match"
                    },
                    Phone = "(822) 376-9958",
                    Email = command.Email,
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    SsnLast4 = "4622",
                    IdNumber = "565314622",
                    Verification = new AccountIndividualVerificationOptions {
                        Document = new AccountIndividualVerificationDocumentOptions {
                            Front = fileId
                        }
                    },
                },
                BusinessProfile = new AccountBusinessProfileOptions {
                    Mcc = "5734",
                    Url = "https://www.linkedin.com/in/daulet-yesirkepov-448185210/"
                }
            };
            var service = new AccountService();
            var account = await service.CreateAsync(options);

            var accountId = account.Id;
            return accountId;
        }
    }
}