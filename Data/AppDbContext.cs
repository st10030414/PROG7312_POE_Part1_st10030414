using Microsoft.EntityFrameworkCore;
using PROG7312_Part1_st10030414.Models;

namespace PROG7312_Part1_st10030414.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<Report> Reports { get; set; }
}