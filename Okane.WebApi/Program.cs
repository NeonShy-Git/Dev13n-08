using Okane.Application;
using Okane.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOpenApi()
    .AddTransient<ExpensesService>()
    .AddSingleton<List<Expense>>();

var app = builder.Build();
    
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/expenses", 
    (ExpensesService service, CreateExpenseRequest request) => 
        service.Create(request).ToHttpResult());

app.MapGet("/expenses/{id}", 
    (ExpensesService service, int id) =>
    {
        var response = service.Retrieve(id);
        
        return response == null ? Results.NotFound() : Results.Ok(response);
    });

app.MapGet("/expenses", (ExpensesService service) => Results.Ok(service.All()));

app.MapPut("/expenses/{id}", 
    (ExpensesService service, int id, UpdateExpenseRequest request) =>
    {
        var response = service.Update(id, request);
        
        return response == null ? Results.NotFound() : Results.Ok(response);
    });

app.MapDelete("/expenses/{id}", 
    (ExpensesService service, int id) =>
    {
        var deleted = service.Delete(id);
        
        return deleted ? Results.NoContent() : Results.Ok();
    });

app.Run();