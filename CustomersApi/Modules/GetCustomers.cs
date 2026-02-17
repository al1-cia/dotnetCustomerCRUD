//called by CustomersModule.cs
namespace CustomersApi.Modules;

public static class GetCustomers //static=> can't instantiate
{
    public static IResult Handler(ICustomersRepository repo)
    {
        var _customers = repo.GetAll().ToList();

        if (_customers == null)
            return Results.NotFound();

        return Results.Ok(_customers);
    }
}
