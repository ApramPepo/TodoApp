using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;
    public List<TodoItem> Todos { get; set; }

    public IndexModel(AppDbContext context)
    {
        _context = context;
        Todos = new List<TodoItem>();
    }

    public async Task OnGetAsync()
    {
        Todos = await _context.Todos.ToListAsync();
    }

    public async Task<IActionResult> OnPostAddAsync(string task)
    {
        if (!string.IsNullOrEmpty(task))
        {
            _context.Todos.Add(new TodoItem { TaskName = task, Completed = false });
            await _context.SaveChangesAsync();
        }
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo != null)
        {
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage();
    }
}
