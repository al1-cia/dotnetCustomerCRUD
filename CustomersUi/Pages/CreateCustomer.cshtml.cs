using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;


using CustomersApi;

public class CreateCustomerModel : PageModel
{
    private readonly HttpClient _http;
    public CreateCustomerModel(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("api");

    }
    [BindProperty]
    public CreateCustomerRequest Customer { get; set; } = new();

    public async Task<IActionResult> OnPostAsync()
    {
        await _http.PostAsJsonAsync("/customers", Customer);

        return RedirectToPage("/customers");
    }
}