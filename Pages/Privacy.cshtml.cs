using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PROG7312_Part1_st10030414.Data;

namespace PROG7312_Part1_st10030414.Pages;

public class PrivacyModel : PageModel
{
    private readonly AppDbContext _context;

    public PrivacyModel(AppDbContext context)
    {
        _context = context;
    }

    [TempData]
    public string Message { get; set; }
    
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            _context.Reports.RemoveRange(_context.Reports);
            await _context.SaveChangesAsync();
            Message = "All reports have been cleared.";
        }
        catch (Exception ex)
        {
            Message = $"Error clearing reports: {ex.Message}";
        }
        return RedirectToPage();
    }
}