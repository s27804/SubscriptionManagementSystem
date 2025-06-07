namespace SubscriptionManagementSystem.DTOs;

public class CreateSubscriptionDto
{
    public string Name { get; set; }
    public int RenewalPeriod { get; set; }
    public DateTime EndTime { get; set; }
    public Decimal Price { get; set; }
}