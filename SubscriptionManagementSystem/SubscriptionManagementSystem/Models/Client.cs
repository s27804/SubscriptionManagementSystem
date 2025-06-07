namespace SubscriptionManagementSystem.Models;
using System.Collections.Generic;
public class Client
{
    public int IdClient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
}