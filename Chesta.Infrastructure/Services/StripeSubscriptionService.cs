using Chesta.Application.Services;
using Chesta.Domain.Entities;
using Stripe;

namespace Chesta.Infrastructure.Services
{
    public class StripeSubscriptionService : IStripeSubscriptionService
    {
        public async Task<string> CreateStripeSubscription(string customerId, string accountId, AuthorPlan subscriptionPlan) 
        {
            StripeConfiguration.ApiKey = "sk_test_51MXfIUHsaxdXWEFBtf4h279DV4TSjtXUOSlvPG5WzeR68VGZ11mdPuPbARFZmbuwMo3OcAiHZxd317bqVoqXhiNL00LTFwNscZ";

            // create product
            var productOptions = new ProductCreateOptions { Name = subscriptionPlan.Name };
            var productService = new ProductService();
            var product = productService.Create(productOptions);

            //create price
            var priceOptions = new PriceCreateOptions
            {
                Product = product.Id,
                UnitAmount = 1000,
                Currency = "usd",
                Recurring = new PriceRecurringOptions { Interval = "month" },
            };
            var priceService = new PriceService();
            var price = await priceService.CreateAsync(priceOptions);

            var options = new SubscriptionCreateOptions
            {
                Customer = customerId, // simple customer
                OnBehalfOf = accountId,
                Items = new List<SubscriptionItemOptions>
                {
                    new SubscriptionItemOptions { Price = price.Id },
                },
                Expand = new List<string> { "latest_invoice.payment_intent" },
                TransferData = new SubscriptionTransferDataOptions
                {
                    Destination = accountId, // japanese account
                },
            };
            var service = new SubscriptionService();
            var sub = await service.CreateAsync(options);
            
            return sub.Id;
        }
    }
}