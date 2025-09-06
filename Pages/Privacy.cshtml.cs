using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PROG7312_Part1_st10030414.Data;

namespace PROG7312_Part1_st10030414.Pages;

public class PrivacyModel : PageModel
{
    private readonly AppDbContext _context;
    //(W3 Schools, 2025)

    public PrivacyModel(AppDbContext context)
    {
        _context = context;
        //(W3 Schools, 2025)
    }

    [TempData]
    public string Message { get; set; }
    //(W3 Schools, 2025)
    
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            _context.Reports.RemoveRange(_context.Reports);
            //(Geeks For Geeks, 2025)
            await _context.SaveChangesAsync();
            //(W3 Schools, 2025)
            Message = "All reports have been cleared.";
            //(Geeks For Geeks, 2025)
        }
        catch (Exception ex)
        {
            Message = $"Error clearing reports: {ex.Message}";
            //(W3 Schools, 2025)
        }
        return RedirectToPage();
        //(W3 Schools, 2025)
    }
}

/*
Reference List
   
   Geeks For Geeks. 2025. SQLite Tutorial, 23 July 2025. [Online]. Available at: https://www.geeksforgeeks.org/sqlite/sqlite-tutorial/ [Accessed 4 September 2025].
   
   Mdn. 2025. CSS styling basics, 2 September 2025. [Online]. Available at: https://developer.mozilla.org/en-US/docs/Learn_web_development/Core/Styling_basics [Accessed 4 September 2025].
   
   Mdn. 2025. JavaScript, 8 July 2025. [Online]. Available at: https://developer.mozilla.org/en-US/docs/Web/JavaScript [Accessed 4 September 2025].
   
   W3 Schools. 2025. How TO - Snackbar / Toast, [n.d.]. [Online]. Available at: https://www.w3schools.com/howto/howto_js_snackbar.asp [Accessed 4 September 2025].
   
   W3 Schools. 2025. How TO - CSS/JS Modal, [n.d.]. [Online]. Available at: https://www.w3schools.com/howto/howto_css_modals.asp [Accessed 4 September 2025].
   
   W3 Schools. 2025. JavaScript Tutorial, [n.d.]. [Online]. Available at: https://www.w3schools.com/js/ [Accessed 4 September 2025].
   
   W3 Schools. 2025. CSS Introduction, [n.d.]. [Online]. Available at: https://www.w3schools.com/css/css_intro.asp [Accessed 4 September 2025].
   
   W3 Schools. 2025. HTML Tutorial, [n.d.]. [Online]. Available at: https://www.w3schools.com/Html/ [Accessed 4 September 2025].
   
   W3 Schools. 2025. C# Tutorial, [n.d.]. [Online]. Available at: https://www.w3schools.com/cs/index.php [Accessed 4 September 2025].
*/