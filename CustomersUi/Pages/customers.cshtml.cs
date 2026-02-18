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
    public async Task<IActionResult> OnPostBlockAsync(int id)
    {
        var response = await _http.PutAsync($"/customers/block/{id}", null); //called when form is posted. Goes to Controller.
        if (response.IsSuccessStatusCode)
        {
            // optionally read the API JSON message
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content); // { "message": "Customer blocked successfully" }
        }
        else
        {
            Console.WriteLine($"failed to block {response.StatusCode}");
        }
        return RedirectToPage();

    }
    public async Task OnGetAsync()
    {
        Customers = await _http.GetFromJsonAsync<List<Customer>>(
            "/customers"); //see MapGet in api side. should be customers/1
    }
    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await _http.DeleteAsync($"/customers/{id}"); //called when form is posted. Goes to Controller.

        return RedirectToPage();
    }
}
public class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
}