namespace Okane.Application;

public record CreateExpenseRequest(int Amount, string CategoryName, string? Description = null);