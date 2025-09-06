using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PROG7312_Part1_st10030414.Data;
using PROG7312_Part1_st10030414.Models;
using Microsoft.EntityFrameworkCore;

namespace PROG7312_Part1_st10030414.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;
    //(Geeks For Geeks, 2025)
    public IndexModel(AppDbContext context)
    {
        _context = context;
        //(Geeks For Geeks, 2025)
    }
    
    [BindProperty]
    public Report Report { get; set; }
    //(Geeks For Geeks, 2025)
    [BindProperty]
    public IFormFile? Attachment { get; set; }
    //(Geeks For Geeks, 2025)
    
    [TempData]
    public string Message { get; set; }
    //(W3 Schools, 2025)

    public List<Report> Reports { get; set; }
    //(Geeks For Geeks, 2025)

    public void OnGet()
    {
        try
        {
            Reports = _context.Reports.ToList();
            //(W3 Schools, 2025)
        }
        catch (Exception ex)
        {
            Message = $"Error reading reports: {ex.Message}";
            Reports = new List<Report>();
            //(W3 Schools, 2025)
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Message = "Form is invalid. Please check the fields.";
            //(W3 Schools, 2025)
            Reports = _context.Reports.ToList();
            //(Geeks For Geeks, 2025)
            return Page();
        }

        try
        {
            if (Attachment != null && Attachment.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                await Attachment.CopyToAsync(memoryStream);
                //(W3 Schools, 2025)
                Report.Attachment = memoryStream.ToArray();
                //(Geeks For Geeks, 2025)
            }
            else
            {
                Report.Attachment = null;
                //(W3 Schools, 2025)
            }
            _context.Reports.Add(Report);
            //(W3 Schools, 2025)
            await _context.SaveChangesAsync();
            Message = "Report successfully uploaded. Thank You!";
            //(Geeks For Geeks, 2025)
        }
        catch (Exception ex)
        {
            Message = $"An error occurred while saving the report: {ex.Message}";
            //(W3 Schools, 2025)
        }

        Reports = _context.Reports.ToList();
        //(W3 Schools, 2025)
        return RedirectToPage();
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