using Chesta.Application.Services;
using Chesta.Domain.Entities;
using Stripe;

namespace Chesta.Infrastructure.Services
{
    public class StripeCustomerService : IStripeCustomerService
    {
        public async Task<string> CreateStripeCustomer(User user)
        {
            StripeConfiguration.ApiKey = "sk_test_51MXfIUHsaxdXWEFBtf4h279DV4TSjtXUOSlvPG5WzeR68VGZ11mdPuPbARFZmbuwMo3OcAiHZxd317bqVoqXhiNL00LTFwNscZ";

            // Creating customer
            var options = new CustomerCreateOptions
            {
                Description = "My First Test Customer (created for API docs at https://www.stripe.com/docs/api)",
                Name = user.FirstName + " " + user.LastName,
                Email = user.Email
            };
            var service = new CustomerService();
            var customer = await service.CreateAsync(options);

            // Returning stripe customer id
            var customerId = customer.Id;

            return customerId;
        }
    }
}