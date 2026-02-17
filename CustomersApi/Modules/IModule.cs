public interface IModule
{
	//any module that implements this interface must have these 2 methods
	IServiceCollection RegisterModule(IServiceCollection services);
	IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}