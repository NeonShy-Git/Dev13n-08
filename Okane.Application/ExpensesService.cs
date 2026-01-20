namespace Okane.Application;

public class ExpensesService(List<Expense> expenses)
{
    private int _lastId = 1;

    public Expense Create(int amount, string category)
    {
        var id = _lastId++;
        var expense = new Expense(id, amount, category);
        expenses.Add(expense);
        return expense;
    }

    public Expense Retrive(int expenseId)
    {
        var expense = expenses.First(expense1 => expense1.Id == expenseId);
        return expense;
    }
}