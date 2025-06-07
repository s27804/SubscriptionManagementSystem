namespace SubscriptionManagementSystem.DTOs;

public class CreatePaymentDto
{
    public DateTime Date { get; set; }
    public int IdClient { get; set; }
    public int IdSubscription { get; set; }
}