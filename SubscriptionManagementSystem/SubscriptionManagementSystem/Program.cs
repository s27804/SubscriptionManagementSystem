using SubscriptionManagementSystem.Models;
using SubscriptionManagementSystem.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubscriptionManagementSystem.DTOs;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/client/{id}", (int id, [FromServices]ClientContext clientContext) =>
{
    /*var client = clientContext.Client.Find(id);
    if (client == null)
        return Results.NotFound();*/

    /*var sale = saleContext.Sale.Single(e =>
    {
        e.IdClient == id;
    });*/
    
    return clientContext.Client.ToList();
});

app.MapPost("/api/payments", (CreatePaymentDto newPayment, [FromServices]PaymentContext paymentContext, [FromServices]ClientContext clientContext, [FromServices]SubscriptionContext subscriptionContext) =>
{
    var payment = new Payment()
    {
        Date = newPayment.Date,
        IdSubscription = newPayment.IdSubscription,
        IdClient = newPayment.IdClient,
    };
    
    var client = clientContext.Client.Find(newPayment.IdClient);
    if (client == null)
        return Results.NotFound();
    
    var subscription = subscriptionContext.Subscription.Find(newPayment.IdSubscription);
    if (subscription == null)
        return Results.NotFound();
    if (subscription.EndTime < DateTime.Now)
        return Results.Problem("The subscription has expired");
    //if (subscription.Price != newPayment.)
    
    paymentContext.Payment.Add(payment);
    paymentContext.SaveChanges();
});

app.Run();