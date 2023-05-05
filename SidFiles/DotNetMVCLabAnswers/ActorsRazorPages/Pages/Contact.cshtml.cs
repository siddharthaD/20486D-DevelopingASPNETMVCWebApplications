using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ActorsRazorPages.Pages
{
    public class ContactModel : PageModel
    {   
        public string? Message { get; set; } 
        public void OnGet()
        {
            Message = "Your truly contact page";
        }
    }
}
