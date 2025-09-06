using Microsoft.EntityFrameworkCore;
using PROG7312_Part1_st10030414.Models;

namespace PROG7312_Part1_st10030414.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        //(Geeks For Geeks, 2025)
    }
    
    public DbSet<Report> Reports { get; set; }
    //(Geeks For Geeks, 2025)
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