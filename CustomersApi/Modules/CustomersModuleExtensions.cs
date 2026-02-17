namespace CustomersApi.Modules;

public static class CustomersModuleExtensions
{
    //adds new member function to the class by passing current object
    public static IServiceCollection AddCustomersModule(this IServiceCollection services) 
    {
        var module = new CustomersModule();
        return module.RegisterModule(services);
    }

    public static IEndpointRouteBuilder MapCustomersEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var module = new CustomersModule();
        return module.MapEndpoints(endpoints);
    }
}
