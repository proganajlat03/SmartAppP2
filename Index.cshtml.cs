using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmartWaterApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            // Replace with actual authentication logic (e.g., check against a database)
            if (Email == "user@example.com" && Password == "password123")
            {
                // Redirect to home page if credentials are correct
                return RedirectToPage("/Home");
            }

            // If login fails, stay on the same page and show an error
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}
