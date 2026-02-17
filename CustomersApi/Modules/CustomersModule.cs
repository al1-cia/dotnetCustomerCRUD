using Microsoft.AspNetCore.Mvc;
namespace CustomersApi.Modules;

public class CustomersModule : IModule
{
    //implementing IModule interface, so we must have the 2 methods below
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        //Create the repo only when its asked for (Transient => new instance with each HTTP request)
        services.AddTransient<ICustomersRepository, CustomersRepository>(); //Services is the Dependency Injection container
        return services; //allows requests to be chained
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        //if 1st param called, do 2nd param
        endpoints.MapGet("/customers/{customerId}", GetCustomer.Handler); //see GetCustomer.cs for Handler method
        endpoints.MapGet("/customers", GetCustomers.Handler); //see GetCustomers.cs for Handler method
        endpoints.MapPut("/customers/block/{customerId}", BlockCustomer.Handler); //see BlockCustomer.cs for Handler method
        endpoints.MapPost("/customers",
            ([FromBody] CreateCustomerRequest request,
             [FromServices] ICustomersRepository repo) =>
            {
                var customer = repo.Create(request.Name);
                return Results.Created($"/customers/{customer.Id}", customer);
            });
        endpoints.MapDelete("/customers/{customerId}",
            async(int customerId, [FromServices] ICustomersRepository repo) =>
            {
                var deleted = await repo.DeleteAsync(customerId);

                if (!deleted)
                    return Results.NotFound();

                return Results.NoContent(); // 204
            });

        return endpoints;
    }
}

//public record CreateCustomerRequest(string Name);
