using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;


public class CustomersModel : PageModel
{
    private readonly HttpClient _http;
    public List<Customer>? Customers { get; set;  }

    public CustomersModel(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("api");
    }

    public async Task OnGetAsync()
    {
        Customers = await _http.GetFromJsonAsync<List<Customer>>(
            "/customers"); //see MapGet in api side. should be customers/1
    }
    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await _http.DeleteAsync($"/customers/{id}");

        return RedirectToPage();
    }
}
public class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
}