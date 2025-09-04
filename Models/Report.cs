using System.ComponentModel.DataAnnotations;

namespace PROG7312_Part1_st10030414.Models;

public class Report
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Location is required")]
    public string Location { get; set; }
    
    [Required(ErrorMessage = "Report type is required")]
    public string ReportType { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }
    
    public byte[]? Attachment { get; set; }

    public string Status { get; set; } = "Unresolved";
}