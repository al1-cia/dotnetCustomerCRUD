namespace CustomersApi.Modules;

public interface ICustomersRepository
{
    Customer? GetById(int id);  //since id may not exist, the object might be null , so we use nullable reference type (Customer?)
    IEnumerable<Customer> GetAll();
    Task<bool> BlockCustomerAsync(int id); //is customer blocked? lack of access specifier because interface is public by default
    Customer Create(string name); //create a new customer with the given name
    Task<bool> DeleteAsync(int id);
}
