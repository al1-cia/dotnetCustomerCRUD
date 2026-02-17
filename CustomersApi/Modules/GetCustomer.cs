//called by CustomersModule.cs
namespace CustomersApi.Modules;

public static class GetCustomer //static=> can't instantiate
{
    public static IResult Handler(int customerId, ICustomersRepository repo)
    {
        var customer = repo.GetById(customerId);

        if (customer == null)
            return Results.NotFound();

        return Results.Ok(customer);
    }
}
