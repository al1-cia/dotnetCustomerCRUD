//called by CustomersModule.cs
namespace CustomersApi.Modules;

public static class BlockCustomer
{
    public static IResult Handler(int customerId, ICustomersRepository repo) //gets ID from URL and data from repo (See CustomersRepository.cs)
    {
        var customer = repo.GetById(customerId);

        if (customer == null)
            return Results.NotFound();

        repo.BlockCustomer(customerId); //function is inside ICustomersRepository.cs

        return Results.Ok(new { message = "Customer blocked successfully" });
    }
}
