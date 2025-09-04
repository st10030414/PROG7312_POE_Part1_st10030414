using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PROG7312_Part1_st10030414.Data;
using PROG7312_Part1_st10030414.Models;
using Microsoft.EntityFrameworkCore;

namespace PROG7312_Part1_st10030414.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }
    
    [BindProperty]
    public Report Report { get; set; }
    [BindProperty]
    public IFormFile? Attachment { get; set; }
    
    [TempData]
    public string Message { get; set; }

    public List<Report> Reports { get; set; }

    public void OnGet()
    {
        try
        {
            Reports = _context.Reports.ToList();
        }
        catch (Exception ex)
        {
            Message = $"Error reading reports: {ex.Message}";
            Reports = new List<Report>();
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Message = "Form is invalid. Please check the fields.";
            Reports = _context.Reports.ToList();
            return Page();
        }

        try
        {
            if (Attachment != null && Attachment.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                await Attachment.CopyToAsync(memoryStream);
                Report.Attachment = memoryStream.ToArray();
            }
            else
            {
                Report.Attachment = null;
            }
            _context.Reports.Add(Report);
            await _context.SaveChangesAsync();
            Message = "Report successfully uploaded.";
        }
        catch (Exception ex)
        {
            Message = $"An error occurred while saving the report: {ex.Message}";
        }

        // Reload reports after adding new one
        Reports = _context.Reports.ToList();
        return RedirectToPage();
    }
}