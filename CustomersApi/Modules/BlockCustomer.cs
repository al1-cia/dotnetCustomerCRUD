//called by CustomersModule.cs
namespace CustomersApi.Modules;

public static class BlockCustomer
{
    public static async Task<IResult> Handler(int customerId, ICustomersRepository repo) //gets ID from URL and data from repo (See CustomersRepository.cs)
    {
        var customer = repo.GetById(customerId);

        if (customer == null)
            return Results.NotFound();

        var blocked = await repo.BlockCustomerAsync(customerId); //function is inside ICustomersRepository.cs
        if (!blocked) { return Results.NotFound(); }

        return Results.Ok(new { message = "Customer blocked successfully" });
    }
}
