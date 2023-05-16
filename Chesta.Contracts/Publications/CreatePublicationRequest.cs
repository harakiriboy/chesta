namespace Chesta.Contracts.Publications
{
    public record CreatePublicationRequest(
        string SubscriptionPlanId,
        string Title,
        string Text,
        string VideoLink
    );
}