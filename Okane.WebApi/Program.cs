using Okane.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();
    
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/expenses", 
    (int amount, string categoryName) =>
    {
        var expenses = new List<Expense>();
        var service = new ExpensesService(expenses);
        var response = service.Create(amount, categoryName);
        return Results.Created("/expenses", response);
    });

app.Run();