using Okane.Application;

namespace Okane.Tests;

public class CreateExpenseTests
{
    [Fact]
    public void Response()
    {
        var service = new ExpensesService([]);
        var expense = service.Create(10, "Food");

        Assert.Equal(10, expense.Amount);
        Assert.Equal("Food", expense.CategoryName);
    }
    
    [Fact]
    public void AddsExpense()
    {
        var expenses = new List<Expense>();
        var service = new ExpensesService(expenses);
        
        service.Create(10, "Food");
        
        var created = Assert.Single(expenses);
        Assert.Equal(10, created.Amount);
        Assert.Equal("Food", created.CategoryName);
    }
}