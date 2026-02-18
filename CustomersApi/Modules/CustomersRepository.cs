namespace CustomersApi.Modules;

public class CustomersRepository : ICustomersRepository
{
    private readonly AppDbContext _context;

    public CustomersRepository(AppDbContext context)
    {
        _context = context;
    }

    public Customer? GetById(int id)
    {
        return _context.Customers.Find(id);
    }
    
    public IEnumerable<Customer> GetAll()
    {
        return _context.Customers.ToList();
    }
    public Customer Create(string name)
    {
        var customer = new Customer
        {
            Name = name,
            IsBlocked = false
        };

        _context.Customers.Add(customer);
        _context.SaveChanges();

        return customer;
    }

    public async Task<bool> BlockCustomerAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            customer.IsBlocked = true;
            await _context.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);

        if (customer == null)
            return false;

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        return true;
    }

}
