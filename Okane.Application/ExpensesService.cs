namespace Okane.Application;

public class ExpensesService(List<Expense> expenses)
{
    public Expense Create(int amount, string category)
    {
        var expense = new Expense(amount, category);
        expenses.Add(expense);
        return expense;
    }
}