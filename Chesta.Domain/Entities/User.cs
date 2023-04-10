namespace Chesta.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string CustomerId { get; set; } = null!;

        // Payments
        public List<Payment> Payments { get; set; } = null!;

        // Author
        public Author Author { get; set; }= null!;

        // Comments
        public List<Comment> Comments { get; set; } = null!;

        // Subscriptions
        public List<Subscription> Subscriptions { get; set; } = null!;
    }
}