namespace Chesta.Contracts.Publications
{
    public record CreatePublicationRequest(
        int SubscriptionPlanId,
        string Title,
        string Text,
        string VideoLink
    );
}