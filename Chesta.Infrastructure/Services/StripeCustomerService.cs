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

            // adding default payment method
            var pm_options = new PaymentMethodCreateOptions
            {
              Type = "card",
              Card = new PaymentMethodCardOptions
              {
                Number = "4242424242424242",
                ExpMonth = 8,
                ExpYear = 2024,
                Cvc = "314",
              },
            };
            var pm_service = new PaymentMethodService();
            var pm = pm_service.Create(pm_options);

            // attaching payment method to a user
            var attachoptions = new PaymentMethodAttachOptions
            {
              Customer = customer.Id,
            };
            var attachservice = new PaymentMethodService();
            attachservice.Attach(pm.Id, attachoptions);

            var update_options = new CustomerUpdateOptions {
                InvoiceSettings = new CustomerInvoiceSettingsOptions {
                    DefaultPaymentMethod = pm.Id
                }
            };

            var update_service = new CustomerService();
            update_service.Update(customer.Id, update_options);

            // Returning stripe customer id
            var customerId = customer.Id;

            return customerId;
        }
    }
}