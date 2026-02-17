//this class is available in the whole Namespace of the module
namespace CustomersApi.Modules;


public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsBlocked { get; set; }
}
